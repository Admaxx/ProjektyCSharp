using Autofac;
using PaperStoreApplication.Services.ActualInventory.Create;
using PaperStoreApplication.Services.ActualInventory.Update;
using PaperStoreApplication.Services.OptionsForServices;
using PaperStoreModel.Models;

namespace PaperStoreApplication.Services.ActualInventory.Options
{
    public class CreateOrUpdate(Container _container) : ICreateOrUpdate
    {
        IContainer _conn { get; init; } = _container.RegistrationContainer(new ContainerBuilder()) ?? throw new ArgumentNullException(nameof(_container));
        public bool ChooseItem(ModifyItemModel model)
        {
            var CurrentItemId = _conn.Resolve<IGetCurrentItemId>().ByAll(model).Result;

            return CurrentItemId == 0 ? 
                _conn.Resolve<ICreateItem>().CreateItemByName(model).Result : //Create new item
                _conn.Resolve<IUpdateItem>().UpdateItemByName(CurrentItemId, model).Result; //Update old item
        }
    }
}