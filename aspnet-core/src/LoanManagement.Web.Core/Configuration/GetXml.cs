using System.IO;
using System.Xml;
using System.Xml.Serialization;
namespace LoanManagement.Configuration
{
    public static class GetXml
    {
        static string getXml<T>(T obj) where T : class
        {
            var xsSubmit = new XmlSerializer(typeof(T));

            using (var sww = new StringWriter())
            {
                using (XmlWriter writer = XmlWriter.Create(sww))
                {
                    xsSubmit.Serialize(writer, obj);
                    return sww.ToString();
                }
            }
        }
    }
}