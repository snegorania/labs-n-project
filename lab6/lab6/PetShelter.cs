using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Net.NetworkInformation;
using System.Windows.Forms;

namespace lab6
{
    internal class PetShelter
    {
        public static DataTable pets = Form1.ds.Tables.Add("Pets");
        public static DataColumn petId = new DataColumn();
        public static DataColumn petName = new DataColumn();
        public static DataColumn petType = new DataColumn();
        public static DataColumn petStatus = new DataColumn();
        public static DataColumn petVolunteer = new DataColumn();

        public static void addColums()
        {
            petId.DataType = Type.GetType("System.Int32");
            petId.ColumnName = "ID";
            petId.Caption = "ID";

            petName.DataType = Type.GetType("System.String");
            petName.ColumnName = "Name";
            petName.Caption = "Name";
            petName.AllowDBNull = true;
            petName.MaxLength = 20;

            petType.DataType = Type.GetType("System.String");
            petType.ColumnName = "Type";
            petType.Caption = "Type";
            petType.AllowDBNull = false;
            petType.MaxLength = 50;

            petStatus.DataType = Type.GetType("System.String");
            petStatus.ColumnName = "Status";
            petStatus.Caption = "Status";
            petType.AllowDBNull = false;

            petVolunteer.DataType = Type.GetType("System.String");
            petVolunteer.ColumnName = "Volunteer";
            petVolunteer.Caption = "Volunteer";
            petVolunteer.AllowDBNull = true;
            petVolunteer.MaxLength = 20;

            pets.Columns.Add(petId);
            pets.Columns.Add(petName);
            pets.Columns.Add(petType);
            pets.Columns.Add(petStatus);
            pets.Columns.Add(petVolunteer);
        }
    }
}
