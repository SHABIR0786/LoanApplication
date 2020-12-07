using System.Xml.Serialization;

namespace LoanManagement.CoreLogicModels.JointResponse
{

    [XmlRoot(ElementName = "_ALERT_MESSAGE")]
    public class AlertMessage
    {
        [XmlElement(ElementName = "_Text")]
        public string _Text { get; set; }
        [XmlAttribute(AttributeName = "_AdverseIndicator")]
        public string _AdverseIndicator { get; set; }
        [XmlAttribute(AttributeName = "_CategoryType")]
        public string _CategoryType { get; set; }
    }
}