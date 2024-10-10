using Server.Data.Enums;

namespace Server.Data.Model
{
    public interface IDataContext
    {
        List<FxRate> FxRates { get; set; }
    }

    public class DataContext : IDataContext
    {
        public DataContext()
        {
            FillTestPrices();
        }

        public List<FxRate> FxRates { get; set; } = [];

        private void FillTestPrices()
        {
            // add sample rates for EUR/USD
            FxRates.Add(new FxRate { Currency = CurrencyEnum.USD, RefCurrency = CurrencyEnum.EUR, Bid = 1.08491m, Ask = 1.09499m, LastPrice = 1.09099m, LastUpdated = DateTime.Now });
            FxRates.Add(new FxRate { Currency = CurrencyEnum.USD, RefCurrency = CurrencyEnum.EUR, Bid = 1.08591m, Ask = 1.09599m, LastPrice = 1.09199m, LastUpdated = DateTime.Now });
            FxRates.Add(new FxRate { Currency = CurrencyEnum.USD, RefCurrency = CurrencyEnum.EUR, Bid = 1.08691m, Ask = 1.09699m, LastPrice = 1.09299m, LastUpdated = DateTime.Now });
            FxRates.Add(new FxRate { Currency = CurrencyEnum.USD, RefCurrency = CurrencyEnum.EUR, Bid = 1.08791m, Ask = 1.09799m, LastPrice = 1.09399m, LastUpdated = DateTime.Now });
            FxRates.Add(new FxRate { Currency = CurrencyEnum.USD, RefCurrency = CurrencyEnum.EUR, Bid = 1.08891m, Ask = 1.09899m, LastPrice = 1.09499m, LastUpdated = DateTime.Now });
            FxRates.Add(new FxRate { Currency = CurrencyEnum.USD, RefCurrency = CurrencyEnum.EUR, Bid = 1.08991m, Ask = 1.09999m, LastPrice = 1.09599m, LastUpdated = DateTime.Now });
            FxRates.Add(new FxRate { Currency = CurrencyEnum.USD, RefCurrency = CurrencyEnum.EUR, Bid = 1.08191m, Ask = 1.09199m, LastPrice = 1.09099m, LastUpdated = DateTime.Now });
            FxRates.Add(new FxRate { Currency = CurrencyEnum.USD, RefCurrency = CurrencyEnum.EUR, Bid = 1.08291m, Ask = 1.09299m, LastPrice = 1.09099m, LastUpdated = DateTime.Now });
            FxRates.Add(new FxRate { Currency = CurrencyEnum.USD, RefCurrency = CurrencyEnum.EUR, Bid = 1.08311m, Ask = 1.09399m, LastPrice = 1.09099m, LastUpdated = DateTime.Now });
            FxRates.Add(new FxRate { Currency = CurrencyEnum.USD, RefCurrency = CurrencyEnum.EUR, Bid = 1.08321m, Ask = 1.09319m, LastPrice = 1.09019m, LastUpdated = DateTime.Now });
            FxRates.Add(new FxRate { Currency = CurrencyEnum.USD, RefCurrency = CurrencyEnum.EUR, Bid = 1.08331m, Ask = 1.09329m, LastPrice = 1.09309m, LastUpdated = DateTime.Now });
            FxRates.Add(new FxRate { Currency = CurrencyEnum.USD, RefCurrency = CurrencyEnum.EUR, Bid = 1.08341m, Ask = 1.09339m, LastPrice = 1.09319m, LastUpdated = DateTime.Now });
            FxRates.Add(new FxRate { Currency = CurrencyEnum.USD, RefCurrency = CurrencyEnum.EUR, Bid = 1.08351m, Ask = 1.09349m, LastPrice = 1.09329m, LastUpdated = DateTime.Now });
            FxRates.Add(new FxRate { Currency = CurrencyEnum.USD, RefCurrency = CurrencyEnum.EUR, Bid = 1.08361m, Ask = 1.09359m, LastPrice = 1.09339m, LastUpdated = DateTime.Now });
            FxRates.Add(new FxRate { Currency = CurrencyEnum.USD, RefCurrency = CurrencyEnum.EUR, Bid = 1.08371m, Ask = 1.09369m, LastPrice = 1.09349m, LastUpdated = DateTime.Now });
            FxRates.Add(new FxRate { Currency = CurrencyEnum.USD, RefCurrency = CurrencyEnum.EUR, Bid = 1.08381m, Ask = 1.09379m, LastPrice = 1.09359m, LastUpdated = DateTime.Now });
            FxRates.Add(new FxRate { Currency = CurrencyEnum.USD, RefCurrency = CurrencyEnum.EUR, Bid = 1.08391m, Ask = 1.09389m, LastPrice = 1.09369m, LastUpdated = DateTime.Now });
            FxRates.Add(new FxRate { Currency = CurrencyEnum.USD, RefCurrency = CurrencyEnum.EUR, Bid = 1.08301m, Ask = 1.09391m, LastPrice = 1.09371m, LastUpdated = DateTime.Now });
            FxRates.Add(new FxRate { Currency = CurrencyEnum.USD, RefCurrency = CurrencyEnum.EUR, Bid = 1.08390m, Ask = 1.09392m, LastPrice = 1.09382m, LastUpdated = DateTime.Now });
            FxRates.Add(new FxRate { Currency = CurrencyEnum.USD, RefCurrency = CurrencyEnum.EUR, Bid = 1.08391m, Ask = 1.09393m, LastPrice = 1.09383m, LastUpdated = DateTime.Now });
            // add sample rates for USD/EUR
            FxRates.Add(new FxRate { Currency = CurrencyEnum.EUR, RefCurrency = CurrencyEnum.USD, Bid = 0.90000m, Ask = 0.99000m, LastPrice = 0.93090m, LastUpdated = DateTime.Now });
            FxRates.Add(new FxRate { Currency = CurrencyEnum.EUR, RefCurrency = CurrencyEnum.USD, Bid = 0.91000m, Ask = 0.98000m, LastPrice = 0.96390m, LastUpdated = DateTime.Now });
        }
    }
}
