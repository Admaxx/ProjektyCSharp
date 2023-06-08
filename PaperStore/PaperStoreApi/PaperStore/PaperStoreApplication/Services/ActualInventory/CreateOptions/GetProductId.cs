using Microsoft.EntityFrameworkCore;
using PaperStoreApplication.Contexts;

namespace PaperStoreApplication.Services.ActualInventory.CreateOptions;

public class GetProductId(PaperWarehouseContext conn) : IGetProduct
{
    PaperWarehouseContext _context { get; init; } = conn ?? throw new ArgumentNullException(nameof(conn));

    public async Task<long> ByNameAndCompany(string ProductName, string CompanyName)
            => await
            _context.CurrentStocks
            .AsNoTracking()
            .Include(item => item.ProductNameNavigation)
            .ThenInclude(item => item.Company)
            .Where(item => item.ProductNameNavigation.ItemName.ToLower() == ProductName.ToLower() &&
            item.ProductNameNavigation.Company.CompanyName.ToLower() == CompanyName.ToLower())
            .Select(item => item.ProductNameNavigation.Id)
            .FirstOrDefaultAsync();

}

