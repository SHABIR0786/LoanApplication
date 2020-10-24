using System.Xml.Serialization;


namespace LoanManagement.CoreLogicModels.JointRequest{


[XmlRoot(ElementName="SUBMITTING_PARTY")]
	public class SubmittingParty {
		[XmlAttribute(AttributeName="_Name")]
		public string _Name { get; set; }
		[XmlAttribute(AttributeName="_Identifier")]
		public string _Identifier { get; set; }
	}}