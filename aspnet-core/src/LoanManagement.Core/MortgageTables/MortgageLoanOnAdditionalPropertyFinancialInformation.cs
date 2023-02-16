using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.MortgageTables
{
    public class MortgageLoanOnAdditionalPropertyFinancialInformation : FullAuditedEntity<int>
    {
        public string CreditorName { get; set; }
        public long AccountNumber { get; set; }
        public decimal MonthlyMortagagePayment { get; set; }
        public decimal UnpaidBalance { get; set; }
        public string Type { get; set; }
        public decimal CreditLimit { get; set; }
        public bool? IsApplied { get; set; }
        public int? MortgagePropertyFinancialInformationId { get; set; }
        public virtual MortgagePropertyFinancialInformation MortgagePropertyFinancialInformation { get; set; }
    }
}
