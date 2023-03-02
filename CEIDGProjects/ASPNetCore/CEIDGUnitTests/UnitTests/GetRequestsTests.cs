using CEIDGREGON;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CEIDGUnitTests.UnitTests
{
    [TestClass]
    public  class GetRequestsTests : ProgramGeneralData
    {
        GetRequests requests;
        public GetRequestsTests() 
        {
            requests = new GetRequests();
        
        }
        [TestMethod]
        public void ReturnNonEmptySessionId()
        {
            Assert.AreNotEqual(requests.Login(GusToken), string.Empty);
        }

        [TestMethod]
        public void ReturnNonEmptyValueForNIP()
        {
            Assert.AreNotEqual(requests.GetValuesForDanePodmiotu(new ServiceReference1.ParametryWyszukiwania() {Regon = "8942867482" }), string.Empty);
        }
    }
}
