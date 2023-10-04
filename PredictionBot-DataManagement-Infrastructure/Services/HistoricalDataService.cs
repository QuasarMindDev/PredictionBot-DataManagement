using FluentValidation;
using MapsterMapper;
using PredictionBot_DataManagement_Domain.Dtos.HistoricalData;
using PredictionBot_DataManagement_Domain.Models.HistoricalData;
using PredictionBot_DataManagement_Infrastructure.Database.Repository;
using PredictionBot_DataManagement_Infrastructure.Models.TwelveData.HistoricalData;

namespace PredictionBot_DataManagement_Infrastructure.Services
{
    public class HistoricalDataService : IHistoricalDataService
    {
        private readonly IMarketDataRepository _marketDataRepository;
        private readonly IMetadataRepository _metadataRepository;
        private readonly IValidator<Metadata> _metadataValidator;
        private readonly IValidator<MarketData> _marketDataValidator;
        private readonly IMapper _mapper;

        public HistoricalDataService(IMetadataRepository metadataRepository, IMarketDataRepository marketDataRepository, IMapper mapper, IValidator<Metadata> metadataValidator, IValidator<MarketData> marketDataValidator)
        {
            _metadataRepository = metadataRepository;
            _marketDataRepository = marketDataRepository;
            _metadataValidator = metadataValidator;
            _marketDataValidator = marketDataValidator;
            _mapper = mapper;
        }

        public async void CreateHistoricalData(HistoricalDataDto historicalDataDto)
        {
            var metadata = _mapper.Map<Metadata>(historicalDataDto.Meta);
            await _metadataValidator.ValidateAsync(metadata);
            var metadataid = await _metadataRepository.AddAsync(metadata);

            foreach (var historicalValue in historicalDataDto.Values)
            {
                var marketData = _mapper.Map<MarketData>(historicalValue);
                marketData.MetadataId = metadataid;
                await _marketDataValidator.ValidateAsync(marketData);
                await _marketDataRepository.AddAsync(marketData);
            }
        }

        public async Task<HistoricalDataDatabaseDto> GetHistoricalData(HistoricalDataRequestDto historicalDataRequest)
        {
            var metadataDatabaseValue = (await _metadataRepository.FindAsync(item => item.Symbol == historicalDataRequest.Symbol &&
                                                                       item.Interval == historicalDataRequest.Interval &&
                                                                       item.Exchange == historicalDataRequest.Exchange)).FirstOrDefault()
                                                                       ?? throw new KeyNotFoundException("Metadata not found");
            var marketData = await _marketDataRepository.FindAsync(item => item.MetadataId == metadataDatabaseValue.Id &&
                                                                            item.Datetime >= DateTime.Parse(historicalDataRequest.InitialDate) &&
                                                                            item.Datetime <= DateTime.Parse(historicalDataRequest.FinalDate));

            return new HistoricalDataDatabaseDto
            {
                Metadata = metadataDatabaseValue,
                MarketData = marketData
            };
        }
    }
}