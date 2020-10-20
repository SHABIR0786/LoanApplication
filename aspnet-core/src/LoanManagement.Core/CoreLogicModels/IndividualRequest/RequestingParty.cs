using System.Xml.Serialization;
using System.Collections.Generic;
namespace LoanManagement.CoreLogicModels.IndividualRequest{

[XmlRoot(ElementName="REQUESTING_PARTY")]
	public class RequestingParty {
		[XmlElement(ElementName="PREFERRED_RESPONSE")]
		public List<PreferredResponse> PREFERRED_RESPONSE { get; set; }
	}
}
