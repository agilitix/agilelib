using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using AxData.Interfaces;
using AxQuality;
using NUnit.Framework;

namespace AxData.UnitTests
{
    internal class Location
    {
        private int? _col_ID;
        private string _col_name;
        private string _col_city;
        private DateTime? _col_datetime;

        public int? Id
        {
            get { return _col_ID; }
            set { _col_ID = value; }
        }

        public string Name
        {
            get { return _col_name; }
            set { _col_name = value; }
        }

        public string City
        {
            get { return _col_city; }
            set { _col_city = value; }
        }

        public DateTime? Datetime
        {
            get { return _col_datetime; }
            set { _col_datetime = value; }
        }
    }

    internal class Class1 : ArrangeActAssert
    {
        public override void Act()
        {
            // TODO.

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

            IEntityMapper<Location> mapper = new EntityMapper<Location>();
            IEnumerable<Location> entities = mapper.Map(table1);

            DataTable fromEntities = mapper.Map(entities);
        }

        [Test]
        public void Assert()
        {
            // TODO.
        }
    }
}
