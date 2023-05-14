using PaperStore.WareHouseData;

namespace PaperStore.Services.Create
{
    public interface IChooseDetails
    {
        Task<List<StockItem>> ChooseStockItem(CompaniesList model);
        Task<List<StockAdditionalInfo>> ChooseAdditionalInfo();
    }
}
