using LoanManagement.Features.Loan.LoanAndPropertyInformation;
using LoanManagement.Features.Loan.LoanAndPropertyInformationGift;
using LoanManagement.Features.Loan.LoanAndPropertyInformationOtherMortageLoan;
using LoanManagement.Features.Loan.LoanAndPropertyInformationRentalIncome;
using LoanManagement.Features.Loan.LoanOriginatorInformation;
using LoanManagement.Features.Loan.LoanPropertyGiftType;
using LoanManagement.Features.Loan.LoanPropertyOccupancy;
using LoanManagement.Features.Loan.MortageLoanOnProperty;
using LoanManagement.Features.Loan.MortageLoanType;
using LoanManagement.Features.PdfData;
using System.Collections.Generic;

namespace LoanManagement.Services.Interface
{
	public interface ILoanService
	{
		string AddLoanPropertyGiftType(AddLoanPropertyGiftTypeRequest request);
		string UpdateLoanPropertyGiftType(UpdateLoanPropertyGiftTypeRequest request);
		string DeleteLoanPropertyGiftType(int id);
		List<UpdateLoanPropertyGiftTypeRequest> GetLoanPropertyGiftTypes();
		UpdateLoanPropertyGiftTypeRequest GetLoanPropertyGiftTypeById(int id);
		
		string AddLoanPropertyOccupancy(AddLoanPropertyOccupancyRequest request);
		string UpdateLoanPropertyOccupancy(UpdateLoanPropertyOccupancyRequest request);
		string DeleteLoanPropertyOccupancy(int id);
		List<UpdateLoanPropertyOccupancyRequest> GetLoanPropertyOccupancies();
		UpdateLoanPropertyOccupancyRequest GetLoanPropertyOccupancyById(int id);
		
		string AddMortageLoanType(AddMortageLoanTypeRequest request);
		string UpdateMortageLoanType(UpdateMortageLoanTypeRequest request);
		string DeleteMortageLoanType(int id);
		List<UpdateMortageLoanTypeRequest> GetMortageLoanTypes();
		UpdateMortageLoanTypeRequest GetMortageLoanTypeById(int id);

		string AddLoanAndPropertyInformationGift(AddLoanAndPropertyInformationGiftRequest request);
		string UpdateLoanAndPropertyInformationGift(UpdateLoanAndPropertyInformationGiftRequest request);
		string DeleteLoanAndPropertyInformationGift(int id);
		List<UpdateLoanAndPropertyInformationGiftRequest> GetLoanAndPropertyInformationGifts();
		UpdateLoanAndPropertyInformationGiftRequest GetLoanAndPropertyInformationGiftById(int id);
	
		string AddLoanAndPropertyInformation(AddLoanAndPropertyInformationRequest request);
		string UpdateLoanAndPropertyInformation(UpdateLoanAndPropertyInformationRequest request);
		string DeleteLoanAndPropertyInformation(int id);
		List<UpdateLoanAndPropertyInformationRequest> GetLoanAndPropertyInformations();
		UpdateLoanAndPropertyInformationRequest GetLoanAndPropertyInformationById(int id);

		string AddLoanOriginatorInformation(AddLoanOriginatorInformationRequest request);
		string UpdateLoanOriginatorInformation(UpdateLoanOriginatorInformationRequest request);
		string DeleteLoanOriginatorInformation(int id);
		List<UpdateLoanOriginatorInformationRequest> GetLoanOriginatorInformations();
		UpdateLoanOriginatorInformationRequest GetLoanOriginatorInformationById(int id);
	
		string AddLoanAndPropertyInformationOtherMortageLoan(AddLoanAndPropertyInformationOtherMortageLoanRequest request);
		string UpdateLoanAndPropertyInformationOtherMortageLoan(UpdateLoanAndPropertyInformationOtherMortageLoanRequest request);
		string DeleteLoanAndPropertyInformationOtherMortageLoan(int id);
		List<UpdateLoanAndPropertyInformationOtherMortageLoanRequest> GetLoanAndPropertyInformationOtherMortageLoans();
		UpdateLoanAndPropertyInformationOtherMortageLoanRequest GetLoanAndPropertyInformationOtherMortageLoanById(int id);
	
		string AddLoanAndPropertyInformationRentalIncome(AddLoanAndPropertyInformationRentalIncomeRequest request);
		string UpdateLoanAndPropertyInformationRentalIncome(UpdateLoanAndPropertyInformationRentalIncomeRequest request);
		string DeleteLoanAndPropertyInformationRentalIncome(int id);
		List<UpdateLoanAndPropertyInformationRentalIncomeRequest> GetLoanAndPropertyInformationRentalIncomes();
		UpdateLoanAndPropertyInformationRentalIncomeRequest GetLoanAndPropertyInformationRentalIncomeById(int id);
	
		string AddMortageLoanOnProperty(AddMortageLoanOnPropertyRequest request);
		string UpdateMortageLoanOnProperty(UpdateMortageLoanOnPropertyRequest request);
		string DeleteMortageLoanOnProperty(int id);
		List<UpdateMortageLoanOnPropertyRequest> GetMortageLoanOnProperties();
		UpdateMortageLoanOnPropertyRequest GetMortageLoanOnPropertyById(int id);

		GetPdfDataModel GetLoanApplicationDetail(long id);
		dynamic CreatePdfNew(long id);
	}
}
