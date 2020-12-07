using System.Xml.Serialization;

namespace LoanManagement.CoreLogicModels.Response
{

    [XmlRoot(ElementName = "_ALIAS")]
    public class Alias
    {
        [XmlAttribute(AttributeName = "_FirstName")]
        public string _FirstName { get; set; }
        [XmlAttribute(AttributeName = "_LastName")]
        public string _LastName { get; set; }
        [XmlAttribute(AttributeName = "_MiddleName")]
        public string _MiddleName { get; set; }
    }
}