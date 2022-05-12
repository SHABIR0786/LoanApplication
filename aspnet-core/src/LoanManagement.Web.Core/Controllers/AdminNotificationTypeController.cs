using LoanManagement.Features.AdminNotificationType;
using LoanManagement.Services.Implementation;
using LoanManagement.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace LoanManagement.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AdminNotificationTypeController : LoanManagementControllerBase
	{
		private readonly IAdminNotificationTypeService _service;

		public AdminNotificationTypeController(IAdminNotificationTypeService service)
		{
			_service = service;
		}

		[HttpPost]
		[Route("Add")]
		public string Insert([FromBody] AddAdminNotificationType request)
		{
			return _service.Add(request);
		}

		[HttpPost]
		[Route("Update")]
		public string Update([FromBody] UpdateAdminNotificationType request)
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