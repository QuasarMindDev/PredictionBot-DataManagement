using Database;
using Microsoft.EntityFrameworkCore;
using Moq;
using PredictionBot_DataManagement_Domain.Models;
using PredictionBot_DataManagement_Infrastructure.Database.Repository;

namespace PredictionBot_DataManagement_Infrastructure_UnitTest
{
    public class HistoricalDataRepositoryTests
    {
        [Fact]
        public void GetAll_ReturnsDataFromMockContext()
        {
            var testData = new List<HistoricalData>
            {
                new HistoricalData
                {
                    DataId = "1",
                    Datetime = new DateTime(2022, 1, 1),
                    SymbolId = "XYZ",
                    ClosePrice = 10.0f
                },
                new HistoricalData
                {
                    DataId = "2",
                    Datetime = new DateTime(2022, 1, 2),
                    SymbolId = "XYZ",
                    ClosePrice = 15.0f
                }
            };

            var mockDbSet = new Mock<DbSet<HistoricalData>>();
            mockDbSet.As<IQueryable<HistoricalData>>().Setup(m => m.Provider).Returns(testData.AsQueryable().Provider);
            mockDbSet.As<IQueryable<HistoricalData>>().Setup(m => m.Expression).Returns(testData.AsQueryable().Expression);
            mockDbSet.As<IQueryable<HistoricalData>>().Setup(m => m.ElementType).Returns(testData.AsQueryable().ElementType);
            mockDbSet.As<IQueryable<HistoricalData>>().Setup(m => m.GetEnumerator()).Returns(testData.AsQueryable().GetEnumerator());

            var mockOptions = new DbContextOptions<DataManagementDbContext>();
            var mockContext = new Mock<DataManagementDbContext>(mockOptions);
            mockContext.Setup(c => c.Set<HistoricalData>()).Returns(mockDbSet.Object);

            var mockExchangeRepository = new Mock<IExchangeRepository>();
            var mockCurrencyRepository = new Mock<ICurrencyRepository>();
            var mockSymbolRepository = new Mock<ISymbolRepository>();
            var mockIntervalRepository = new Mock<IIntervalRepository>();

            var repository = new HistoricalDataRepository(
                mockContext.Object,
                mockExchangeRepository.Object,
                mockCurrencyRepository.Object,
                mockSymbolRepository.Object,
                mockIntervalRepository.Object);

            var result = repository.GetAll();

            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
            Assert.Equal("XYZ", result.First().SymbolId);
            Assert.Equal(10.0f, result.First().ClosePrice);
        }
    }
}