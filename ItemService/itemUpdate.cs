using MySql.Data.MySqlClient;
using System;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace ItemService
{
    class ItemUpdate
    {
        private string season;
        private string itemtype;
        private string istwohand;
        private string two = "2_";
        private int basevalue;

        String hquery;

        public ItemUpdate(string istwohand, string season, string itemtype)
        {
            this.istwohand = istwohand;
            this.season = season;
            this.itemtype = itemtype;
        }

        public string IsTwoHand
        {
            get { return istwohand; }
            set { istwohand = value; }
        }
        public string Season
        {
            get { return season; }
            set { season = value; }
        }

        public string ItemType
        {
            get { return itemtype; }
            set { itemtype = value; }
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
                String squery = "SELECT " + Season + " FROM itemtype WHERE i_type = @itemtype";
                using (MySqlCommand scmd = new MySqlCommand(squery, dbConn))
                {
                    scmd.Parameters.AddWithValue("@itemtype", ItemType);
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
                switch (IsTwoHand)
                {
                    case "2":
                        //Need to update this. its not updating the database.
                        hquery = "UPDATE itemtype SET " + Season + " = @newbasevalue WHERE i_type = " + two + "@itemtype";
                        break;
                    default:
                        hquery = "UPDATE itemtype SET " + Season + " = @newbasevalue WHERE i_type = @itemtype";
                        break;
                }
                
                using (MySqlCommand cmd = new MySqlCommand(hquery, dbConn))
                {
                    cmd.Parameters.AddWithValue("@itemtype", ItemType);
                    cmd.Parameters.AddWithValue("@newbasevalue", getBase());
                    cmd.ExecuteNonQuery();
                    dbConn.Close();
                }
                return "Updated Database";
            }
        }

    }
}
