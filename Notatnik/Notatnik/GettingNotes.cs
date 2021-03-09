using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Windows;

namespace Notatnik
{
    class GettingNotes
    {
        static internal IList<string> GetDatas(string title)
        {
           
                AllDatas.TitlesAndContent.Clear();
                string query = "Select Content, AddDate, UpdateData from datas where Title = " + string.Format($" '{title}'");

                AllDatas.TitlesAndContent.Add(title);

                if (DatabaseConn.conn.State != ConnectionState.Open)
                {
                    DatabaseConn.Connect();


                }

                MySqlCommand command = new MySqlCommand(query, DatabaseConn.conn);

                //MessageBox.Show(string.Format(" '{0}'", title));
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    AllDatas.TitlesAndContent.Add(reader.GetString(0));
                    AllDatas.TitlesAndContent.Add(reader.GetString(1));
                }
                DatabaseConn.Disconnect();
           
            return AllDatas.TitlesAndContent;
        }


    }
}
