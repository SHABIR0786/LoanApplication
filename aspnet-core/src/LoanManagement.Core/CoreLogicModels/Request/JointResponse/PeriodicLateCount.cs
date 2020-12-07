using System.Xml.Serialization;

namespace LoanManagement.CoreLogicModels.JointResponse
{

    [XmlRoot(ElementName = "PERIODIC_LATE_COUNT")]
    public class PeriodicLateCount
    {
        [XmlAttribute(AttributeName = "_Type")]
        public string _Type { get; set; }
        [XmlAttribute(AttributeName = "_60Days")]
        public string _60Days { get; set; }
        [XmlAttribute(AttributeName = "_90Days")]
        public string _90Days { get; set; }
        [XmlAttribute(AttributeName = "_30Days")]
        public string _30Days { get; set; }
    }
}