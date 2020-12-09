using Abp.Application.Services.Dto;
using JetBrains.Annotations;
using System.Collections.Generic;

namespace LoanManagement.ViewModels
{
    public class PersonalInformationDto : EntityDto<long?>
    {
        public bool? IsApplyingWithCoBorrower { get; set; }
        public bool? UseIncomeOfPersonOtherThanBorrower { get; set; }
        public bool? AgreePrivacyPolicy { get; set; }
        [CanBeNull]
        public BorrowerDto Borrower { get; set; }
        [CanBeNull]
        public BorrowerDto CoBorrower { get; set; }

        public AddressDto ResidentialAddress { get; set; }

        public AddressDto CoBorrowerResidentialAddress { get; set; }
        public List<AddressDto> PreviousAddresses { get; set; }
        public AddressDto MailingAddress { get; set; }
        public bool? IsMailingAddressSameAsResidential { get; set; }
        public List<AddressDto> CoBorrowerPreviousAddresses { get; set; }
        public AddressDto CoBorrowerMailingAddress { get; set; }
        public bool? CoBorrowerIsMailingAddressSameAsResidential { get; set; }
        public long LoanApplicationId { get; set; }
        public bool? CoBorrowerResidentialAddressSameAsBorrowerResidential { get; set; }
    }
}