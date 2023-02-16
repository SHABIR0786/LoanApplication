using Abp.Domain.Entities;
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
        public string SourceType { get; set; }
        public decimal MonthlyIncome { get; set; }
        public int? IncomeSourceId { get; set; }
        public virtual MortgageApplicationIncomeSource IncomeSource { get; set; }
    }
}
