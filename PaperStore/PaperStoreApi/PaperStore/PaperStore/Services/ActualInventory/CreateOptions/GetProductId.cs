namespace PaperStore.Services.ActualInventory.CreateOptions;

public class GetProductId : IGetProduct
{
    PaperWarehouseContext _context;
    public GetProductId(PaperWarehouseContext conn)
    {
        _context = conn ?? throw new ArgumentNullException(nameof(conn));
    }

    public async Task<long> ByNameAndCompany(string ProductName, string CompanyName)
    {
        try
        {
            return await
                _context.CurrentStocks
                .AsNoTracking()
                .Include(item => item.ProductNameNavigation)
                .ThenInclude(item => item.Company)
                .Where(item => item.ProductNameNavigation.ItemName.ToLower() == ProductName.ToLower() &&
                item.ProductNameNavigation.Company.CompanyName.ToLower() == CompanyName.ToLower())
                .Select(item => item.ProductNameNavigation.Id)
                .FirstAsync();
        }
        catch (Exception) { }
        return 0;
    }
}

