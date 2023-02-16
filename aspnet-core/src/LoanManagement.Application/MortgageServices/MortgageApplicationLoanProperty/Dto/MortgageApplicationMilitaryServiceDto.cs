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
        public bool? IsServeUSForces { get; set; }
        public bool? IsCurrentlyServing { get; set; }
        public string ProjectedExpirationServiceDate { get; set; }
        public bool? IsCurrentlyRetired { get; set; }
        public bool? IsNonActivatedMember { get; set; }
        public bool? IsSurvivingSpouse { get; set; }
    }
}
