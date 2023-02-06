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
    [AutoMapFrom(typeof(MortgageApplicationMilitaryService))]
    public class MortgageApplicationMilitaryServiceDto:FullAuditedEntityDto<int>
    {
        public int? PersonalInformationId { get; set; }
       // public virtual MortgageApplicationPersonalInformation PersonalInformation { get; set; }
        public bool? isServeUSForces { get; set; }
        public bool? isCurrentlyServing { get; set; }
        public string projectedExpirationServiceDate { get; set; }
        public bool? isCurrentlyRetired { get; set; }
        public bool? isNonActivatedMember { get; set; }
        public bool? isSurvivingSpouse { get; set; }
    }
}
