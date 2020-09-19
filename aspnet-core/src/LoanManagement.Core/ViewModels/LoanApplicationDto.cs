using Abp.Application.Services.Dto;
using LoanManagement.LoanApplications.Dto;

namespace LoanManagement.ViewModels
{
    public class LoanApplicationDto : EntityDto<long>
    {
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

        public CreateOrUpdateAssetAndLiablityDto AssetAndLiablity { get; set; }
        public CreateOrUpdateDetailsOfTransactionDto DetailsOfTransaction { get; set; }

        public GrossMonthlyIncomeDto GrossMonthlyIncomeBorrower { get; set; }
        public GrossMonthlyIncomeDto GrossMonthlyIncomeCoBorrower { get; set; }

        public CombinedMonthlyHousingExpenseDto CombinedMonthlyHousingExpensePresent { get; set; }
        public CombinedMonthlyHousingExpenseDto CombinedMonthlyHousingExpenseProposed { get; set; }
    }
}