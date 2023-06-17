using Microsoft.EntityFrameworkCore;
using PaperStoreApplication.Contexts;

namespace PaperStoreApplication.Services.ActualInventory.Create.CreateOptions;

public class GetProductId(PaperWarehouseContext conn) : IGetProduct
{
    PaperWarehouseContext _context { get; init; } = conn ?? throw new ArgumentNullException(nameof(conn));

    public async Task<long> ByNameAndCompany(string ProductName, string CompanyName)
            => await
            _context.StockItems
            .AsNoTracking()
            .Include(item => item.Company)
            .Where(item => item.ItemName.ToLower() == ProductName.ToLower() &&
            item.Company.CompanyName.ToLower() == CompanyName.ToLower())
            .Select(item => item.Id)
            .FirstOrDefaultAsync();
}

