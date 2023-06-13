namespace PredictionBot_DataManagement_Domain.Models;

public class Currency
{
    public string CurrencyId { get; set; } = Guid.NewGuid().ToString();

    public string CurrencyName { get; set; } = null!;

    public string CurrencySymbol { get; set; } = null!;

    public virtual ICollection<Symbol> Symbols { get; set; } = new List<Symbol>();
}