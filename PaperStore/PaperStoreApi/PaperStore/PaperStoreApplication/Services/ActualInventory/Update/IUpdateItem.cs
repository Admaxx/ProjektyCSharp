namespace PaperStoreApplication.Services.ActualInventory.Update;

public interface IUpdateItem
{
    Task<bool> UpdateItemByName(long Id, int? Qty, string AdditionalInfo);
}
