using CEIDGASPNetCore.Services.CEIDG;
using CEIDGREGON;
using Newtonsoft.Json;

namespace CEIDGUnitTests.UnitTests
{
    [TestClass]
    public class ShowRaportValuesTest
    {
        ShowRaportValues show;
        public ShowRaportValuesTest()
        {
            show = new ShowRaportValues();
        }
        [TestMethod]
        public void ReturnEmptyForNonExistActionName()
        {
            int ActionNameTest = 3;


            Assert.AreEqual(show.GetValuesFromGUS(ActionNameTest, new List<string>() { string.Empty }, null), string.Empty);
        }
        [TestMethod]
        public void ReturnNonEmptyKRSValues()
        {
            int ActionNameTest = 0;
            string KRSTestNumber = "0000260284";


            Assert.AreNotEqual(show.GetValuesFromGUS(ActionNameTest, new List<string>() { "0", "0", KRSTestNumber }, null), string.Empty);

        }
    }
}