using Autofac;
using PaperStoreApplication.Contexts;
using PaperStoreApplication.Services.ActualInventory.Update;
using PaperStoreApplication.Services.OptionsForServices;

namespace PaperStoreApplication.Services.LastItem.Update.UpdateOptions;

public class UpdateRegistration : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<GetModel>().As<IGetModel>().WithParameter("conn", new PaperWarehouseContext()).WithParameter("_container", new Container());
        builder.RegisterType<UpdateItem>().As<IUpdateItem>().WithParameter("conn", new PaperWarehouseContext()).WithParameter("_container", new Container());
    }
}