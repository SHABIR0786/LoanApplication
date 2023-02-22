using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using LoanManagement.MortgageTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.MortgageServices.MortgageApplication.Dto
{
    [AutoMapFrom(typeof(MortgageApplicationPersonalInformation))]
    public class MortgageApplicationPersonalInformationDto : FullAuditedEntityDto<int>
    {
        public string BorrowerType { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Suffix { get; set; }
        public string SocialSecurityNumber { get; set; }
        public string Dob { get; set; }
        public string Citizenship { get; set; }
        public string MarritalStatus { get; set; }
        public string Dependents { get; set; }
        public string ApplyingFor { get; set; }
        public int? TotalBorrowers { get; set; }
        public string YourInitials { get; set; }
        public int? MortgageApplicationId { get; set; }
        //public virtual MortgageApplicationDto MortgageApplication { get; set; }
        public MortgageApplicationAlternateNameDto AlternateNames { get; set; }
        public MortgageApplicationTypeOfCreditDto TypeOfCredit { get; set; }
        public MortgageApplicationContactInformationDto ContactInformation { get; set; }
        public List<MortgageApplicationCurrentAddressDto> Address { get; set; }
        //public MortgageApplicationFormerAddressDto FormerAddress { get; set; }
        //public MortgageApplicationMailingAddressDto MailingAddress { get; set; }

    }
    [AutoMapFrom(typeof(MortgageApplicationAlternateName))]
    public class MortgageApplicationAlternateNameDto : FullAuditedEntityDto<int>
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Suffix { get; set; }
        public int? PersonalInformationId { get; set; }
       // public virtual MortgageApplicationPersonalInformationDto PersonalInformation { get; set; }
    }
}
