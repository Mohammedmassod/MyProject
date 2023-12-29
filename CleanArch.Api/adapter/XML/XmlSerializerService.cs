using System.Xml.Serialization;

namespace MyProject.Api.adapter.XML
{
    public class XmlSerializerService : IXmlSerializerService
    {

        public T Deserialize<T>(string xml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));

            using (StringReader reader = new StringReader(xml))
            {
                try
                {
                    return (T)serializer.Deserialize(reader);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error deserializing XML", ex);
                }
            }
        }

    }
}