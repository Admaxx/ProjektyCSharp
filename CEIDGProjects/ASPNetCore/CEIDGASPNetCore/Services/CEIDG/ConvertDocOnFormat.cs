using Newtonsoft.Json;
using System.Xml;

namespace CEIDGASPNetCore.Services.CEIDG
{
    public class ConvertDocOnFormat
    {
        XmlDocument doc;
        bool JSONFormat;
        public ConvertDocOnFormat(bool SetJSONFormat)
        {
            JSONFormat = SetJSONFormat;
            doc = new XmlDocument();
        }
        public string ChooseFormat(string Values)
        {
            if (string.IsNullOrEmpty(Values))
                return "Brak danych";

            if (JSONFormat)
                return ToJSON(Values);

            return ToXML(Values);
        }
        public string ToJSON(string Values)
        {
            try
            {
                doc.LoadXml(Values);
                return JsonConvert.SerializeXmlNode(doc);
            }catch(JsonReaderException ex) { }
            return Values;
        }
        public string ToXML(string Values)
        {
            try
            {
                return JsonConvert.DeserializeXmlNode(Values).ToString();
            }catch(JsonReaderException ex) { }
            return Values;
        }


    }
}
