using System;
using System.Data;
using System.Linq;
using AxData;
using AxExtensions;

namespace UtilsSamples
{
    class Program
    {
        static void Main(string[] args)
        {
            object t = "100g";
            object b = (int ?)t.ConvertTo<int?>();


            DataTable table1 = new DataTable();
            table1.TableName = "tbl1";

            DataColumn dc11 = new DataColumn("ID", typeof(int));
            DataColumn dc12 = new DataColumn("name", typeof(string));
            DataColumn dc13 = new DataColumn("city", typeof(string));
            DataColumn dc14 = new DataColumn("datetime", typeof(string));

            table1.Columns.Add(dc11);
            table1.Columns.Add(dc12);
            table1.Columns.Add(dc13);
            table1.Columns.Add(dc14);

            table1.Rows.Add(111, "Amit Kumar", "Jhansi", DateTime.Now);
            table1.Rows.Add(222, "Rajesh Tripathi", "Delhi", DateTime.Now);
            table1.Rows.Add(null, "Vineet Saini", "Patna", DateTime.Now);
            table1.Rows.Add(444, "Deepak Dwij", "Noida", DateTime.Now);

            string s = AdoNetSerializer.Serialize(table1);
            DataRow[] set = AdoNetSerializer.DeserializeDataRows(s);

            string srow = AdoNetSerializer.Serialize(table1.Rows[0]);
            DataRow r = AdoNetSerializer.DeserializeDataRows(srow).FirstOrDefault();
        }
    }
}
