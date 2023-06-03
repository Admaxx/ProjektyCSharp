using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PaperStoreModel.Models;
using PaperStoreApplication.Contexts;
using PaperStoreApplication.Services.OptionsForServices;

namespace PaperStoreApplication.Services.OptionsForServices;

public class ReadAllItems : IReadAllItems
{
    readonly PaperWarehouseContext context;
    public ReadAllItems(PaperWarehouseContext _context)
        =>
        context = _context ?? throw new ArgumentNullException(nameof(_context));

    [HttpGet]
    public async Task<List<CurrentStock>> GetAllItems(bool? IsArchive)
    {

        return await
             context.CurrentStocks.AsNoTracking()
            .Include(item => item.AddtionalInfoNavigation)
            .Include(item => item.ProductNameNavigation)
            .Where(item => item.Archive == IsArchive).ToListAsync();

    }
}