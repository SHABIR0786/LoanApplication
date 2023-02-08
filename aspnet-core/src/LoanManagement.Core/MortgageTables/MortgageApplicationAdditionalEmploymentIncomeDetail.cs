using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.MortgageTables
{
    public class MortgageApplicationAdditionalEmploymentIncomeDetail:FullAuditedEntity<int>
    {
        public decimal BaseIncome { get; set; }
        public decimal Overtime { get; set; }
        public decimal Bonus { get; set; }
        public decimal Commission { get; set; }
        public decimal MilitaryEntitlements { get; set; }
        public decimal Others { get; set; }
        public decimal Total { get; set; }
        public int? AdditionalEmploymentDetailId { get; set; }
        public virtual MortgageApplicationAdditionalEmploymentDetail AdditionalEmploymentDetail { get; set; }
    }
}
