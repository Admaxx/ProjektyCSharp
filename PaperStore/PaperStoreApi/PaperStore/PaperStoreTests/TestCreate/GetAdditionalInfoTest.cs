using PaperStoreApplication.Services.ActualInventory.Options;

namespace PaperStoreTests.TestCreate;

[TestClass]
public class GetAdditionalInfoTest
{
    IGetAdditionalInfo get = new GetAdditionalInfo(new PaperStoreApplication.Contexts.PaperWarehouseContext());
    string RandomDetailName = "NullName";

    [TestMethod]
    public void shouldReturnZeroBecouseOfFakeDetailName()
    {
        Assert.AreEqual(get.ByName(RandomDetailName).Result, null);
    }
}