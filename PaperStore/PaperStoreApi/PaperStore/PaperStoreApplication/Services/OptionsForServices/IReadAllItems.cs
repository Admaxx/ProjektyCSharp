using PaperStoreModel.Models;

namespace PaperStoreApplication.Services.OptionsForServices;

public interface IReadAllItems
{
    Task<List<CurrentStock>> GetAllItems(bool? IsArchive);
}