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
            if (ActionName == 0)
                return request.GetValuesForDanePodmiotu(Box.ReturnFirstNonEmpty(BoxList));

            else if (ActionName == 1)
                return request.GetValuesForPelnyRaport(BoxList[0], AdditionalValue);

            return request.GetValuesForZbiorczyRaport(BoxList[0], AdditionalValue);
        }
    }
}
