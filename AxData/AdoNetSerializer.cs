using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

namespace AxData
{
    public static class AdoNetSerializer
    {
        private static readonly XmlWriterSettings _writerSettings = new XmlWriterSettings
                                                                    {
                                                                        OmitXmlDeclaration = true,
                                                                        Indent = false
                                                                    };

        public static string SerializeDataRow(DataRow row)
        {
            DataTable table = row.Table.Clone();
            table.ImportRow(row);
            return SerializeDataTable(table);
        }

        public static DataRow DeserializeDataRow(string serialized)
        {
            DataTable table = DeserializeDataTable(serialized);
            if (table.Rows.Count != 1)
            {
                throw new InvalidOperationException();
            }

            DataRow row = table.Rows[0];
            table.Rows.Remove(row);
            return row;
        }

        public static string SerializeDataSet(DataSet dataset)
        {
            using (StringWriter sw = new StringWriter())
            using (XmlWriter xw = XmlWriter.Create(sw, _writerSettings))
            {
                dataset.WriteXml(xw, XmlWriteMode.IgnoreSchema);
                return sw.ToString();
            }
        }

        public static DataSet DeserializeDataSet(string serialized)
        {
            DataSet dataset = new DataSet();
            using (StringReader sr = new StringReader(serialized))
            {
                dataset.ReadXml(sr);
            }
            return dataset;
        }

        public static string SerializeDataTable(DataTable table)
        {
            using (StringWriter sw = new StringWriter())
            using (XmlWriter xw = XmlWriter.Create(sw, _writerSettings))
            {
                table.WriteXml(xw, XmlWriteMode.IgnoreSchema, true);
                return sw.ToString();
            }
        }

        public static DataTable DeserializeDataTable(string serialized)
        {
            DataSet dataset = new DataSet();
            using (StringReader sr = new StringReader(serialized))
            {
                dataset.ReadXml(sr);
            }
            if (dataset.Tables.Count != 1)
            {
                throw new InvalidOperationException();
            }

            DataTable result = dataset.Tables[0];
            dataset.Tables.Remove(result);
            return result;
        }
    }
}
