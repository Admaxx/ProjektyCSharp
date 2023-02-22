namespace CEIDGREGON
{
    internal class ShowRaportValues : ProgramGeneralData
    {
        GetRequests request;
        GetFirstNonEmptyValue Box;
        public ShowRaportValues()
        {
            request = new GetRequests();
            Box = new GetFirstNonEmptyValue();
        }
        internal string GetValuesAndInsertToDB(int ActionName, List<string> BoxList, string AdditionalValue = null)
        {
            string GetValueFromAPI = string.Empty;

            if (ActionName == 0)
                GetValueFromAPI = request.GetValuesForDanePodmiotu(Box.ReturnFirstNonEmpty(BoxList));

            else if (ActionName == 1)
                GetValueFromAPI = request.GetValuesForPelnyRaport(BoxList[0], AdditionalValue);

            else //(ActionName == 2)
                GetValueFromAPI = request.GetValuesForZbiorczyRaport(BoxList[0], AdditionalValue);

            return GetValueFromAPI;
        }
    }
}
