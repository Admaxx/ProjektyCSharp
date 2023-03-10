using CEIDGASPNetCore.Services.CEIDG.Abstract;
using CEIDGASPNetCore.Services.CEIDG.Interfaces;
using Newtonsoft.Json;
using System.Xml;

namespace CEIDGASPNetCore.Services.CEIDG
{
    public class ConvertDocOnFormat : FormatOptions
    {
        public override string ChooseFormat(string Values, bool SetJSONFormat)
        {
            if (string.IsNullOrEmpty(Values))
                return "Brak danych";

            return base.ChooseFormat(Values, SetJSONFormat);
        }
    }
}
