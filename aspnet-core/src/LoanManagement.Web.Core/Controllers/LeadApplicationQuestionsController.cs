using LoanManagement.Features.LeadApplicationQuestions;
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
    public class LeadApplicationQuestionsController : LoanManagementControllerBase
    {
        private readonly ILeadApplicationQuestionService _service;

		public LeadApplicationQuestionsController(ILeadApplicationQuestionService service)
		{
			_service = service;
		}

		[HttpPost]
		[Route("Add")]
		public string Insert([FromBody] AddLeadApplicationQuestions request)
		{
			return _service.Add(request);
		}

		[HttpPost]
		[Route("Update")]
		public string Update([FromBody] UpdateLeadApplicationQuestions request)
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
