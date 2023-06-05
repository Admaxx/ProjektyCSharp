using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PaperStoreModel.Models;
using PaperStoreApplication.Contexts;

namespace PaperStoreApplication.Services.OptionsForServices;

public class ReadAllItems(PaperWarehouseContext conn) : IReadAllItems
{
    PaperWarehouseContext _context { get; init; } = conn ?? throw new ArgumentNullException(nameof(conn));

    public async Task<List<CurrentStock>> GetAllItems(bool? IsArchive)
        => await
             _context.CurrentStocks.AsNoTracking()
            .Include(item => item.AddtionalInfoNavigation)
            .Include(item => item.ProductNameNavigation)
            .Where(item => item.Archive == IsArchive).ToListAsync();

    
}