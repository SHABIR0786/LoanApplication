using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.MortgageTables
{
    public class MortgageApplicationSource:FullAuditedEntity<int>
    {
        public string sourceType { get; set; }
        public decimal monthlyIncome { get; set; }
        public int? IncomeSourceId { get; set; }
        public virtual MortgageApplicationIncomeSource IncomeSource { get; set; }
    }
}
