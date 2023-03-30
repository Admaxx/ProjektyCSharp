using CEIDGASPNetCore.Services.CEIDG.Interfaces;

namespace CEIDGREGON
{
    public class ShowRaportValues : ProgramGeneralData, IGusGetValues
    {
        GetRequests request;
        IGetFirstNonEmptyValue Box;
        public ShowRaportValues(GetRequests requests, IGetFirstNonEmptyValue Boxes)
        {
            request = requests;
            Box = Boxes;
        }
        #region Getting values from GUS 
        public string GetValuesFromGUS(int ActionName, List<string> BoxList, string AdditionalValue = null)
        {
            if (ActionName == 0)
                return request.GetValuesForDanePodmiotu(Box.ReturnFirstNonEmpty(BoxList));

            else if (ActionName == 1)
                return request.GetValuesForPelnyRaport(BoxList[0], AdditionalValue);

            return request.GetValuesForZbiorczyRaport(BoxList[0], AdditionalValue);
        }
        #endregion
    }
}
