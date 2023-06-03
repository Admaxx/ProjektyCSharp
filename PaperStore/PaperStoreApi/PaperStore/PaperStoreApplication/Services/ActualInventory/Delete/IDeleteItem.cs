namespace PaperStoreApplication.Services.ActualInventory.Delete;

public interface IDeleteItem
{
    Task<bool> ItemById(long id, bool IsArchive);
}
