using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ItemService
{
    class mysql
    {
        private const string SERVER = "localhost";
        private const string DATABASE = "diacollector";
        private const string UID = "root";
        private const string PASSWORD = "";
        private static MySqlConnection dbConn;

        public static void InitializedDB()
        {
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
            builder.Server = SERVER;
            builder.UserID = UID;
            builder.Password = PASSWORD;
            builder.Database = DATABASE;

            string connString = builder.ToString();
            builder = null;
            //Console.WriteLine(connString);
            dbConn = new MySqlConnection(connString);
        }

    }
}
