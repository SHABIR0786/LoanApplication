using System.Xml.Serialization;

namespace LoanManagement.CoreLogicModels.IndividualRequest2
{

    [XmlRoot(ElementName = "_PAYMENT_PATTERN")]
    public class PaymentPattern
    {
        [XmlAttribute(AttributeName = "_Data")]
        public string _Data { get; set; }
        [XmlAttribute(AttributeName = "_StartDate")]
        public string _StartDate { get; set; }
    }
}