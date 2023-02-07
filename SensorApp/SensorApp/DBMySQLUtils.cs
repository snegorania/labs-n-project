using MySql.Data.MySqlClient;

namespace SensorApp
{
    public class DBMySQLUtils
    {
        public static MySqlConnection
            GetDBConnection(string host, int port, string database, string username, string password)
        {
            String connString = "Server=" + host + ";Database=" + database + ";Uid=" + username + ";Password=" + password;/*";port=" +
                +port*/
            MySqlConnection conn = new MySqlConnection(connString);
            return conn;
        }
    }
}
