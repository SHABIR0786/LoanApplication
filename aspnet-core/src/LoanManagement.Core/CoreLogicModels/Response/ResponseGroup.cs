
using System.Xml.Serialization;

namespace LoanManagement.CoreLogicModels.JointResponse
{

    [XmlRoot(ElementName = "RESPONSE_GROUP")]
    public class ResponseGroup
    {
        [XmlElement(ElementName = "RESPONDING_PARTY")]
        public RespondingParty RESPONDING_PARTY { get; set; }
        [XmlElement(ElementName = "RESPOND_TO_PARTY")]
        public RespondToParty RESPOND_TO_PARTY { get; set; }
        [XmlElement(ElementName = "RESPONSE")]
        public Response RESPONSE { get; set; }
        [XmlAttribute(AttributeName = "MISMOVersionID")]
        public string MISMOVersionID { get; set; }
        [XmlAttribute(AttributeName = "_ID")]
        public string _ID { get; set; }
    }
}