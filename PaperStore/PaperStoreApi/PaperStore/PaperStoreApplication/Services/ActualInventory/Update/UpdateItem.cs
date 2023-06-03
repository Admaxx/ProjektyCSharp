using Autofac;
using Microsoft.EntityFrameworkCore;
using PaperStoreApplication.Contexts;
using PaperStoreApplication.Services.ActualInventory.Options;
using PaperStoreApplication.Services.ActualInventory.UpdateOptions;
using PaperStoreApplication.Services.OptionsForServices;

namespace PaperStoreApplication.Services.ActualInventory.Update;

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
        try
        {
            var updateModel = _conn.Resolve<IGetModel>().ModelById(Id).Result;

            return await _context.CurrentStocks.Where(item => item.Id == Id)
                .ExecuteUpdateAsync
                (
                    item => item
                    .SetProperty(item => item.Qty, item => Qty ?? updateModel.Qty)
                    .SetProperty(item => item.UpdateData, item => DateTime.Now)
                    .SetProperty(item => item.AddtionalInfoId,
                    item => _conn.Resolve<IGetAdditionalInfo>()
                    .ByName(AdditionalInfo ?? string.Empty).Result ?? updateModel.AddtionalInfoId)
                ) > 0;
        }
        catch (Exception) { return false; }
    }
}
