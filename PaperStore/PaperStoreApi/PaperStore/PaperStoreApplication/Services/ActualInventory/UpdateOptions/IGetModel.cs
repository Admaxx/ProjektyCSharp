using PaperStoreModel.Models;
namespace PaperStoreApplication.Services.ActualInventory.UpdateOptions;

public interface IGetModel
{
    Task<CurrentStock> ModelById(long Id);
}
