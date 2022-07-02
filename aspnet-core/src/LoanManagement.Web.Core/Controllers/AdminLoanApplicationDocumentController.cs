using LoanManagement.Features.AdminLoanApplicationDocument;
using LoanManagement.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LoanManagement.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AdminLoanApplicationDocumentController : LoanManagementControllerBase
	{
		private readonly IAdminLoanApplicationDocumentService _service;

		public AdminLoanApplicationDocumentController(IAdminLoanApplicationDocumentService service)
		{
			_service = service;
		}

		[HttpPost]
		[Route("Add")]
		public string Insert([FromBody] AddAdminLoanApplicationDocument request)
		{
			return _service.Add(request);
		}

		[HttpPost]
		[Route("Upload")]
		public string Upload([FromForm] UploadAdminLoanApplicationDocument request,IFormFile formFile)
		{
			return _service.UploadDocument(request, formFile);
		}

		[HttpPost]
		[Route("Update")]
		public string Update([FromBody] UpdateAdminLoanApplicationDocument request)
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
