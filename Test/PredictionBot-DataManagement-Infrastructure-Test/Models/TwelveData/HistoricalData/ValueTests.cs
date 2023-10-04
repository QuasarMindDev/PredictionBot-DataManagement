using PredictionBot_DataManagement_Infrastructure.Models.TwelveData.HistoricalData;
using System.Text.Json;
using Xunit;

namespace PredictionBot_DataManagement_Infrastructure_Test.Models.TwelveData.HistoricalData
{
    public class ValueTests
    {
        [Fact]
        public void Datetime_GetSet_ShouldWork()
        {
            // Arrange
            var value = new Value();
            const string expectedDatetime = "2023-10-04T14:30:00";

            // Act
            value.Datetime = expectedDatetime;
            var actualDatetime = value.Datetime;

            // Assert
            Assert.Equal(expectedDatetime, actualDatetime);
        }

        [Fact]
        public void Open_GetSet_ShouldWork()
        {
            // Arrange
            var value = new Value();
            const string expectedOpen = "150.25";

            // Act
            value.Open = expectedOpen;
            var actualOpen = value.Open;

            // Assert
            Assert.Equal(expectedOpen, actualOpen);
        }

        [Fact]
        public void High_GetSet_ShouldWork()
        {
            // Arrange
            var value = new Value();
            const string expectedHigh = "152.10";

            // Act
            value.High = expectedHigh;
            var actualHigh = value.High;

            // Assert
            Assert.Equal(expectedHigh, actualHigh);
        }

        [Fact]
        public void Low_GetSet_ShouldWork()
        {
            // Arrange
            var value = new Value();
            const string expectedLow = "149.80";

            // Act
            value.Low = expectedLow;
            var actualLow = value.Low;

            // Assert
            Assert.Equal(expectedLow, actualLow);
        }

        [Fact]
        public void Close_GetSet_ShouldWork()
        {
            // Arrange
            var value = new Value();
            const string expectedClose = "151.45";

            // Act
            value.Close = expectedClose;
            var actualClose = value.Close;

            // Assert
            Assert.Equal(expectedClose, actualClose);
        }

        [Fact]
        public void Volume_GetSet_ShouldWork()
        {
            // Arrange
            var value = new Value();
            const long expectedVolume = 100000;

            // Act
            value.Volume = expectedVolume;
            var actualVolume = value.Volume;

            // Assert
            Assert.Equal(expectedVolume, actualVolume);
        }

        [Fact]
        public void DeserializeFromJson_ShouldDeserializeCorrectly()
        {
            // Arrange
            const string json = "{\"datetime\":\"2023-10-04T14:30:00\",\"open\":\"150.25\",\"high\":\"152.10\",\"low\":\"149.80\",\"close\":\"151.45\",\"volume\":100000}";

            // Act
            var value = JsonSerializer.Deserialize<Value>(json);

            // Assert
            Assert.NotNull(value);
            Assert.IsType<Value>(value);
            Assert.Equal("2023-10-04T14:30:00", value.Datetime);
            Assert.Equal("150.25", value.Open);
            Assert.Equal("152.10", value.High);
            Assert.Equal("149.80", value.Low);
            Assert.Equal("151.45", value.Close);
            Assert.Equal(100000, value.Volume);
        }
    }
}