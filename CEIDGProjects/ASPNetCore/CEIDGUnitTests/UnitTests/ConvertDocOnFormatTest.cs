using Autofac;
using CEIDGASPNetCore.Services.CEIDG;
using CEIDGASPNetCore.Services.CEIDG.Interfaces;
using System.Xml;

namespace CEIDGUnitTests
{
    [TestClass]
    public class ConvertDocOnFormatTest
    {
        ContrainerResolve resolve = new ContrainerResolve();
        string NoDateAnswer = "Brak danych";

        [TestMethod]
        public void ReturnEmptyStringMessage()
        {
            var docFormat = resolve.ContainerResolve(new ContainerBuilder()).Resolve<ConvertDocOnFormat>();  
            Assert.AreEqual(docFormat.ChooseFormat(string.Empty, true), NoDateAnswer);
        }

        [TestMethod]
        public void ReturnJsonReaderException()
        {
            var docFormat = resolve.ContainerResolve(new ContainerBuilder()).Resolve<IConvertToJson>();
            Assert.ThrowsException<XmlException>(() => docFormat.ToJSON(NoDateAnswer));
        }
    }
}
