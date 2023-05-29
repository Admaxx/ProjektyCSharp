using PaperStore.Services.ActualInventory.CreateOptions;
using PaperStore.Services.ActualInventory.UpdateOptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaperStoreTests.TestUpdate
{
    [TestClass]
    public class GetUpdatingModelTest
    {
        IGetModel get = new GetModel(new PaperStore.PaperStoreModel.PaperWarehouseContext());

        int ModelQty = 0;

        [TestMethod]
        public void gettingQtyByNotExistingModelShouldThrowError()
        {
            Assert.ThrowsException<AggregateException>(() => get.ModelById(ModelQty).Result.Qty);
        }


    }
}
