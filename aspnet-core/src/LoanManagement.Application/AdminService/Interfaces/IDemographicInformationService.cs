using LoanManagement.Features.DemographicInformation;
using System.Collections.Generic;

namespace LoanManagement.Services.Interface
{
	public interface IDemographicInformationService
	{
		string AddDemographicInfoSource(AddDemographicInfoSourceRequest request);
		string UpdateDemographicInfoSource(UpdateDemographicInfoSourceRequest request);
		string DeleteDemographicInfoSource(int id);
		List<UpdateDemographicInfoSourceRequest> GetDemographicInfoSources();
		UpdateDemographicInfoSourceRequest GetDemographicInfoSourceById(int id);
		string AddDemographicInformation(AddDemographicInformationRequest request);
		string UpdateDemographicInformation(UpdateDemographicInformationRequest request);
		string DeleteDemographicInformation(int id);
		List<UpdateDemographicInformationRequest> GetDemographicInformations();
		UpdateDemographicInformationRequest GetDemographicInformationById(int id);
	}
}
