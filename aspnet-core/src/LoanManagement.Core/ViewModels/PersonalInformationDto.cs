using Abp.Application.Services.Dto;
using JetBrains.Annotations;
using System.Collections.Generic;

namespace LoanManagement.ViewModels
{
    public class PersonalInformationDto : EntityDto<long>
    {
        public bool? IsApplyingWithCoBorrower { get; set; }
        public bool? UseIncomeOfPersonOtherThanBorrower { get; set; }
        public bool? AgreePrivacyPolicy { get; set; }
        [CanBeNull]
        public BorrowerDto Borrower { get; set; }
        [CanBeNull]
        public BorrowerDto CoBorrower { get; set; }
        public bool IsMailingAddressSameAsResidential { get; set; }

        public AddressDto ResidentialAddress { get; set; }
        public List<AddressDto> PreviousAddresses { get; set; }
        public AddressDto MailingAddress { get; set; }
    }
}