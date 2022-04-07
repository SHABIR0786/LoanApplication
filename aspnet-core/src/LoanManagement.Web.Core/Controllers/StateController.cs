using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LoanManagement.Features.State;
using LoanManagement.Services.Interface;

namespace LoanManagement.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class StateController : LoanManagementControllerBase
	{
		private readonly IStateService _service;

		public StateController(IStateService StateService)
		{
			_service = StateService;
		}

		[HttpPost]
		[Route("add")]
		public string InsertState([FromBody] AddStateRequest request)
		{
			return _service.AddState(request);
		}

		[HttpPost]
		[Route("Update")]
		public string UpdateState([FromBody] UpdateStateRequest request)
		{
			return _service.UpdateState(request);
		}

		[HttpDelete]
		[Route("Delete")]
		public string DeleteState([FromQuery] int id)
		{
			return _service.DeleteState(id);
		}

		[HttpGet]
		[Route("states")]
		public ActionResult GetStates()
		{
			return Ok(_service.GetStates());
		}

		[HttpGet]
		[Route("State")]
		public ActionResult GetState([FromQuery] int id)
		{
			return Ok(_service.GetStateById(id));
		}
	}
}
