using Autofac;
using PaperStore.PaperStoreModel;

namespace PaperStore.Services.OptionsForServices
{
    public class Registration : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ReadAllItems>().As<IReadAllItems>().WithParameter("_context", new PaperWarehouseContext());
            builder.RegisterType<PaperWarehouseContext>().AsSelf();
        }
    }
}
