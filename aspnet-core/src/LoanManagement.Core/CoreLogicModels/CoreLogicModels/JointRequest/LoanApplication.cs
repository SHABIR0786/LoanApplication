using System.Xml.Serialization;
using System.Collections.Generic;
namespace LoanManagement.CoreLogicModels.JointRequest
{

    [XmlRoot(ElementName = "LOAN_APPLICATION")]
    public class LoanApplication
    {
        [XmlElement(ElementName = "BORROWER")]
        public List<Borrower> BORROWER { get; set; }
    }
}
