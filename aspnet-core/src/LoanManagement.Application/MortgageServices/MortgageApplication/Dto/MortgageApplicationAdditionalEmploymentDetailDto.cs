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
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Street { get; set; }
        public string Unit { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }
        public string OwnershipShare { get; set; }
        public string MonthlyIncome { get; set; }
        public int? WorkingYears { get; set; }
        public int? WorkingMonths { get; set; }
        public string Position { get; set; }
        public string StartDate { get; set; }
        public bool IsEmployedBySomeone { get; set; }
        public bool IsSelfEmployed { get; set; }
        public bool IsOwnershipLessThan25 { get; set; }
        public int? PersonalInformationId { get; set; }
        //public virtual MortgageApplicationPersonalInformationDto PersonalInformation { get; set; }
        public MortgageApplicationAdditionalEmploymentIncomeDetailDto GrossMonthlyIncome { get; set; }
    }
}
