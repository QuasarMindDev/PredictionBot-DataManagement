using FluentValidation;
using PredictionBot_DataManagement_Domain.Models.HistoricalData;

namespace PredictionBot_DataManagement_Infrastructure.Common.Validations.HistoricalData
{
    public class MarketDataValidator : AbstractValidator<MarketData>
    {
        public MarketDataValidator()
        {
            RuleFor(x => x.Datetime).NotEmpty().WithMessage("Date cannot be empty");
            RuleFor(x => x.Open).NotEmpty().WithMessage("Open cannot be empty");
            RuleFor(x => x.High).NotEmpty().WithMessage("High cannot be empty");
            RuleFor(x => x.Low).NotEmpty().WithMessage("Low cannot be empty");
            RuleFor(x => x.Close).NotEmpty().WithMessage("Close cannot be empty");
            RuleFor(x => x.Volume).NotEmpty().WithMessage("Volume cannot be empty");
            RuleFor(x => x.MetadataId).NotEmpty().WithMessage("MetadataId cannot be empty");
        }
    }
}