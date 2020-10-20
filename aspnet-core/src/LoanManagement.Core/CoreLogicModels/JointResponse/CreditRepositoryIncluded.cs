using System.Xml.Serialization;

namespace LoanManagement.CoreLogicModels.JointResponse{

[XmlRoot(ElementName="CREDIT_REPOSITORY_INCLUDED")]
	public class CreditRepositoryIncluded {
		[XmlAttribute(AttributeName="_EquifaxIndicator")]
		public string _EquifaxIndicator { get; set; }
		[XmlAttribute(AttributeName="_ExperianIndicator")]
		public string _ExperianIndicator { get; set; }
		[XmlAttribute(AttributeName="_TransUnionIndicator")]
		public string _TransUnionIndicator { get; set; }
		[XmlAttribute(AttributeName="_OtherRepositoryName")]
		public string _OtherRepositoryName { get; set; }
	}}