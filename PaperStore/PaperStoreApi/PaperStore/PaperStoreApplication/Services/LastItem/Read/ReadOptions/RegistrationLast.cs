using Autofac;
using PaperStoreApplication.Services.OptionsForServices;

namespace PaperStoreApplication.Services.LastItem.Read.ReadOptions
{
    internal class RegistrationLast : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<GetLast>().As<IGetLast>().WithParameter("_container", new Container());//Container _container
        }


    }
}
