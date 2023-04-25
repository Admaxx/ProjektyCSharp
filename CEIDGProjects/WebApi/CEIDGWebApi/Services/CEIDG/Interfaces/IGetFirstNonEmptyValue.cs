using ServiceReference1;

namespace CEIDGASPNetCore.Services.CEIDG.Interfaces
{
    public interface IGetFirstNonEmptyValue
    {
        public ParametryWyszukiwania ReturnFirstNonEmpty(List<string> ModelValues);
    }
}
