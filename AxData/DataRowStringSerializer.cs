using System;
using System.Data;
using System.IO;
using System.Xml;
using AxData.Interfaces;

namespace AxData
{
    public class DataRowStringSerializer : IDataSerializer<DataRow, string>
    {
        protected readonly IDataSerializer<DataTable, string> _tableStringSerializer = new DataTableStringSerializer();

        public string Serialize(DataRow row)
        {
            DataTable table = row.Table.Clone();
            table.ImportRow(row);
            return _tableStringSerializer.Serialize(table);
        }

        public DataRow Deserialize(string serialized)
        {
            DataTable table = _tableStringSerializer.Deserialize(serialized);
            if (table.Rows.Count != 1)
            {
                throw new InvalidOperationException();
            }

            DataRow row = table.Rows[0];
            table.Rows.Remove(row);
            return row;
        }
    }
}
