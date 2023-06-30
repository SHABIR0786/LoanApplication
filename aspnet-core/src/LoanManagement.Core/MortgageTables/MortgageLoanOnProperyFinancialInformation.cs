using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.MortgageTables
{
    public class MortgageLoanOnProperyFinancialInformation : FullAuditedEntity<int>
    {
        public string CreditorName { get; set; }
        public string AccountNumber { get; set; }
        public decimal MonthlyMortagagePayment { get; set; }
        public decimal UnpaidBalance { get; set; }
        public string Type { get; set; }
        public decimal CreditLimit { get; set; }
        public bool? IsPaidBeforeClosing { get; set; }
        public int? MortgagePropertyFinancialInformationId { get; set; }
        public virtual MortgagePropertyFinancialInformation MortgagePropertyFinancialInformation { get; set; }
    }
}
