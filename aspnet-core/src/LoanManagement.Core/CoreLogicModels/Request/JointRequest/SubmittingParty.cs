using System.Xml.Serialization;


namespace LoanManagement.CoreLogicModels.JointRequest
{


    [XmlRoot(ElementName = "SUBMITTING_PARTY")]
    public class SubmittingParty
    {
        [XmlAttribute(AttributeName = "_Name")]
        public string _Name { get; set; }
        [XmlAttribute(AttributeName = "_Identifier")]
        public string _Identifier { get; set; } = "EOM";

        [XmlAttribute(AttributeName = "_StreetAddress")]
        public string _StreetAddress { get; set; }

        [XmlAttribute(AttributeName = "_State")]
        public string _State { get; set; }


        [XmlAttribute(AttributeName = "_PostalCode")]
        public string _PostalCode { get; set; }


        [XmlAttribute(AttributeName = "_City")]
        public string _City { get; set; }
    }
}