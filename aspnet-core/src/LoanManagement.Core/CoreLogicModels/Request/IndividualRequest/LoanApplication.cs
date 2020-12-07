using System.Xml.Serialization;

namespace LoanManagement.CoreLogicModels.IndividualRequest
{

    [XmlRoot(ElementName = "LOAN_APPLICATION")]
    public class LoanApplication
    {
        [XmlElement(ElementName = "BORROWER")]
        public Borrower BORROWER { get; set; }
    }
}
