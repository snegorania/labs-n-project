using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab6
{
    public partial class Form1 : Form
    {
        public static DataSet ds = new DataSet("DataBase");
        public Form1()
        {
            InitializeComponent();
            PetShelter.addColums();
            People.AddCollumns();
            dataGridView1.DataSource = ds.Tables["Pets"];
            dataGridView1.Update();
            dataGridView2.DataSource = ds.Tables["People"];
            dataGridView2.Update();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataRow row = People.people.NewRow();
            row["Name"] = PersonName.Text;
            row["Age"] = PersonAge.Text;
            row["Specialisation"] = PersonSpecialisation.Text;
            People.people.Rows.Add(row);
        }
    }
}
