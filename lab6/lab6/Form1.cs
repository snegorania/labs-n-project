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
            comboBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataRow row = PetShelter.pets.NewRow();
            row["ID"] = PetShelter.pets == null ? 0 : PetShelter.pets.Rows.Count;
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
            row["ID"] = People.people == null ? 0 : People.people.Rows.Count;
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
            DataRow row;
            for (int i = Int32.Parse(textBox1.Text) + 1; i < People.people.Rows.Count; i++)
            {
                row = People.people.Rows[i];
                row["ID"] = (int)row["ID"] - 1;
            }
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
            DataRow row;
            for (int i = Int32.Parse(textBox2.Text) + 1; i < PetShelter.pets.Rows.Count; i++)
            {
                row = PetShelter.pets.Rows[i];
                row["ID"] = (int)row["ID"] - 1;
            }
            foreach (DataRow item in People.people.Rows)
            {
                if (PetShelter.pets.Rows[Int32.Parse(textBox2.Text)]["Volunteer"].Equals("All"))
                {
                    foreach(DataRow human in People.people.Rows)
                    {
                        human["WorkLoad"] = (int)human["Workload"] == 0 ? 0 : (int)human["Workload"] - 1;
                    }
                }
                else
                {
                    if (item["Name"].Equals(PetShelter.pets.Rows[Int32.Parse(textBox2.Text)]["Volunteer"]))
                    {
                        item["WorkLoad"] = (int)item["WorkLoad"] == 0 ? 0 : (int)item["WorkLoad"] - 1;
                    }
                }
            }
            PetShelter.pets.Rows.RemoveAt(Int32.Parse(textBox2.Text));
        }

        private void button7_Click(object sender, EventArgs e)
        {
            foreach (DataTable dt in ds.Tables)
            {
                Console.WriteLine(dt.TableName); // название таблицы
                                                 // перебор всех столбцов
                
                // перебор всех строк таблицы
                foreach (DataRow row in dt.Rows)
                {
                    // получаем все ячейки строки
                    var cells = row.ItemArray;
                    foreach (object cell in cells)
                        Console.Write("\t{0}", cell);
                    Console.WriteLine();
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            foreach (DataTable dt in ds.Tables)
            {
                Console.WriteLine(dt.TableName); // название таблицы
                                                 // перебор всех столбцов

                // перебор всех строк таблицы
                foreach (DataRow row in dt.Rows)
                {
                    // получаем все ячейки строки
                    var cells = row.ItemArray;
                    foreach (object cell in cells)
                        Console.Write("\t{0}", cell);
                    Console.WriteLine();
                }
            }
        }
    }
}
    