using PredictionBot_DataManagement_Infrastructure.Models.Configuration;
using Xunit;

namespace PredictionBot_DataManagement_Infrastructure_Test.Models.Configuration
{
    public class TwelveDataConnectionTests
    {
        [Fact]
        public void Token_GetSet_ShouldWork()
        {
            // Arrange
            var connection = new TwelveDataConnection();
            const string expectedToken = "myToken";

            // Act
            connection.Token = expectedToken;
            var actualToken = connection.Token;

            // Assert
            Assert.Equal(expectedToken, actualToken);
        }

        [Fact]
        public void Url_GetSet_ShouldWork()
        {
            // Arrange
            var connection = new TwelveDataConnection();
            const string expectedUrl = "https://example.com";

            // Act
            connection.Url = expectedUrl;
            var actualUrl = connection.Url;

            // Assert
            Assert.Equal(expectedUrl, actualUrl);
        }
    }
}