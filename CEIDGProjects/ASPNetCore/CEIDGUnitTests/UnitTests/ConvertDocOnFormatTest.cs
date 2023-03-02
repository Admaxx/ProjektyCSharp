using CEIDGASPNetCore.Services.CEIDG;
using System.Xml;

namespace CEIDGUnitTests
{
    [TestClass]
    public class ConvertDocOnFormatTest
    {
        ConvertDocOnFormat docFormat;

        [TestMethod]
        public void ReturnEmptyStringMessage()
        {
            docFormat = new ConvertDocOnFormat(true);
            string NoDateAnswer = "Brak danych";

            Assert.AreEqual(docFormat.ChooseFormat(string.Empty), NoDateAnswer);
        }

        [TestMethod]
        public void ReturnJsonReaderException()
        {
            docFormat = new ConvertDocOnFormat(false);
            string randomNonXMLString = "Empty string";

            Assert.ThrowsException<XmlException>(() => docFormat.ToJSON(randomNonXMLString));
        }
    }
}
