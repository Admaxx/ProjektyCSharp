using System.Net.NetworkInformation;

namespace CEIDGREGON
{
    internal class CheckAllReq : ProgramGeneralData
    {
        DbChooseForm db;
        internal void Requiments()
        {
            if (!IsInternetConnection())
            {
                MessageBox.Show("Program nie może zostać uruchomiony \nSprawdź swoje połączenie internetowe", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(-1);
            }
            if (!System.IO.File.Exists(DBFile))
            {
                db = new DbChooseForm();
                db.ShowDialog();
            }
        }
        private bool IsInternetConnection()
        =>
        NetworkInterface.GetIsNetworkAvailable();
    }
}
