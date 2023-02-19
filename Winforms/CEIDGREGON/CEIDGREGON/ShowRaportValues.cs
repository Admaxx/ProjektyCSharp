namespace CEIDGREGON
{
    internal class ShowRaportValues : ProgramGeneralData
    {
        InsertToRaportyToDB raporty;
        GetRequests request;
        GetFirstNonEmptyValue Box;
        public ShowRaportValues()
        {
            request = new GetRequests();
            Box = new GetFirstNonEmptyValue();
            raporty = new InsertToRaportyToDB();

            request.Login(GusToken);
        }
        internal string GetValuesAndInsertToDB(int RaportIndex, List<string> BoxList, List<string> ComboList)
        {
            string GetValueFromAPI = string.Empty;

            if (RaportIndex == 0)
                GetValueFromAPI = request.GetValuesForDanePodmiotu(Box.ReturnFirstNonEmpty(new string[] { BoxList[0], BoxList[1], BoxList[2] }));

            else if (RaportIndex == 1)
                GetValueFromAPI = request.GetValuesForPelnyRaport(BoxList[0], ComboList[0]);

            else //(SelectedRaportIndex == 2)
                GetValueFromAPI = request.GetValuesForZbiorczyRaport(BoxList[3], ComboList[1]);

            if (raporty.InsertToDB(GetValueFromAPI, (byte)RaportIndex) != 1)
                MessageBox.Show($"Nie udało się wprowadzić wartości do bazy, sprawdź połączenie");

            return GetValueFromAPI;
        }
    }
}
