using PaperStoreApplication.Services.ActualInventory.UpdateOptions;

namespace PaperStoreTests.TestUpdate
{
    [TestClass]
    public class GetUpdatingModelTest
    {
        IGetModel get = new GetModel(new PaperStoreApplication.Contexts.PaperWarehouseContext());

        int ModelQty = 0;

        [TestMethod]
        public void gettingQtyByNotExistingModelShouldThrowError()
        {
            Assert.ThrowsException<AggregateException>(() => get.ModelById(ModelQty).Result.Qty);
        }


    }
}
