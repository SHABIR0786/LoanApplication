using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Entities.Auditing;
using Castle.MicroKernel.SubSystems.Conversion;
using LoanManagement.MortgageTables;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.MortgageServices.MortgageApplicationLoanProperty.Dto
{
    public class CreateMortgageLoanAndProperty
    {
        public MortgageApplicationLoanPropertyInformationDto LoanPropertyInfo { get; set; }
        public List<MortgageApplicationLoanPropertyOtherNewMortgageLoansDto> NewMortgageLoans { get; set; }
        public MortgageApplicationLoanPropertyRentalIncomeDto RentalIncome { get; set; }
        public List<MortgageApplicationLoanPropertyGiftsOrGrantsDto> GiftsOrGrants { get; set; }
    }
    [AutoMapFrom(typeof(MortgageApplicationLoanPropertyInformation))]
    public class MortgageApplicationLoanPropertyInformationDto:FullAuditedEntityDto<int>
    {
        public int? PersonalInformationId { get; set; }
        //public virtual MortgageApplicationPersonalInformation PersonalInformation { get; set; }
        public decimal LoanAmount { get; set; }
        public string LoanPurpose { get; set; }
        public string Occupancy { get; set; }
        public bool IsManufacturedHome { get; set; }
        public bool IsMixedUseProperty { get; set; }
        public MortgageApplicationLoanPropertyAddressDto PropertyAddress { get; set; }
    }
    [AutoMapFrom(typeof(MortgageApplicationLoanPropertyAddress))]
    public class MortgageApplicationLoanPropertyAddressDto : FullAuditedEntityDto<int>
    {
        public int? PersonalInformationId { get; set; }
       // public virtual MortgageApplicationPersonalInformation PersonalInformation { get; set; }
        public string Street { get; set; }
        public int? CityId { get; set; }
        public int? StateId { get; set; }
        public int? CountryId { get; set; }
        public string Zip { get; set; }
        public int? NumberOfUnits { get; set; }
        public decimal PropertyValue { get; set; }
    }
    [AutoMapFrom(typeof(MortgageApplicationLoanPropertyOtherNewMortgageLoans))]
    public class MortgageApplicationLoanPropertyOtherNewMortgageLoansDto : FullAuditedEntityDto<int>
    {
        public int? PersonalInformationId { get; set; }
        // public virtual MortgageApplicationPersonalInformation PersonalInformation { get; set; }
        [DataType(DataType.Text)]
        public string CreditorName { get; set; }
        public string LienType { get; set; }
        public decimal MonthlyPayment { get; set; }
        public decimal LoanAmount { get; set; }
        public decimal CreditLimit { get; set; }
    }
    [AutoMapFrom(typeof(MortgageApplicationLoanPropertyRentalIncome))]
    public class MortgageApplicationLoanPropertyRentalIncomeDto : FullAuditedEntityDto<int>
    {
        public int? PersonalInformationId { get; set; }
        //public virtual MortgageApplicationPersonalInformation PersonalInformation { get; set; }
        public decimal MonthlyRentalIncome { get; set; }
        public decimal NetMonthlyRentalIncome { get; set; }
    }
    [AutoMapFrom(typeof(MortgageApplicationLoanPropertyGiftsOrGrants))]
    public class MortgageApplicationLoanPropertyGiftsOrGrantsDto : FullAuditedEntityDto<int>
    {
        public int? PersonalInformationId { get; set; }
        // public virtual MortgageApplicationPersonalInformation PersonalInformation { get; set; }
        public int? AssetTypeId { get; set; }
        public bool IsDeposited { get; set; }
        public string Source { get; set; }
        public decimal MarketValue { get; set; }
    }
}
