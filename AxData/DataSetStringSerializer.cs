using System.Data;
using System.IO;
using System.Xml;
using AxData.Interfaces;

namespace AxData
{
    public class DataSetStringSerializer : IDataStringSerializer<DataSet>
    {
        protected readonly XmlWriterSettings _writerSettings = new XmlWriterSettings
                                                               {
                                                                   OmitXmlDeclaration = true,
                                                                   Indent = false
                                                               };

        public string Serialize(DataSet dataset)
        {
            using (var sw = new StringWriter())
            using (var xw = XmlWriter.Create(sw, _writerSettings))
            {
                dataset.WriteXml(xw, XmlWriteMode.IgnoreSchema);
                return sw.ToString();
            }
        }

        public DataSet Deserialize(string serialized)
        {
            DataSet dataset = new DataSet();
            using (var sr = new StringReader(serialized))
            {
                dataset.ReadXml(sr);
            }
            return dataset;
        }
    }
}
