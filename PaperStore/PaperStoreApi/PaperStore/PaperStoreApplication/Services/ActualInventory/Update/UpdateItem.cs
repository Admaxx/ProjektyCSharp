using Autofac;
using Microsoft.EntityFrameworkCore;
using PaperStoreApplication.Contexts;
using PaperStoreApplication.Services.ActualInventory.Options;
using PaperStoreApplication.Services.ActualInventory.UpdateOptions;
using PaperStoreApplication.Services.OptionsForServices;
using PaperStoreModel.Models;
using System.Diagnostics;

namespace PaperStoreApplication.Services.ActualInventory.Update;

public class UpdateItem(PaperWarehouseContext conn, Container _container) : IUpdateItem
{
    PaperWarehouseContext _context { get; init; } = conn ?? throw new ArgumentNullException(nameof(conn));
    IContainer _conn { get; init; } = _container.RegistrationContainer(new ContainerBuilder()) ?? throw new ArgumentNullException(nameof(_container));

    public async Task<bool> UpdateItemByName(long Id, ModifyItemModel model, bool AddQtyToExists)
    {
        try
        {
            var updateModel = _conn.Resolve<IGetModel>().ModelById(Id).Result;
            if(AddQtyToExists) //Refactor needed!
                updateModel.Qty = 0;

            return await _context.CurrentStocks.Where(item => item.Id == Id)
                .ExecuteUpdateAsync
                (
                    item => item
                    .SetProperty(item => item.Qty, item => updateModel.Qty + (model.Qty ?? item.Qty))
                    .SetProperty(item => item.UpdateData, item => DateTime.Now)
                    .SetProperty(item => item.AddtionalInfoId,
                    item => _conn.Resolve<IGetAdditionalInfo>()
                    .ByName(model.AdditionalDetail ?? string.Empty).Result ?? updateModel.AddtionalInfoId)

                    .SetProperty(item => item.ProductName, 
                    item => _conn.Resolve<IGetProductId>()
                    .ByName(model.ProductName, model.CompanyName).Result ?? updateModel.ProductName)
                ) > 0;
        }
        catch (Exception) { return false; }
    }
}