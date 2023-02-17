using Abp.Domain.Entities.Auditing;
using LoanManagement.codeFirstEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.MortgageTables
{
    public class MortgageFinancialLaibilitiesType : FullAuditedEntity<int>
    {
        public int? FinancialLaibilitiesTypeId { get; set; }
        public virtual FinancialLaibilitiesType FinancialLaibilitiesType { get; set; }
        public string AccountNumber { get; set; }
        public decimal UnpaidBalance { get; set; }
        public bool? IsPaidBeforeClosing { get; set; }
        public decimal MonthlyPayment { get; set; }
        public int? PersonalInformationId { get; set; }
        public virtual MortgageApplicationPersonalInformation PersonalInformation { get; set; }
    }
}
