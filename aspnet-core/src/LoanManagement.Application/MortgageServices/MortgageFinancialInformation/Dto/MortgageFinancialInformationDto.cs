using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Entities.Auditing;
using LoanManagement.MortgageServices.MortgageApplication.Dto;
using LoanManagement.MortgageTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.MortgageServices.MortgageFinancialInformation.Dto
{
    [AutoMapFrom(typeof(MortgagePropertyFinancialInformation))]
    public class MortgagePropertyFinancialInformationDto : FullAuditedEntityDto<int>
    {
        //type: current, additional
        public string FinancialInformationType { get; set; }
        public int? PersonalInformationId { get; set; }
      //  public virtual MortgageApplicationPersonalInformationDto PersonalInformation { get; set; }
        public string Street { get; set; }
        public string Unit { get; set; }
        public int? CityId { get; set; }
        public int? StateId { get; set; }
        public int? CountryId { get; set; }
        public string Zip { get; set; }
        public decimal PropertyValue { get; set; }
        public string IntendedOccupancy { get; set; }
        public decimal MonthlyInsurance { get; set; }
        public decimal MonthlyRentalIncome { get; set; }
        public decimal NetMonthlyRentalIncome { get; set; }
        public List<MortgageLoanOnProperyFinancialInformationDto> MortgageLoanOnProperty { get; set; }
    }

    [AutoMapFrom(typeof(MortgageLoanOnProperyFinancialInformation))]
    public class MortgageLoanOnProperyFinancialInformationDto : FullAuditedEntity<int>
    {
        public string CreditorName { get; set; }
        public string AccountNumber { get; set; }
        public decimal MonthlyMortagagePayment { get; set; }
        public decimal UnpaidBalance { get; set; }
        public string Type { get; set; }
        public decimal CreditLimit { get; set; }
        public bool? IsPaidBeforeClosing { get; set; }
        public int? MortgagePropertyFinancialInformationId { get; set; }
      //  public virtual MortgagePropertyFinancialInformationDto MortgagePropertyFinancialInformation { get; set; }
    }

    [AutoMapFrom(typeof(MortgagePropertyAdditionalFinancialInformation))]
    public class MortgagePropertyAdditionalFinancialInformationDto : FullAuditedEntity<int>
    {
        public string Street { get; set; }
        public string Unit { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }
        public decimal PropertyValue { get; set; }
        public string IntendedOccupancy { get; set; }
        public decimal MonthlyInsurance { get; set; }
        public decimal MonthlyRentalIncome { get; set; }
        public decimal NetMonthlyRentalIncome { get; set; }
        public int? PersonalInformationId { get; set; }
    //    public virtual MortgageApplicationPersonalInformationDto PersonalInformation { get; set; }
    }

    [AutoMapFrom(typeof(MortgageLoanOnAdditionalPropertyFinancialInformation))]
    public class MortgageLoanOnAdditionalPropertyFinancialInformationDto : FullAuditedEntity<int>
    {
        public string CreditorName { get; set; }
        public long AccountNumber { get; set; }
        public decimal MonthlyMortagagePayment { get; set; }
        public decimal UnpaidBalance { get; set; }
        public string Type { get; set; }
        public decimal CreditLimit { get; set; }
        public bool IsApplied { get; set; }
        public int? MortgagePropertyFinancialInformationId { get; set; }
    //    public virtual MortgagePropertyFinancialInformationDto MortgagePropertyFinancialInformation { get; set; }
    }
    public class CreateMortgagePropertyFinancialInformationDto
    {
        public List<MortgagePropertyFinancialInformationDto> MortgagePropertyFinancialInformation { get; set; }
    }


}
