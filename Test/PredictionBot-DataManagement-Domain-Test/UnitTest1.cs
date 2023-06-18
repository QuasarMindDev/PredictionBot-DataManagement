using PredictionBot_DataManagement_Domain.Models;
namespace PredictionBot_DataManagement_Domain_Test;

public class UnitTest1
{
    [Fact]
    public void NewHistoricalDataExists()
    {
        var historicalData = new HistoricalData();

        Assert.NotNull(historicalData);
        Assert.IsType<HistoricalData>(historicalData);
    }
}