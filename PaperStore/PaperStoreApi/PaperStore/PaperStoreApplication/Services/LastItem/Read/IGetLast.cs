using PaperStoreModel.Models;

namespace PaperStoreApplication.Services.LastItem.Read
{
    public interface IGetLast
    {
        CurrentStock LastItem();
    }
}