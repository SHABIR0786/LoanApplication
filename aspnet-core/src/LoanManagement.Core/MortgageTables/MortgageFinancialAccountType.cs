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
        public string accountType { get; set; }
        public string financialInstitution { get; set; }
        public string accountNumber { get; set; }
        public string cashMarketValue { get; set; }

        public int? MortgageAppliactionFinancialAccountId { get; set; }

        public virtual MortgageAppliactionFinancialAccount MortgageAppliactionFinancialAccount { get; set; }
     
    }
}
