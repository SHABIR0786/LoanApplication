using LoanManagement.Features.AdminLoanProgram;
using LoanManagement.Services.Implementation;
using LoanManagement.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace LoanManagement.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AdminLoanProgramController : LoanManagementControllerBase
	{
		private readonly IAdminLoanProgramService _service;

		public AdminLoanProgramController(IAdminLoanProgramService service)
		{
			_service = service;
		}

		[HttpPost]
		[Route("Add")]
		public string Insert([FromBody] AddAdminLoanProgram request)
		{
			return _service.Add(request);
		}

		[HttpPost]
		[Route("Update")]
		public string Update([FromBody] UpdateAdminLoanProgram request)
		{
			return _service.Update(request);
		}

		[HttpDelete]
		[Route("Delete")]
		public string Delete([FromQuery] int id)
		{
			return _service.Delete(id);
		}

		[HttpGet]
		[Route("GetAll")]
		public ActionResult GetAll()
		{
			return Ok(_service.GetAll());
		}

		[HttpGet]
		[Route("GetById")]
		public ActionResult GetById([FromQuery] int id)
		{
			return Ok(_service.GetById(id));
		}
	}
}