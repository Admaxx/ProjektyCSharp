using System.Data.SqlClient;
using System.ServiceModel.Channels;

namespace CEIDGREGON
{
    internal class DBOperations : ProgramGeneralData
    {
        internal void Operations(string ServerName, string UserName, string UserPass)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(GetConnectionString(ServerName, UserName, UserPass)))
                {
                    conn.Open();
                    foreach (var SqlFile in PathsToFiles)//Contains Create: DB, Tables, Triggers, Values. Strict to db
                    {
                        string script = new FileInfo(SqlFile).OpenText().ReadToEnd();
                        if (!string.IsNullOrEmpty(script))
                            new SqlCommand(script, conn).ExecuteNonQuery();
                    }
                    conn.Close();
                }
            }catch(SqlException ex) { if (ex.Number != 2714) MessageBox.Show($"Wystąpił błąd nr {ex.Number}, przekaż go administratorowi"); }
            WriteDBFile($"Data Source = {ServerName}; INITIAL Catalog = CEIDGREGON;User ID = {UserName}; Password = {UserPass};");

        }
        private string GetConnectionString(string ServerName, string UserName, string UserPass)
        => 
        $"Data Source = {ServerName}; INITIAL Catalog = master;User ID = {UserName}; Password = {UserPass};";

        internal string WriteDBFile(string DbConnectionString)
        {
            using (StreamWriter sw = new StreamWriter(DBFile, true))
            {
                sw.WriteLine(DbConnectionString);
            }

            return DbConnectionString;
        }
    }
}
