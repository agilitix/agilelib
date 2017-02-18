using System.Data;
using System.IO;
using System.Xml;
using AxData.Interfaces;

namespace AxData
{
    public class DataTableStringSerializer : IDataStringSerializer<DataTable>
    {
        protected readonly XmlWriterSettings _writerSettings = new XmlWriterSettings
                                                               {
                                                                   OmitXmlDeclaration = true,
                                                                   Indent = false
                                                               };

        public string Serialize(DataTable table)
        {
            using (StringWriter sw = new StringWriter())
            using (XmlWriter xw = XmlWriter.Create(sw, _writerSettings))
            {
                table.WriteXml(xw, XmlWriteMode.IgnoreSchema, true);
                return sw.ToString();
            }
        }

        public DataTable Deserialize(string serialized)
        {
            DataSet dataset = new DataSet();
            using (StringReader sr = new StringReader(serialized))
            {
                dataset.ReadXml(sr);
            }
            if (dataset.Tables.Count == 1)
            {
                DataTable result = dataset.Tables[0];
                dataset.Tables.Remove(result);
                return result;
            }
            return null;
        }
    }
}
