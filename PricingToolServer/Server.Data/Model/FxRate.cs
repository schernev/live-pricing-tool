using Server.Data.Enums;

namespace Server.Data.Model
{
    public class FxRate
    {
        public int Id { get; set; }

        public DateTime LastUpdated { get; set; }

        public CurrencyEnum Currency { get; set; }

        public CurrencyEnum RefCurrency { get; set; }

        public decimal Bid { get; set; }

        public decimal Ask { get; set; }

        public decimal LastPrice { get; set; }
    }
}
