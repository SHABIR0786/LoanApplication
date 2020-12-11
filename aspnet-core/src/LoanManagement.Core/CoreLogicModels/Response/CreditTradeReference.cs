using System.Xml.Serialization;

namespace LoanManagement.CoreLogicModels.Response
{

    [XmlRoot(ElementName = "CREDIT_TRADE_REFERENCE")]
    public class CreditTradeReference
    {
        [XmlElement(ElementName = "CONTACT_DETAIL")]
        public ContactDetail CONTACT_DETAIL { get; set; }
        [XmlElement(ElementName = "CREDIT_REPOSITORY")]
        public CreditRepository CREDIT_REPOSITORY { get; set; }
        [XmlAttribute(AttributeName = "CreditTradeReferenceID")]
        public string CreditTradeReferenceID { get; set; }
        [XmlAttribute(AttributeName = "_Name")]
        public string _Name { get; set; }
        [XmlAttribute(AttributeName = "_StreetAddress")]
        public string _StreetAddress { get; set; }
        [XmlAttribute(AttributeName = "_City")]
        public string _City { get; set; }
        [XmlAttribute(AttributeName = "_State")]
        public string _State { get; set; }
        [XmlAttribute(AttributeName = "_PostalCode")]
        public string _PostalCode { get; set; }
    }
}