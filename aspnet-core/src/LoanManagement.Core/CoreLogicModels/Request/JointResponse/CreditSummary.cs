using System.Collections.Generic;
using System.Xml.Serialization;
namespace LoanManagement.CoreLogicModels.JointResponse
{

    [XmlRoot(ElementName = "CREDIT_SUMMARY")]
    public class CreditSummary
    {
        [XmlElement(ElementName = "_DATA_SET")]
        public List<DataSet> _DATA_SET { get; set; }
        [XmlElement(ElementName = "_Text")]
        public List<string> _Text { get; set; }
        [XmlAttribute(AttributeName = "_Name")]
        public string _Name { get; set; }
        [XmlAttribute(AttributeName = "BorrowerID")]
        public string BorrowerID { get; set; }
    }
}