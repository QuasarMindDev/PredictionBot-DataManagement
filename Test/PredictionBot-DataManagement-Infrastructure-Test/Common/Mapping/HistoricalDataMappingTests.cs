using Mapster;
using PredictionBot_DataManagement_Domain.Models.HistoricalData;
using PredictionBot_DataManagement_Infrastructure.Common.Mapping;
using PredictionBot_DataManagement_Infrastructure.Models.TwelveData.HistoricalData;
using Xunit;

namespace PredictionBot_DataManagement_Infrastructure_Test.Common.Mapping
{
    public class HistoricalDataMappingTests
    {
        [Fact]
        public void MapSymbol_ShouldMapCorrectly()
        {
            // Arrange
            var config = new TypeAdapterConfig();
            var mapping = new HistoricalDataMapping();
            mapping.Register(config);

            var meta = new Meta
            {
                Symbol = "AAPL",
                Interval = "1d",
                ExchangeTimezone = "EST",
                Exchange = "NASDAQ",
                MarketIdentifierCode = "US",
                AssetClassType = "Equity"
            };

            // Act
            var metadata = meta.Adapt<Metadata>(config);

            // Assert
            Assert.Equal("AAPL", metadata.Symbol);
            Assert.Equal("1d", metadata.Interval);
            Assert.Equal("EST", metadata.ExchangeTimezone);
            Assert.Equal("NASDAQ", metadata.Exchange);
            Assert.Equal("US", metadata.MarketIdentifierCode);
            Assert.Equal("Equity", metadata.AssetClassType);
        }

        [Fact]
        public void MapExchange_ShouldMapCorrectly()
        {
            // Arrange
            var config = new TypeAdapterConfig();
            var mapping = new HistoricalDataMapping();
            mapping.Register(config);

            var value = new Value
            {
                Open = "100.00",
                High = "110.00",
                Low = "95.00",
                Close = "105.00",
                Volume = 1000000,
                Datetime = "2023-01-01T12:00:00Z"
            };

            // Act
            var marketData = value.Adapt<MarketData>(config);

            // Assert
            Assert.Equal("100.00", marketData.Open);
            Assert.Equal("110.00", marketData.High);
            Assert.Equal("95.00", marketData.Low);
            Assert.Equal("105.00", marketData.Close);
            Assert.Equal(1000000, marketData.Volume);
            Assert.Equal(DateTime.Parse("2023-01-01T12:00:00Z"), marketData.Datetime);
        }

        [Fact]
        public void MapDateTime_ShouldMapCorrectly()
        {
            // Arrange
            var config = new TypeAdapterConfig();
            var mapping = new HistoricalDataMapping();
            mapping.Register(config);

            const string dateTimeString = "2023-01-01T12:00:00Z";

            // Act
            var dateTime = dateTimeString.Adapt<DateTime?>(config);

            // Assert
            Assert.Equal(DateTime.Parse(dateTimeString), dateTime);
        }
    }
}