using Microsoft.EntityFrameworkCore;
using PaperStoreApplication.Contexts;
using PaperStoreModel.Models;

namespace PaperStoreApplication.Services.ActualInventory.UpdateOptions;

public class GetModel(PaperWarehouseContext conn) : IGetModel
{
    PaperWarehouseContext _context { get; init; } = conn ?? throw new ArgumentNullException(nameof(conn));

    public async Task<CurrentStock> ModelById(long Id)
        => await
        _context.CurrentStocks.Where(item => item.Id == Id)
        .AsNoTracking()
        .FirstAsync();
}