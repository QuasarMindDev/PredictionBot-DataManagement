using PredictionBot_DataManagement_Domain.Dtos.HistoricalData;
using Xunit;

namespace PredictionBot_DataManagement_Domain_Test.Dtos.HistoricalData
{
    public class HistoricalDataRequestDtoTests
    {
        [Fact]
        public void Properties_ShouldBeSettableAndGettable()
        {
            // Arrange
            var requestDto = new HistoricalDataRequestDto
            {
                Symbol = "AAPL",
                Interval = "1d",
                Exchange = "NASDAQ",
                InitialDate = "2023-01-01",
                FinalDate = "2023-12-31"
            };

            // Act

            // Assert
            Assert.Equal("AAPL", requestDto.Symbol);
            Assert.Equal("1d", requestDto.Interval);
            Assert.Equal("NASDAQ", requestDto.Exchange);
            Assert.Equal("2023-01-01", requestDto.InitialDate);
            Assert.Equal("2023-12-31", requestDto.FinalDate);
        }
    }
}