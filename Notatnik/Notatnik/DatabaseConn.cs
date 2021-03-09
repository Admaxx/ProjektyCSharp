using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notatnik
{
    internal static class DatabaseConn
    {
        internal static MySqlConnection conn = new MySqlConnection(
            "Server = SampleServer " +
                "Database = SampleDB; " +
                "user = SampleUser; " +
                "password = SamplePass;"
            );

        static internal void Connect()
        {
            conn.Open();

        }
        static internal void Disconnect()
        {
            conn.Close();


        }
        
    }
}
