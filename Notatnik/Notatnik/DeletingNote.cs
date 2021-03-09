using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notatnik
{
    static internal class DeletingNote
    {
        static internal string Deleting(string title)
        {
            if(DatabaseConn.conn.State != System.Data.ConnectionState.Open)  
                DatabaseConn.Connect();

            string query = string.Format($"Delete from datas where title = '{title}'");

            MySqlCommand command = new MySqlCommand(query, DatabaseConn.conn);

            

            if (command.ExecuteNonQuery() > 0)
                return "Poprawnie usunięto!";
            DatabaseConn.Disconnect();
            return "Błąd usuwania";
        }
    }
}
