using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.MortgageTables
{
    public class MortgageFinancialAccountType  : FullAuditedEntity<int>
    {
        public string AccountType { get; set; }
        public string FinancialInstitution { get; set; }
        public string AccountNumber { get; set; }
        public string CashMarketValue { get; set; }

        public int? MortgageAppliactionFinancialAccountId { get; set; }

        public virtual MortgageAppliactionFinancialAccount MortgageAppliactionFinancialAccount { get; set; }
     
    }
}
