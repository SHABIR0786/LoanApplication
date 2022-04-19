
using LoanManagement.Features.Application.MilitaryService;
using LoanManagement.Features.Loan.LoanAndPropertyInformationOtherMortageLoan;
using LoanManagement.Features.Loan.LoanAndPropertyInformationRentalIncome;
using LoanManagement.Features.Loan.LoanOriginatorInformation;
using System;
using System.Collections.Generic;

namespace LoanManagement.Features.PdfData
{
    public class GetPdfDataModel
    {
        public int Id { get; set; }
        public int ApplicationId { get; set; }
        public string FirstName1a1 { get; set; }
        public string MiddleName1a2 { get; set; }
        public string LastName1a3 { get; set; }
        public string Suffix1a4 { get; set; }
        public string AlternateFirstName1a21 { get; set; }
        public string AlternateMiddleName1a22 { get; set; }
        public string AlternateLastName1a23 { get; set; }
        public string AlternateSuffix1a24 { get; set; }
        public string Ssn1a3 { get; set; }
        public DateTime? Dob1a4 { get; set; }
        public string CitizenshipType1a5 { get; set; }
        public int MaritialStatusId1a7 { get; set; }
        public int? Dependents1a8 { get; set; }
        public string Ages1a81 { get; set; }
        public string HomePhone1a9 { get; set; }
        public string CellPhone1a10 { get; set; }
        public string WorkPhone1a11 { get; set; }
        public string Ext1a111 { get; set; }
        public string Email1a12 { get; set; }
        public string CurrentStreet1a131 { get; set; }
        public string CurrentUnit1a132 { get; set; }
        public string CurrentZip1a135 { get; set; }
        public string CurrentCountry1a136 { get; set; }
        public string CurrentState1a134 { get; set; }
        public string CurrentCity1a133 { get; set; }
        public int? CurrentYears1a14 { get; set; }
        public int? CurrentMonths1a15 { get; set; }
        public string CurrentHousingType1a141 { get; set; }
        public float? CurrentRent1a142 { get; set; }
        public string FormerStreet1a151 { get; set; }
        public string FormerUnit1a152 { get; set; }
        public string FormerZip1a155 { get; set; }
        public string FormerCountry1a156 { get; set; }
        public string FormerState1a154 { get; set; }
        public string FormerCity1a153 { get; set; }
        public int? FormerYears1a16 { get; set; }
        public int? FormerMonths1a161 { get; set; }
        public string FormerHousingType1a161 { get; set; }
        public float? FormerRent1a162 { get; set; }
        public string MailingStreet1a171 { get; set; }
        public string MailingUnit1a172 { get; set; }
        public string MailingZip1a175 { get; set; }
        public string MailingCountry1a176 { get; set; }
        public string MailingState1a174 { get; set; }
        public string MailingCity1a173 { get; set; }

        public ApplicationDetail Application { get; set; } = null!;
        public List<AdditionalEmploymentDetail> AdditionalEmploymentDetails { get; set; }
        public List<DeclarationCategory> ApplicationDeclarationQuestionDetail { get; set; }
        public List<ApplicationDeclarationQuestion>  DeclarationQuestions { get; set; }
        public List<ApplicationEmployementDetail> ApplicationEmployementDetails { get; set; }
        public List<ApplicationFinancialAsset> ApplicationFinancialAssets { get; set; }
        public List<ApplicationFinancialLiabilityDetail> ApplicationFinancialLaibilities { get; set; }
        public List<ApplicationFinancialOtherAssetDetail> ApplicationFinancialOtherAssets { get; set; }
        public List<ApplicationFinancialOtherLaibilityDetail> ApplicationFinancialOtherLaibilities { get; set; }
        public List<FinancialRealEstateDetail> ApplicationFinancialRealEstates { get; set; }
        public List<ApplicationIncomeSourceDetail> ApplicationIncomeSources { get; set; }
        public List<PreviousEmployementDetail> ApplicationPreviousEmployementDetails { get; set; }
        public List<DemographicInformationDetail> DemographicInformations { get; set; }
        public List<LoanAndPropertyInformationGiftDetail> LoanAndPropertyInformationGifts { get; set; }
        public List<UpdateLoanAndPropertyInformationOtherMortageLoanRequest> LoanAndPropertyInformationOtherMortageLoans { get; set; }
        public List<UpdateLoanAndPropertyInformationRentalIncomeRequest> LoanAndPropertyInformationRentalIncomes { get; set; }
        public List<LoanAndPropertyInformationDetail> LoanAndPropertyInformations { get; set; }
        public List<UpdateLoanOriginatorInformationRequest> LoanOriginatorInformations { get; set; }
        public List<UpdateMilitaryServiceRequest> MilitaryServices { get; set; }
    }
}
