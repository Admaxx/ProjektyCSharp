using Autofac;
using PaperStoreApplication.Contexts;
using PaperStoreApplication.Services.OptionsForServices;

namespace PaperStoreApplication.Services.ActualInventory.Options;

public class ShareRegistration : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<GetAdditionalInfo>().As<IGetAdditionalInfo>().WithParameter("conn", new PaperWarehouseContext());
        builder.RegisterType<GetCurrentItemId>().As<IGetCurrentItemId>().WithParameter("conn", new PaperWarehouseContext());

        builder.RegisterType<CreateOrUpdate>().As<ICreateOrUpdate>().WithParameter("_container", new Container());
    }
}
