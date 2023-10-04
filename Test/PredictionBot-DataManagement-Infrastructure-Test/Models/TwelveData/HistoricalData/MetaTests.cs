using PredictionBot_DataManagement_Infrastructure.Models.TwelveData.HistoricalData;
using System.Text.Json;
using Xunit;

namespace PredictionBot_DataManagement_Infrastructure_Test.Models.TwelveData.HistoricalData
{
    public class MetaTests
    {
        [Fact]
        public void Symbol_GetSet_ShouldWork()
        {
            // Arrange
            var meta = new Meta();
            const string expectedSymbol = "AAPL";

            // Act
            meta.Symbol = expectedSymbol;
            var actualSymbol = meta.Symbol;

            // Assert
            Assert.Equal(expectedSymbol, actualSymbol);
        }

        [Fact]
        public void Interval_GetSet_ShouldWork()
        {
            // Arrange
            var meta = new Meta();
            const string expectedInterval = "1d";

            // Act
            meta.Interval = expectedInterval;
            var actualInterval = meta.Interval;

            // Assert
            Assert.Equal(expectedInterval, actualInterval);
        }

        [Fact]
        public void Currency_GetSet_ShouldWork()
        {
            // Arrange
            var meta = new Meta();
            const string expectedCurrency = "USD";

            // Act
            meta.Currency = expectedCurrency;
            var actualCurrency = meta.Currency;

            // Assert
            Assert.Equal(expectedCurrency, actualCurrency);
        }

        [Fact]
        public void ExchangeTimezone_GetSet_ShouldWork()
        {
            // Arrange
            var meta = new Meta();
            const string expectedExchangeTimezone = "EST";

            // Act
            meta.ExchangeTimezone = expectedExchangeTimezone;
            var actualExchangeTimezone = meta.ExchangeTimezone;

            // Assert
            Assert.Equal(expectedExchangeTimezone, actualExchangeTimezone);
        }

        [Fact]
        public void Exchange_GetSet_ShouldWork()
        {
            // Arrange
            var meta = new Meta();
            const string expectedExchange = "NASDAQ";

            // Act
            meta.Exchange = expectedExchange;
            var actualExchange = meta.Exchange;

            // Assert
            Assert.Equal(expectedExchange, actualExchange);
        }

        [Fact]
        public void MicCode_GetSet_ShouldWork()
        {
            // Arrange
            var meta = new Meta();
            const string expectedMicCode = "XYZ";

            // Act
            meta.MarketIdentifierCode = expectedMicCode;
            var actualMicCode = meta.MarketIdentifierCode;

            // Assert
            Assert.Equal(expectedMicCode, actualMicCode);
        }

        [Fact]
        public void Type_GetSet_ShouldWork()
        {
            // Arrange
            var meta = new Meta();
            const string expectedType = "Stock";

            // Act
            meta.AssetClassType = expectedType;
            var actualType = meta.AssetClassType;

            // Assert
            Assert.Equal(expectedType, actualType);
        }

        [Fact]
        public void DeserializeFromJson_ShouldDeserializeCorrectly()
        {
            // Arrange
            const string json = "{\"symbol\":\"AAPL\",\"interval\":\"1d\",\"currency\":\"USD\",\"exchange_timezone\":\"EST\",\"exchange\":\"NASDAQ\",\"mic_code\":\"XYZ\",\"type\":\"Stock\"}";

            // Act
            var meta = JsonSerializer.Deserialize<Meta>(json);

            // Assert
            Assert.NotNull(meta);
            Assert.IsType<Meta>(meta);
            Assert.Equal("AAPL", meta.Symbol);
            Assert.Equal("1d", meta.Interval);
            Assert.Equal("USD", meta.Currency);
            Assert.Equal("EST", meta.ExchangeTimezone);
            Assert.Equal("NASDAQ", meta.Exchange);
            Assert.Equal("XYZ", meta.MarketIdentifierCode);
            Assert.Equal("Stock", meta.AssetClassType);
        }
    }
}