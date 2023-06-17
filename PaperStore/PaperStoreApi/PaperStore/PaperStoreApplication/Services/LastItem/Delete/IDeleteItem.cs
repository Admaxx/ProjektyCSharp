namespace PaperStoreApplication.Services.LastItem.Delete;

public interface IDeleteItem
{
    Task<bool> ItemById(long id, bool IsArchive);
}
