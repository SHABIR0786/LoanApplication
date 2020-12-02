using System.Xml.Serialization;

namespace LoanManagement.CoreLogicModels.JointRequest
{
    [XmlRoot(ElementName = "REQUEST")]
    public class Request
    {
        [XmlElement(ElementName = "KEY")]
        public Key KEY { get; set; }
        [XmlElement(ElementName = "REQUEST_DATA")]
        public RequestData REQUEST_DATA { get; set; }
        [XmlAttribute(AttributeName = "LoginAccountIdentifier")]
        public string LoginAccountIdentifier { get; set; }
        [XmlAttribute(AttributeName = "LoginAccountPassword")]
        public string LoginAccountPassword { get; set; }
        [XmlAttribute(AttributeName = "RequestingPartyBranchIdentifier")]
        public string RequestingPartyBranchIdentifier { get; set; }
    }
}