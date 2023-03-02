using CEIDGASPNetCore.Models;
using ServiceReference1;

namespace CEIDGREGON
{
    public class GetFirstNonEmptyValue
    {
        public ParametryWyszukiwania ReturnFirstNonEmpty(List<string> ModelValues)
        {
            if (Convert.ToInt64(ModelValues[0]) != 0)
                return new ParametryWyszukiwania() { Regon = ModelValues[0] };

            else if (Convert.ToInt64(ModelValues[1]) != 0)
                return new ParametryWyszukiwania() { Nip = ModelValues[1] };

            return new ParametryWyszukiwania() { Krs = ModelValues[2] };
        }
    }
}