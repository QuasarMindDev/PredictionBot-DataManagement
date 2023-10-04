using FluentValidation;
using Mapster;
using MapsterMapper;
using MongoDB.Bson;
using Moq;
using PredictionBot_DataManagement_Domain.Dtos.HistoricalData;
using PredictionBot_DataManagement_Domain.Models.HistoricalData;
using PredictionBot_DataManagement_Infrastructure.Database.Repository;
using PredictionBot_DataManagement_Infrastructure.Models.TwelveData.HistoricalData;
using PredictionBot_DataManagement_Infrastructure.Services;
using System.Linq.Expressions;
using Xunit;

namespace PredictionBot_DataManagement_Infrastructure_Test.Services
{
    public class HistoricalDataServiceTests
    {
        [Fact]
        public void CreateHistoricalData_ShouldAddMetadataAndMarketData()
        {
            // Arrange
            var historicalDataDto = new HistoricalDataDto
            {
                Meta = new Meta { Symbol = "AAPL", Interval = "1d" },
                Values = new Value[] { new Value { Datetime = "2023-10-01", Open = "150.25", High = "152.10", Low = "149.80", Close = "151.45", Volume = 100000 } }
            };

            var metadata = new Metadata { Symbol = "AAPL", Interval = "1d" };
            var marketData = new MarketData { Datetime = DateTime.Parse("2023-10-01"), Open = "150.25", High = "152.10", Low = "149.80", Close = "151.45", Volume = 100000, MetadataId = ObjectId.GenerateNewId() };

            var metadataValidatorMock = new Mock<IValidator<Metadata>>();
            metadataValidatorMock.Setup(x => x.ValidateAsync(metadata, It.IsAny<CancellationToken>())).ReturnsAsync(new FluentValidation.Results.ValidationResult());

            var marketDataValidatorMock = new Mock<IValidator<MarketData>>();
            marketDataValidatorMock.Setup(x => x.ValidateAsync(marketData, It.IsAny<CancellationToken>())).ReturnsAsync(new FluentValidation.Results.ValidationResult());

            var metadataRepositoryMock = new Mock<IMetadataRepository>();
            metadataRepositoryMock.Setup(x => x.AddAsync(metadata)).ReturnsAsync(ObjectId.GenerateNewId());

            var marketDataRepositoryMock = new Mock<IMarketDataRepository>();
            marketDataRepositoryMock.Setup(x => x.AddAsync(marketData)).Returns(Task.CompletedTask);

            var mapper = new TypeAdapterConfig();
            mapper.NewConfig<Meta, Metadata>().Map(dest => dest.Symbol, src => src.Symbol);
            mapper.NewConfig<Value, MarketData>().Map(dest => dest.Datetime, src => DateTime.Parse(src.Datetime));

            var historicalDataService = new HistoricalDataService(
                metadataRepositoryMock.Object,
                marketDataRepositoryMock.Object,
                new Mapper(mapper),
                metadataValidatorMock.Object,
                marketDataValidatorMock.Object);

            // Act
            historicalDataService.CreateHistoricalData(historicalDataDto);

            // Assert
            metadataRepositoryMock.Verify(x => x.AddAsync(It.IsAny<Metadata>()), Times.Once);
            marketDataRepositoryMock.Verify(x => x.AddAsync(It.IsAny<MarketData>()), Times.Once);
        }

        [Fact]
        public async Task GetHistoricalData_ShouldReturnHistoricalDataDatabaseDto()
        {
            // Arrange
            var historicalDataRequest = new HistoricalDataRequestDto
            {
                Symbol = "AAPL",
                Interval = "1d",
                Exchange = "NASDAQ",
                InitialDate = "2023-10-01",
                FinalDate = "2023-10-05"
            };

            var metadataDatabaseValue = new Metadata
            {
                Symbol = "AAPL",
                Interval = "1d",
                Exchange = "NASDAQ",
                Id = ObjectId.GenerateNewId()
            };

            var marketData = new List<MarketData>
        {
            new MarketData { Datetime = DateTime.Parse("2023-10-01"), Open = "150.25", High = "152.10", Low = "149.80", Close = "151.45", Volume = 100000, MetadataId = metadataDatabaseValue.Id },
            new MarketData { Datetime = DateTime.Parse("2023-10-02"), Open = "152.50", High = "155.20", Low = "151.10", Close = "154.30", Volume = 110000, MetadataId = metadataDatabaseValue.Id }
        };

            var metadataRepositoryMock = new Mock<IMetadataRepository>();
            metadataRepositoryMock.Setup(x => x.FindAsync(It.IsAny<Expression<Func<Metadata, bool>>>())).ReturnsAsync(new List<Metadata> { metadataDatabaseValue });

            var marketDataRepositoryMock = new Mock<IMarketDataRepository>();
            marketDataRepositoryMock.Setup(x => x.FindAsync(It.IsAny<Expression<Func<MarketData, bool>>>())).ReturnsAsync(marketData);

            var historicalDataService = new HistoricalDataService(
                metadataRepositoryMock.Object,
                marketDataRepositoryMock.Object,
                Mock.Of<IMapper>(),
                Mock.Of<IValidator<Metadata>>(),
                Mock.Of<IValidator<MarketData>>());

            // Act
            var result = await historicalDataService.GetHistoricalData(historicalDataRequest);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(metadataDatabaseValue, result.Metadata);
            Assert.Equal(marketData, result.MarketData);
        }
    }
}