using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.MortgageTables
{
    public class MortgageFinancialLaibilitiesType : FullAuditedEntity<int>
    {
        public string AccountType { get; set; }
        public string CompanyName { get; set; }
        public string AccountNumber { get; set; }
        public string UnpaidBalance { get; set; }
        public string CashMarketValue { get; set; }

        public int? MortgageApplicationFinancialLiabilityId { get; set; }

        public virtual MortgageAppliactionFinancialLiability MortgageApplicationFinancialLiability { get; set; }    
    }
}
