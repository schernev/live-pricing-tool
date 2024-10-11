using System.Text.Json.Serialization;
using Server.Data.Enums;
using Server.Data.Model;

namespace Server.Data.DTO
{
    public class FxRateResponse
    {
        public FxRateResponse(FxRate fxRate)
        {
            LastUpdated = fxRate.LastUpdated;
            Currency = fxRate.Currency;
            RefCurrency = fxRate.RefCurrency;
            Bid = fxRate.Bid;
            Ask = fxRate.Ask;
            LastPrice = fxRate.LastPrice;
        }
        public DateTime LastUpdated { get; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public CurrencyEnum Currency { get; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public CurrencyEnum RefCurrency { get; }

        public decimal Bid { get; }

        public decimal Ask { get; }

        public decimal LastPrice { get; }
    }
}
