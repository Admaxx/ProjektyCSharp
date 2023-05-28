using Autofac;
using Microsoft.EntityFrameworkCore;
using PaperStore.PaperStoreModel;
using PaperStore.Services.ActualInventory.CreateOptions;
using PaperStore.Services.OptionsForServices;
using System.Diagnostics;

namespace PaperStore.Services.ActualInventory.Create
{
    public class CreateItem : ICreateItem
    {
        readonly PaperWarehouseContext _context;
        readonly IContainer _conn;
        public CreateItem(PaperWarehouseContext conn, Container _container)
        {
            this._context = conn ?? throw new ArgumentNullException(nameof(conn));
            this._conn = _container.RegistrationContainer(new ContainerBuilder()) ?? throw new ArgumentNullException(nameof(conn));

        }
        public async Task<bool> CreateItemByName(ModifyItemModel model)
        {
            try
            {
                await _context.AddAsync(new CurrentStock()
                {
                    ProductName = _conn.Resolve<IGetProduct>().ByNameAndCompany(model.ProductName, model.CompanyName).Result,
                    Qty = model.Qty,
                    AddtionalInfoId = _conn.Resolve<IGetAdditionalInfo>().ByName(model.AdditionalDetail ?? string.Empty).Result
                });
                return await _context.SaveChangesAsync() > 0;
            }
            catch (Exception) { }
            return false;

        }
    }
}
