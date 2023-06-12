namespace PredictionBot_DataManagement_Domain.Models;

public class Exchange
{
    public string ExchangeId { get; set; } = Guid.NewGuid().ToString();

    public string ExchangeName { get; set; } = null!;

    public virtual ICollection<Symbol> Symbols { get; set; } = new List<Symbol>();
    public string Timezone { get; set; } = null!;
}