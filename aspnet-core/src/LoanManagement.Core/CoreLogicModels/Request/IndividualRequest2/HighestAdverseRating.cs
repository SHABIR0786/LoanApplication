using System.Xml.Serialization;

namespace LoanManagement.CoreLogicModels.IndividualRequest2
{

    [XmlRoot(ElementName = "_HIGHEST_ADVERSE_RATING")]
    public class HighestAdverseRating
    {
        [XmlAttribute(AttributeName = "_Code")]
        public string _Code { get; set; }
        [XmlAttribute(AttributeName = "_Date")]
        public string _Date { get; set; }
        [XmlAttribute(AttributeName = "_Type")]
        public string _Type { get; set; }
    }
}