using MongoDB.Bson;
using PredictionBot_DataManagement_Domain.Models.HistoricalData;
using Xunit;

namespace PredictionBot_DataManagement_Domain_Test.Models.HistoricalData
{
    public class MarketDataTests
    {
        [Fact]
        public void MarketDataProperties_ShouldBeSettableAndGettable()
        {
            // Arrange
            var marketData = new MarketData
            {
                Id = ObjectId.GenerateNewId(),
                Open = "100.00",
                High = "110.00",
                Low = "95.00",
                Close = "105.00",
                Volume = 1000000,
                Datetime = DateTime.Now,
                MetadataId = ObjectId.GenerateNewId()
            };

            // Act

            // Assert
            Assert.Equal("100.00", marketData.Open);
            Assert.Equal("110.00", marketData.High);
            Assert.Equal("95.00", marketData.Low);
            Assert.Equal("105.00", marketData.Close);
            Assert.Equal(1000000, marketData.Volume);
            Assert.NotNull(marketData.Datetime);
        }
    }
}