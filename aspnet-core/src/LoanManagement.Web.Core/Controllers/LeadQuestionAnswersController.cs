using LoanManagement.Features.LeadQuestionAnswers;
using LoanManagement.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeadQuestionAnswersController : LoanManagementControllerBase
    {
        private readonly ILeadQuestionAnswersService _service;

		public LeadQuestionAnswersController(ILeadQuestionAnswersService service)
		{
			_service = service;
		}

		[HttpPost]
		[Route("Add")]
		public string Insert([FromBody] AddLeadQuestionAnswers request)
		{
			return _service.Add(request);
		}

		[HttpPost]
		[Route("Update")]
		public string Update([FromBody] UpdateLeadQuestionAnswers request)
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
