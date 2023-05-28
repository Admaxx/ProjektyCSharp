using Autofac;
using PaperStore.Controllers;
using PaperStore.Services.CurrentWarehouse.Create;
using PaperStore.Services.CurrentWarehouse.Delete;
using PaperStore.Services.CurrentWarehouse.Details;
using PaperStore.Services.CurrentWarehouse.Read;
using PaperStore.Services.CurrentWarehouse.Update.Single;
using PaperStore.Services.Options;
using PaperStore.WareHouseData;

namespace PaperStore.Services.CurrentWarehouse
{
    public class MassRegistration : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<GetItem>().As<IGetItem>().WithParameter("_context", new PaperWarehouseContext());
            builder.RegisterType<GetUpdateItem>().As<IGetUpdatedItem>().WithParameter("_context", new PaperWarehouseContext());
            builder.RegisterType<UpdateItem>().As<IUpdateItem>().WithParameter("_context", new PaperWarehouseContext());

            builder.RegisterType<CreateItem>().As<ICreateItem>().WithParameter("_context", new PaperWarehouseContext());
            builder.RegisterType<RemoveItem>().As<IRemoveItem>().WithParameter("_context", new PaperWarehouseContext());
            builder.RegisterType<GetDetails>().As<IGetDetails>().WithParameter("_context", new PaperWarehouseContext());

            builder.RegisterType<ChooseCompany>().As<IChooseCompany>().WithParameter("_context", new PaperWarehouseContext());
            builder.RegisterType<ChooseDetails>().As<IChooseDetails>().WithParameter("_context", new PaperWarehouseContext());
            builder.RegisterType<Logger>().As<ILogging>();


        }


    }
}
