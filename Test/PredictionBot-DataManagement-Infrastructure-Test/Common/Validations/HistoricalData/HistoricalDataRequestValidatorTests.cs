using FluentValidation.TestHelper;
using PredictionBot_DataManagement_Domain.Dtos.HistoricalData;
using PredictionBot_DataManagement_Infrastructure.Common.Validations.HistoricalData;
using Xunit;

namespace PredictionBot_DataManagement_Infrastructure_Test.Common.Validations.HistoricalData
{
    public class HistoricalDataRequestValidatorTests
    {
        [Fact]
        public void Validate_ShouldFail_WhenSymbolIsEmpty()
        {
            // Arrange
            var validator = new HistoricalDataRequestValidator();
            var dto = new HistoricalDataRequestDto { Symbol = "", Interval = "1d", InitialDate = "2023-01-01", FinalDate = "2023-12-31" };

            // Act
            var result = validator.TestValidate(dto);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Symbol).WithErrorMessage("Symbol cannot be empty");
        }

        [Fact]
        public void Validate_ShouldFail_WhenIntervalIsEmpty()
        {
            // Arrange
            var validator = new HistoricalDataRequestValidator();
            var dto = new HistoricalDataRequestDto { Symbol = "AAPL", Interval = "", InitialDate = "2023-01-01", FinalDate = "2023-12-31" };

            // Act
            var result = validator.TestValidate(dto);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Interval).WithErrorMessage("Interval cannot be empty");
        }

        [Fact]
        public void Validate_ShouldFail_WhenInitialDateIsEmpty()
        {
            // Arrange
            var validator = new HistoricalDataRequestValidator();
            var dto = new HistoricalDataRequestDto { Symbol = "AAPL", Interval = "1d", InitialDate = "", FinalDate = "2023-12-31" };

            // Act
            var result = validator.TestValidate(dto);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.InitialDate).WithErrorMessage("InitialDate cannot be empty");
        }

        [Fact]
        public void Validate_ShouldFail_WhenFinalDateIsEmpty()
        {
            // Arrange
            var validator = new HistoricalDataRequestValidator();
            var dto = new HistoricalDataRequestDto { Symbol = "AAPL", Interval = "1d", InitialDate = "2023-01-01", FinalDate = "" };

            // Act
            var result = validator.TestValidate(dto);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.FinalDate).WithErrorMessage("FinalDate cannot be empty");
        }

        [Fact]
        public void Validate_ShouldPass_WhenAllFieldsAreValid()
        {
            // Arrange
            var validator = new HistoricalDataRequestValidator();
            var dto = new HistoricalDataRequestDto { Symbol = "AAPL", Interval = "1d", InitialDate = "2023-01-01", FinalDate = "2023-12-31" };

            // Act
            var result = validator.TestValidate(dto);

            // Assert
            result.ShouldNotHaveAnyValidationErrors();
        }
    }
}