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
        public int? PersonalInformationId { get; set; }
      //  public virtual MortgageApplicationPersonalInformationDto PersonalInformation { get; set; }
        public string street { get; set; }
        public string unit { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zip { get; set; }
        public string country { get; set; }
        public decimal propertyValue { get; set; }
        public string intendedOccupancy { get; set; }
        public decimal monthlyInsurance { get; set; }
        public decimal monthlyRentalIncome { get; set; }
        public decimal netMonthlyRentalIncome { get; set; }
    }

    [AutoMapFrom(typeof(MortgageLoanOnProperyFinancialInformation))]
    public class MortgageLoanOnProperyFinancialInformationDto : FullAuditedEntity<int>
    {
        public string creditorName { get; set; }
        public long accountNumber { get; set; }
        public decimal monthlyMortagagePayment { get; set; }
        public decimal unpaidBalance { get; set; }
        public string type { get; set; }
        public decimal creditLimit { get; set; }
        public bool isApplied { get; set; }
        public int? MortgagePropertyFinancialInformationId { get; set; }
      //  public virtual MortgagePropertyFinancialInformationDto MortgagePropertyFinancialInformation { get; set; }
    }

    [AutoMapFrom(typeof(MortgagePropertyAdditionalFinancialInformation))]
    public class MortgagePropertyAdditionalFinancialInformationDto : FullAuditedEntity<int>
    {
        public string street { get; set; }
        public string unit { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zip { get; set; }
        public string country { get; set; }
        public decimal propertyValue { get; set; }
        public string intendedOccupancy { get; set; }
        public decimal monthlyInsurance { get; set; }
        public decimal monthlyRentalIncome { get; set; }
        public decimal netMonthlyRentalIncome { get; set; }
        public int? PersonalInformationId { get; set; }
    //    public virtual MortgageApplicationPersonalInformationDto PersonalInformation { get; set; }
    }

    [AutoMapFrom(typeof(MortgageLoanOnAdditionalPropertyFinancialInformation))]
    public class MortgageLoanOnAdditionalPropertyFinancialInformationDto : FullAuditedEntity<int>
    {
        public string creditorName { get; set; }
        public long accountNumber { get; set; }
        public decimal monthlyMortagagePayment { get; set; }
        public decimal unpaidBalance { get; set; }
        public string type { get; set; }
        public decimal creditLimit { get; set; }
        public bool isApplied { get; set; }
        public int? MortgagePropertyFinancialInformationId { get; set; }
    //    public virtual MortgagePropertyFinancialInformationDto MortgagePropertyFinancialInformation { get; set; }
    }
    public class CreateMortgagePropertyFinancialInformationDto
    {
        public MortgagePropertyFinancialInformationDto MortgagePropertyFinancialInformation { get; set; }
        public MortgagePropertyAdditionalFinancialInformationDto MortgagePropertyAdditionalFinancialInformation { get; set; }
        public List<MortgageLoanOnProperyFinancialInformationDto> MortgageLoanOnProperyFinancialInformation { get; set; }
        public List<MortgageLoanOnAdditionalPropertyFinancialInformationDto> MortgageLoanOnAdditionalPropertyFinancialInformation { get; set; }
    }


}
