namespace PaperStore.Services.ActualInventory.Delete;

public interface IDeleteItem
{
    Task<bool> ItemById(long id, bool IsArchive);
}
