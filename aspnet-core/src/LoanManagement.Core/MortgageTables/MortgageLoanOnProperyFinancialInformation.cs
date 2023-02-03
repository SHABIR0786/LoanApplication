using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.MortgageTables
{
    public class MortgageLoanOnProperyFinancialInformation:FullAuditedEntity<int>
    {
        public string creditorName { get; set; }
        public long accountNumber { get; set; }
        public decimal monthlyMortagagePayment{ get; set; }
        public decimal unpaidBalance{ get; set; }
        public string type { get; set; }
        public decimal creditLimit{ get; set; }
        public bool isApplied { get; set; }
        public int? MortgagePropertyFinancialInformationId { get; set; }
        public virtual MortgagePropertyFinancialInformation MortgagePropertyFinancialInformation { get; set; }
    }
}
