using PaperStoreModel.Models;

namespace PaperStoreApplication.Services.OptionsForServices;

public interface IReadAllItems
{
    IAsyncEnumerable<CurrentStock> GetAllItems(bool? IsArchive);
}