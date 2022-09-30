using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;
using System.Xml;
using PSC_ERP_Util.XML;

namespace PSC_ERP_Util.Serialize
{
    public class SerializeUtil
    {
        public static void SerializeToXmlFile<T>(T obj, string filePath)
        {
            try
            {
                System.Text.Encoding encoding = System.Text.Encoding.Unicode;
                String xmlizedString = null;
                MemoryStream memoryStream = new MemoryStream();
                XmlSerializer xs = new XmlSerializer(typeof(T));
                XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, encoding);

                xs.Serialize(xmlTextWriter, obj);
                memoryStream = (MemoryStream)xmlTextWriter.BaseStream;
                xmlizedString = ByteArrayUtil.BytesToString(memoryStream.ToArray(), encoding);

                IOUtil.WriteStringToNewFile(xmlizedString, filePath, true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static T DeserializeFromXmlFile<T>(string filePath)
        {
            Object obj;
            try
            {

                String xml = IOUtil.ReadFileToString(filePath);
                System.Text.Encoding encoding = System.Text.Encoding.Unicode;
                XmlSerializer xs = new XmlSerializer(typeof(T));
                MemoryStream memoryStream = new MemoryStream(ByteArrayUtil.StringToBytes(xml, encoding));
                XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, encoding);

                obj = xs.Deserialize(memoryStream);
            }
            catch (Exception ex)
            {
                obj = null;
            }

            return (T)obj;
        }

    }
}
