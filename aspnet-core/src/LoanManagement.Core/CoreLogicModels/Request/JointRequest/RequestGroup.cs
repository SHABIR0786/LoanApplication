
using System.Collections.Generic;
using System.Xml.Serialization;
namespace LoanManagement.CoreLogicModels.JointRequest
{
    [XmlRoot(ElementName = "REQUEST_GROUP")]
    public class RequestGroup
    {
        [XmlElement(ElementName = "REQUESTING_PARTY")]
        public RequestingParty REQUESTING_PARTY { get; set; }
        [XmlElement(ElementName = "RECEIVING_PARTY")]
        public RecievingParty RECEIVING_PARTY { get; set; }
        [XmlElement(ElementName = "SUBMITTING_PARTY")]
        public List<SubmittingParty> SUBMITTING_PARTY { get; set; }
        [XmlElement(ElementName = "REQUEST")]
        public Request REQUEST { get; set; }
        [XmlAttribute(AttributeName = "MISMOVersionID")]
        public string MISMOVersionID { get; set; } = "2.1";
    }
}