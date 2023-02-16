using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.MortgageTables
{
    public class MortgageApplicationEmploymentIncomeDetail:FullAuditedEntity<int>
    {
        public decimal BaseIncome { get; set; }
        public decimal Overtime { get; set; }
        public decimal Bonus { get; set; }
        public decimal Commission { get; set; }
        public decimal MilitaryEntitlements { get; set; }
        public decimal Other { get; set; }
        public decimal Total { get; set; }
        public int? EmploymentDetailId { get; set; }
        public virtual MortgageApplicationEmploymentDetail EmploymentDetail { get; set; }
    }
}
