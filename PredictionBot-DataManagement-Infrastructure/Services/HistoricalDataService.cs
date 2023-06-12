using MapsterMapper;
using PredictionBot_DataManagement_Domain.Dtos;
using PredictionBot_DataManagement_Domain.Models;
using PredictionBot_DataManagement_Infrastructure.Database.Repository;

namespace PredictionBot_DataManagement_Infrastructure.Services
{
    public class HistoricalDataService : IHistoricalDataService
    {
        private readonly IHistoricalDataRepository _historicalDataRepository;
        private readonly IMapper _mapper;

        public HistoricalDataService(IHistoricalDataRepository historicalDataRepository, IMapper mapper)
        {
            _historicalDataRepository = historicalDataRepository;
            _mapper = mapper;
        }

        public void CreateHistoricalData(HistoricalDataDto historicalDataDto)
        {
            var intervalData = _mapper.Map<Interval>(historicalDataDto.Meta);
            var exchangeData = _mapper.Map<Exchange>(historicalDataDto.Meta);
            var currencyData = _mapper.Map<Currency>(historicalDataDto.Meta);
            var symbolData = new Symbol { SymbolName = historicalDataDto.Meta.Symbol, Currency = currencyData, CurrencyId = currencyData.CurrencyId, Exchange = exchangeData, ExchangeId = exchangeData.ExchangeId };

            foreach (var historicalValue in historicalDataDto.Values)
            {
                var historicalDataEntity = _mapper.Map<HistoricalData>(historicalValue);
                historicalDataEntity.Interval = intervalData;
                historicalDataEntity.IntervalId = intervalData.IntervalId;
                historicalDataEntity.Symbol = symbolData;
                historicalDataEntity.SymbolId = symbolData.SymbolId;
                _historicalDataRepository.Add(historicalDataEntity);
            }
        }
    }
}