using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LoanManagement.Features.HousingType;
using LoanManagement.Services.Interface;

namespace LoanManagement.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class HousingTypeController : ControllerBase
	{
		private readonly IHousingTypeService _service;

		public HousingTypeController(IHousingTypeService HousingTypeService)
		{
			_service = HousingTypeService;
		}

		[HttpPost]
		[Route("add")]
		public string InsertHousingType([FromBody] AddHousingTypeRequest request)
		{
			return _service.AddHousingType(request);
		}

		[HttpPost]
		[Route("Update")]
		public string UpdateHousingType([FromBody] UpdateHousingTypeRequest request)
		{
			return _service.UpdateHousingType(request);
		}

		[HttpDelete]
		[Route("Delete")]
		public string DeleteHousingType([FromQuery] int id)
		{
			return _service.DeleteHousingType(id);
		}

		[HttpGet]
		[Route("housing-types")]
		public ActionResult GetHousingTypes()
		{
			return Ok(_service.GetHousingTypes());
		}

		[HttpGet]
		[Route("housing-type")]
		public ActionResult GetHousingType([FromQuery] int id)
		{
			return Ok(_service.GetHousingTypeById(id));
		}
	}
}
