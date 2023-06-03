using Autofac;
using PaperStoreApplication.Contexts;

namespace PaperStoreApplication.Services.ActualInventory.Options;

public class ShareRegistration : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<GetAdditionalInfo>().As<IGetAdditionalInfo>().WithParameter("conn", new PaperWarehouseContext());
    }
}
