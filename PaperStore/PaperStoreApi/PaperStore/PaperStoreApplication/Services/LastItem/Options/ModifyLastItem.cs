using Autofac;
using PaperStoreApplication.Services.ActualInventory.Update;
using PaperStoreApplication.Services.LastItem.Create.CreateOptions;
using PaperStoreApplication.Services.OptionsForServices;
using PaperStoreModel.Models;
namespace PaperStoreApplication.Services.LastItem.Options;

internal class ModifyLastItem(Container _container) : IModifyLastItem
{
    IContainer _conn { get; init; } = _container.RegistrationContainer(new ContainerBuilder()) ?? throw new ArgumentNullException(nameof(_container));
    public async Task<bool> ItemByModel(ModifyItemModel model, bool ModeChoose)
        => await
        _conn.Resolve<IUpdateItem>().UpdateItemByName(
        _conn.Resolve<IGetProduct>().LastId().Result,
        model,
        ModeChoose);
}

