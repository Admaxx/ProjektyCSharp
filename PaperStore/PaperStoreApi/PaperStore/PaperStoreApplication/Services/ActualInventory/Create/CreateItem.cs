using Autofac;
using PaperStoreApplication.Contexts;
using PaperStoreApplication.Services.ActualInventory.Create.CreateOptions;
using PaperStoreApplication.Services.ActualInventory.Options;
using PaperStoreApplication.Services.OptionsForServices;
using PaperStoreModel.Models;

namespace PaperStoreApplication.Services.ActualInventory.Create;

public class CreateItem(PaperWarehouseContext conn, Container _container) : ICreateItem
{
    PaperWarehouseContext _context { get; init; } = conn ?? throw new ArgumentNullException(nameof(conn));
    IContainer _conn { get; init; } = _container.RegistrationContainer(new ContainerBuilder()) ?? throw new ArgumentNullException(nameof(_container));
    
    public async Task<bool> CreateItemByName(ModifyItemModel model)
    {
        try
        {
            await _context.AddAsync(new CurrentStock()
            {
                ProductName = _conn.Resolve<IGetProduct>().ByNameAndCompany(model.ProductName, model.CompanyName).Result,
                Qty = (int)model.Qty,
                AddtionalInfoId = _conn.Resolve<IGetAdditionalInfo>().ByName(model.AdditionalDetail ?? string.Empty).Result
            });
            return await _context.SaveChangesAsync() > 0;
        }
        catch (Exception) { return false; }
    }
}