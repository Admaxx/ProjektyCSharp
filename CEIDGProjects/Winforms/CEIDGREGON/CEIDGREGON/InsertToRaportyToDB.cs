using CEIDGREGON.CEIDGREGONBLL;
using CEIDGREGON.CEIDGREGONDAL.GUSValuesBLLTableAdapters;

namespace CEIDGREGON
{
    internal class InsertToRaportyToDB : ProgramGeneralData
    {
        GUSValuesTableAdapter gusConn;
        GUSValuesBLL gusData;
        public InsertToRaportyToDB()
        {
            gusData = new GUSValuesBLL();
            gusConn = new GUSValuesTableAdapter();
        }
        internal int InsertToDB(string GetValueFromAPI, byte RaportIndex)
        {
            using (StreamReader sr = new StreamReader(DBFile))
                gusConn.Connection.ConnectionString = sr.ReadToEnd();

            if (!GetValueFromAPI.Contains("<ErrorCode>"))//Jesli wiadomosc nie jest bledem, to moge ja zapisac - po co zapisywac blad?
                return gusData.InsertXMLValuesToDB(GetValueFromAPI, (byte)RaportIndex);
            return 1;
        }
    }
}
