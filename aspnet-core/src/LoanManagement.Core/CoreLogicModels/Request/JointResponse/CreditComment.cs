using System.Xml.Serialization;

namespace LoanManagement.CoreLogicModels.JointResponse
{

    [XmlRoot(ElementName = "CREDIT_COMMENT")]
    public class CreditComment
    {
        [XmlElement(ElementName = "_Text")]
        public string _Text { get; set; }
        [XmlAttribute(AttributeName = "_Code")]
        public string _Code { get; set; }
        [XmlAttribute(AttributeName = "_ReportedDate")]
        public string _ReportedDate { get; set; }
        [XmlAttribute(AttributeName = "_SourceType")]
        public string _SourceType { get; set; }
        [XmlAttribute(AttributeName = "_Type")]
        public string _Type { get; set; }
        [XmlAttribute(AttributeName = "_TypeOtherDescription")]
        public string _TypeOtherDescription { get; set; }
    }
}