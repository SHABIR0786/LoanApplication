using System.Xml.Serialization;

namespace LoanManagement.CoreLogicModels.IndividualRequest
{

    [XmlRoot(ElementName = "REQUEST_DATA")]
    public class RequestData
    {
        [XmlElement(ElementName = "CREDIT_REQUEST")]
        public CreditRequest CREDIT_REQUEST { get; set; }
    }
}
