using CEIDGASPNetCore.DbModel;

namespace CEIDGASPNetCore.Services.CEIDG.Interfaces.Abstract
{
    public interface IValuesInsert
    {
        public Gusvalue LastInsertValues(byte ActionName, List<string> ModelValues, string AdditionalValue = null);
    }
}
