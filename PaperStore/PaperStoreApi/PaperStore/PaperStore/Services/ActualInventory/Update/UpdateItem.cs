using Autofac;
using Microsoft.EntityFrameworkCore;
using PaperStore.PaperStoreModel;
using PaperStore.Services.ActualInventory.CreateOptions;
using PaperStore.Services.ActualInventory.Options;
using PaperStore.Services.ActualInventory.UpdateOptions;
using PaperStore.Services.OptionsForServices;
using System.Diagnostics;

namespace PaperStore.Services.ActualInventory.Update
{
    public class UpdateItem : IUpdateItem
    {
        readonly PaperWarehouseContext _context;
        readonly IContainer _conn;
        public UpdateItem(PaperWarehouseContext conn, Container _container)
        {
            this._context = conn ?? throw new ArgumentNullException(nameof(conn));
            this._conn = _container.RegistrationContainer(new ContainerBuilder()) ?? throw new ArgumentNullException(nameof(conn));

        }
        public async Task<bool> UpdateItemByName(long Id, int? Qty, string AdditionalInfo)
        {
            var updateModel = _conn.Resolve<IGetModel>().ModelById(Id).Result;

            updateModel.Qty = Qty ?? updateModel.Qty;
            updateModel.AddtionalInfoId = _conn.Resolve<IGetAdditionalInfo>().ByName(AdditionalInfo ?? string.Empty).Result ?? updateModel.AddtionalInfoId;

            _context.Update(updateModel);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
