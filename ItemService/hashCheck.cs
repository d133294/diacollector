using MySql.Data.MySqlClient;
using System;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace ItemService
{
    class HashCheck
    {
        
        private string hash;
        public HashCheck(string hash)
        {
            this.hash = hash;
        }

        public int returnHash()
        {
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
            builder.Server = "localhost";
            builder.UserID = "root";
            builder.Password = "";
            builder.Database = "test";
            String connString = builder.ToString();
            builder = null;

            using (var dbConn = new MySqlConnection(connString))
            {
                dbConn.Open();
                String hquery = "SELECT COUNT(itemhash) FROM itemstats WHERE itemhash = @hash";
                using (MySqlCommand cmd = new MySqlCommand(hquery, dbConn))
                {
                    
                    cmd.Parameters.AddWithValue("@hash", Hash);

                    var userCount = cmd.ExecuteScalar();
                    return Convert.ToInt32(userCount);                        
                }

            }
        }

        public string Hash
        {
            get { return hash; }
            set { hash = value; }
        }
    }
}
