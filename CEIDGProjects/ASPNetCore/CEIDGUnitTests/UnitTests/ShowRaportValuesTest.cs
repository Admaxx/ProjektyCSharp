using Autofac;
using CEIDGASPNetCore.Services.CEIDG;
using CEIDGASPNetCore.Services.CEIDG.Interfaces;
using CEIDGASPNetCore.Services.CEIDG.Interfaces.Abstract;
using CEIDGREGON;
using Newtonsoft.Json;

namespace CEIDGUnitTests.UnitTests
{
    [TestClass]
    public class ShowRaportValuesTest
    {
        ContrainerResolve resolve = new ContrainerResolve();
        byte ActionNameTest;
        [TestMethod]
        public void ReturnEmptyForNonExistActionName()
        {
            ActionNameTest = 4;
            var LastInsertCon = resolve.ContainerResolve(new ContainerBuilder()).Resolve<IValuesInsert>();

            Assert.AreEqual(LastInsertCon.LastInsertValues(ActionNameTest, new List<string>() { "0", "0", "0" }, null).Xmlvalues, string.Empty);
        }
        [TestMethod]
        public void ReturnNonEmptyKRSValues()
        {
            ActionNameTest = 0;
            var LastInsertCon = resolve.ContainerResolve(new ContainerBuilder()).Resolve<IValuesInsert>();
            string KRSTestNumber = "0000260284";

            Assert.AreNotEqual(LastInsertCon.LastInsertValues(ActionNameTest, new List<string>() { "0", "0", KRSTestNumber }, null).Xmlvalues, string.Empty);
        }
    }
}