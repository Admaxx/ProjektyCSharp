using PaperStore.Services.ActualInventory.Update;
using PaperStore.Services.OptionsForServices;

namespace PaperStore.Services.ActualInventory.UpdateOptions;

public class DeleteRegistration : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<GetModel>().As<IGetModel>().WithParameter("conn", new PaperWarehouseContext()).WithParameter("_container", new Container());
        builder.RegisterType<UpdateItem>().As<IUpdateItem>().WithParameter("conn", new PaperWarehouseContext()).WithParameter("_container", new Container());
    }
}