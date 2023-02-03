using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using LoanManagement.codeFirstEntities;
using LoanManagement.MortgageTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.MortgageServices.MortgageApplication.Dto
{
    [AutoMapFrom(typeof(MortgageApplications))]
    public class MortgageApplicationsDto : FullAuditedEntityDto<int>
    {

    }
    [AutoMapFrom(typeof(MortgageApplicationPersonalInformation))]
    public class MortgageApplicationPersonalInformationDto : FullAuditedEntityDto<int>
    {

    }
    [AutoMapFrom(typeof(MortgageApplicationEmployementDetail))]
    public class MortgageApplicationEmployementDetailDto : FullAuditedEntityDto<int>
    {
    }
    [AutoMapFrom(typeof(MortgageApplicationEmployementIncomeDetail))]
    public class MortgageApplicationEmployementIncomeDetailDto : FullAuditedEntityDto<int>
    {
    }
    [AutoMapFrom(typeof(MortgageApplicationAdditionalEmployementDetail))]
    public class MortgageApplicationAdditionalEmployementDetailDto : FullAuditedEntityDto<int>
    {
    }
    [AutoMapFrom(typeof(MortgageApplicationAdditionalEmployementIncomeDetail))]
    public class MortgageApplicationAdditionalEmployementIncomeDetailDto : FullAuditedEntityDto<int>
    {
    }
    [AutoMapFrom(typeof(MortgageApplicationPreviousEmployementDetail))]
    public class MortgageApplicationPreviousEmployementDetailDto : FullAuditedEntityDto<int>
    {
    }
}
