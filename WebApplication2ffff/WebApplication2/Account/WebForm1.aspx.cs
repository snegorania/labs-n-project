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
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ServiceReference1.Service1SoapClient dd = new ServiceReference1.Service1SoapClient();
            Label1.Text = dd.HelloWorld();
            GridView2.DataSource = dt;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            using (var client = new WebClient())
            {
                // client.UseDefaultCredentials = false;
                //  client.Credentials = new NetworkCredential("password", "password");
                // client.DownloadFile(new Uri("http://localhost:6307/Account/WebForm1.aspx"), @"G:\file.html");
                /*string HtmlText = string.Empty;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(@"http://localhost:6307/Account/WebForm1.aspx");
                request.Credentials = System.Net.CredentialCache.DefaultCredentials;
                request.Proxy.Credentials = System.Net.CredentialCache.DefaultCredentials;
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                StreamReader strm = new StreamReader(response.GetResponseStream());
                HtmlText = strm.ReadToEnd();

                using (StreamWriter writer = new StreamWriter(@"G:\file.html", false)) { 
                    writer.WriteLine(HtmlText);
                }*/

                using (SqlConnection conn = new SqlConnection("Data Source=1-123-09;Initial Catalog=jkrdghsggh;Integrated Security=True"))
                {
                    using (StreamWriter sw = new StreamWriter(@"G:\file.html"))
                    {
                        SqlDataReader dr;
                        SqlCommand cmd = new SqlCommand();
                        cmd.CommandTimeout = 60;
                        cmd.Connection = conn;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "SELECT COUNT(*) FROM indication";
                        try
                        {
                            conn.Open();
                            if (conn.State == ConnectionState.Open)
                            {
                                object objCount = cmd.ExecuteScalar();
                                int iCount = (int)objCount;
                                cmd.CommandText = "SELECT * FROM indication";
                                dr = cmd.ExecuteReader(CommandBehavior.SingleResult);
                                for (int i = 0; i < iCount; i++)
                                {
                                    dr.Read();
                                    sw.WriteLine("ID: " + dr[0] + " \t Sensor id: " + dr[1] + " \t Date: " + dr[2] + " \t Time: " + dr[3] + " \t Temperature: " + dr[4]);
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

        protected void SqlDataSource2_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {

        }

        public static DataTable dt = new DataTable("Table");
        public static DataColumn name = dt.Columns.Add("Name", typeof(String));
        public static DataColumn temp = dt.Columns.Add("Temp", typeof(String));
        public static DataColumn abs = dt.Columns.Add("ABS", typeof(String));

        

        public DataRow row;

        protected void Button2_Click(object sender, EventArgs e)
        {
            string s = TextBox1.Text;
            string sqlExpression = "temp_dev";
            

            using (SqlConnection conn = new SqlConnection("Data Source=1-123-09;Initial Catalog=jkrdghsggh;Integrated Security=True"))
            {

                {
                    SqlCommand cmd = new SqlCommand(sqlExpression, conn);
                    cmd.CommandTimeout = 60;
                    cmd.CommandType = CommandType.StoredProcedure;
                    try
                    {
                        conn.Open();
                        if (conn.State == ConnectionState.Open)
                        {
                            var reader = cmd.ExecuteReader();
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    string name1 = reader.GetString(0);
                                    double temp1 = reader.GetFloat(1);
                                    double abs1 = reader.GetFloat(2);
                                    row = dt.NewRow();
                                    row["Name"] = name1;
                                    row["Temp"] = temp1;
                                    row["ABS"] = abs1;
                                    dt.Rows.Add(row);
                                }
                            }
                            reader.Close();
                        }
                    }
                    catch (Exception exp)
                    {
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