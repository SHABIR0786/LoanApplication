using System.Xml.Serialization;

namespace LoanManagement.CoreLogicModels.IndividualRequest
{

    [XmlRoot(ElementName = "REQUEST_GROUP")]
    public class REQUEST_GROUP
    {
        [XmlElement(ElementName = "REQUESTING_PARTY")]
        public RecievingParty REQUESTING_PARTY { get; set; }
        [XmlElement(ElementName = "RECEIVING_PARTY")]
        public RecievingParty RECEIVING_PARTY { get; set; }
        [XmlElement(ElementName = "SUBMITTING_PARTY")]
        public SubmittingParty SUBMITTING_PARTY { get; set; }
        [XmlElement(ElementName = "REQUEST")]
        public Request REQUEST { get; set; }
        [XmlAttribute(AttributeName = "MISMOVersionID")]
        public string MISMOVersionID { get; set; }
    }
}
