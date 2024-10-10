using Moq;
using Server.Data;
using Server.Services;

namespace Server.Tests
{
    public class PricePickerServiceTests
    {
        private IPriceTickerService priceTickerService;
        private Mock<IDataAccessService> dataAccessServiceMock;

        public PricePickerServiceTests()
        {
            dataAccessServiceMock = new Mock<IDataAccessService>();
            priceTickerService = new PriceTickerService(dataAccessServiceMock.Object);
        }

        [Theory]
        [InlineData("USD", "EUR")]
        [InlineData("EUR", "USD")]
        public void GetCurrencyRate_ReturnCorrectRange(string from, string to)
        {
            // Act
            var result = priceTickerService.GetCurrentFxRate(from, to);

            // Assert
            Assert.InRange(result.LastPrice, result.Bid, result.Ask);
            Assert.InRange(result.LastUpdated, DateTime.Now.AddSeconds(-10), DateTime.Now);
        }

        [Theory]
        [InlineData("USD", "EUR")]
        [InlineData("EUR", "USD")]
        public void GetCurrencyRate_ReturnCorrectCurrency(string from, string to)
        {
            // Act
            var result = priceTickerService.GetCurrentFxRate(from, to);

            // Assert
            Assert.Equal(from, result.Currency.ToString());
            Assert.Equal(to, result.RefCurrency.ToString());
        }

        [Theory]
        [InlineData("USD", "USD")]
        [InlineData("EUR", "EUR")]
        public void GetCurrencyRate_SameCurrencyReturnsZero(string from, string to)
        {
            // Act
            var result = priceTickerService.GetCurrentFxRate(from, to);

            // Assert
            Assert.Equal(0, result.Ask);
            Assert.Equal(0, result.Bid);
            Assert.Equal(0, result.LastPrice);
        }

        [Fact]
        public void GetCurrencyRate_InvalidCurrencyReturnsZero()
        {
            // Arrange
            var currency = "AAA";

            // Act & Assert
            Assert.Throws<ArgumentException>(() => priceTickerService.GetCurrentFxRate(currency, "USD"));
            Assert.Throws<ArgumentException>(() => priceTickerService.GetCurrentFxRate("USD", currency));
        }
    }
}