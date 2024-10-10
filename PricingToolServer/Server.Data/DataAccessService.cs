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
        readonly DataContext dataContext;

        public DataAccessService(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public FxRate GetCurrentFxRate(CurrencyEnum from, CurrencyEnum to)
        {
            throw new NotImplementedException();
        }
    }
}
