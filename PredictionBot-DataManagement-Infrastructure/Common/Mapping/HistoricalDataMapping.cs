using Mapster;
using PredictionBot_DataManagement_Domain.Models.HistoricalData;
using PredictionBot_DataManagement_Infrastructure.Models.TwelveData.HistoricalData;

namespace PredictionBot_DataManagement_Infrastructure.Common.Mapping
{
    public class HistoricalDataMapping : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            MapDateTime(config);
            MapMetadata(config);
            MapMarketData(config);
        }

        private static void MapMetadata(TypeAdapterConfig config)
        {
            config.NewConfig<Meta, Metadata>()
                .Map(dest => dest.Symbol, src => src.Symbol)
                .Map(dest => dest.Interval, src => src.Interval)
                .Map(dest => dest.ExchangeTimezone, src => src.ExchangeTimezone)
                .Map(dest => dest.Exchange, src => src.Exchange)
                .Map(dest => dest.MarketIdentifierCode, src => src.MarketIdentifierCode)
                .Map(dest => dest.AssetClassType, src => src.AssetClassType);
        }

        private static void MapMarketData(TypeAdapterConfig config)
        {
            config.NewConfig<Value, MarketData>()
                .Map(dest => dest.Open, src => src.Open)
                .Map(dest => dest.High, src => src.High)
                .Map(dest => dest.Low, src => src.Low)
                .Map(dest => dest.Close, src => src.Close)
                .Map(dest => dest.Volume, src => src.Volume)
                .Map(dest => dest.Datetime, src => src.Datetime);
        }

        private static void MapDateTime(TypeAdapterConfig config)
        {
            config.NewConfig<string, DateTime?>()
            .MapWith(src => string.IsNullOrEmpty(src) ? null : DateTime.Parse(src));
        }
    }
}