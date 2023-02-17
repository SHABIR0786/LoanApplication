using Abp.Domain.Entities.Auditing;
using LoanManagement.codeFirstEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.MortgageTables
{
    public class MortgageFinancialAccountType  : FullAuditedEntity<int>
    {
        public int? AccountTypeId { get; set; }
        public virtual FinancialAccountType AccountType { get; set; }
        public string FinancialInstitution { get; set; }
        public string AccountNumber { get; set; }
        public decimal CashMarketValue { get; set; }
        public int? PersonalInformationId { get; set; }
        public virtual MortgageApplicationPersonalInformation PersonalInformation { get; set; }

    }
}
