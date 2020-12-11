
using System.Xml.Serialization;

namespace LoanManagement.CoreLogicModels.IndividualRequest2
{


    [XmlRoot(ElementName = "RESPONSE_GROUP")]
    public class RESPONSE_GROUP
    {
        [XmlElement(ElementName = "RESPONDING_PARTY")]
        public RespondingParty RESPONDING_PARTY { get; set; }
        [XmlElement(ElementName = "RESPOND_TO_PARTY")]
        public RespondToParty RESPOND_TO_PARTY { get; set; }
        [XmlElement(ElementName = "RESPONSE")]
        public RESPONSE RESPONSE { get; set; }
        [XmlAttribute(AttributeName = "MISMOVersionID")]
        public string MISMOVersionID { get; set; }
        [XmlAttribute(AttributeName = "_ID")]
        public string _ID { get; set; }
    }
}