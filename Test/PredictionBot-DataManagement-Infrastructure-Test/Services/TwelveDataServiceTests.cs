using Microsoft.Extensions.Options;
using Moq;
using PredictionBot_DataManagement_Infrastructure.Models.Configuration;
using PredictionBot_DataManagement_Infrastructure.Models.TwelveData.HistoricalData;
using PredictionBot_DataManagement_Infrastructure.Services;
using PredictionBot_DataManagement_Infrastructure_Test.Helpers;
using System.Net;
using TwelveDataServices;
using Xunit;

namespace PredictionBot_DataManagement_Infrastructure_Test.Services
{
    public class TwelveDataServiceTests
    {
        [Fact]
        public async Task DataSeries_ShouldReturnHistoricalDataDtoAndCreateHistoricalData()
        {
            // Arrange
            const string currency = "AAPL";
            const string interval = "1d";
            var twelveDataOptions = new TwelveDataConnection { Token = "your-api-key", Url = "https://api.twelvedata.com/" };
            var expectedHistoricalData = new HistoricalDataDto { Status = "ok" };
            var historicalDataServiceMock = new Mock<IHistoricalDataService>();
            var twelveDataOptionsMock = new Mock<IOptions<TwelveDataConnection>>();

            historicalDataServiceMock.Setup(service => service.CreateHistoricalData(expectedHistoricalData)).Verifiable();
            twelveDataOptionsMock.Setup(options => options.Value).Returns(twelveDataOptions);
            var twelveDataService = new TwelveDataService(historicalDataServiceMock.Object, HttpClientMocks.CreateFactoryMock(expectedHistoricalData, HttpStatusCode.OK), twelveDataOptionsMock.Object);

            // Act
            var result = await twelveDataService.DataSeries(currency, interval);

            // Assert
            historicalDataServiceMock.Verify(service => service.CreateHistoricalData(expectedHistoricalData), Times.Once);
            Assert.NotNull(result);
            Assert.Equal(expectedHistoricalData, result);
        }

        [Fact]
        public async Task DataSeries_ShouldThrowHttpRequestException_WhenApiResponseIsNotSuccessful()
        {
            // Arrange
            const string currency = "AAPL";
            const string interval = "1d";
            var twelveDataOptions = new TwelveDataConnection { Token = "your-api-key", Url = "https://api.twelvedata.com/" };
            var expectedHistoricalData = new HistoricalDataDto { Status = "error" };
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            var historicalDataServiceMock = new Mock<IHistoricalDataService>();
            var twelveDataOptionsMock = new Mock<IOptions<TwelveDataConnection>>();

            twelveDataOptionsMock.Setup(options => options.Value).Returns(twelveDataOptions);
            var twelveDataService = new TwelveDataService(historicalDataServiceMock.Object, HttpClientMocks.CreateFactoryMock(expectedHistoricalData, HttpStatusCode.BadRequest), twelveDataOptionsMock.Object);

            // Act & Assert
            await Assert.ThrowsAsync<HttpRequestException>(() => twelveDataService.DataSeries(currency, interval));
        }

        [Fact]
        public async Task DataSeries_ShouldThrowHttpRequestException_WhenApiResponseIsNotOk()
        {
            // Arrange
            const string currency = "AAPL";
            const string interval = "1d";
            var twelveDataOptions = new TwelveDataConnection { Token = "your-api-key", Url = "https://api.twelvedata.com/" };
            var expectedHistoricalData = new HistoricalDataDto { Status = "error" };
            var historicalDataServiceMock = new Mock<IHistoricalDataService>();
            var twelveDataOptionsMock = new Mock<IOptions<TwelveDataConnection>>();

            twelveDataOptionsMock.Setup(options => options.Value).Returns(twelveDataOptions);
            var twelveDataService = new TwelveDataService(historicalDataServiceMock.Object, HttpClientMocks.CreateFactoryMock(expectedHistoricalData, HttpStatusCode.OK), twelveDataOptionsMock.Object);

            // Act & Assert
            await Assert.ThrowsAsync<HttpRequestException>(() => twelveDataService.DataSeries(currency, interval));
        }
    }
}