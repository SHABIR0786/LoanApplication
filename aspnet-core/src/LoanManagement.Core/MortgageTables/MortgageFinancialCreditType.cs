using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.MortgageTables
{
    public class MortgageFinancialCreditType : FullAuditedEntity<int>
    {
        public string assetsCreditType { get; set; }
        public string cashMarketValue { get; set; }

        public int? MortgageAppliactionFinancialCreditId { get; set; }
        public virtual MortgageAppliactionFinancialCredit MortgageAppliactionFinancialCredit { get; set; }
    }
}
