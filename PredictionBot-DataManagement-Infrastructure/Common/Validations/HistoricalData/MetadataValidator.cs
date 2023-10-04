using FluentValidation;
using PredictionBot_DataManagement_Domain.Models.HistoricalData;

namespace PredictionBot_DataManagement_Infrastructure.Common.Validations.HistoricalData
{
    public class MetadataValidator : AbstractValidator<Metadata>
    {
        public MetadataValidator()
        {
            RuleFor(x => x.Symbol).NotEmpty().WithMessage("Symbol cannot be empty");
            RuleFor(x => x.Interval).NotEmpty().WithMessage("Interval cannot be empty");
        }
    }
}