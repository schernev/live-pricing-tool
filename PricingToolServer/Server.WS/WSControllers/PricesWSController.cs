using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Server.Data.DTO;
using Server.Services;

namespace Server.WS.WSControllers
{
    [Route("/ws")]
    public class PricesWSController : ControllerBase
    {
        readonly IPriceTickerService priceTickerService;

        readonly JsonSerializerOptions jsonSerializerOptions = new()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        };

        public PricesWSController(IPriceTickerService priceTickerService)
        {
            this.priceTickerService = priceTickerService;
        }

        [Route("prices")]
        public async Task GetPrices()
        {
            if (HttpContext.WebSockets.IsWebSocketRequest)
            {
                using var webSocket = await HttpContext.WebSockets.AcceptWebSocketAsync();
                await OpenPricesSocket(webSocket);
            }
            else
            {
                HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            }
        }

        private async Task OpenPricesSocket(WebSocket webSocket)
        {
            var buffer = new byte[1024 * 4];
            var messageResult = new ArraySegment<byte>(buffer);
            var cancellationTokenSource = new CancellationTokenSource();

            var receiveResult = await webSocket.ReceiveAsync(messageResult, CancellationToken.None); // receive first message
            while (!receiveResult.CloseStatus.HasValue)
            {
                if (messageResult.Array != null)
                {
                    var latestMessage = Encoding.UTF8.GetString(messageResult.Array, messageResult.Offset, receiveResult.Count);

                    // Cancel the previous sending task and start a new one with the updated message
                    cancellationTokenSource.Cancel();
                    cancellationTokenSource = new CancellationTokenSource();
                    _ = SendPriceResponseMsg(webSocket, latestMessage, cancellationTokenSource.Token);
                }

                receiveResult = await webSocket.ReceiveAsync(messageResult, CancellationToken.None); // receive new message after cancelled previous
            }

            await webSocket.CloseAsync(
                receiveResult.CloseStatus.Value,
                receiveResult.CloseStatusDescription,
                CancellationToken.None);
        }

        private async Task SendPriceResponseMsg(WebSocket webSocket, string receiveMessage, CancellationToken cancellationToken)
        {
            while (webSocket.State == WebSocketState.Open && !cancellationToken.IsCancellationRequested)
            {
                var responseMsg = GetCurrentPrice(receiveMessage);
                await webSocket.SendAsync(
                    new ArraySegment<byte>(responseMsg),
                    WebSocketMessageType.Text, 
                    true, 
                    CancellationToken.None);
                await Task.Delay(1000, cancellationToken); // Send on each 1 second
            }
        }

        private byte[] GetCurrentPrice(string receiveMessage)
        {
            var requestObj = JsonSerializer.Deserialize<FxRateRequest>(receiveMessage, jsonSerializerOptions);
            if (requestObj == null) return [];

            var result = priceTickerService.GetCurrentFxRate(requestObj.FromCurrency, requestObj.ToCurrency);
            var dto = new FxRateResponse(result);
            var byteArray = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(dto, jsonSerializerOptions));

            return byteArray;
        }
    }
}
