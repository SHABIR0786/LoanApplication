using Microsoft.AspNetCore.Mvc;
using LoanManagement.Features.Financial.AccountType;
using LoanManagement.Features.Financial.LaibilitiesType;
using LoanManagement.Features.Financial.OtherLaibilitiesType;
using LoanManagement.Features.Financial.PropertyIntendedOccupancy;
using LoanManagement.Features.Financial.PropertyStatus;
using LoanManagement.Services.Interface;

namespace LoanManagement.Controllers
{
    [Route("[controller]")]
	[ApiController]
	public class FinancialController : ControllerBase
	{
		private readonly IFinancialService _service;

		public FinancialController(IFinancialService FinancialPropertyStatusService)
		{
			_service = FinancialPropertyStatusService;
		}

		[HttpPost]
		[Route("property/status/add")]
		public string InsertFinancialPropertyStatus([FromBody] AddPropertyStatusRequest FinancialPropertyStatusRequest)
		{
			return _service.AddFinancialPropertyStatus(FinancialPropertyStatusRequest);
		}

		[HttpPost]
		[Route("property/status/Update")]
		public string UpdateFinancialPropertyStatus([FromBody] UpdatePropertyStatusRequest FinancialPropertyStatusRequest)
		{
			return _service.UpdateFinancialPropertyStatus(FinancialPropertyStatusRequest);
		}

		[HttpDelete]
		[Route("property/status/Delete")]
		public string DeleteFinancialPropertyStatus([FromQuery] int id)
		{
			return _service.DeleteFinancialPropertyStatus(id);
		}

		[HttpGet]
		[Route("property/statuses")]
		public ActionResult GetFinancialPropertyStatuses()
		{
			return Ok(_service.GetFinancialPropertyStatuses());
		}

		[HttpGet]
		[Route("property/status")]
		public ActionResult GetFinancialPropertyStatus([FromQuery] int id)
		{
			return Ok(_service.GetFinancialPropertyStatusById(id));
		}

		[HttpPost]
		[Route("property/intended-occupancy/add")]
		public string InsertFinancialPropertyIntendedOccupancy([FromBody] AddPropertyIntendedOccupancyRequest FinancialPropertyIntendedOccupancyRequest)
		{
			return _service.AddFinancialPropertyIntendedOccupancy(FinancialPropertyIntendedOccupancyRequest);
		}

		[HttpPost]
		[Route("property/intended-occupancy/Update")]
		public string UpdateFinancialPropertyIntendedOccupancy([FromBody] UpdatePropertyIntendedOccupancyRequest FinancialPropertyIntendedOccupancyRequest)
		{
			return _service.UpdateFinancialPropertyIntendedOccupancy(FinancialPropertyIntendedOccupancyRequest);
		}

		[HttpDelete]
		[Route("property/intended-occupancy/Delete")]
		public string DeleteFinancialPropertyIntendedOccupancy([FromQuery] int id)
		{
			return _service.DeleteFinancialPropertyIntendedOccupancy(id);
		}

		[HttpGet]
		[Route("property/intended-occupancies")]
		public ActionResult GetFinancialPropertyIntendedOccupancies()
		{
			return Ok(_service.GetFinancialPropertyIntendedOccupancies());
		}

		[HttpGet]	
		[Route("property/intended-occupancy")]
		public ActionResult GetFinancialPropertyIntendedOccupancy([FromQuery] int id)
		{
			return Ok(_service.GetFinancialPropertyIntendedOccupancyById(id));
		}

		[HttpPost]
		[Route("other-laibilities-type/add")]
		public string InsertFinancialOtherLaibilitiesType([FromBody] AddOtherLaibilitiesTypeRequest FinancialOtherLaibilitiesTypeRequest)
		{
			return _service.AddFinancialOtherLaibilitiesType(FinancialOtherLaibilitiesTypeRequest);
		}

		[HttpPost]
		[Route("other-laibilities-type/Update")]
		public string UpdateFinancialOtherLaibilitiesType([FromBody] UpdateOtherLaibilitiesTypeRequest FinancialOtherLaibilitiesTypeRequest)
		{
			return _service.UpdateFinancialOtherLaibilitiesType(FinancialOtherLaibilitiesTypeRequest);
		}

		[HttpDelete]
		[Route("other-laibilities-type/Delete")]
		public string DeleteFinancialOtherLaibilitiesType([FromQuery] int id)
		{
			return _service.DeleteFinancialOtherLaibilitiesType(id);
		}

		[HttpGet]
		[Route("other-laibilities-types")]
		public ActionResult GetFinancialOtherLaibilitiesTypes()
		{
			return Ok(_service.GetFinancialOtherLaibilitiesTypes());
		}

		[HttpGet]
		[Route("other-laibilities-type")]
		public ActionResult GetFinancialOtherLaibilitiesType([FromQuery] int id)
		{
			return Ok(_service.GetFinancialOtherLaibilitiesTypeById(id));
		}

		[HttpPost]
		[Route("laibilities-type/add")]
		public string InsertFinancialLaibilitiesType([FromBody] AddLaibilitiesTypeRequest FinancialLaibilitiesTypeRequest)
		{
			return _service.AddFinancialLaibilitiesType(FinancialLaibilitiesTypeRequest);
		}

		[HttpPost]
		[Route("laibilities-type/Update")]
		public string UpdateFinancialLaibilitiesType([FromBody] UpdateLaibilitiesTypeRequest FinancialLaibilitiesTypeRequest)
		{
			return _service.UpdateFinancialLaibilitiesType(FinancialLaibilitiesTypeRequest);
		}

		[HttpDelete]
		[Route("laibilities-type/Delete")]
		public string DeleteFinancialLaibilitiesType([FromQuery] int id)
		{
			return _service.DeleteFinancialLaibilitiesType(id);
		}

		[HttpGet]
		[Route("laibilities-types")]
		public ActionResult GetFinancialLaibilitiesTypes()
		{
			return Ok(_service.GetFinancialLaibilitiesTypes());
		}

		[HttpGet]
		[Route("laibilities-type")]
		public ActionResult GetFinancialLaibilitiesType([FromQuery] int id)
		{
			return Ok(_service.GetFinancialLaibilitiesTypeById(id));
		}

		[HttpPost]
		[Route("account-type/add")]
		public string InsertFinancialAccountType([FromBody] AddAccountTypeRequest FinancialAccountTypeRequest)
		{
			return _service.AddFinancialAccountType(FinancialAccountTypeRequest);
		}

		[HttpPost]
		[Route("account-type/Update")]
		public string UpdateFinancialAccountType([FromBody] UpdateAccountTypeRequest FinancialAccountTypeRequest)
		{
			return _service.UpdateFinancialAccountType(FinancialAccountTypeRequest);
		}

		[HttpDelete]
		[Route("account-type/Delete")]
		public string DeleteFinancialAccountType([FromQuery] int id)
		{
			return _service.DeleteFinancialAccountType(id);
		}

		[HttpGet]
		[Route("account-types")]
		public ActionResult GetFinancialAccountTypes()
		{
			return Ok(_service.GetFinancialAccountTypes());
		}

		[HttpGet]
		[Route("account-type")]
		public ActionResult GetFinancialAccountType([FromQuery] int id)
		{
			return Ok(_service.GetFinancialAccountTypeById(id));
		}
	}
}
