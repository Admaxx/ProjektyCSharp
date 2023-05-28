using Microsoft.EntityFrameworkCore;
using PaperStore.WareHouseData;

namespace PaperStore.Services.CurrentWarehouse.Delete
{
    public class RemoveItem : IRemoveItem
    {
        PaperWarehouseContext context;
        public RemoveItem(PaperWarehouseContext _context)
            =>
            context = _context;
        public async Task<string> Item(long Id)
        {
            var model = await context.CurrentStocks.Where(item => item.Id == Id)
                .FirstAsync();
            model.Archive = true;

            await Task.Run(() =>
            {
                context.Update(model);
            });
            return await
                context.SaveChangesAsync() > 0
                ? AllData.SuccessfullDeleted : string.Empty;
        }
    }
}
