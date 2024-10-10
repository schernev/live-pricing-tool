using Server.Data;
using Server.Data.Model;

namespace Server.Services
{
    public interface IPriceTickerService
    {
        FxRate GetCurrentFxRate(string fromCurrency, string toCurrency);
    }

    public class PriceTickerService : IPriceTickerService
    {
        private readonly IDataAccessService dataAccessService;

        public PriceTickerService(IDataAccessService dataAccessService)
        {
            this.dataAccessService = dataAccessService;
        }

        public FxRate GetCurrentFxRate(string fromCurrency, string toCurrency)
        {
            throw new NotImplementedException();
        }
    }
}
