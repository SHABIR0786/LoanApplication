using LoanManagement.Features.IncomeSource;
using System.Collections.Generic;

namespace LoanManagement.Services.Interface
{
	public interface IIncomeSourceService
	{
		string AddIncomeSource(AddIncomeSourceRequest request);
		string UpdateIncomeSource(UpdateIncomeSourceRequest request);
		string DeleteIncomeSource(int id);
		List<UpdateIncomeSourceRequest> GetIncomeSources();
		UpdateIncomeSourceRequest GetIncomeSourceById(int id);
	}
}
