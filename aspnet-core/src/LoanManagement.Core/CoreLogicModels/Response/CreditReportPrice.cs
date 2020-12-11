
using System.Xml.Serialization;

namespace LoanManagement.CoreLogicModels.Response
{

    [XmlRoot(ElementName = "CREDIT_REPORT_PRICE")]
    public class CreditReportPrice
    {
        [XmlAttribute(AttributeName = "_Type")]
        public string _Type { get; set; }
        [XmlAttribute(AttributeName = "_TypeOtherDescription")]
        public string _TypeOtherDescription { get; set; }
    }
}