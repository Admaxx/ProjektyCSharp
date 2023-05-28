using PaperStore.WareHouseData;

namespace PaperStore.Services.CurrentWarehouse.Create
{
    public interface IChooseDetails
    {
        Task<List<StockItem>> ChooseStockItem(CompaniesList model);
        Task<List<StockAdditionalInfo>> ChooseAdditionalInfo();
    }
}
