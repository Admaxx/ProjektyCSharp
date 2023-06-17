using PaperStoreModel.Models;
namespace PaperStoreApplication.Services.ActualInventory.Update.UpdateOptions;

public interface IGetModel
{
    Task<CurrentStock> ModelById(long Id);
}
