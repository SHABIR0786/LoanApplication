using System.Xml.Serialization;
using System.Collections.Generic;
namespace LoanManagement.CoreLogicModels.JointResponse{

	[XmlRoot(ElementName="CONTACT_DETAIL")]
	public class ContactDetails {
		[XmlElement(ElementName="CONTACT_POINT")]
		public List<ContactPoint> CONTACT_POINT { get; set; }
		[XmlAttribute(AttributeName="_Name")]
		public string _Name { get; set; }
	}}