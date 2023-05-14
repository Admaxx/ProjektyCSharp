using Microsoft.EntityFrameworkCore;
using PaperStore.WareHouseData;

namespace PaperStore.Services.Details
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
                .Include(item => item.ProductNameNavigation).ThenInclude(item => item.Company)
                .Include(item => item.AddtionalInfoNavigation)
                .FirstAsync();
        
    }
}
