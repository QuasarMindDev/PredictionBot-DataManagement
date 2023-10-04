using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using PredictionBot_DataManagement.Controllers;
using PredictionBot_DataManagement_Domain.Dtos.HistoricalData;
using PredictionBot_DataManagement_Infrastructure.Services;
using Xunit;

namespace PredictionBot_DataManagement_Test.Controllers
{
    public class DataManagementControllerTests
    {
        [Fact]
        public async Task GetHistoricalDataFromDatabase_ReturnsOkResult_WhenDataIsValid()
        {
            // Arrange
            var loggerMock = new Mock<ILogger<DataManagementController>>();
            var historicalDataRepositoryMock = new Mock<IHistoricalDataService>();
            var validatorMock = new Mock<IValidator<HistoricalDataRequestDto>>();
            var controller = new DataManagementController(loggerMock.Object, historicalDataRepositoryMock.Object, validatorMock.Object);
            var requestDto = new HistoricalDataRequestDto();
            var expectedData = new HistoricalDataDatabaseDto();

            validatorMock.Setup(validator => validator.ValidateAsync(requestDto, It.IsAny<CancellationToken>())).ReturnsAsync(new FluentValidation.Results.ValidationResult());
            historicalDataRepositoryMock.Setup(x => x.GetHistoricalData(requestDto)).ReturnsAsync(expectedData);

            // Act
            var result = await controller.GetHistoricalDataFromDatabase(requestDto);

            // Assert
            Assert.IsType<ActionResult<HistoricalDataDatabaseDto>>(result);
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            Assert.Same(expectedData, okResult.Value);
        }
    }
}