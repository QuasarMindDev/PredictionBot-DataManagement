using FluentValidation;
using PredictionBot_DataManagement_Domain.Dtos.HistoricalData;

namespace PredictionBot_DataManagement_Infrastructure.Common.Validations.HistoricalData
{
    public class HistoricalDataRequestValidator : AbstractValidator<HistoricalDataRequestDto>
    {
        public HistoricalDataRequestValidator()
        {
            RuleFor(x => x.Symbol).NotEmpty().WithMessage("Symbol cannot be empty");
            RuleFor(x => x.Interval).NotEmpty().WithMessage("Interval cannot be empty");
            RuleFor(x => x.InitialDate).NotEmpty().WithMessage("InitialDate cannot be empty");
            RuleFor(x => x.FinalDate).NotEmpty().WithMessage("FinalDate cannot be empty");
        }
    }
}