using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using LoanManagement.MortgageTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.MortgageServices.MortgageApplicationLoanProperty.Dto
{
    [AutoMapFrom(typeof(MortgageApplicationLoanOriginatorInformation))]
    public class MortgageApplicationLoanOriginatorInformationDto:FullAuditedEntityDto<int>
    {
        public int? PersonalInformationId { get; set; }
       // public virtual MortgageApplicationPersonalInformation PersonalInformation { get; set; }
        public string OrganizationName { get; set; }
        public string Address { get; set; }
        public string OrganizationNmlsrId { get; set; }
        public string OrganizationStateLicenceId { get; set; }
        public string OriginatorName { get; set; }
        public string OriginatorNmlsrId { get; set; }
        public string OriginatorStateLicenseId { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Date { get; set; }
    }
}
