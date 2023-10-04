using PredictionBot_DataManagement_Infrastructure.Models.TwelveData.HistoricalData;
using System.Text.Json;
using Xunit;

namespace PredictionBot_DataManagement_Infrastructure_Test.Models.TwelveData.HistoricalData
{
    public class HistoricalDataDtoTests
    {
        [Fact]
        public void Meta_GetSet_ShouldWork()
        {
            // Arrange
            var dto = new HistoricalDataDto();
            var expectedMeta = new Meta();

            // Act
            dto.Meta = expectedMeta;
            var actualMeta = dto.Meta;

            // Assert
            Assert.Same(expectedMeta, actualMeta);
        }

        [Fact]
        public void Values_GetSet_ShouldWork()
        {
            // Arrange
            var dto = new HistoricalDataDto();
            var expectedValues = new Value[] { new Value(), new Value() };

            // Act
            dto.Values = expectedValues;
            var actualValues = dto.Values;

            // Assert
            Assert.Same(expectedValues, actualValues);
        }

        [Fact]
        public void Status_GetSet_ShouldWork()
        {
            // Arrange
            var dto = new HistoricalDataDto();
            const string expectedStatus = "success";

            // Act
            dto.Status = expectedStatus;
            var actualStatus = dto.Status;

            // Assert
            Assert.Equal(expectedStatus, actualStatus);
        }

        [Fact]
        public void DeserializeFromJson_ShouldDeserializeCorrectly()
        {
            // Arrange
            const string json = "{\"meta\":{},\"values\":[],\"status\":\"success\"}";

            // Act
            var dto = JsonSerializer.Deserialize<HistoricalDataDto>(json);

            // Assert
            Assert.NotNull(dto);
            Assert.IsType<HistoricalDataDto>(dto);
            Assert.NotNull(dto.Meta);
            Assert.NotNull(dto.Values);
            Assert.Equal("success", dto.Status);
        }
    }
}