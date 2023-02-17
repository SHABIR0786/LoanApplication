using Abp.Domain.Entities.Auditing;
using LoanManagement.codeFirstEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.MortgageTables
{
    public class MortgageFinancialCreditType : FullAuditedEntity<int>
    {
        public int? FinancialAssetsTypeId { get; set; }
        public virtual FinancialAssetsType FinancialAssetsType { get; set; }
        public decimal CashMarketValue { get; set; }

        public int? PersonalInformationId { get; set; }
        public virtual MortgageApplicationPersonalInformation PersonalInformation { get; set; }
    }
}
