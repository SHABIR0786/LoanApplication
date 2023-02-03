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
    public class MortgageApplicationDto : FullAuditedEntityDto<int>
    {
        public MortgageApplicationPersonalInformationDto PersonalInformation { get; set; }
        public MortgageApplicationEmploymentDetailDto CurrentEmployment { get; set; }
        public MortgageApplicationAdditionalEmploymentDetailDto AdditionalEmployment { get; set; }
        public MortgageApplicationPreviousEmploymentDetailDto PreviousEmployment { get; set; }
        public MortgageApplicationIncomeSourceDto IncomeOtherSources { get; set; }
    }
    //public class CreateMortgageLoanApplicationDto
    //{
    //    public MortgageApplicationDto MortgageApplication { get; set; }
    //    public MortgageApplicationPersonalInformationDto PersonalInformation { get; set; }
    //    public MortgageApplicationEmploymentDetailDto CurrentEmployment { get; set; }
    //    public MortgageApplicationAdditionalEmploymentDetailDto AdditionalEmployment { get; set; }
    //    public MortgageApplicationPreviousEmploymentDetailDto PreviousEmployment { get; set; }
    //    public MortgageApplicationIncomeSourceDto IncomeOtherSources { get; set; }
    //}

    [AutoMapFrom(typeof(MortgageApplicationIncomeSource))]
    public class MortgageApplicationIncomeSourceDto : FullAuditedEntityDto<int>
    {
        public decimal totalAmount { get; set; }
        public int? PersonalInformationId { get; set; }
      //  public virtual MortgageApplicationPersonalInformationDto PersonalInformation { get; set; }
        public List<MortgageApplicationSourceDto> Sources { get; set; }
    }
    [AutoMapFrom(typeof(MortgageApplicationTypeOfCredit))]
    public class MortgageApplicationTypeOfCreditDto : FullAuditedEntityDto<int>
    {
        public string applyingFor { get; set; }
        public int? totalBorrowers { get; set; }
        public string yourIntials { get; set; }
        public int? PersonalInformationId { get; set; }
       // public virtual MortgageApplicationPersonalInformationDto PersonalInformation { get; set; }
    }
    [AutoMapFrom(typeof(MortgageApplicationOtherBorrower))]
    public class MortgageApplicationOtherBorrowerDto : FullAuditedEntityDto<int>
    {
        public string firstName { get; set; }
        public string middleName { get; set; }
        public string lastName { get; set; }
        public string suffix { get; set; }
        public string email { get; set; }
        public int? PersonalInformationId { get; set; }
       // public virtual MortgageApplicationPersonalInformationDto PersonalInformation { get; set; }
    }
    [AutoMapFrom(typeof(MortgageApplicationContactInformation))]
    public class MortgageApplicationContactInformationDto : FullAuditedEntityDto<int>
    {
        public string homePhone { get; set; }
        public string cellPhone { get; set; }
        public string workPhone { get; set; }
        public string ext { get; set; }
        public string email { get; set; }
        public int? PersonalInformationId { get; set; }
        // public virtual MortgageApplicationPersonalInformationDto PersonalInformation { get; set; }
    }
}
