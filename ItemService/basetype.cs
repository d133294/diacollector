using MySql.Data.MySqlClient;
using System;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace ItemService
{
    class BaseType
    {
        private string basetype;
        public BaseType(string basetype)
        {
            this.basetype = basetype;
        }

        public string ItemBaseType
        {
            get { return basetype; }
            set { basetype = value; }
        }

        public int returnBaseID()
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
                String hquery = "SELECT b_value FROM basetype WHERE b_type = @basetype";
                using (MySqlCommand cmd = new MySqlCommand(hquery, dbConn))
                {

                    cmd.Parameters.AddWithValue("@basetype", ItemBaseType);

                    var baseValue = cmd.ExecuteScalar();
                    return Convert.ToInt32(baseValue);
                }

            }
        }
    }
}
