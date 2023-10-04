using FluentValidation.TestHelper;
using MongoDB.Bson;
using PredictionBot_DataManagement_Domain.Models.HistoricalData;
using PredictionBot_DataManagement_Infrastructure.Common.Validations.HistoricalData;
using Xunit;

namespace PredictionBot_DataManagement_Infrastructure_Test.Common.Validations.HistoricalData
{
    public class MarketDataValidatorTests
    {
        [Fact]
        public void Validate_ShouldFail_WhenDatetimeIsEmpty()
        {
            // Arrange
            var validator = new MarketDataValidator();
            var marketData = new MarketData { Datetime = null, Open = "100.00", High = "110.00", Low = "95.00", Close = "105.00", Volume = 1000000, MetadataId = ObjectId.GenerateNewId() };

            // Act
            var result = validator.TestValidate(marketData);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Datetime).WithErrorMessage("Date cannot be empty");
        }

        [Fact]
        public void Validate_ShouldFail_WhenOpenIsEmpty()
        {
            // Arrange
            var validator = new MarketDataValidator();
            var marketData = new MarketData { Datetime = DateTime.Parse("2023-01-01"), Open = "", High = "110.00", Low = "95.00", Close = "105.00", Volume = 1000000, MetadataId = ObjectId.GenerateNewId() };

            // Act
            var result = validator.TestValidate(marketData);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Open).WithErrorMessage("Open cannot be empty");
        }

        [Fact]
        public void Validate_ShouldFail_WhenHighIsEmpty()
        {
            // Arrange
            var validator = new MarketDataValidator();
            var marketData = new MarketData { Datetime = DateTime.Parse("2023-01-01"), Open = "100.00", High = "", Low = "95.00", Close = "105.00", Volume = 1000000, MetadataId = ObjectId.GenerateNewId() };

            // Act
            var result = validator.TestValidate(marketData);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.High).WithErrorMessage("High cannot be empty");
        }

        [Fact]
        public void Validate_ShouldFail_WhenLowIsEmpty()
        {
            // Arrange
            var validator = new MarketDataValidator();
            var marketData = new MarketData { Datetime = DateTime.Parse("2023-01-01"), Open = "100.00", High = "110.00", Low = "", Close = "105.00", Volume = 1000000, MetadataId = ObjectId.GenerateNewId() };

            // Act
            var result = validator.TestValidate(marketData);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Low).WithErrorMessage("Low cannot be empty");
        }

        [Fact]
        public void Validate_ShouldFail_WhenCloseIsEmpty()
        {
            // Arrange
            var validator = new MarketDataValidator();
            var marketData = new MarketData { Datetime = DateTime.Parse("2023-01-01"), Open = "100.00", High = "110.00", Low = "95.00", Close = "", Volume = 1000000, MetadataId = ObjectId.GenerateNewId() };

            // Act
            var result = validator.TestValidate(marketData);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Close).WithErrorMessage("Close cannot be empty");
        }

        [Fact]
        public void Validate_ShouldFail_WhenVolumeIsEmpty()
        {
            // Arrange
            var validator = new MarketDataValidator();
            var marketData = new MarketData { Datetime = DateTime.Parse("2023-01-01"), Open = "100.00", High = "110.00", Low = "95.00", Close = "105.00", Volume = 0, MetadataId = ObjectId.GenerateNewId() };

            // Act
            var result = validator.TestValidate(marketData);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Volume).WithErrorMessage("Volume cannot be empty");
        }

        [Fact]
        public void Validate_ShouldFail_WhenMetadataIdIsEmpty()
        {
            // Arrange
            var validator = new MarketDataValidator();
            var marketData = new MarketData { Datetime = DateTime.Parse("2023-01-01"), Open = "100.00", High = "110.00", Low = "95.00", Close = "105.00", Volume = 1000000, MetadataId = ObjectId.Empty };

            // Act
            var result = validator.TestValidate(marketData);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.MetadataId).WithErrorMessage("MetadataId cannot be empty");
        }

        [Fact]
        public void Validate_ShouldPass_WhenAllFieldsAreValid()
        {
            // Arrange
            var validator = new MarketDataValidator();
            var marketData = new MarketData { Datetime = DateTime.Parse("2023-01-01"), Open = "100.00", High = "110.00", Low = "95.00", Close = "105.00", Volume = 1000000, MetadataId = ObjectId.GenerateNewId() };

            // Act
            var result = validator.TestValidate(marketData);

            // Assert
            result.ShouldNotHaveAnyValidationErrors();
        }
    }
}