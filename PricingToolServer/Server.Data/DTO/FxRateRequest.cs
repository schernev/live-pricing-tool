
namespace Server.Data.DTO
{
    public class FxRateRequest
    {
        public required string FromCurrency { get; set; }

        public required string ToCurrency { get; set; }
    }
}
