using PaperStore.WareHouseData;

namespace PaperStore.Services.Create
{
    public interface IChooseCompany
    {
        Task<List<CompaniesList>> Company();


    }
}
