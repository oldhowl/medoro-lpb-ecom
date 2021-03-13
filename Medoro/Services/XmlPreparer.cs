using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;

namespace Medoro.Services
{
    public static class XmlPreparer
    {
        public static T Deserialize<T>(string xml)
        {
            var serializer = new XmlSerializer(typeof(T));
            using TextReader reader = new StringReader(xml);
            return (T) serializer.Deserialize(reader);
        }

        public static string Serialize(object input)
        {
            var xmlDocRec = new XmlDocument();
            xmlDocRec.LoadXml(SerializeToXml(input));
            var root = xmlDocRec.DocumentElement;
            root.RemoveAllAttributes();

            var declarations = xmlDocRec.ChildNodes.OfType<XmlNode>()
                .Where(x => x.NodeType == XmlNodeType.XmlDeclaration)
                .ToList();

            declarations.ForEach(x => xmlDocRec.RemoveChild(x));

            return xmlDocRec.InnerXml;
        }

        private static string SerializeToXml(object input)
        {
            var ser = new XmlSerializer(input.GetType());

            using var memStm = new MemoryStream();
            ser.Serialize(memStm, input);

            memStm.Position = 0;
            return new StreamReader(memStm).ReadToEnd();
        }
    }
}