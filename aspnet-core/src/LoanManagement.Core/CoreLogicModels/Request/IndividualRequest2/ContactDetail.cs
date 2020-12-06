using System.Collections.Generic;
using System.Xml.Serialization;

namespace LoanManagement.CoreLogicModels.IndividualRequest2
{

    [XmlRoot(ElementName = "CONTACT_DETAIL")]
    public class ContactDetail
    {
        [XmlElement(ElementName = "CONTACT_POINT")]
        public List<ContactPoint> CONTACT_POINT { get; set; }
        [XmlAttribute(AttributeName = "_Name")]
        public string _Name { get; set; }
    }
}