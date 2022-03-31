using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LoanManagement.Features.MaritalStatus;
using LoanManagement.Services.Interface;

namespace LoanManagement.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class MaritalStatusController : ControllerBase
	{
		private readonly IMaritalStatusService _service;

		public MaritalStatusController(IMaritalStatusService MaritalStatusService)
		{
			_service = MaritalStatusService;
		}

		[HttpPost]
		[Route("add")]
		public string InsertMaritalStatus([FromBody] AddMaritalStatusRequest request)
		{
			return _service.AddMaritalStatus(request);
		}

		[HttpPost]
		[Route("Update")]
		public string UpdateMaritalStatus([FromBody] UpdateMaritalStatusRequest request)
		{
			return _service.UpdateMaritalStatus(request);
		}

		[HttpDelete]
		[Route("Delete")]
		public string DeleteMaritalStatus([FromQuery] int id)
		{
			return _service.DeleteMaritalStatus(id);
		}

		[HttpGet]
		[Route("Marital-Statuses")]
		public ActionResult GetMaritalStatuses()
		{
			return Ok(_service.GetMaritalStatuses());
		}

		[HttpGet]
		[Route("Marital-Status")]
		public ActionResult GetMaritalStatus([FromQuery] int id)
		{
			return Ok(_service.GetMaritalStatusById(id));
		}
	}
}
