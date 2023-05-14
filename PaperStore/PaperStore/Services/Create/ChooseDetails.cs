using Microsoft.EntityFrameworkCore;
using PaperStore.WareHouseData;

namespace PaperStore.Services.Create
{
    public class ChooseDetails : IChooseDetails
    {
        PaperWarehouseContext context;
        public ChooseDetails(PaperWarehouseContext _context)
            =>
            context = _context;
        public async Task<List<StockItem>> ChooseStockItem(CompaniesList model)
            => await
            context.StockItems.Where(item => item.CompanyId == model.Id)
                .ToListAsync();

        

        public async Task<List<StockAdditionalInfo>> ChooseAdditionalInfo()
            => await
            context.StockAdditionalInfos
                .ToListAsync();

    }
}
