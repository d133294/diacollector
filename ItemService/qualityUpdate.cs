using MySql.Data.MySqlClient;
using System;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace ItemService
{
    class QualityUpdate
    {
        private string season;
        private string itemname;
        private int basevalue;
        string hquery;

        public QualityUpdate(string itemname, string season)
        {
            this.itemname = itemname;
            this.season = season;
        }

        public string Season
        {
            get { return season; }
            set { season = value; }
        }

        public string ItemName
        {
            get { return itemname; }
            set { itemname = value; }
        }

        public int getBase()
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
                String squery = "SELECT " + Season + " FROM itemquality WHERE name = @itemname";
                using (MySqlCommand scmd = new MySqlCommand(squery, dbConn))
                {
                    scmd.Parameters.AddWithValue("@itemname", ItemName);
                    using (MySqlDataReader reader = scmd.ExecuteReader())
                    {
                        while (reader.Read())
                            basevalue = reader.GetInt32(0);
                            return basevalue + 1;
                    }
                }
            }
        }

        public string Update()
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
                hquery = "UPDATE itemquality SET " + Season + " = @newbasevalue WHERE name = @itemname";
                using (MySqlCommand cmd = new MySqlCommand(hquery, dbConn))
                {
                    cmd.Parameters.AddWithValue("@itemname", ItemName);
                    cmd.Parameters.AddWithValue("@newbasevalue", getBase());
                    cmd.ExecuteNonQuery();
                    dbConn.Close();
                }
                return "Updated Database";
            }
        }
    }
}
