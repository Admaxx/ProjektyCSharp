using PaperStoreApplication.Contexts;
using PaperStoreApplication.Services.ActualInventory.CreateOptions;

namespace PaperStoreTests.TestCreate.UnitTests;

[TestClass]
public class GetProductsTest
{
    IGetProduct get = new GetProductId(new PaperWarehouseContext());
    string RandomName = "NullName";
    string RandomCompany = "NullCompany";

    [TestMethod]
    public void shouldReturnZeroBecouseOfFakeCompanyAndName()
    {
        Assert.AreEqual(get.ByNameAndCompany(RandomName, RandomCompany).Result, 0);
    }
}
