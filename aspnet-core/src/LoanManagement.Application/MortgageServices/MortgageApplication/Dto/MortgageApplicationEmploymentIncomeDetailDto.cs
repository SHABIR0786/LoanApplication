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
        public decimal baseIncome { get; set; }
        public decimal overtime { get; set; }
        public decimal bonus { get; set; }
        public decimal commission { get; set; }
        public decimal militaryEntitlements { get; set; }
        public decimal other { get; set; }
        public decimal total { get; set; }
        public int? EmploymentDetailId { get; set; }
      //  public virtual MortgageApplicationEmploymentDetailDto EmploymentDetail { get; set; }
    }
}
