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
        public string accountType { get; set; }
        public string companyName { get; set; }
        public string accountNumber { get; set; }
        public string unpaidBalance { get; set; }
        public string cashMarketValue { get; set; }

        public int? MortgageApplicationFinancialLiabilityId { get; set; }

        public virtual MortgageAppliactionFinancialLiability MortgageApplicationFinancialLiability { get; set; }    
    }
}
