using Microsoft.EntityFrameworkCore;
using PaperStore.WareHouseData;

namespace PaperStore.Services.Read
{
    public class GetItem : IGetItem
    {
        PaperWarehouseContext context;
        public GetItem(PaperWarehouseContext _context)
            =>
            context = _context;
        public async Task<List<CurrentStock>> Item()

           => await
           context.CurrentStocks.Where(item => item.Archive == false)
                .Include(item => item.ProductNameNavigation)
                .Include(item => item.AddtionalInfoNavigation)
                .ToListAsync();

    }
}
