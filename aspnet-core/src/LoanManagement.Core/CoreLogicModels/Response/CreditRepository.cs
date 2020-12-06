
using System.Xml.Serialization;

namespace LoanManagement.CoreLogicModels.Response
{

    [XmlRoot(ElementName = "CREDIT_REPOSITORY")]
    public class CreditRepository
    {
        [XmlAttribute(AttributeName = "_SourceType")]
        public string _SourceType { get; set; }
        [XmlAttribute(AttributeName = "_SubscriberCode")]
        public string _SubscriberCode { get; set; }
    }
}