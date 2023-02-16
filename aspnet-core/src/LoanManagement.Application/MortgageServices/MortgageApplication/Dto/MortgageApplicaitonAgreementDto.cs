using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using LoanManagement.MortgageTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.MortgageServices.MortgageApplication.Dto
{
    [AutoMapFrom(typeof(MortgageApplicationAgreement))]
    public class MortgageApplicationAgreementDto:FullAuditedEntityDto<int>
    {
        public bool? IsAgreeAgreement { get; set; }
        public int? PersonalInformationId { get; set; }
        //public virtual MortgageApplicationPersonalInformation PersonalInformation { get; set; }
    }
}
