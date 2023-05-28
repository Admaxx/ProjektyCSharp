using Microsoft.EntityFrameworkCore;
using PaperStore.WareHouseData;

namespace PaperStore.Services.CurrentWarehouse.Details
{
    public class GetDetails : IGetDetails
    {
        PaperWarehouseContext context;
        public GetDetails(PaperWarehouseContext _context)
            =>
            context = _context;
        public async Task<CurrentStock> Item(long Id)
            => await
            context.CurrentStocks.Where(item => item.Id == Id)
                .AsNoTracking()
                .Include(item => item.ProductNameNavigation).ThenInclude(item => item.Company)
                .Include(item => item.AddtionalInfoNavigation)
                .FirstAsync();

    }
}
