using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PomocnikStudenta
{
    internal class MySqlConnector
    {
       internal static string SelectAllCommand = "Select * from dane";
       internal static string SelectSpecificCommand = "Select * from dane where nazwa =";
       internal static string InsertSpecyficCommand = "Select * from dane";
       internal static MySqlConnection conn = new MySqlConnection
                (
                "Server = localhost; " +
                "Database = wyk; " +
                "user = root; " +
                "password = Jajeczko8;"
                );
    }
}
