using Autofac;
using PaperStoreApplication.Services.LastItem.Create.CreateOptions;
using PaperStoreApplication.Services.LastItem.Update;
using PaperStoreApplication.Services.OptionsForServices;
using PaperStoreModel.Models;
using System.Diagnostics;

namespace PaperStoreApplication.Services.LastItem.Create;

public class CreateItem(Container _container) : ICreateItem
{
    IContainer _conn { get; init; } = _container.RegistrationContainer(new ContainerBuilder()) ?? throw new ArgumentNullException(nameof(_container));
    public async Task<bool> CreateItemByName(ModifyItemModel model)
       =>  await
       _conn.Resolve<IUpdateItem>().UpdateItemByName(
       _conn.Resolve<IGetProduct>().LastId().Result,
       model,
       false);
    
}