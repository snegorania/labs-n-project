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
        public Form1()
        {
            InitializeComponent();
            PetShelter.addColums();
            DataSet ds = new DataSet();
            
            dataGridView1.DataSource = PetShelter.pets;
            dataGridView1.Update();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
