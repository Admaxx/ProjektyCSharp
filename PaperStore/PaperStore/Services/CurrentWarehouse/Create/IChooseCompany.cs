using PaperStore.WareHouseData;

namespace PaperStore.Services.CurrentWarehouse.Create
{
    public interface IChooseCompany
    {
        Task<List<CompaniesList>> Company();


    }
}
