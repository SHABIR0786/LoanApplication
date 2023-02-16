using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities.Auditing;

namespace LoanManagement.MortgageTables
{
    public class MortgageFinancialOtherLaibilitiesType : FullAuditedEntity<int>
    {
        public string Expense { get; set; }
        public string CashMarketValue { get; set; }

        public int? MortgageApplicationFinancialOtherLiabilityId { get; set; }  
        public virtual MortgageAppliactionFinancialOtherLiability MortgageApplicationFinancialOtherLiability { get;set; }
    }
}
