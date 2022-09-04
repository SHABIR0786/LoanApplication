using Abp;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Notifications;
using Abp.Timing;
using LoanManagement.Features.AdminLoanApplicationDocument;
using LoanManagement.Models;
using LoanManagement.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace LoanManagement.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AdminLoanApplicationDocumentController : LoanManagementControllerBase
    {
		private readonly IAdminLoanApplicationDocumentService _service;
		private readonly INotificationPublisher _notificationPublisher;

		public AdminLoanApplicationDocumentController(IAdminLoanApplicationDocumentService service, INotificationPublisher notificationPublisher)
		{
			_service = service;
			_notificationPublisher = notificationPublisher;
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
        [HttpPost]
        [Route("SendNotificationsAsync")]
        public Task SendNotificationsAsync(UserNotification[] userNotifications)
		{
			throw new NotImplementedException();
		}
	}
}
