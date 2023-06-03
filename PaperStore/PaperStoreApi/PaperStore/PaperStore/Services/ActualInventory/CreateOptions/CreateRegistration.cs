using Autofac;
using PaperStore.PaperStoreModel;
using PaperStore.Services.ActualInventory.Create;
using PaperStore.Services.OptionsForServices;

namespace PaperStore.Services.ActualInventory.CreateOptions;

public class CreateRegistration : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<GetProductId>().As<IGetProduct>().WithParameter("conn", new PaperWarehouseContext());

        builder.RegisterType<CreateItem>().As<ICreateItem>().WithParameter("conn", new PaperWarehouseContext()).WithParameter("_container", new Container());
    }
}
