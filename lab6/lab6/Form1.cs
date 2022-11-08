using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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
            dataGridView2.DataSource = ds.Tables["People"];
            comboBox1.Items.Add("All");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataRow row = PetShelter.pets.NewRow();
            row["Name"] = PetName.Text;
            if (comboBox1.SelectedIndex > 0)
            {
                row["Type"] = People.people.Rows[comboBox1.SelectedIndex - 1]["Specialization"];
                People.people.Rows[comboBox1.SelectedIndex - 1]["WorkLoad"] = (int)People.people.Rows[comboBox1.SelectedIndex - 1]["WorkLoad"] + 1;
            }
            else
            {
                row["Type"] = "Unique";
                foreach(DataRow item in People.people.Rows)
                {
                    item["WorkLoad"] = (int)item["WorkLoad"] + 1;
                }
            }
            row["Status"] = PetStatus.Text;
            row["Volunteer"] = comboBox1.SelectedIndex > 0 ? People.people.Rows[comboBox1.SelectedIndex - 1]["Name"] : "All";
            PetShelter.pets.Rows.Add(row);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DataRow row = People.people.NewRow();
            row["Name"] = PersonName.Text;
            row["Age"] = PersonAge.Text;
            row["Specialization"] = PersonSpecialisation.Text;
            People.people.Rows.Add(row);
            comboBox1.Items.Add(row["Name"]);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DataRow row = People.people.Rows[Int32.Parse(textBox1.Text)];
            row["Name"] = PersonName.Text;
            row["Age"] = PersonAge.Text;
            row["Specialization"] = PersonSpecialisation.Text;
            comboBox1.Items[Int32.Parse(textBox1.Text) + 1] = row["Name"];
        }

        private void button5_Click(object sender, EventArgs e)
        {
            People.people.Rows.RemoveAt(Int32.Parse(textBox1.Text));
            comboBox1.Items.RemoveAt(Int32.Parse(textBox1.Text) + 1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataRow row = PetShelter.pets.Rows[Int32.Parse(textBox2.Text)];
            if (row["Volunteer"].Equals("All"))
            {
                foreach (DataRow item in People.people.Rows)
                {
                    if ((int)item["WorkLoad"] != 0)
                    {
                        item["WorkLoad"] = (int)item["WorkLoad"] - 1;
                    }
                }
            }
            else
            {
                foreach (DataRow item in People.people.Rows)
                {
                    if ((int)item["WorkLoad"] != 0 && item["Name"].Equals(row["Volunteer"]))
                    {
                        item["WorkLoad"] = (int)item["WorkLoad"] - 1;
                    }
                }
            }
            row["Name"] = PetName.Text;
            if (comboBox1.SelectedIndex > 0)
            {
                row["Type"] = People.people.Rows[comboBox1.SelectedIndex - 1]["Specialization"];
                People.people.Rows[comboBox1.SelectedIndex - 1]["WorkLoad"] = (int)People.people.Rows[comboBox1.SelectedIndex - 1]["WorkLoad"] + 1;
            }
            else
            {
                row["Type"] = "Unique";
                foreach (DataRow item in People.people.Rows)
                {
                    item["WorkLoad"] = (int)item["WorkLoad"] + 1;
                }
            }
            row["Status"] = PetStatus.Text;
            row["Volunteer"] = comboBox1.SelectedIndex > 0 ? People.people.Rows[comboBox1.SelectedIndex - 1]["Name"] : "All";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataRow row = null;
            foreach (DataRow thing in PetShelter.pets.Rows)
            {
                if ((int)thing["ID"] == Int32.Parse(textBox2.Text))
                {
                    row = thing;
                    if (row["Volunteer"].Equals("All"))
                    {
                        foreach (DataRow item in People.people.Rows)
                        {
                            if ((int)item["WorkLoad"] != 0)
                            {
                                item["WorkLoad"] = (int)item["WorkLoad"] - 1;
                            }
                        }
                    }
                    else
                    {
                        foreach (DataRow item in People.people.Rows)
                        {
                            if ((int)item["WorkLoad"] != 0 && item["Name"].Equals(row["Volunteer"]))
                            {
                                item["WorkLoad"] = (int)item["WorkLoad"] - 1;
                            }
                        }
                    }
                }
            }
            PetShelter.pets.Rows.Remove(row);
        }
    }
}
