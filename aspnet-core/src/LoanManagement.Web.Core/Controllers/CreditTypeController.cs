using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LoanManagement.Features.CreditType;
using LoanManagement.Services.Interface;

namespace LoanManagement.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CreditTypeController : LoanManagementControllerBase
	{
		private readonly ICreditTypeService _service;

		public CreditTypeController(ICreditTypeService creditTypeService)
		{
			_service = creditTypeService;
		}

		[HttpPost]
		[Route("add")]
		public string InsertCreditType([FromBody] AddCreditTypeRequest creditTypeRequest)
		{
			return _service.AddCreditType(creditTypeRequest);
		}

		[HttpPost]
		[Route("Update")]
		public string UpdateCreditType([FromBody] UpdateCreditTypeRequest creditTypeRequest)
		{
			return _service.UpdateCreditType(creditTypeRequest);
		}

		[HttpDelete]
		[Route("Delete")]
		public string DeleteCreditType([FromQuery] int id)
		{
			return _service.DeleteCreditType(id);
		}

		[HttpGet]
		[Route("credit-types")]
		public ActionResult GetCreditTypes()
		{
			return Ok(_service.GetCreditTypes());
		}

		[HttpGet]
		[Route("credit-type")]
		public ActionResult GetCreditType([FromQuery] int id)
		{
			return Ok(_service.GetCreditTypeById(id));
		}
	}
}
