using Microsoft.EntityFrameworkCore;
using PaperStore.WareHouseData;

namespace PaperStore.Services.Update
{
    public class ChooseUpdateItemContext : IChooseUpdateItemContext
    {
        PaperWarehouseContext context;

        public ChooseUpdateItemContext(PaperWarehouseContext _context)
            =>
            context = _context;
        public async Task<List<StockAdditionalInfo>> ChooseUpdateItems()
            =>
            await context.StockAdditionalInfos
                .ToListAsync();
    }
}
