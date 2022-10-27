using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6
{
    internal class People
    {
        public static DataTable people = new DataTable();
        public static DataColumn workerID = new DataColumn();
        public static DataColumn workerName = new DataColumn();
        public static DataColumn workerAge = new DataColumn();
        public static DataColumn workerSpecialization = new DataColumn();
        public static DataColumn workerWorkLoad = new DataColumn();

        public static void AddCollumns()
        {
            workerID.DataType = Type.GetType("System.Int32");
            workerID.ColumnName = "ID";
            workerID.Caption = "ID";
            workerID.AutoIncrement = true;
            workerID.Unique = true;
            workerID.ReadOnly = true;

            workerName.DataType = Type.GetType("System.String");
            workerName.ColumnName = "Name";
            workerName.Caption = "Name";
            workerName.AllowDBNull = true;
            workerName.MaxLength = 20;

            workerAge.DataType = Type.GetType("System.Int32");
            workerAge.ColumnName = "Age";
            workerAge.Caption = "Age";
            workerAge.AllowDBNull = false;

            workerSpecialization.DataType = Type.GetType("System.String");
            workerSpecialization.ColumnName = "Specialization";
            workerSpecialization.Caption = "Specialization";
            workerSpecialization.AllowDBNull = false;
            workerSpecialization.MaxLength = 50;

            workerWorkLoad.DataType = Type.GetType("System.Int32");
            workerWorkLoad.ColumnName = "WorkLoad";
            workerWorkLoad.Caption = "WorkLoad";
            workerWorkLoad.DefaultValue = 0;
            workerWorkLoad.AllowDBNull = false;

            people.Columns.Add(workerID);
            people.Columns.Add(workerName);
            people.Columns.Add(workerAge);
            people.Columns.Add(workerSpecialization);
            people.Columns.Add(workerWorkLoad);
        }
    }
}
