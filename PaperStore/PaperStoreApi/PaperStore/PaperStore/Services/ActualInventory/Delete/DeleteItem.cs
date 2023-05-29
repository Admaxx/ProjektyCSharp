using Microsoft.EntityFrameworkCore;
using PaperStore.PaperStoreModel;

namespace PaperStore.Services.ActualInventory.Delete
{
    public class DeleteItem : IDeleteItem
    {
        PaperWarehouseContext _context;
        public DeleteItem(PaperWarehouseContext conn)
        {
            this._context = conn;
        }
        public async Task<bool> ItemById(long id, bool IsArchive)
        {
            try
            {
                _context.Remove(await _context.CurrentStocks.Where(item => item.Id == id && item.Archive == IsArchive).FirstAsync());

                return await _context.SaveChangesAsync() > 0;
            }
            catch (Exception) { }

            return false;
        }
    }
}
