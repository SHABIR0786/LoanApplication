using Abp.Application.Services.Dto;

namespace LoanManagement.Models
{
    public class PersonalInformationDto : EntityDto<long>
    {
        public bool IsApplyingWithCoBorrower { get; set; }
        public bool UseIncomeOfPersonOtherThanBorrower { get; set; }
        public bool AgreePrivacyPolicy { get; set; }
        public Borrower Borrower { get; set; }
        public Borrower CoBorrower { get; set; }


    }
}