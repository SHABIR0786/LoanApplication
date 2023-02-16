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
        public string TotalAmount { get; set; }
    }


    [AutoMapFrom(typeof(MortgageAppliactionFinancialCredit))]
    public class MortgageAppliactionFinancialCreditDto : FullAuditedEntityDto<int>
    {
        public List<MortgageFinancialAssetsTypeDto> MortgageFinancialAssetsType { get; set; }
        public int? PersonalInformationId  { get; set; }
       // public virtual MortgageApplicationPersonalInformationDto PersonalInformation { get; set; }
        public string TotalAmount { get; set; }

    }




    [AutoMapFrom(typeof(MortgageAppliactionFinancialLiability))]
    public class MortgageApplicationFinancialLiabilityDto : FullAuditedEntityDto<int>
    {
        public List<MortgageFinancialLaibilitiesTypeDto> MortgageFinancialLaibilitiesType { get; set; }
        public string TotalAmount { get; set; }

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

        public string AccountType { get; set; }
        public string FinancialInstitution { get; set; }
        public string AccountNumber { get; set; }
        public string CashMarketValue { get; set; }

        public int? MortgageAppliactionFinancialAccountId { get; set; }

        //public virtual MortgageAppliactionFinancialAccountDto MortgageAppliactionFinancialAccount { get; set; }

    }




    [AutoMapFrom(typeof(MortgageFinancialCreditType))]
    public class MortgageFinancialAssetsTypeDto : FullAuditedEntityDto<int>
    {

        public string AssetsCreditType { get; set; }
        public string CashMarketValue { get; set; }

        public int? MortgageAppliactionFinancialCreditId { get; set; }
       // public virtual MortgageAppliactionFinancialCreditDto MortgageAppliactionFinancialCreditDto { get; set; }
    }



    [AutoMapFrom(typeof(MortgageFinancialLaibilitiesType))]
    public class MortgageFinancialLaibilitiesTypeDto : FullAuditedEntityDto<int>
    {

        public string AccountType { get; set; }
        public string CompanyName { get; set; }
        public string AccountNumber { get; set; }
        public string UnpaidBalance { get; set; }
        public string CashMarketValue { get; set; }

        public int? MortgageApplicationFinancialLiabilityId { get; set; }

       // public virtual MortgageApplicationFinancialLiabilityDto MortgageApplicationFinancialLiability { get; set; }
    }


    [AutoMapFrom(typeof(MortgageFinancialOtherLaibilitiesType))]
    public class MortgageFinancialOtherLaibilitiesTypeDto : FullAuditedEntityDto<int>
    {
        public string Expense { get; set; }
        public string CashMarketValue { get; set; }

        public int? MortgageApplicationFinancialOtherLiabilityId { get; set; }
       // public virtual MortgageApplicationFinancialOtherLiabilityDto MortgageApplicationFinancialOtherLiability { get; set; }
    }

    public class CreateMotgageApplicationFinancialAsset
    {
        public MortgageAppliactionFinancialAccountDto MortgageAppliactionFinancialAccount { get; set; }
        public MortgageAppliactionFinancialCreditDto MortgageAppliactionFinancialCredit { get; set; }
        public MortgageApplicationFinancialLiabilityDto MortgageappliactionFinancialLiability { get; set; }
        public MortgageApplicationFinancialOtherLiabilityDto MortgageappliactionFinancialOtherLiability { get; set; }
        public string BorrowerName { get; set; }
    }
}
