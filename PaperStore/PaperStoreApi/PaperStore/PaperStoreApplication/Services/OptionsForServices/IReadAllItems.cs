using PaperStoreModel.Models;

namespace PaperStoreApplication.Services.OptionsForServices;

public interface IReadAllItems
{
    IQueryable<CurrentStock> GetAllItems(bool? IsArchive);
}