using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.IO;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication2.Account
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            using (var client = new WebClient())
            {
                using (SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\DataBaseSensors.mdf;Integrated Security=True"))
                {
                    using (StreamWriter sw = new StreamWriter(@"D:/save-data/region.txt"))
                    {
                        SqlDataReader dr;
                        SqlCommand cmd = new SqlCommand();
                        cmd.CommandTimeout = 60;
                        cmd.Connection = conn;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "SELECT COUNT(*) FROM region";
                        try
                        {
                            conn.Open();
                            if (conn.State == ConnectionState.Open)
                            {
                                object objCount = cmd.ExecuteScalar();
                                int iCount = (int)objCount;
                                cmd.CommandText = "SELECT * FROM region";
                                dr = cmd.ExecuteReader(CommandBehavior.SingleResult);
                                for (int i = 0; i < iCount; i++)
                                {
                                    dr.Read();
                                    sw.WriteLine("ID: " + dr[0] + " \t Name: " + dr[1]);
                                }
                            }
                        }
                        catch (Exception exp)
                        {
                            sw.WriteLine(exp.Message);
                        }
                        finally
                        {
                            conn.Close();
                        }
                    }
                }

            }
        }
    }
}