using Database;
using PredictionBot_DataManagement_Domain.Models;

namespace PredictionBot_DataManagement_Infrastructure.Database.Repository
{
    public class HistoricalDataRepository : Repository<HistoricalData>, IHistoricalDataRepository
    {
        private readonly ICurrencyRepository _currencyRepository;
        private readonly IExchangeRepository _exchangeRepository;
        private readonly IIntervalRepository _intervalRepository;
        private readonly ISymbolRepository _symbolRepository;

        public HistoricalDataRepository(DataManagementDbContext context, IExchangeRepository exchangeRepository, ICurrencyRepository currencyRepository, ISymbolRepository symbolRepository, IIntervalRepository intervalRepository) : base(context)
        {
            _symbolRepository = symbolRepository;
            _intervalRepository = intervalRepository;
            _exchangeRepository = exchangeRepository;
            _currencyRepository = currencyRepository;
        }

        public override void Add(HistoricalData entity)
        {
            entity.Symbol.Currency = GetOrCreateCurrency(entity.Symbol.Currency);
            entity.Symbol.Exchange = GetOrCreateExchange(entity.Symbol.Exchange);
            entity.Symbol = GetOrCreateSymbol(entity.Symbol);
            entity.Interval = GetOrCreateInterval(entity.Interval);

            entity.Symbol.CurrencyId = entity.Symbol.Currency.CurrencyId;
            entity.Symbol.ExchangeId = entity.Symbol.Exchange.ExchangeId;
            entity.SymbolId = entity.Symbol.SymbolId;
            entity.IntervalId = entity.Interval.IntervalId;

            if (GetAll(item => item.Datetime == entity.Datetime && item.Interval.IntervalName == entity.Interval.IntervalName && item.Symbol.SymbolName == entity.Symbol.SymbolName)?.FirstOrDefault() == null)
            {
                base.Add(entity);
            }
        }

        private Currency GetOrCreateCurrency(Currency currency)
        {
            var existingCurrency = _currencyRepository.GetAll(item => item.CurrencyName == currency.CurrencyName)?.FirstOrDefault();

            if (existingCurrency == null)
            {
                _currencyRepository.Add(currency);
                return currency;
            }

            return existingCurrency;
        }

        private Exchange GetOrCreateExchange(Exchange exchange)
        {
            var existingExchange = _exchangeRepository.GetAll(item => item.ExchangeName == exchange.ExchangeName)?.FirstOrDefault();

            if (existingExchange == null)
            {
                _exchangeRepository.Add(exchange);
                return exchange;
            }

            return existingExchange;
        }

        private Interval GetOrCreateInterval(Interval interval)
        {
            var existingInterval = _intervalRepository.GetAll(item => item.IntervalName == interval.IntervalName)?.FirstOrDefault();

            if (existingInterval == null)
            {
                _intervalRepository.Add(interval);
                return interval;
            }

            return existingInterval;
        }

        private Symbol GetOrCreateSymbol(Symbol symbol)
        {
            var existingSymbol = _symbolRepository.GetAll(item => item.SymbolName == symbol.SymbolName)?.FirstOrDefault();

            if (existingSymbol == null)
            {
                _symbolRepository.Add(symbol);
                return symbol;
            }

            return existingSymbol;
        }
    }
}