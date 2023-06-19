using Microsoft.EntityFrameworkCore;
using PaperStoreModel.Models;
using PaperStoreApplication.Contexts;

namespace PaperStoreApplication.Services.OptionsForServices;
public class ReadAllItems(PaperWarehouseContext conn) : IReadAllItems
{
    PaperWarehouseContext _context { get; init; } = conn ?? throw new ArgumentNullException(nameof(conn));

    public IQueryable<CurrentStock> GetAllItems(bool? IsArchive)
        =>
        _context.CurrentStocks.AsNoTracking()
        .Include(item => item.AddtionalInfoNavigation)
        .Include(item => item.ProductNameNavigation)
        .ThenInclude(item => item.Company)
        .Where(item => item.Archive == IsArchive)
        .AsQueryable();
}