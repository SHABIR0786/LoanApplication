using System.Xml.Serialization;

namespace LoanManagement.CoreLogicModels.JointResponse
{

    [XmlRoot(ElementName = "_MOST_RECENT_ADVERSE_RATING")]
    public class MostRecentAdverseRating
    {
        [XmlAttribute(AttributeName = "_Code")]
        public string _Code { get; set; }
        [XmlAttribute(AttributeName = "_Type")]
        public string _Type { get; set; }
        [XmlAttribute(AttributeName = "_Date")]
        public string _Date { get; set; }
    }
}