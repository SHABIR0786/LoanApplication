using LoanManagement.Features.HousingType;
using System.Collections.Generic;

namespace LoanManagement.Services.Interface
{
	public interface IHousingTypeService
	{
		string AddHousingType(AddHousingTypeRequest request);
		string UpdateHousingType(UpdateHousingTypeRequest request);
		string DeleteHousingType(int id);
		List<UpdateHousingTypeRequest> GetHousingTypes();
		UpdateHousingTypeRequest GetHousingTypeById(int id);
	}
}
