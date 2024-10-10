using Microsoft.AspNetCore.Mvc;

namespace Server.WS.WSControllers
{
    [Route("/ws")]
    public class PricesWSController : ControllerBase
    {
        [Route("fxrates")]
        public async Task GetRates()
        {
            throw new NotImplementedException();
        }
    }
}
