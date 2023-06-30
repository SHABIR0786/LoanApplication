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
        public List<MortgageApplicationEmploymentDetailDto> Employment { get; set; }
        public List<MortgageApplicationIncomeSourceDto> IncomeOtherSources { get; set; }
        public List<MortgageApplicationPersonalInformationDto> OtherBorrowers { get; set; }
    }

    [AutoMapFrom(typeof(MortgageApplicationIncomeSource))]
    public class MortgageApplicationIncomeSourceDto : FullAuditedEntityDto<int>
    {
        public decimal MonthlyIncome { get; set; }
        public int? IncomeSourceId { get; set; }
        public int? PersonalInformationId { get; set; }
      //  public virtual MortgageApplicationPersonalInformationDto PersonalInformation { get; set; }
        public List<MortgageApplicationSourceDto> Sources { get; set; }
    }
    [AutoMapFrom(typeof(MortgageApplicationTypeOfCredit))]
    public class MortgageApplicationTypeOfCreditDto : FullAuditedEntityDto<int>
    {
        public string ApplyingFor { get; set; }
        public int? TotalBorrowers { get; set; }
        public string YourIntials { get; set; }
        public int? PersonalInformationId { get; set; }
       // public virtual MortgageApplicationPersonalInformationDto PersonalInformation { get; set; }
    }
    [AutoMapFrom(typeof(MortgageApplicationOtherBorrower))]
    public class MortgageApplicationOtherBorrowerDto : FullAuditedEntityDto<int>
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Suffix { get; set; }
        public string Email { get; set; }
        public int? PersonalInformationId { get; set; }
       // public virtual MortgageApplicationPersonalInformationDto PersonalInformation { get; set; }
    }
    [AutoMapFrom(typeof(MortgageApplicationContactInformation))]
    public class MortgageApplicationContactInformationDto : FullAuditedEntityDto<int>
    {
        public string HomePhone { get; set; }
        public string CellPhone { get; set; }
        public string WorkPhone { get; set; }
        public string Ext { get; set; }
        public string Email { get; set; }
        public int? PersonalInformationId { get; set; }
        // public virtual MortgageApplicationPersonalInformationDto PersonalInformation { get; set; }
    }
}
