using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LoanManagement.Features.City;
using LoanManagement.Services.Interface;

namespace LoanManagement.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class CityController : ControllerBase
	{
		private readonly ICityService _service;

		public CityController(ICityService CityService)
		{
			_service = CityService;
		}

		[HttpPost]
		[Route("add")]
		public string InsertCity([FromBody] AddCityRequest request)
		{
			return _service.AddCity(request);
		}

		[HttpPost]
		[Route("Update")]
		public string UpdateCity([FromBody] UpdateCityRequest  request)
		{
			return _service.UpdateCity(request);
		}

		[HttpDelete]
		[Route("Delete")]
		public string DeleteCity([FromQuery] int id)
		{
			return _service.DeleteCity(id);
		}

		[HttpGet]
		[Route("cities")]
		public ActionResult GetCities()
		{
			return Ok(_service.GetCities());
		}

		[HttpGet]
		[Route("city")]
		public ActionResult GetCity([FromQuery] int id)
		{
			return Ok(_service.GetCityById(id));
		}
	}
}
