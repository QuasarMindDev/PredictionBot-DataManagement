namespace PredictionBot_DataManagement_Test;
public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        var result = "Este Test pertenece a la capa de aplicacion";

        Assert.Equal("Este Test pertenece a la capa de aplicacion", result);
    }
}