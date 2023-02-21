using CEIDGWebApi.Services.CEIDG;
using CEIDGWebApi.Models;

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
        internal string GetValuesAndInsertToDB(string GetRegonOrNIP, int RaportIndex, string? NazwaRaportu)
        {
            string GetValueFromAPI = string.Empty;

            if (RaportIndex == 0)
                GetValueFromAPI = request.GetValuesForDanePodmiotu(Box.ReturnFirstNonEmpty(GetRegonOrNIP));

            else if (RaportIndex == 1)
                GetValueFromAPI = request.GetValuesForPelnyRaport(GetRegonOrNIP, NazwaRaportu);

            else //(RaportIndex == 2)
                GetValueFromAPI = request.GetValuesForZbiorczyRaport(GetRegonOrNIP, NazwaRaportu);

            return GetValueFromAPI;
        }
    }
}
