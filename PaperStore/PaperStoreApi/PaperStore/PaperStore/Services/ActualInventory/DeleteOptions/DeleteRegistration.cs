using Autofac;
using PaperStore.PaperStoreModel;
using PaperStore.Services.ActualInventory.Delete;
using PaperStore.Services.ActualInventory.Update;
using PaperStore.Services.OptionsForServices;

namespace PaperStore.Services.ActualInventory.DeleteOptions
{
    public class DeleteRegistration : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DeleteItem>().As<IDeleteItem>().WithParameter("conn", new PaperWarehouseContext()).WithParameter("_container", new Container());
        }
    }
}
