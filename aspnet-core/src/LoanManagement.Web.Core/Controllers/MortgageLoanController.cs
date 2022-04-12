using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LoanManagement.Features.Loan.LoanAndPropertyInformation;
using LoanManagement.Features.Loan.LoanAndPropertyInformationGift;
using LoanManagement.Features.Loan.LoanAndPropertyInformationOtherMortageLoan;
using LoanManagement.Features.Loan.LoanAndPropertyInformationRentalIncome;
using LoanManagement.Features.Loan.LoanOriginatorInformation;
using LoanManagement.Features.Loan.LoanPropertyGiftType;
using LoanManagement.Features.Loan.LoanPropertyOccupancy;
using LoanManagement.Features.Loan.MortageLoanOnProperty;
using LoanManagement.Features.Loan.MortageLoanType;
using LoanManagement.Services.Interface;

namespace LoanManagement.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MortgageLoanController : LoanManagementControllerBase
	{
		private readonly ILoanService _service;

		public MortgageLoanController(ILoanService loanService)
		{
			_service = loanService;
		}

		[HttpPost]
		[Route("property-gift-type/add")]
		public string InsertLoanPropertyGiftType([FromBody] AddLoanPropertyGiftTypeRequest LoanPropertyGiftTypeRequest)
		{
			return _service.AddLoanPropertyGiftType(LoanPropertyGiftTypeRequest);
		}

		[HttpPost]
		[Route("property-gift-type/Update")]
		public string UpdateLoanPropertyGiftType([FromBody] UpdateLoanPropertyGiftTypeRequest LoanPropertyGiftTypeRequest)
		{
			return _service.UpdateLoanPropertyGiftType(LoanPropertyGiftTypeRequest);
		}

		[HttpDelete]
		[Route("property-gift-type/Delete")]
		public string DeleteLoanPropertyGiftType([FromQuery] int id)
		{
			return _service.DeleteLoanPropertyGiftType(id);
		}

		[HttpGet]
		[Route("property-gift-types")]
		public ActionResult GetLoanPropertyGiftTypes()
		{
			return Ok(_service.GetLoanPropertyGiftTypes());
		}

		[HttpGet]
		[Route("property-gift-type")]
		public ActionResult GetLoanPropertyGiftType([FromQuery] int id)
		{
			return Ok(_service.GetLoanPropertyGiftTypeById(id));
		}

		[HttpPost]
		[Route("property-occupancy/add")]
		public string InsertLoanPropertyOccupancy([FromBody] AddLoanPropertyOccupancyRequest request)
		{
			return _service.AddLoanPropertyOccupancy(request);
		}

		[HttpPost]
		[Route("property-occupancy/Update")]
		public string UpdateLoanPropertyOccupancy([FromBody] UpdateLoanPropertyOccupancyRequest request)
		{
			return _service.UpdateLoanPropertyOccupancy(request);
		}

		[HttpDelete]
		[Route("property-occupancy/Delete")]
		public string DeleteLoanPropertyOccupancy([FromQuery] int id)
		{
			return _service.DeleteLoanPropertyOccupancy(id);
		}

		[HttpGet]
		[Route("property-occupancies")]
		public ActionResult GetLoanPropertyOccupancies()
		{
			return Ok(_service.GetLoanPropertyOccupancies());
		}

		[HttpGet]
		[Route("property-occupancy")]
		public ActionResult GetLoanPropertyOccupancy([FromQuery] int id)
		{
			return Ok(_service.GetLoanPropertyOccupancyById(id));
		}

		[HttpPost]
		[Route("mortgage-type/add")]
		public string InsertMortageLoanType([FromBody] AddMortageLoanTypeRequest MortageLoanTypeRequest)
		{
			return _service.AddMortageLoanType(MortageLoanTypeRequest);
		}

		[HttpPost]
		[Route("mortgage-type/Update")]
		public string UpdateMortageLoanType([FromBody] UpdateMortageLoanTypeRequest MortageLoanTypeRequest)
		{
			return _service.UpdateMortageLoanType(MortageLoanTypeRequest);
		}

		[HttpDelete]
		[Route("mortgage-type/Delete")]
		public string DeleteMortageLoanType([FromQuery] int id)
		{
			return _service.DeleteMortageLoanType(id);
		}

		[HttpGet]
		[Route("mortgage-types")]
		public ActionResult GetMortageLoanTypes()
		{
			return Ok(_service.GetMortageLoanTypes());
		}

		[HttpGet]
		[Route("mortgage-type")]
		public ActionResult GetMortageLoanType([FromQuery] int id)
		{
			return Ok(_service.GetMortageLoanTypeById(id));
		}

		[HttpPost]
		[Route("property-information-gift/add")]
		public string InsertLoanAndPropertyInformationGift([FromBody] AddLoanAndPropertyInformationGiftRequest request)
		{
			return _service.AddLoanAndPropertyInformationGift(request);
		}

		[HttpPost]
		[Route("property-information-gift/Update")]
		public string UpdateLoanAndPropertyInformationGift([FromBody] UpdateLoanAndPropertyInformationGiftRequest request)
		{
			return _service.UpdateLoanAndPropertyInformationGift(request);
		}

		[HttpDelete]
		[Route("property-information-gift/Delete")]
		public string DeleteLoanAndPropertyInformationGift([FromQuery] int id)
		{
			return _service.DeleteLoanAndPropertyInformationGift(id);
		}

		[HttpGet]
		[Route("property-information-gifts")]
		public ActionResult GetLoanAndPropertyInformationGifts()
		{
			return Ok(_service.GetLoanAndPropertyInformationGifts());
		}

		[HttpGet]
		[Route("property-information-gift")]
		public ActionResult GetLoanAndPropertyInformationGift([FromQuery] int id)
		{
			return Ok(_service.GetLoanAndPropertyInformationGiftById(id));
		}

		[HttpPost]
		[Route("property-information/add")]
		public string InsertLoanAndPropertyInformation([FromBody] AddLoanAndPropertyInformationRequest request)
		{
			return _service.AddLoanAndPropertyInformation(request);
		}

		[HttpPost]
		[Route("property-information/Update")]
		public string UpdateLoanAndPropertyInformation([FromBody] UpdateLoanAndPropertyInformationRequest request)
		{
			return _service.UpdateLoanAndPropertyInformation(request);
		}

		[HttpDelete]
		[Route("property-information/Delete")]
		public string DeleteLoanAndPropertyInformation([FromQuery] int id)
		{
			return _service.DeleteLoanAndPropertyInformation(id);
		}

		[HttpGet]
		[Route("property-informations")]
		public ActionResult GetLoanAndPropertyInformations()
		{
			return Ok(_service.GetLoanAndPropertyInformations());
		}

		[HttpGet]
		[Route("property-information")]
		public ActionResult GetLoanAndPropertyInformation([FromQuery] int id)
		{
			return Ok(_service.GetLoanAndPropertyInformationById(id));
		}

		[HttpPost]
		[Route("originator-information/add")]
		public string InsertLoanOriginatorInformation([FromBody] AddLoanOriginatorInformationRequest request)
		{
			return _service.AddLoanOriginatorInformation(request);
		}

		[HttpPost]
		[Route("originator-information/Update")]
		public string UpdateLoanOriginatorInformation([FromBody] UpdateLoanOriginatorInformationRequest request)
		{
			return _service.UpdateLoanOriginatorInformation(request);
		}

		[HttpDelete]
		[Route("originator-information/Delete")]
		public string DeleteLoanOriginatorInformation([FromQuery] int id)
		{
			return _service.DeleteLoanOriginatorInformation(id);
		}

		[HttpGet]
		[Route("originator-informations")]
		public ActionResult GetLoanOriginatorInformations()
		{
			return Ok(_service.GetLoanOriginatorInformations());
		}

		[HttpGet]
		[Route("originator-information")]
		public ActionResult GetLoanOriginatorInformation([FromQuery] int id)
		{
			return Ok(_service.GetLoanOriginatorInformationById(id));
		}

		[HttpPost]
		[Route("property-information/other-mortgage-loan/add")]
		public string InsertLoanAndPropertyInformationOtherMortageLoan([FromBody] AddLoanAndPropertyInformationOtherMortageLoanRequest request)
		{
			return _service.AddLoanAndPropertyInformationOtherMortageLoan(request);
		}

		[HttpPost]
		[Route("property-information/other-mortgage-loan/Update")]
		public string UpdateLoanAndPropertyInformationOtherMortageLoan([FromBody] UpdateLoanAndPropertyInformationOtherMortageLoanRequest request)
		{
			return _service.UpdateLoanAndPropertyInformationOtherMortageLoan(request);
		}

		[HttpDelete]
		[Route("property-information/other-mortgage-loan/Delete")]
		public string DeleteLoanAndPropertyInformationOtherMortageLoan([FromQuery] int id)
		{
			return _service.DeleteLoanAndPropertyInformationOtherMortageLoan(id);
		}

		[HttpGet]
		[Route("property-information/other-mortgage-loans")]
		public ActionResult GetLoanAndPropertyInformationOtherMortageLoans()
		{
			return Ok(_service.GetLoanAndPropertyInformationOtherMortageLoans());
		}

		[HttpGet]
		[Route("property-information/other-mortgage-loan")]
		public ActionResult GetLoanAndPropertyInformationOtherMortageLoan([FromQuery] int id)
		{
			return Ok(_service.GetLoanAndPropertyInformationOtherMortageLoanById(id));
		}

		[HttpPost]
		[Route("property-information/rental-income/add")]
		public string InsertLoanAndPropertyInformationRentalIncome([FromBody] AddLoanAndPropertyInformationRentalIncomeRequest request)
		{
			return _service.AddLoanAndPropertyInformationRentalIncome(request);
		}

		[HttpPost]
		[Route("property-information/rental-income/Update")]
		public string UpdateLoanAndPropertyInformationRentalIncome([FromBody] UpdateLoanAndPropertyInformationRentalIncomeRequest request)
		{
			return _service.UpdateLoanAndPropertyInformationRentalIncome(request);
		}

		[HttpDelete]
		[Route("property-information/rental-income/Delete")]
		public string DeleteLoanAndPropertyInformationRentalIncome([FromQuery] int id)
		{
			return _service.DeleteLoanAndPropertyInformationRentalIncome(id);
		}

		[HttpGet]
		[Route("property-information/rental-incomes")]
		public ActionResult GetLoanAndPropertyInformationRentalIncomes()
		{
			return Ok(_service.GetLoanAndPropertyInformationRentalIncomes());
		}

		[HttpGet]
		[Route("property-information/rental-income")]
		public ActionResult GetLoanAndPropertyInformationRentalIncome([FromQuery] int id)
		{
			return Ok(_service.GetLoanAndPropertyInformationRentalIncomeById(id));
		}

		[HttpPost]
		[Route("property-mortgage-loan/add")]
		public string InsertMortageLoanOnProperty([FromBody] AddMortageLoanOnPropertyRequest request)
		{
			return _service.AddMortageLoanOnProperty(request);
		}

		[HttpPost]
		[Route("property-mortgage-loan/Update")]
		public string UpdateMortageLoanOnProperty([FromBody] UpdateMortageLoanOnPropertyRequest request)
		{
			return _service.UpdateMortageLoanOnProperty(request);
		}

		[HttpDelete]
		[Route("property-mortgage-loan/Delete")]
		public string DeleteMortageLoanOnProperty([FromQuery] int id)
		{
			return _service.DeleteMortageLoanOnProperty(id);
		}

		[HttpGet]
		[Route("property-mortgage-loans")]
		public ActionResult GetMortageLoanOnProperties()
		{
			return Ok(_service.GetMortageLoanOnProperties());
		}

		[HttpGet]
		[Route("property-mortgage-loan")]
		public ActionResult GetMortageLoanOnProperty([FromQuery] int id)
		{
			return Ok(_service.GetMortageLoanOnPropertyById(id));
		}
	
		[HttpGet]
		[Route("loan-details")]
		public ActionResult GetLoanApplicationDetail([FromQuery] long id)
		{
			return Ok(_service.GetLoanApplicationDetail(id));
		}
	}
}
