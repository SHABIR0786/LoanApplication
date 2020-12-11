using System.Xml.Serialization;

namespace LoanManagement.CoreLogicModels.JointResponse
{

    [XmlRoot(ElementName = "RESPONSE_DATA")]
    public class ResponseData
    {
        [XmlElement(ElementName = "CREDIT_RESPONSE")]
        public CreditResponse CREDIT_RESPONSE { get; set; }
    }
}