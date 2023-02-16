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
    [AutoMapFrom(typeof(MortgageApplicationEmploymentIncomeDetail))]
    public class MortgageApplicationEmploymentIncomeDetailDto : FullAuditedEntityDto<int>
    {
        public decimal BaseIncome { get; set; }
        public decimal Overtime { get; set; }
        public decimal Bonus { get; set; }
        public decimal Commission { get; set; }
        public decimal MilitaryEntitlements { get; set; }
        public decimal Other { get; set; }
        public decimal Total { get; set; }
        public int? EmploymentDetailId { get; set; }
      //  public virtual MortgageApplicationEmploymentDetailDto EmploymentDetail { get; set; }
    }
}
