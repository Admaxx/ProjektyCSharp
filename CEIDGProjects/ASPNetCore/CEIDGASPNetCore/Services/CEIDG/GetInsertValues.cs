using CEIDGASPNetCore.DbModel;
using CEIDGASPNetCore.Services.CEIDG.Interfaces.Abstract;
using CEIDGREGON;

namespace CEIDGASPNetCore.Services.CEIDG
{
    public class GetInsertValues : InsertValues
    {
        ShowRaportValues show;
        public GetInsertValues()
        {
            show = new ShowRaportValues();
        }
        internal override Gusvalue LastInsertValues(byte ActionName, List<string> ModelValues, string AdditionalValue = null)
        {
            string GetValue = show.GetValuesFromGUS(ActionName, ModelValues, AdditionalValue);

            return new Gusvalue() { ImportDate = DateTime.Now, Xmlvalues = GetValue, RaportType = ActionName };
        }
    }
}
