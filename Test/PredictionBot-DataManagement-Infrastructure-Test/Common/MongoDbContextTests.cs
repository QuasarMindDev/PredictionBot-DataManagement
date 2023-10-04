using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Moq;
using PredictionBot_DataManagement_Domain.Configuration;
using PredictionBot_DataManagement_Infrastructure.Common;
using Xunit;

namespace PredictionBot_DataManagement_Infrastructure_Test.Common
{
    public class MongoDbContextTests
    {
        [Fact]
        public void Constructor_SetsDatabaseCorrectly()
        {
            // Arrange
            var dbOptionsMock = new Mock<IOptions<DatabaseConnection>>();
            dbOptionsMock.Setup(x => x.Value).Returns(new DatabaseConnection
            {
                ConnectionString = "mongodb://localhost:27017",
                DatabaseName = "TestDatabase"
            });

            // Act
            var dbContext = new MongoDbContext(dbOptionsMock.Object);

            // Assert
            Assert.NotNull(dbContext.Database);
            Assert.Equal("TestDatabase", dbContext.Database.DatabaseNamespace.DatabaseName);
        }

        [Fact]
        public void Constructor_SetsClientCorrectly()
        {
            // Arrange
            var dbOptionsMock = new Mock<IOptions<DatabaseConnection>>();
            dbOptionsMock.Setup(x => x.Value).Returns(new DatabaseConnection
            {
                ConnectionString = "mongodb://localhost:27017",
                DatabaseName = "TestDatabase"
            });

            // Act
            var dbContext = new MongoDbContext(dbOptionsMock.Object);

            // Assert
            Assert.NotNull(dbContext.Client);
        }

        [Fact]
        public void Constructor_ThrowsException_WhenConnectionStringIsInvalid()
        {
            // Arrange
            var dbOptionsMock = new Mock<IOptions<DatabaseConnection>>();
            dbOptionsMock.Setup(x => x.Value).Returns(new DatabaseConnection
            {
                ConnectionString = "invalid_connection_string",
                DatabaseName = "TestDatabase"
            });

            // Act & Assert
            Assert.Throws<MongoConfigurationException>(() => new MongoDbContext(dbOptionsMock.Object));
        }
    }
}