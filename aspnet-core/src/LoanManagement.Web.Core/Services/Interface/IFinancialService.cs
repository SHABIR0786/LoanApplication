using LoanManagement.Features.Financial.AccountType;
using LoanManagement.Features.Financial.LaibilitiesType;
using LoanManagement.Features.Financial.OtherLaibilitiesType;
using LoanManagement.Features.Financial.PropertyIntendedOccupancy;
using LoanManagement.Features.Financial.PropertyStatus;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.Services.Interface
{
	public interface IFinancialService
	{
		string AddFinancialPropertyStatus(AddPropertyStatusRequest request);
		string UpdateFinancialPropertyStatus(UpdatePropertyStatusRequest request);
		string DeleteFinancialPropertyStatus(int id);
		List<UpdatePropertyStatusRequest> GetFinancialPropertyStatuses();
		UpdatePropertyStatusRequest GetFinancialPropertyStatusById(int id);

		string AddFinancialPropertyIntendedOccupancy(AddPropertyIntendedOccupancyRequest request);
		string UpdateFinancialPropertyIntendedOccupancy(UpdatePropertyIntendedOccupancyRequest request);
		string DeleteFinancialPropertyIntendedOccupancy(int id);
		List<UpdatePropertyIntendedOccupancyRequest> GetFinancialPropertyIntendedOccupancies();
		UpdatePropertyIntendedOccupancyRequest GetFinancialPropertyIntendedOccupancyById(int id);

		string AddFinancialOtherLaibilitiesType(AddOtherLaibilitiesTypeRequest request);
		string UpdateFinancialOtherLaibilitiesType(UpdateOtherLaibilitiesTypeRequest request);
		string DeleteFinancialOtherLaibilitiesType(int id);
		List<UpdateOtherLaibilitiesTypeRequest> GetFinancialOtherLaibilitiesTypes();
		UpdateOtherLaibilitiesTypeRequest GetFinancialOtherLaibilitiesTypeById(int id);

		string AddFinancialLaibilitiesType(AddLaibilitiesTypeRequest request);
		string UpdateFinancialLaibilitiesType(UpdateLaibilitiesTypeRequest request);
		string DeleteFinancialLaibilitiesType(int id);
		List<UpdateLaibilitiesTypeRequest> GetFinancialLaibilitiesTypes();
		UpdateLaibilitiesTypeRequest GetFinancialLaibilitiesTypeById(int id);

		string AddFinancialAccountType(AddAccountTypeRequest request);
		string UpdateFinancialAccountType(UpdateAccountTypeRequest request);
		string DeleteFinancialAccountType(int id);
		List<UpdateAccountTypeRequest> GetFinancialAccountTypes();
		UpdateAccountTypeRequest GetFinancialAccountTypeById(int id);
	}
}
