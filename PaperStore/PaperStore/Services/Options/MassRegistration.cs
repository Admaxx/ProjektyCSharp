using Autofac;
using PaperStore.Services.Create;
using PaperStore.Services.Delete;
using PaperStore.Services.Details;
using PaperStore.Services.Read;
using PaperStore.Services.Update.Single;
using PaperStore.WareHouseData;

namespace PaperStore.Services.Options
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


        }


    }
}
