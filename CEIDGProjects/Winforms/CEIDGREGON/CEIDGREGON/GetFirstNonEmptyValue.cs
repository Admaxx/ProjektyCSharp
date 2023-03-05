using ServiceReference1;

namespace CEIDGREGON
{
    internal class GetFirstNonEmptyValue
    {
        internal ParametryWyszukiwania ReturnFirstNonEmpty(string[] Values)
        {
            if (!string.IsNullOrEmpty(Values[0]))
                return new ParametryWyszukiwania() { Regon = Values[0] };

            else if (!string.IsNullOrEmpty(Values[1]))
                return new ParametryWyszukiwania() { Nip = Values[1] };

            return new ParametryWyszukiwania() { Krs = Values[2] };
        }
    }
}