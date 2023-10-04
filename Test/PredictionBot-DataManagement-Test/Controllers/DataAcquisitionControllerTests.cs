using DataModule.Controllers;
using DataModuleInfrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using PredictionBot_DataManagement_Infrastructure.Models.TwelveData.HistoricalData;
using Xunit;

namespace PredictionBot_DataManagement_Test.Controllers
{
    public class DataAcquisitionControllerTests
    {
        [Fact]
        public async Task GetHistoricalData_ReturnsOkResult()
        {
            // Arrange
            var loggerMock = new Mock<ILogger<DataAcquisitionController>>();
            var dataServiceMock = new Mock<ITwelveDataService>();
            const string currency = "USD";
            const string interval = "1min";
            var marketDataList = new Value[]
                {
                new Value
                {
                    Open = "100.00",
                    High = "110.00",
                    Low = "95.00",
                    Close = "105.00",
                    Volume = 1000000
                },
                new Value
                {
                    Open = "110.00",
                    High = "120.00",
                    Low = "100.00",
                    Close = "115.00",
                    Volume = 1200000
                }
                };

            var metadata = new Meta
            {
                Symbol = "AAPL",
                Interval = "1d",
                Exchange = "NASDAQ"
            };

            var expectedData = new HistoricalDataDto
            {
                Values = marketDataList,
                Meta = metadata,
                Status = "ok"
            };
            dataServiceMock.Setup(x => x.DataSeries(currency, interval)).Returns(Task.FromResult(expectedData));
            var controller = new DataAcquisitionController(loggerMock.Object, dataServiceMock.Object);

            // Act
            var result = await controller.GetHistoricalData(currency, interval);

            // Assert
            Assert.IsType<ActionResult<HistoricalDataDto>>(result);
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            Assert.Same(expectedData, okResult.Value);
        }
    }
}