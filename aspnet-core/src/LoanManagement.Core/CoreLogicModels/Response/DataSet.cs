
using System.Xml.Serialization;

namespace LoanManagement.CoreLogicModels.sResponse
{

    [XmlRoot(ElementName = "_DATA_SET")]
    public class DataSet
    {
        [XmlAttribute(AttributeName = "_Name")]
        public string _Name { get; set; }
        [XmlAttribute(AttributeName = "_Value")]
        public string _Value { get; set; }
    }
}
