using CEIDGASPNetCore.Models;
using ServiceReference1;

namespace CEIDGREGON
{
    internal class GetFirstNonEmptyValue
    {
        internal ParametryWyszukiwania ReturnFirstNonEmpty(List<string> ModelValues)
        {
             if (!string.IsNullOrEmpty(ModelValues[0]))
                return new ParametryWyszukiwania() { Regon = ModelValues[0] };

            else if (!string.IsNullOrEmpty(ModelValues[1]))
                return new ParametryWyszukiwania() { Nip = ModelValues[1] };

            else
                return new ParametryWyszukiwania() { Krs = ModelValues[2] };
        }
    }
}