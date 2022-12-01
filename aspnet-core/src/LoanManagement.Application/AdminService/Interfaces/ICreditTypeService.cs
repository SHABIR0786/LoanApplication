using LoanManagement.Features.CreditType;
using System.Collections.Generic;
using System.Linq;

namespace LoanManagement.Services.Interface
{
	public interface ICreditTypeService
	{
		string AddCreditType(AddCreditTypeRequest request);
		string UpdateCreditType(UpdateCreditTypeRequest request);
		string DeleteCreditType(int id);
		List<UpdateCreditTypeRequest> GetCreditTypes();
		UpdateCreditTypeRequest GetCreditTypeById(int id);
	}
}
