using Autofac;
using PaperStoreApplication.Services.OptionsForServices;
namespace PaperStoreApplication.Services.LastItem.Options;

internal class LastItemOptionsRegistration : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<ModifyLastItem>().As<IModifyLastItem>().WithParameter("_container", new Container());
    }
}

