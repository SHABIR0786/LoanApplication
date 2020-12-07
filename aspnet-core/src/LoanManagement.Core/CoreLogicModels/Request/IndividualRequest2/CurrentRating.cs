

using System.Xml.Serialization;

namespace LoanManagement.CoreLogicModels.IndividualRequest2
{
    [XmlRoot(ElementName = "_CURRENT_RATING")]
    public class CurrentRating
    {
        [XmlAttribute(AttributeName = "_Code")]
        public string _Code { get; set; }
        [XmlAttribute(AttributeName = "_Type")]
        public string _Type { get; set; }
    }
}