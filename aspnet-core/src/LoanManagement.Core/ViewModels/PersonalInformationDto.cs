using Abp.Application.Services.Dto;
using JetBrains.Annotations;

namespace LoanManagement.Models
{
    public class PersonalInformationDto : EntityDto<long>
    {
        public bool? IsApplyingWithCoBorrower { get; set; }
        public bool? UseIncomeOfPersonOtherThanBorrower { get; set; }
        public bool? AgreePrivacyPolicy { get; set; }
        [CanBeNull]
        public Borrower Borrower { get; set; }
        [CanBeNull]
        public Borrower CoBorrower { get; set; }
    }
}