namespace CEIDGASPNetCore.Services.CEIDG.Interfaces
{
    public interface IGusGetValues
    {
        public string GetValuesFromGUS(int ActionName, List<string> BoxList, string AdditionalValue = null);
    }
}
