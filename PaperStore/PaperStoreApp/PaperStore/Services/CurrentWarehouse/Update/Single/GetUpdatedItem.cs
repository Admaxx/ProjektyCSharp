using Microsoft.EntityFrameworkCore;
using PaperStore.WareHouseData;

namespace PaperStore.Services.CurrentWarehouse.Update.Single
{
    public class GetUpdateItem : IGetUpdatedItem
    {
        PaperWarehouseContext context;

        public GetUpdateItem(PaperWarehouseContext _context)
            =>
            context = _context;
        public async Task<CurrentStock> Item(long Id)
            => await
            context.CurrentStocks.Where(item => item.Id == Id)
                .Include(item => item.ProductNameNavigation)
                .FirstAsync();

    }
}
