using PaperStoreApplication.Contexts;
using Microsoft.EntityFrameworkCore;

namespace PaperStoreApplication.Services.ActualInventory.Options
{
    internal class GetCompanyId(PaperWarehouseContext conn) : IGetCompanyId
    {
        PaperWarehouseContext _context { get; init; } = conn ?? throw new ArgumentNullException(nameof(conn));
        public async Task<long?> ByName(string CompanyName)
        =>
        await _context.CompaniesLists
        .AsNoTracking()
        .Where(item => item.CompanyName.ToLower() == CompanyName.ToLower())
        .Select(item => item.Id)
        .FirstOrDefaultAsync();
    }
}
