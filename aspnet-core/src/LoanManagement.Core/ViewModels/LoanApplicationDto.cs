using Abp.Application.Services.Dto;
using LoanManagement.LoanApplications.Dto;
using System.Collections.Generic;

namespace LoanManagement.ViewModels
{
    public class LoanApplicationDto : EntityDto<long>
    {
        public LoanDetailDto LoanDetails { get; set; }

        public MortgageTypeDto MortgageType { get; set; }
        public PropertyInformationDto PropertyInformation { get; set; }
        public BorrowerInformationDto BorrowerInformation { get; set; }
        public BorrowerInformationDto CoBorrowerInformation { get; set; }

        public BorrowerEmploymentInformationDto BorrowerEmploymentInformation1 { get; set; }
        public BorrowerEmploymentInformationDto BorrowerEmploymentInformation2 { get; set; }
        public BorrowerEmploymentInformationDto BorrowerEmploymentInformation3 { get; set; }

        public BorrowerEmploymentInformationDto CoBorrowerEmploymentInformation1 { get; set; }
        public BorrowerEmploymentInformationDto CoBorrowerEmploymentInformation2 { get; set; }
        public BorrowerEmploymentInformationDto CoBorrowerEmploymentInformation3 { get; set; }

        public AssetAndLiabilityDto AssetAndLiability { get; set; }
        public DetailsOfTransactionDto DetailsOfTransaction { get; set; }

        public GrossMonthlyIncomeDto GrossMonthlyIncomeBorrower { get; set; }
        public GrossMonthlyIncomeDto GrossMonthlyIncomeCoBorrower { get; set; }

        public CombinedMonthlyHousingExpenseDto CombinedMonthlyHousingExpensePresent { get; set; }
        public CombinedMonthlyHousingExpenseDto CombinedMonthlyHousingExpenseProposed { get; set; }

        public List<OtherIncomeDto> OtherIncomes { get; set; }
    }
}