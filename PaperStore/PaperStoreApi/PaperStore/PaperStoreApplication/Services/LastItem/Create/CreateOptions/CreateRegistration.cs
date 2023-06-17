using Autofac;
using PaperStoreApplication.Contexts;
using PaperStoreApplication.Services.OptionsForServices;

namespace PaperStoreApplication.Services.LastItem.Create.CreateOptions;

public class CreateRegistration : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<GetProductId>().As<IGetProduct>().WithParameter("conn", new PaperWarehouseContext());

        builder.RegisterType<CreateItem>().As<ICreateItem>().WithParameter("_container", new Container());
    }
}
