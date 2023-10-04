using PredictionBot_DataManagement_Domain.Dtos.HistoricalData;
using PredictionBot_DataManagement_Domain.Models.HistoricalData;
using Xunit;

namespace PredictionBot_DataManagement_Domain_Test.Dtos.HistoricalData
{
    public class HistoricalDataDatabaseDtoTests
    {
        [Fact]
        public void Properties_ShouldBeSettableAndGettable()
        {
            // Arrange
            var marketDataList = new List<MarketData>
            {
                new MarketData
                {
                    Open = "100.00",
                    High = "110.00",
                    Low = "95.00",
                    Close = "105.00",
                    Volume = 1000000
                },
                new MarketData
                {
                    Open = "110.00",
                    High = "120.00",
                    Low = "100.00",
                    Close = "115.00",
                    Volume = 1200000
                }
            };

            var metadata = new Metadata
            {
                Symbol = "AAPL",
                Interval = "1d",
                Exchange = "NASDAQ",
                MarketIdentifierCode = "US",
                AssetClassType = "Equity"
            };

            var dto = new HistoricalDataDatabaseDto
            {
                MarketData = marketDataList,
                Metadata = metadata
            };

            // Act

            // Assert
            Assert.NotNull(dto.MarketData);
            Assert.NotNull(dto.Metadata);
            Assert.Same(marketDataList, dto.MarketData);
            Assert.Same(metadata, dto.Metadata);
        }
    }
}