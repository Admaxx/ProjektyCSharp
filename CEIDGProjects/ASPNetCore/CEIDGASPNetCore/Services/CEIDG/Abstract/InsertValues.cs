using CEIDGASPNetCore.DbModel;

namespace CEIDGASPNetCore.Services.CEIDG.Interfaces.Abstract
{
    public abstract class InsertValues
    {
        internal abstract Gusvalue LastInsertValues(byte ActionName, List<string> ModelValues, string AdditionalValue = null);
    }
}
