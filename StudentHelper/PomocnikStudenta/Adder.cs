using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PomocnikStudenta
{
    internal class Adder
    {

        internal void Person(Dictionary<string, string> list)
        {
            MySqlConnector.conn.Close();
            if(MySqlConnector.conn.State 
                == 
                System.Data.ConnectionState.Closed)
            {
                MySqlConnector.conn.Open();

            }
            //Not finished
            MySqlCommand cmd = new MySqlCommand(MySqlConnector.SelectSpecificCommand + list.Values);

        }

    }
}
