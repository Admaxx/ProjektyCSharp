using Microsoft.EntityFrameworkCore;
using PaperStoreApplication.Contexts;

namespace PaperStoreApplication.Services.ActualInventory.Options
{
    internal class GetProductId(PaperWarehouseContext conn) : IGetProductId
    {
        PaperWarehouseContext _context { get; init; } = conn ?? throw new ArgumentNullException(nameof(conn));
        public async Task<long?> ByName(string ProductName, string CompanyName)
            => await
            _context.StockItems
            .AsNoTracking()
            .Where(
                item => item.ItemName.ToLower() == (ProductName ?? item.ItemName).ToLower() &&
            item.Company.CompanyName.ToLower() == (CompanyName ?? item.Company.CompanyName).ToLower())
            .Select(item => item.Id)
            .FirstOrDefaultAsync();
        
    }
}
