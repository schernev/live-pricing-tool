
namespace Server.Data.Model
{
    public interface IDataContext
    {
        List<FxRate> FxRates { get; set; }
    }

    public class DataContext : IDataContext
    {
        public List<FxRate> FxRates { get; set; } = [];
    }
}
