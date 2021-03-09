using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Notatnik
{
    static class UpdateQuery
    {
        static internal string Update(string title, string content)
        {
            if(DatabaseConn.conn.State != System.Data.ConnectionState.Open) 
                DatabaseConn.Connect();

            string query = string.Format(
                $"Update datas set Content = '{content}'" +
                $" where Title = '{title}'");

            MySqlCommand command = new MySqlCommand(query, DatabaseConn.conn);
            //MessageBox.Show(query);

            
            if (command.ExecuteNonQuery() > 0)
                return "Poprawnie wpisano";
            DatabaseConn.Disconnect();
            return "Błąd";

        }



    }
}
