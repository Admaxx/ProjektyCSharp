using PaperStore.Services.ActualInventory.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaperStoreTests.TestCreate
{
    [TestClass]
    public class GetAdditionalInfoTest
    {
        IGetAdditionalInfo get = new GetAdditionalInfo(new PaperStore.PaperStoreModel.PaperWarehouseContext());
        string RandomDetailName = "NullName";

        [TestMethod]
        public void shouldReturnZeroBecouseOfFakeDetailName()
        {
            Assert.AreEqual(get.ByName(RandomDetailName).Result, null);
        }
    }
}
