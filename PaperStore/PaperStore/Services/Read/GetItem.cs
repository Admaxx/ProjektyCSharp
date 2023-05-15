using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using PaperStore.WareHouseData;

namespace PaperStore.Services.Read
{
    public class GetItem : IGetItem
    {
        PaperWarehouseContext context;
        public GetItem(PaperWarehouseContext _context)
            =>
            context = _context;
        public async Task<List<CurrentStock>> Item(string Name)
           => await
           context.CurrentStocks.Where(item => item.Archive == false)
                .Include(item => item.ProductNameNavigation).Where(item => item.ProductNameNavigation.ItemName.Contains(Name ?? item.ProductNameNavigation.ItemName)) //TODO: refactor
                .Include(item => item.AddtionalInfoNavigation)
                .ToListAsync();
    }
}
