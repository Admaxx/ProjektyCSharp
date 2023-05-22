using PaperStore.WareHouseData;

namespace PaperStore.Services.CurrentWarehouse.Create
{
    public interface ICreateItem
    {
        Task<string> Item(CurrentStock model);


    }
}
