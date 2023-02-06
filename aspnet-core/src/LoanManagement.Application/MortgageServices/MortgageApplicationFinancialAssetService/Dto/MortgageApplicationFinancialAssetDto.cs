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
        public string totalAmount { get; set; }
    }


    [AutoMapFrom(typeof(MortgageAppliactionFinancialCredit))]
    public class MortgageAppliactionFinancialCreditDto : FullAuditedEntityDto<int>
    {
        public List<MortgageFinancialAssetsTypeDto> MortgageFinancialAssetsType { get; set; }
        public int? PersonalInformationId  { get; set; }
       // public virtual MortgageApplicationPersonalInformationDto PersonalInformation { get; set; }
        public string totalAmount { get; set; }

    }




    [AutoMapFrom(typeof(MortgageAppliactionFinancialLiability))]
    public class MortgageApplicationFinancialLiabilityDto : FullAuditedEntityDto<int>
    {
        public List<MortgageFinancialLaibilitiesTypeDto> MortgageFinancialLaibilitiesType { get; set; }
        public string totalAmount { get; set; }

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

        public string accountType { get; set; }
        public string financialInstitution { get; set; }
        public string accountNumber { get; set; }
        public string cashMarketValue { get; set; }

        public int? MortgageAppliactionFinancialAccountId { get; set; }

        //public virtual MortgageAppliactionFinancialAccountDto MortgageAppliactionFinancialAccount { get; set; }

    }




    [AutoMapFrom(typeof(MortgageFinancialCreditType))]
    public class MortgageFinancialAssetsTypeDto : FullAuditedEntityDto<int>
    {

        public string assetsCreditType { get; set; }
        public string cashMarketValue { get; set; }

        public int? MortgageAppliactionFinancialCreditId { get; set; }
       // public virtual MortgageAppliactionFinancialCreditDto MortgageAppliactionFinancialCreditDto { get; set; }
    }



    [AutoMapFrom(typeof(MortgageFinancialLaibilitiesType))]
    public class MortgageFinancialLaibilitiesTypeDto : FullAuditedEntityDto<int>
    {

        public string accountType { get; set; }
        public string companyName { get; set; }
        public string accountNumber { get; set; }
        public string unpaidBalance { get; set; }
        public string cashMarketValue { get; set; }

        public int? MortgageApplicationFinancialLiabilityId { get; set; }

       // public virtual MortgageApplicationFinancialLiabilityDto MortgageApplicationFinancialLiability { get; set; }
    }


    [AutoMapFrom(typeof(MortgageFinancialOtherLaibilitiesType))]
    public class MortgageFinancialOtherLaibilitiesTypeDto : FullAuditedEntityDto<int>
    {
        public string expense { get; set; }
        public string cashMarketValue { get; set; }

        public int? MortgageApplicationFinancialOtherLiabilityId { get; set; }
       // public virtual MortgageApplicationFinancialOtherLiabilityDto MortgageApplicationFinancialOtherLiability { get; set; }
    }

    public class CreateMotgageApplicationFinancialAsset
    {
        public MortgageAppliactionFinancialAccountDto mortgageAppliactionFinancialAccount { get; set; }
        public MortgageAppliactionFinancialCreditDto mortgageAppliactionFinancialCredit { get; set; }
        public MortgageApplicationFinancialLiabilityDto mortgageappliactionFinancialLiability { get; set; }
        public MortgageApplicationFinancialOtherLiabilityDto mortgageappliactionFinancialOtherLiability { get; set; }
        public string borrowerName { get; set; }
    }
}
