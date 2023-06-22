namespace PredictionBot_DataManagement_Test;

public class ApplicationTests
{
    [Fact]
    public void ApplicationLayerTest()
    {
        // Arrange
        var result = "This Test belongs to the application layer";

        // Assert
        Assert.Equal("This Test belongs to the application layer", result);
    }
}