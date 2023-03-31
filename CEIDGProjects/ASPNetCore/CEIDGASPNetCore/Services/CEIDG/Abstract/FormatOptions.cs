using CEIDGASPNetCore.Services.CEIDG.Interfaces;
using Newtonsoft.Json;
using System.Xml;

namespace CEIDGASPNetCore.Services.CEIDG.Abstract
{
    public class FormatOptions : IConvertToJson, IConvertToXML
    {
        XmlDocument doc = new XmlDocument();
        



        //I haven't got an idea, to make a virtual method example
        // at this project, so i think it will be the best shot...
        // moved check if Values is null to override method
        public virtual string ChooseFormat(string Values, bool SetJSONFormat)
        { 
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
            }
            catch (JsonReaderException ex) { }
            return Values;
        }
        #endregion

        #region convert data to XML format
        public string ToXML(string Values)
        {
            try
            {
                return JsonConvert.DeserializeXmlNode(Values).ToString();
            }
            catch (JsonReaderException ex) { }
            return Values;
        }
        #endregion
    }
}
