using LoanManagement.Features.IncomeType;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.Services.Interface
{
	public interface IIncomeTypeService
	{
		string AddIncomeType(AddIncomeTypeRequest request);
		string UpdateIncomeType(UpdateIncomeTypeRequest request);
		string DeleteIncomeType(int id);
		List<UpdateIncomeTypeRequest> GetIncomeTypes();
		UpdateIncomeTypeRequest GetIncomeTypeById(int id);
	}
}
