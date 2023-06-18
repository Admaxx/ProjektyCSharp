using Autofac;
using PaperStoreApplication.Services.LastItem.Options;
using PaperStoreApplication.Services.OptionsForServices;
using PaperStoreModel.Models;
namespace PaperStoreApplication.Services.LastItem.Create;

public class CreateItem(Container _container) : ICreateItem
{
    IContainer _conn { get; init; } = _container.RegistrationContainer(new ContainerBuilder()) ?? throw new ArgumentNullException(nameof(_container));

    public async Task<bool> AddQtyUpdateRemainingItems(ModifyItemModel model, bool ModeChoose)
        => await 
        _conn.Resolve<IModifyLastItem>().ItemByModel(model, ModeChoose);

}