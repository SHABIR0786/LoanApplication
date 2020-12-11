using System.Xml.Serialization;

namespace LoanManagement.CoreLogicModels.JointResponse
{

    [XmlRoot(ElementName = "REGULATORY_PRODUCT")]
    public class RegulatoryProduct
    {
        [XmlAttribute(AttributeName = "BorrowerID")]
        public string BorrowerID { get; set; }
        [XmlAttribute(AttributeName = "CreditRepositorySourceType")]
        public string CreditRepositorySourceType { get; set; }
        [XmlAttribute(AttributeName = "CreditRepositorySourceTypeOtherDescription")]
        public string CreditRepositorySourceTypeOtherDescription { get; set; }
        [XmlAttribute(AttributeName = "_SourceType")]
        public string _SourceType { get; set; }
        [XmlAttribute(AttributeName = "_ProviderDescription")]
        public string _ProviderDescription { get; set; }
        [XmlAttribute(AttributeName = "_ResultText")]
        public string _ResultText { get; set; }
        [XmlAttribute(AttributeName = "_ResultStatusType")]
        public string _ResultStatusType { get; set; }
    }
}