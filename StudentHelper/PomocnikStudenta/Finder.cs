using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PomocnikStudenta
{
    class Finder
    {
        Dictionary<string, string> list = new Dictionary<string, string>();
        
        internal Dictionary<string, string> Teachers()
        {
            MySqlConnector.conn.Close();
            if(MySqlConnector.conn.State != System.Data.ConnectionState.Open)
            {
                MySqlConnector.conn.Open();

            }
            MySqlCommand cmd = new MySqlCommand(MySqlConnector.SelectAllCommand, MySqlConnector.conn);
            MySqlDataReader reader = cmd.ExecuteReader();

            try
            {
                while (reader.Read())
                {
                    list.Add(
                        (string)reader.GetValue(1),
                        (string)reader.GetValue(2)
                        );


                }
            }catch (ArgumentException)
            {
                

            }

            return list;
        }

    }
}
