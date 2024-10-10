using Server.Data;
using Server.Data.Enums;
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
            if (!Enum.TryParse<CurrencyEnum>(fromCurrency, out CurrencyEnum from) || !Enum.TryParse<CurrencyEnum>(toCurrency, out CurrencyEnum to))
            {
                throw new ArgumentException("Invalid currency");
            }

            if (from == to)
            {
                return new FxRate { Currency = from, RefCurrency = to, Ask = 0, Bid = 0, LastPrice = 0, LastUpdated = DateTime.Now };
            }

            var fxRate = dataAccessService.GetCurrentFxRate(from, to);

            return fxRate;
        }
    }
}
