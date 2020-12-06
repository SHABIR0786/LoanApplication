using System.Xml.Serialization;

namespace LoanManagement.CoreLogicModels.JointRequest
{

    [XmlRoot(ElementName = "RECEIVING_PARTY")]
    public class RecievingParty
    {
        [XmlAttribute(AttributeName = "_Name")]
        public string _Name { get; set; }
    }
}