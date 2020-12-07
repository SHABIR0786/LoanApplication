
using System.Xml.Serialization;

namespace LoanManagement.CoreLogicModels.IndividualRequest2
{

    [XmlRoot(ElementName = "_LATE_COUNT")]
    public class LateCount
    {
        [XmlAttribute(AttributeName = "_30Days")]
        public string _30Days { get; set; }
        [XmlAttribute(AttributeName = "_60Days")]
        public string _60Days { get; set; }
        [XmlAttribute(AttributeName = "_90Days")]
        public string _90Days { get; set; }
    }
}