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
    static class GettingDatas
    {
        static internal IList<string> GetDatas()
        {
            AllDatas.TitlesList.Clear();
            if (DatabaseConn.conn.State != ConnectionState.Open)
            {
                DatabaseConn.Connect();


            }
            MySqlCommand command = new MySqlCommand("Select title from datas", DatabaseConn.conn);
            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                AllDatas.TitlesList.Add(reader.GetString(0));


            }
            DatabaseConn.Disconnect();

            return AllDatas.TitlesList;
        }
    }
}
