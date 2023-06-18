namespace PaperStoreApplication.Services.LastItem.Delete;

public interface IDeleteItem
{
    Task<bool> RemoveLastElement(bool IsArchive);
}
