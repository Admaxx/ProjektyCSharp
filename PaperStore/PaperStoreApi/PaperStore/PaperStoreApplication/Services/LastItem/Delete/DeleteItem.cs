using Autofac;
using PaperStoreApplication.Services.LastItem.Create.CreateOptions;
using PaperStoreApplication.Services.OptionsForServices;
namespace PaperStoreApplication.Services.LastItem.Delete;

public class DeleteItem(Container _container) : IDeleteItem
{
    IContainer _conn { get; init; } = _container.RegistrationContainer(new ContainerBuilder()) ?? throw new ArgumentNullException(nameof(_container));

    public async Task<bool> RemoveLastElement(bool IsArchive)
    {
        return await _conn.Resolve<ActualInventory.Delete.IDeleteItem>().ItemById(
            _conn.Resolve<IGetProduct>().LastId().Result, 
            IsArchive);
    }
}