using Mapster;
using PredictionBot_DataManagement_Domain.Dtos;
using PredictionBot_DataManagement_Domain.Models;

namespace PredictionBot_DataManagement_Infrastructure.Common.Mapping
{
    public class HistoricalDataMapping : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Value, HistoricalData>()
                .Map(dest => dest.ClosePrice, src => src.Close)
                .Map(dest => dest.LowPrice, src => src.Low)
                .Map(dest => dest.OpenPrice, src => src.Open)
                .Map(dest => dest.HighPrice, src => src.High)
                .Map(dest => dest.Datetime, src => src.Datetime)
                .Map(dest => dest.Volume, src => src.Volume);
            config.NewConfig<Meta, Interval>().Map(dest => dest.IntervalName, src => src.Interval);
            config.NewConfig<Meta, Exchange>()
                .Map(dest => dest.ExchangeName, src => src.Exchange)
                .Map(dest => dest.Timezone, src => src.ExchangeTimezone);
            config.NewConfig<Meta, Currency>().Map(dest => dest.CurrencyName, src => src.Currency);
        }
    }
}