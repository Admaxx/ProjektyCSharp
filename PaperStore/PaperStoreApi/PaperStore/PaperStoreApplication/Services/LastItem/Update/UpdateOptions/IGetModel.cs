using PaperStoreModel.Models;
namespace PaperStoreApplication.Services.LastItem.Update.UpdateOptions;

public interface IGetModel
{
    Task<CurrentStock> ModelById(long Id);
}
