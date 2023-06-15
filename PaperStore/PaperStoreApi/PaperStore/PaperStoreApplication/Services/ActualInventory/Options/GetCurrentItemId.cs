using Microsoft.EntityFrameworkCore;
using PaperStoreApplication.Contexts;
using PaperStoreModel.Models;

namespace PaperStoreApplication.Services.ActualInventory.Options
{
    internal class GetCurrentItemId(PaperWarehouseContext conn) : IGetCurrentItemId
    {
        PaperWarehouseContext _context { get; init; } = conn ?? throw new ArgumentNullException(nameof(conn));


        public async Task<long> ByAll(ModifyItemModel model)
            => await
            _context.CurrentStocks
            .AsNoTracking()
            .Include(item => item.AddtionalInfoNavigation)
            .Include(item => item.ProductNameNavigation)
            .ThenInclude(item => item.Company)
            .Where(item => 
            item.ProductNameNavigation.ItemName.ToLower() == model.ProductName.ToLower() &&
            item.ProductNameNavigation.Company.CompanyName.ToLower() == model.CompanyName.ToLower() &&
            item.AddtionalInfoNavigation.AdditionalInfo == model.AdditionalDetail &&
            item.Archive == false)
            .Select(item => item.Id)
            .FirstOrDefaultAsync();

    }
}
