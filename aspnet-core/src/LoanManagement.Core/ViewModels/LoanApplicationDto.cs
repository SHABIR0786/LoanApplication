using Abp.Application.Services.Dto;
using System.Collections.Generic;

namespace LoanManagement.ViewModels
{
    public class LoanApplicationDto : EntityDto<long?>
    {
        public LoanDetailDto LoanDetails { get; set; }
        public PersonalInformationDto PersonalInformation { get; set; }
        public ExpensesDto Expenses { get; set; }
        public List<ManualAssetEntryDto> ManualAssetEntries { get; set; }
        public EmploymentIncomeDto EmploymentIncome { get; set; }

        public CreditAuthAgreementDto OrderCredit { get; set; }
        public AdditionalDetailsDto AdditionalDetails { get; set; }
        public EConsentDto EConsent { get; set; }

        public DeclarationDto Declaration { get; set; }
    }
}