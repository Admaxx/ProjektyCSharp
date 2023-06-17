using Microsoft.EntityFrameworkCore;
using PaperStoreApplication.Contexts;

namespace PaperStoreApplication.Services.LastItem.Create.CreateOptions;

public class GetProductId(PaperWarehouseContext conn) : IGetProduct
{
    PaperWarehouseContext _context { get; init; } = conn ?? throw new ArgumentNullException(nameof(conn));

    public async Task<long> LastId()
            => await
            _context.CurrentStocks
            .AsNoTracking().OrderBy(item => item.Id)
            .Select(item => item.Id)
            .LastOrDefaultAsync();
}