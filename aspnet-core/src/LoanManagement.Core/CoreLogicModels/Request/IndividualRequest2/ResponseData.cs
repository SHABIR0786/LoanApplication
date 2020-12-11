

using System.Xml.Serialization;

namespace LoanManagement.CoreLogicModels.IndividualRequest2
{
    [XmlRoot(ElementName = "RESPONSE_DATA")]
    public class ResponseData
    {
        [XmlElement(ElementName = "CREDIT_RESPONSE")]
        public CREDIT_RESPONSE CREDIT_RESPONSE { get; set; }
    }
}