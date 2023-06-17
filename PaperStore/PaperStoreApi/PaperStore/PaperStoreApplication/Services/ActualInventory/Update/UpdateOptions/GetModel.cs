using Microsoft.EntityFrameworkCore;
using PaperStoreApplication.Contexts;
using PaperStoreModel.Models;

namespace PaperStoreApplication.Services.ActualInventory.Update.UpdateOptions;

public class GetModel(PaperWarehouseContext conn) : IGetModel
{
    PaperWarehouseContext _context { get; init; } = conn ?? throw new ArgumentNullException(nameof(conn));

    public async Task<CurrentStock> ModelById(long Id)
        => await
        _context.CurrentStocks.AsNoTracking()
        .FirstAsync(item => item.Id == Id && item.Archive == false);
}