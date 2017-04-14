using System.Data;
using System.IO;
using System.Xml;
using AxData.Interfaces;

namespace AxData
{
    public class DataSetStringSerializer : IDataSerializer<DataSet, string>
    {
        protected readonly XmlWriterSettings _writerSettings = new XmlWriterSettings
                                                               {
                                                                   OmitXmlDeclaration = true,
                                                                   Indent = false
                                                               };

        public string Serialize(DataSet dataset)
        {
            using (StringWriter sw = new StringWriter())
            using (XmlWriter xw = XmlWriter.Create(sw, _writerSettings))
            {
                dataset.WriteXml(xw, XmlWriteMode.IgnoreSchema);
                return sw.ToString();
            }
        }

        public DataSet Deserialize(string serialized)
        {
            DataSet dataset = new DataSet();
            using (StringReader sr = new StringReader(serialized))
            {
                dataset.ReadXml(sr);
            }
            return dataset;
        }
    }
}
