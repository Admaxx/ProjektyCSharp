namespace CEIDGREGON
{
    public class ShowRaportValues : ProgramGeneralData
    {
        GetRequests request;
        GetFirstNonEmptyValue Box;
        public ShowRaportValues()
        {
            request = new GetRequests();
            Box = new GetFirstNonEmptyValue();
        }
        public string GetValuesFromGUS(int ActionName, List<string> BoxList, string AdditionalValue = null)
        {
            string GetValueFromAPI = string.Empty;

            if (ActionName == 0)
                GetValueFromAPI = request.GetValuesForDanePodmiotu(Box.ReturnFirstNonEmpty(BoxList));

            else if (ActionName == 1)
                GetValueFromAPI = request.GetValuesForPelnyRaport(BoxList[0], AdditionalValue);

            else if (ActionName == 2)
                GetValueFromAPI = request.GetValuesForZbiorczyRaport(BoxList[0], AdditionalValue);

            return GetValueFromAPI;
        }
    }
}
