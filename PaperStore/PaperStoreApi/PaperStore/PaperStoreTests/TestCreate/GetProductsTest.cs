using PaperStore.Services.ActualInventory.CreateOptions;

namespace PaperStoreTests.TestCreate
{
    [TestClass]
    public class GetProductsTest
    {
        GetProductId get = new GetProductId(new PaperStore.PaperStoreModel.PaperWarehouseContext());
        string RandomName = "NullName";
        string RandomCompany = "NullCompany";

        [TestMethod]
        public void shouldReturnZeroBecouseOfFakeCompanyAndName()
        {
            Assert.AreEqual(get.ByNameAndCompany(RandomName, RandomCompany).Result, 0);
        }
    }
}