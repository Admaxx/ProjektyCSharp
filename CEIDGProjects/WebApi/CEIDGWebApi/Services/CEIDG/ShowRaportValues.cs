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
        internal string GetValuesFromGus(string GetRegonOrNIP, int RaportIndex, string? NazwaRaportu)
        {
            if (RaportIndex == 0)
                return request.GetValuesForDanePodmiotu(Box.ReturnFirstNonEmpty(GetRegonOrNIP));

            else if (RaportIndex == 1)
                return request.GetValuesForPelnyRaport(GetRegonOrNIP, NazwaRaportu);

            return request.GetValuesForZbiorczyRaport(GetRegonOrNIP, NazwaRaportu);
        }
    }
}
