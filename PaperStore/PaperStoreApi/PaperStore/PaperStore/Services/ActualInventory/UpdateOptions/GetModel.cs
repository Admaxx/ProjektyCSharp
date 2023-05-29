using Autofac;
using Microsoft.EntityFrameworkCore;
using PaperStore.PaperStoreModel;

namespace PaperStore.Services.ActualInventory.UpdateOptions
{
    public class GetModel : IGetModel
    {
        readonly PaperWarehouseContext _context;
        public GetModel(PaperWarehouseContext conn)
            =>
           this._context = conn ?? throw new ArgumentNullException(nameof(conn));

        public async Task<CurrentStock> ModelById(long Id)
            => await
            _context.CurrentStocks.Where(item => item.Id == Id).AsNoTracking().FirstAsync();
    }
}
