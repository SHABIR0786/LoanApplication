using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LoanManagement.Features.DemographicInformation;
using LoanManagement.Services.Interface;

namespace LoanManagement.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DemographicInfoController : LoanManagementControllerBase
	{
		private readonly IDemographicInformationService _service;

		public DemographicInfoController(IDemographicInformationService DemographicInfoSourceService)
		{
			_service = DemographicInfoSourceService;
		}

        [HttpPost]
        [Route("source/add")]
        public string InsertDemographicInfoSource([FromBody] AddDemographicInfoSourceRequest DemographicInfoSourceRequest)
        {
            return _service.AddDemographicInfoSource(DemographicInfoSourceRequest);
        }

        [HttpPost]
        [Route("source/Update")]
        public string UpdateDemographicInfoSource([FromBody] UpdateDemographicInfoSourceRequest DemographicInfoSourceRequest)
        {
            return _service.UpdateDemographicInfoSource(DemographicInfoSourceRequest);
        }

        [HttpDelete]
        [Route("source/Delete")]
        public string DeleteDemographicInfoSource([FromQuery] int id)
        {
            return _service.DeleteDemographicInfoSource(id);
        }

        [HttpGet]
        [Route("sources")]
        public ActionResult GetDemographicInfoSources()
        {
            return Ok(_service.GetDemographicInfoSources());
        }

        [HttpGet]
        [Route("source")]
        public ActionResult GetDemographicInfoSource([FromQuery] int id)
        {
            return Ok(_service.GetDemographicInfoSourceById(id));
        }

        [HttpPost]
		[Route("add")]
		public string InsertDemographicInformation([FromBody] AddDemographicInformationRequest DemographicInformationRequest)
		{
			return _service.AddDemographicInformation(DemographicInformationRequest);
		}

		[HttpPost]
		[Route("Update")]
		public string UpdateDemographicInformation([FromBody] UpdateDemographicInformationRequest DemographicInformationRequest)
		{
			return _service.UpdateDemographicInformation(DemographicInformationRequest);
		}

		[HttpDelete]
		[Route("Delete")]
		public string DeleteDemographicInformation([FromQuery] int id)
		{
			return _service.DeleteDemographicInformation(id);
		}

		[HttpGet]
		[Route("informations")]
		public ActionResult GetDemographicInformations()
		{
			return Ok(_service.GetDemographicInformations());
		}

		[HttpGet]
		[Route("information")]
		public ActionResult GetDemographicInformation([FromQuery] int id)
		{
			return Ok(_service.GetDemographicInformationById(id));
		}
	}
}
