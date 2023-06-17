using PaperStoreApplication.Contexts;
using PaperStoreModel.Models;

namespace PaperStoreApplication.Services.LastItem.Create.CreateOptions;

public interface IGetProduct
{
    Task<long> LastId();
}
