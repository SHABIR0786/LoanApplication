using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using LoanManagement.codeFirstEntities;
using LoanManagement.MortgageServices.MortgageApplication.Dto;
using LoanManagement.MortgageTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.MortgageServices.MortgageApplicationFinancialAssetService.Dto
{
    [AutoMapFrom(typeof(MortgageAppliactionFinancialAccount))]
    public class MortgageAppliactionFinancialAccountDto : FullAuditedEntityDto<int>
    {
        public List<MortgageFinancialAccountTypeDto> MortgageFinancialAccountType { get; set; }

        public int? PersonalInformationId  { get; set; }
      // public virtual MortgageApplicationPersonalInformationDto PersonalInformation { get; set; }
        public decimal TotalAmount { get; set; }
        public string FinancialType { get; set; }
    }


    [AutoMapFrom(typeof(MortgageAppliactionFinancialCredit))]
    public class MortgageAppliactionFinancialCreditDto : FullAuditedEntityDto<int>
    {
        public List<MortgageFinancialAssetsTypeDto> MortgageFinancialAssetsType { get; set; }
        public int? PersonalInformationId  { get; set; }
       // public virtual MortgageApplicationPersonalInformationDto PersonalInformation { get; set; }
        public decimal TotalAmount { get; set; }

    }




    [AutoMapFrom(typeof(MortgageAppliactionFinancialLiability))]
    public class MortgageApplicationFinancialLiabilityDto : FullAuditedEntityDto<int>
    {
        public List<MortgageFinancialLaibilitiesTypeDto> MortgageFinancialLaibilitiesType { get; set; }
        public decimal TotalAmount { get; set; }

        public int? PersonalInformationId  { get; set; }
       // public virtual MortgageApplicationPersonalInformationDto PersonalInformation { get; set; }
    }



    [AutoMapFrom(typeof(MortgageAppliactionFinancialOtherLiability))]
    public class MortgageApplicationFinancialOtherLiabilityDto : FullAuditedEntityDto<int>
    {
        public List<MortgageFinancialOtherLaibilitiesTypeDto> MortgageFinancialOtherLaibilitiesType { get; set; }

        public int? PersonalInformationId  { get; set; }
     //  public virtual MortgageApplicationPersonalInformationDto PersonalInformation { get; set; }
     

    }


    [AutoMapFrom(typeof(MortgageFinancialAccountType))]
    public class MortgageFinancialAccountTypeDto : FullAuditedEntityDto<int>
    {

        public int? AccountTypeId { get; set; }
        public string FinancialInstitution { get; set; }
        public string AccountNumber { get; set; }
        public decimal CashMarketValue { get; set; }
        public int? PersonalInformationId { get; set; }     

    }




    [AutoMapFrom(typeof(MortgageFinancialCreditType))]
    public class MortgageFinancialAssetsTypeDto : FullAuditedEntityDto<int>
    {

        public int? FinancialAssetsTypeId { get; set; }
        public decimal CashMarketValue { get; set; }

        public int? PersonalInformationId { get; set; }       
    }



    [AutoMapFrom(typeof(MortgageFinancialLaibilitiesType))]
    public class MortgageFinancialLaibilitiesTypeDto : FullAuditedEntityDto<int>
    {
        public int? FinancialLaibilitiesTypeId { get; set; }
        public string CompanyName { get; set; }
        public string AccountNumber { get; set; }
        public decimal UnpaidBalance { get; set; }
        public bool? IsPaidBeforeClosing { get; set; }
        public decimal MonthlyPayment { get; set; }
        public int? PersonalInformationId { get; set; }
    }


    [AutoMapFrom(typeof(MortgageFinancialOtherLaibilitiesType))]
    public class MortgageFinancialOtherLaibilitiesTypeDto : FullAuditedEntityDto<int>
    {
        public int? FinancialOtherLaibilitiesTypeId { get; set; }
        public decimal MonthlyPayment { get; set; }
        public int? PersonalInformationId { get; set; }
        
    }

    public class CreateMotgageApplicationFinancialAsset
    {
        public List<MortgageFinancialAccountTypeDto> MortgageFinancialAssets { get; set; }
        public List<MortgageFinancialAssetsTypeDto> MortgageFinancialOtherAssets { get; set; }
        public List<MortgageFinancialLaibilitiesTypeDto> MortgageFinancialLiabilities { get; set; }
        public List<MortgageFinancialOtherLaibilitiesTypeDto> MortgageFinancialOtherLaibilities { get; set; }
    }
}
