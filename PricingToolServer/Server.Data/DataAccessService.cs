using Server.Data.Enums;
using Server.Data.Model;

namespace Server.Data
{
    public interface IDataAccessService
    {
        FxRate GetCurrentFxRate(CurrencyEnum from, CurrencyEnum to);
    }

    public class DataAccessService : IDataAccessService
    {
        readonly IDataContext dataContext;

        public DataAccessService(IDataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public FxRate GetCurrentFxRate(CurrencyEnum from, CurrencyEnum to)
        {
            var currRates = dataContext.FxRates
                .Where(x => x.Currency == from && x.RefCurrency == to);

            if (!currRates.Any())
            {
                return new FxRate { Currency = from, RefCurrency = to, Ask = 0, Bid = 0, LastPrice = 0, LastUpdated = DateTime.Now };
            }

            // Get the latest rate
            // return currRates
            //    .OrderByDescending(x => x.LastUpdated).First();

            // for testing purposes return random rate
            return currRates
                .OrderBy(x => Guid.NewGuid()).First();
        }
    }
}
