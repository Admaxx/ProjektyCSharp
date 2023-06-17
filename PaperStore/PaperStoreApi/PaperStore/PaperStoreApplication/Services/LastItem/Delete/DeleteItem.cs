using Microsoft.EntityFrameworkCore;
using PaperStoreApplication.Contexts;

namespace PaperStoreApplication.Services.LastItem.Delete;

public class DeleteItem(PaperWarehouseContext conn) : IDeleteItem
{
    PaperWarehouseContext _context { get; init; } = conn ?? throw new ArgumentNullException(nameof(conn));

    public async Task<bool> ItemById(long id, bool IsArchive)
    {
        try
        {
            return await
            _context.CurrentStocks
            .Where(item => item.Id == id && item.Archive == IsArchive)
            .ExecuteUpdateAsync(item => item.SetProperty(item => item.Archive, item => true)
            ) > 0;
        }
        catch (Exception) { return false; }
    }
}