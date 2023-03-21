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

namespace WebApplication2
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Page_Load(sender, e);
            
        }

		protected void Button2_Click(object sender, EventArgs e)
		{
            using (var client = new WebClient())
            {
                using (SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\DataBaseSensors.mdf;Integrated Security=True"))
                {
                    using (StreamWriter sw = new StreamWriter(@"D:/save-data/sensor.txt"))
                    {
                        SqlDataReader dr;
                        SqlCommand cmd = new SqlCommand();
                        cmd.CommandTimeout = 60;
                        cmd.Connection = conn;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "SELECT COUNT(*) FROM sensor";
                        try
                        {
                            conn.Open();
                            if (conn.State == ConnectionState.Open)
                            {
                                object objCount = cmd.ExecuteScalar();
                                int iCount = (int)objCount;
                                cmd.CommandText = "SELECT * FROM sensor";
                                dr = cmd.ExecuteReader(CommandBehavior.SingleResult);
                                for (int i = 0; i < iCount; i++)
                                {
                                    dr.Read();
                                    sw.WriteLine("ID: " + dr[0] + " \t Region id: " + dr[1] + " \t Name: " + dr[2] + " \t latitude: " + dr[3] + " \t Longtitude: " + dr[4]);
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