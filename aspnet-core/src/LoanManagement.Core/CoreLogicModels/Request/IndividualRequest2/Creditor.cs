
using System.Xml.Serialization;

namespace LoanManagement.CoreLogicModels.IndividualRequest2
{
    [XmlRoot(ElementName = "_CREDITOR")]
    public class Creditor
    {
        [XmlAttribute(AttributeName = "_Name")]
        public string _Name { get; set; }
    }
}
