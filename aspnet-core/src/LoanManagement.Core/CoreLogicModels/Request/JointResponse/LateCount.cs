using System.Collections.Generic;
using System.Xml.Serialization;
namespace LoanManagement.CoreLogicModels.JointResponse
{

    [XmlRoot(ElementName = "_LATE_COUNT")]
    public class LateCount
    {
        [XmlElement(ElementName = "PERIODIC_LATE_COUNT")]
        public List<PeriodicLateCount> PERIODIC_LATE_COUNT { get; set; }
        [XmlAttribute(AttributeName = "_30Days")]
        public string _30Days { get; set; }
        [XmlAttribute(AttributeName = "_60Days")]
        public string _60Days { get; set; }
        [XmlAttribute(AttributeName = "_90Days")]
        public string _90Days { get; set; }
    }
}