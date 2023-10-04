using MongoDB.Bson;
using PredictionBot_DataManagement_Domain.Models.HistoricalData;
using Xunit;

namespace PredictionBot_DataManagement_Domain_Test.Models.HistoricalData
{
    public class MetadataTests
    {
        [Fact]
        public void MetadataProperties_ShouldBeSettableAndGettable()
        {
            // Arrange
            var metadata = new Metadata
            {
                Id = ObjectId.GenerateNewId(),
                Symbol = "AAPL",
                Interval = "1d",
                ExchangeTimezone = "EST",
                Exchange = "NASDAQ",
                MarketIdentifierCode = "US",
                AssetClassType = "Equity"
            };

            // Act

            // Assert
            Assert.Equal("AAPL", metadata.Symbol);
            Assert.Equal("1d", metadata.Interval);
            Assert.Equal("EST", metadata.ExchangeTimezone);
            Assert.Equal("NASDAQ", metadata.Exchange);
            Assert.Equal("US", metadata.MarketIdentifierCode);
            Assert.Equal("Equity", metadata.AssetClassType);
        }
    }
}