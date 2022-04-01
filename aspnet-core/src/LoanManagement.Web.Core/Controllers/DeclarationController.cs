using Microsoft.AspNetCore.Mvc;
using LoanManagement.Features.Declaration.DeclarationCategory;
using LoanManagement.Features.Declaration.DeclarationQuestion;
using LoanManagement.Services.Interface;

namespace LoanManagement.Controllers
{
    [Route("[controller]")]
	[ApiController]
	public class DeclarationController : ControllerBase
	{
		private readonly IDeclarationService _service;

		public DeclarationController(IDeclarationService DeclarationService)
		{
			_service = DeclarationService;
		}

		[HttpPost]
		[Route("category/add")]
		public string InsertDeclarationCategory([FromBody] AddDeclarationCategoryRequest request)
		{
			return _service.AddDeclarationCategory(request);
		}

		[HttpPost]
		[Route("category/Update")]
		public string UpdateDeclarationCategory([FromBody] UpdateDeclarationCategoryRequest request)
		{
			return _service.UpdateDeclarationCategory(request);
		}

		[HttpDelete]
		[Route("category/Delete")]
		public string DeleteDeclarationCategory([FromQuery] int id)
		{
			return _service.DeleteDeclarationCategory(id);
		}

		[HttpGet]
		[Route("categories")]
		public ActionResult GetDeclarationCategorys()
		{
			return Ok(_service.GetDeclarationCategories());
		}

		[HttpGet]
		[Route("category")]
		public ActionResult GetDeclarationCategory([FromQuery] int id)
		{
			return Ok(_service.GetDeclarationCategoryById(id));
		}

		[HttpPost]
		[Route("question/add")]
		public string InsertDeclarationQuestion([FromBody] AddDeclarationQuestionRequest request)
		{
			return _service.AddDeclarationQuestion(request);
		}

		[HttpPost]
		[Route("question/Update")]
		public string UpdateDeclarationQuestion([FromBody] UpdateDeclarationQuestionRequest request)
		{
			return _service.UpdateDeclarationQuestion(request);
		}

		[HttpDelete]
		[Route("question/Delete")]
		public string DeleteDeclarationQuestion([FromQuery] int id)
		{
			return _service.DeleteDeclarationQuestion(id);
		}

		[HttpGet]
		[Route("questions")]
		public ActionResult GetDeclarationQuestions()
		{
			return Ok(_service.GetDeclarationQuestions());
		}

		[HttpGet]
		[Route("question")]
		public ActionResult GetDeclarationQuestionById([FromQuery] int id)
		{
			return Ok(_service.GetDeclarationQuestionById(id));
		}
	}
}
