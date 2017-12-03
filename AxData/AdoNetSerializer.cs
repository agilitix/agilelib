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

        public static string Serialize(DataSet dataset)
        {
            using (StringWriter sw = new StringWriter())
            using (XmlWriter xw = XmlWriter.Create(sw, _writerSettings))
            {
                dataset.WriteXml(xw, XmlWriteMode.IgnoreSchema);
                return sw.ToString();
            }
        }

        public static string Serialize(DataTable table)
        {
            using (StringWriter sw = new StringWriter())
            using (XmlWriter xw = XmlWriter.Create(sw, _writerSettings))
            {
                table.WriteXml(xw, XmlWriteMode.IgnoreSchema, true);
                return sw.ToString();
            }
        }

        public static string Serialize(DataRow row)
        {
            DataTable table = row.Table.Clone();
            table.ImportRow(row);
            return Serialize(table);
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

        public static DataTable[] DeserializeDataTables(string serialized)
        {
            DataSet dataset = new DataSet();
            using (StringReader sr = new StringReader(serialized))
            {
                dataset.ReadXml(sr);
            }
            return dataset.Tables.Cast<DataTable>().ToArray();
        }

        public static DataRow[] DeserializeDataRows(string serialized)
        {
            DataTable[] tables = DeserializeDataTables(serialized);
            return tables.SelectMany(x => x.Rows.Cast<DataRow>()).ToArray();
        }
    }
}
