using Autofac;
using PaperStoreApplication.Services.ActualInventory.Create;
using PaperStoreApplication.Contexts;
using PaperStoreApplication.Services.OptionsForServices;
using PaperStoreApplication.Services.ActualInventory.Options;

namespace PaperStoreApplication.Services.ActualInventory.Create.CreateOptions;

public class CreateRegistration : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<GetProductId>().As<IGetProduct>().WithParameter("conn", new PaperWarehouseContext());

        builder.RegisterType<CreateItem>().As<ICreateItem>().WithParameter("conn", new PaperWarehouseContext()).WithParameter("_container", new Container());
    }
}
