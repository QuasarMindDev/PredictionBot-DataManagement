using FluentValidation.TestHelper;
using PredictionBot_DataManagement_Domain.Models.HistoricalData;
using PredictionBot_DataManagement_Infrastructure.Common.Validations.HistoricalData;
using Xunit;

namespace PredictionBot_DataManagement_Infrastructure_Test.Common.Validations.HistoricalData
{
    public class MetadataValidatorTests
    {
        [Fact]
        public void Validate_ShouldFail_WhenSymbolIsEmpty()
        {
            // Arrange
            var validator = new MetadataValidator();
            var metadata = new Metadata { Symbol = "", Interval = "1d" };

            // Act
            var result = validator.TestValidate(metadata);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Symbol).WithErrorMessage("Symbol cannot be empty");
        }

        [Fact]
        public void Validate_ShouldFail_WhenIntervalIsEmpty()
        {
            // Arrange
            var validator = new MetadataValidator();
            var metadata = new Metadata { Symbol = "AAPL", Interval = "" };

            // Act
            var result = validator.TestValidate(metadata);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Interval).WithErrorMessage("Interval cannot be empty");
        }

        [Fact]
        public void Validate_ShouldPass_WhenAllFieldsAreValid()
        {
            // Arrange
            var validator = new MetadataValidator();
            var metadata = new Metadata { Symbol = "AAPL", Interval = "1d" };

            // Act
            var result = validator.TestValidate(metadata);

            // Assert
            result.ShouldNotHaveAnyValidationErrors();
        }
    }
}