namespace PaperStore.Services.ActualInventory.Delete;

public class DeleteItem : IDeleteItem
{
    readonly PaperWarehouseContext _context;
    public DeleteItem(PaperWarehouseContext conn)
    {
        this._context = conn;
    }
    public async Task<bool> ItemById(long id, bool IsArchive)
    {
        try
        {
            return await
            _context.CurrentStocks
            .Where(item => item.Id == id && item.Archive == IsArchive)
            .ExecuteDeleteAsync() > 0;
        }
        catch (Exception) { return false; }
    }
}