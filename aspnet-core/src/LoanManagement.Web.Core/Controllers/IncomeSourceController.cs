using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LoanManagement.Features.IncomeSource;
using LoanManagement.Services.Interface;

namespace LoanManagement.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class IncomeSourceController : ControllerBase
	{
		private readonly IIncomeSourceService _service;

		public IncomeSourceController(IIncomeSourceService IncomeSourceService)
		{
			_service = IncomeSourceService;
		}

		[HttpPost]
		[Route("add")]
		public string InsertIncomeSource([FromBody] AddIncomeSourceRequest IncomeSourceRequest)
		{
			return _service.AddIncomeSource(IncomeSourceRequest);
		}

		[HttpPost]
		[Route("Update")]
		public string UpdateIncomeSource([FromBody] UpdateIncomeSourceRequest IncomeSourceRequest)
		{
			return _service.UpdateIncomeSource(IncomeSourceRequest);
		}

		[HttpDelete]
		[Route("Delete")]
		public string DeleteIncomeSource([FromQuery] int id)
		{
			return _service.DeleteIncomeSource(id);
		}

		[HttpGet]
		[Route("income-sources")]
		public ActionResult GetIncomeSources()
		{
			return Ok(_service.GetIncomeSources());
		}

		[HttpGet]
		[Route("income-source")]
		public ActionResult GetIncomeSource([FromQuery] int id)
		{
			return Ok(_service.GetIncomeSourceById(id));
		}
	}
}
