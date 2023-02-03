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
        public decimal baseIncome { get; set; }
        public decimal overtime { get; set; }
        public decimal bonus { get; set; }
        public decimal commission { get; set; }
        public decimal militaryEntitlements { get; set; }
        public decimal others { get; set; }
        public decimal total { get; set; }
        public int? AdditionalEmploymentDetailId { get; set; }
        public virtual MortgageApplicationAdditionalEmploymentDetail AdditionalEmploymentDetail { get; set; }
    }
}
