using System;
using System.Data.Common;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace SensorApp
{
    public class quaryTry
    {
        public static string ConnectionTry()
        {
            string result;
            MySqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();
            try
            {
                result = QueryTry(conn);
            }
            catch (Exception ex)
            {
                result= ex.Message;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return result;
        }

        public static string QueryTry(MySqlConnection conn)
        {
            string sql = "SELECT name FROM Regions WHERE id = 1";
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = sql;
            DbDataReader reader = cmd.ExecuteReader();
            int regionIndex;
            string regionName = "";
            if(reader.Read())
            {
                regionIndex = reader.GetOrdinal("name");
                regionName = reader.GetString(regionIndex);
            }
            return regionName;
        }

    }
}
