using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LoanManagement.Features.Country;
using LoanManagement.Services.Interface;

namespace LoanManagement.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CountryController : LoanManagementControllerBase
    {
		private readonly ICountryService _service;

		public CountryController(ICountryService CountryService)
		{
			_service = CountryService;
		}

		[HttpPost]
		[Route("Country/add")]
		public string InsertCountry([FromBody] AddCountryRequest request)
		{
			return _service.AddCountry(request);
		}

        [HttpPost]
        [Route("Country/Update")]
        public string UpdateCountry([FromBody] UpdateCountryRequest request)
        {
            return _service.UpdateCountry(request);
        }

        [HttpDelete]
        [Route("Country/Delete")]
        public string DeleteCountry([FromQuery] int id)
        {
            return _service.DeleteCountry(id);
        }

        [HttpGet]
        [Route("Country/countries")]
        public ActionResult GetCountries()
        {
            return Ok(_service.GetCountries());
        }

        [HttpGet]
        [Route("country/Country")]
        public ActionResult GetCountry([FromQuery] int id)
        {
        	return Ok(_service.GetCountryById(id));
        }
    }
}
