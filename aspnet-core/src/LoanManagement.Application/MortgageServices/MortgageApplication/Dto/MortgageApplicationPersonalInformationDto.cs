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
        public string firstName { get; set; }
        public string middleName { get; set; }
        public string lastName { get; set; }
        public string suffix { get; set; }
        public int socialSecurityNumber { get; set; }
        public DateTime dob { get; set; }
        public string citizenship { get; set; }
        public string marritalStatus { get; set; }
        public string dependents { get; set; }
        public int? MortgageApplicationId { get; set; }
        //public virtual MortgageApplicationDto MortgageApplication { get; set; }
        public MortgageApplicationAlternateNameDto AlternateNames { get; set; }
        public MortgageApplicationTypeOfCreditDto TypeOfCredit { get; set; }
        public MortgageApplicationContactInformationDto ContactInformation { get; set; }
        public List<MortgageApplicationOtherBorrowerDto> OtherBorrowers { get; set; }
        public MortgageApplicationCurrentAddressDto CurrentAddress { get; set; }
        public MortgageApplicationFormerAddressDto FormerAddress { get; set; }
        public MortgageApplicationMailingAddressDto MailingAddress { get; set; }

    }
    [AutoMapFrom(typeof(MortgageApplicationAlternateName))]
    public class MortgageApplicationAlternateNameDto : FullAuditedEntityDto<int>
    {
        public string firstName { get; set; }
        public string middleName { get; set; }
        public string lastName { get; set; }
        public string suffix { get; set; }
        public int? PersonalInformationId { get; set; }
       // public virtual MortgageApplicationPersonalInformationDto PersonalInformation { get; set; }
    }
}
