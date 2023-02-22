using LoanManagement.Features.CitizenshipType;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.Services.Interface
{
	public interface ICitizenshipTypeService
	{
		string AddCitizenshipType(AddCitizenshipTypeRequest request);
		string UpdateCitizenshipType(UpdateCitizenshipTypeRequest request);
		string DeleteCitizenshipType(int id);
		List<UpdateCitizenshipTypeRequest> GetCitizenshipTypes();
		UpdateCitizenshipTypeRequest GetCitizenshipTypeById(int id);
	}
}
