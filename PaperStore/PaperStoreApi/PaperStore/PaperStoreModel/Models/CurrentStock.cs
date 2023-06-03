namespace PaperStoreModel.Models;

public partial class CurrentStock
{
    public long Id { get; set; }

    public long ProductName { get; set; }

    public long? AddtionalInfoId { get; set; }

    public DateTime? InputData { get; set; }

    public DateTime? UpdateData { get; set; }

    public bool? Archive { get; set; }

    public int Qty { get; set; }

    public virtual StockAdditionalInfo? AddtionalInfoNavigation { get; set; }

    public virtual StockItem ProductNameNavigation { get; set; } = null!;
}
