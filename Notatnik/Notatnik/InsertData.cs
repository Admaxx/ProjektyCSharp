using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Notatnik
{
    static class InsertData
    {
        static internal string Insert(string Title, string Content)
        {

            if (DatabaseConn.conn.State != ConnectionState.Open)
                DatabaseConn.Connect();

            
            string query = string.Format("Insert into datas " +
                "(Title, Content) " +
                $"values ('{Title}', '{Content}')");
            //MessageBox.Show(query);
            MySqlCommand command = new MySqlCommand(query,DatabaseConn.conn);

            if(command.ExecuteNonQuery() > 0)
                return "Wpisano prawidłowo!";
            return "Błąd wpisywanie";
        }

        
        static internal string CheckingIfExist(string Title, string Content)
        {
            //MessageBox.Show(GettingNotes.GetDatas(Title).Count.ToString());
            if(GettingNotes.GetDatas(Title).Count != 3)
            {
                return Insert(Title, Content);
            }
            return UpdateNotes.CheckingUpdate(Title, Content);

        }

    }
}
