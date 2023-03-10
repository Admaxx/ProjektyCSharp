using CEIDGASPNetCore.Services.CEIDG.Interfaces;
using Newtonsoft.Json;
using System.Xml;

namespace CEIDGASPNetCore.Services.CEIDG
{
    public class ConvertDocOnFormat : IConvertToXML, IConvertToJson
    {
        XmlDocument doc;
        public ConvertDocOnFormat()
        {
            doc = new XmlDocument();
        }
        public string ChooseFormat(string Values, bool SetJSONFormat)
        {
            if (string.IsNullOrEmpty(Values))
                return "Brak danych";

            if (SetJSONFormat)
                return ToJSON(Values);

            return ToXML(Values);
        }
        #region convert data to JSON format
        public string ToJSON(string Values)
        {
            try
            {
                doc.LoadXml(Values);
                return JsonConvert.SerializeXmlNode(doc);
            }catch(JsonReaderException ex) { }
            return Values;
        }
        #endregion

        #region convert data to XML format
        public string ToXML(string Values)
        {
            try
            {
                return JsonConvert.DeserializeXmlNode(Values).ToString();
            }catch(JsonReaderException ex) { }
            return Values;
        }
        #endregion


    }
}
