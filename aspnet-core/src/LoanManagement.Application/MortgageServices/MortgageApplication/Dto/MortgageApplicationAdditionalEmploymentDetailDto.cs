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
    [AutoMapFrom(typeof(MortgageApplicationAdditionalEmploymentDetail))]
    public class MortgageApplicationAdditionalEmploymentDetailDto : FullAuditedEntityDto<int>
    {
        public string name { get; set; }
        public string phone { get; set; }
        public string street { get; set; }
        public string unit { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zip { get; set; }
        public string country { get; set; }
        public string ownershipShare { get; set; }
        public string monthlyIncome { get; set; }
        public int? workingYears { get; set; }
        public int? workingMonths { get; set; }
        public string position { get; set; }
        public DateTime startDate { get; set; }
        public bool isEmployedBySomeone { get; set; }
        public bool isSelfEmployed { get; set; }
        public bool isOwnershipLessThan25 { get; set; }
        public int? PersonalInformationId { get; set; }
        //public virtual MortgageApplicationPersonalInformationDto PersonalInformation { get; set; }
        public MortgageApplicationAdditionalEmploymentIncomeDetailDto GrossMonthlyIncome { get; set; }
    }
}
