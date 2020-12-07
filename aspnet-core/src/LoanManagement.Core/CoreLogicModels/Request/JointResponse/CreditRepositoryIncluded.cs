using System.Xml.Serialization;

namespace LoanManagement.CoreLogicModels.JointResponse
{

    [XmlRoot(ElementName = "CREDIT_REPOSITORY_INCLUDED")]
    public class CreditRepositoryIncluded
    {

        [XmlAttribute(AttributeName = "_EquifaxIndicator")]
        public string _EquifaxIndicator { get; set; }
        /// <summary>
        ///  Set _ExperianIndicator to “Y” or “N”.
        /// </summary>
        [XmlAttribute(AttributeName = "_ExperianIndicator")]
        public string _ExperianIndicator { get; set; }
        /// <summary>
        ///  Set _TransUnionIndicator to “Y” or “N”.
        /// </summary>
        [XmlAttribute(AttributeName = "_TransUnionIndicator")]
        public string _TransUnionIndicator { get; set; }

        [XmlAttribute(AttributeName = "_OtherRepositoryName")]
        public string _OtherRepositoryName { get; set; } = "CoreLogic Credco";

    }
}