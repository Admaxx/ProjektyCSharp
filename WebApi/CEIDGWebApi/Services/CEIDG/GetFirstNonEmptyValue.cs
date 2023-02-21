using ServiceReference1;

namespace CEIDGREGON
{
    internal class GetFirstNonEmptyValue
    {
        internal ParametryWyszukiwania ReturnFirstNonEmpty(string Values)
        {
            if (Values.Length != 10)
                return new ParametryWyszukiwania() { Regon = Values };

            return new ParametryWyszukiwania() { Nip = Values };
        }
    }
}