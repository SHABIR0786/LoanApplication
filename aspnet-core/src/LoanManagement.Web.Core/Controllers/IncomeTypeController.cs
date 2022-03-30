using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LoanManagement.Features.IncomeType;
using LoanManagement.Services.Interface;

namespace LoanManagement.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class IncomeTypeController : ControllerBase
	{
		private readonly IIncomeTypeService _service;

		public IncomeTypeController(IIncomeTypeService IncomeTypeService)
		{
			_service = IncomeTypeService;
		}

		[HttpPost]
		[Route("add")]
		public string InsertIncomeType([FromBody] AddIncomeTypeRequest request)
		{
			return _service.AddIncomeType(request);
		}

		[HttpPost]
		[Route("Update")]
		public string UpdateIncomeType([FromBody] UpdateIncomeTypeRequest request)
		{
			return _service.UpdateIncomeType(request);
		}

		[HttpDelete]
		[Route("Delete")]
		public string DeleteIncomeType([FromQuery] int id)
		{
			return _service.DeleteIncomeType(id);
		}

		[HttpGet]
		[Route("Income-types")]
		public ActionResult GetIncomeTypes()
		{
			return Ok(_service.GetIncomeTypes());
		}

		[HttpGet]
		[Route("Income-type")]
		public ActionResult GetIncomeType([FromQuery] int id)
		{
			return Ok(_service.GetIncomeTypeById(id));
		}
	}
}
