using PredictionBot_DataManagement_Domain.Models;

namespace PredictionBot_DataManagement_Domain_Test.Models;

public class HistoricalDataUnitTests
{
    [Fact]
    public void NewHistoricalDataExists()
    {
        // Arrange
        var historicalData = new HistoricalData();

        // Assert
        Assert.NotNull(historicalData);
        Assert.IsType<HistoricalData>(historicalData);
    }
}