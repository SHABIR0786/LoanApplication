using Microsoft.AspNetCore.Mvc;
using LoanManagement.Features.CitizenshipType;
using LoanManagement.Services.Interface;

namespace LoanManagement.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class CitizenshipTypeController : ControllerBase
	{
		private readonly ICitizenshipTypeService _service;

		public CitizenshipTypeController(ICitizenshipTypeService CitizenshipTypeService)
		{
			_service = CitizenshipTypeService;
		}

		[HttpPost]
		[Route("add")]
		public string InsertCitizenshipType([FromBody] AddCitizenshipTypeRequest request)
		{
			return _service.AddCitizenshipType(request);
		}

		[HttpPost]
		[Route("Update")]
		public string UpdateCitizenshipType([FromBody] UpdateCitizenshipTypeRequest request)
		{
			return _service.UpdateCitizenshipType(request);
		}

		[HttpDelete]
		[Route("Delete")]
		public string DeleteCitizenshipType([FromQuery] int id)
		{
			return _service.DeleteCitizenshipType(id);
		}

		[HttpGet]
		[Route("citizenship-types")]
		public ActionResult GetCitizenshipTypes()
		{
			return Ok(_service.GetCitizenshipTypes());
		}

		[HttpGet]
		[Route("citizenship-type")]
		public ActionResult GetCitizenshipType([FromQuery] int id)
		{
			return Ok(_service.GetCitizenshipTypeById(id));
		}
	}
}
