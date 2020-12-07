using System.Xml.Serialization;

namespace LoanManagement.CoreLogicModels.IndividualRequest
{

    [XmlRoot(ElementName = "CREDIT_REQUEST")]
    public class CreditRequest
    {
        [XmlElement(ElementName = "CREDIT_REQUEST_DATA")]
        public CreditRequestData CREDIT_REQUEST_DATA { get; set; }
        [XmlElement(ElementName = "LOAN_APPLICATION")]
        public LoanApplication LOAN_APPLICATION { get; set; }
        [XmlAttribute(AttributeName = "MISMOVersionID")]
        public string MISMOVersionID { get; set; }
        [XmlAttribute(AttributeName = "LenderCaseIdentifier")]
        public string LenderCaseIdentifier { get; set; }
        [XmlAttribute(AttributeName = "RequestingPartyRequestedByName")]
        public string RequestingPartyRequestedByName { get; set; }
    }
}