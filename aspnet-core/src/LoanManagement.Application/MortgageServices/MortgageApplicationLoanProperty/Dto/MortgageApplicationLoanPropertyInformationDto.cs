using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Entities.Auditing;
using LoanManagement.MortgageTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.MortgageServices.MortgageApplicationLoanProperty.Dto
{
    public class CreateMortgageLoanAndProperty
    {
        public MortgageApplicationLoanPropertyInformationDto loanPropertyInfo { get; set; }
        public List<MortgageApplicationLoanPropertyOtherNewMortgageLoansDto> newMortgageLoans { get; set; }
        public List<MortgageApplicationLoanPropertyRentalIncomeDto> rentalIncome { get; set; }
        public List<MortgageApplicationLoanPropertyGiftsOrGrantsDto> giftsOrGrants { get; set; }
    }
    [AutoMapFrom(typeof(MortgageApplicationLoanPropertyInformation))]
    public class MortgageApplicationLoanPropertyInformationDto:FullAuditedEntityDto<int>
    {
        public int? PersonalInformationId { get; set; }
        //public virtual MortgageApplicationPersonalInformation PersonalInformation { get; set; }
        public decimal loanAmount { get; set; }
        public string loanPurpose { get; set; }
        public string occupancy { get; set; }
        public bool isManufacturedHome { get; set; }
        public bool isMixedUseProperty { get; set; }
        public MortgageApplicationLoanPropertyAddressDto propertyAddress { get; set; }
    }
    [AutoMapFrom(typeof(MortgageApplicationLoanPropertyAddress))]
    public class MortgageApplicationLoanPropertyAddressDto : FullAuditedEntityDto<int>
    {
        public int? PersonalInformationId { get; set; }
       // public virtual MortgageApplicationPersonalInformation PersonalInformation { get; set; }
        public string street { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zip { get; set; }
        public string country { get; set; }
        public int? numberOfUnits { get; set; }
        public decimal propertyValue { get; set; }
    }
    [AutoMapFrom(typeof(MortgageApplicationLoanPropertyOtherNewMortgageLoans))]
    public class MortgageApplicationLoanPropertyOtherNewMortgageLoansDto : FullAuditedEntityDto<int>
    {
        public int? PersonalInformationId { get; set; }
       // public virtual MortgageApplicationPersonalInformation PersonalInformation { get; set; }
        public string creditorName { get; set; }
        public string lienType { get; set; }
        public decimal monthlyPayment { get; set; }
        public decimal loanAmount { get; set; }
        public decimal creditLimit { get; set; }
    }
    [AutoMapFrom(typeof(MortgageApplicationLoanPropertyRentalIncome))]
    public class MortgageApplicationLoanPropertyRentalIncomeDto : FullAuditedEntityDto<int>
    {
        public int? PersonalInformationId { get; set; }
        //public virtual MortgageApplicationPersonalInformation PersonalInformation { get; set; }
        public string incomeType { get; set; }
        public decimal amount { get; set; }
    }
    [AutoMapFrom(typeof(MortgageApplicationLoanPropertyGiftsOrGrants))]
    public class MortgageApplicationLoanPropertyGiftsOrGrantsDto : FullAuditedEntityDto<int>
    {
        public int? PersonalInformationId { get; set; }
       // public virtual MortgageApplicationPersonalInformation PersonalInformation { get; set; }
        public string assetType { get; set; }
        public bool isDeposited { get; set; }
        public string source { get; set; }
        public decimal marketValue { get; set; }
    }
}
