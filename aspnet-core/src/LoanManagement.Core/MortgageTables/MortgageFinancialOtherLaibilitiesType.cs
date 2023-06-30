using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities.Auditing;
using LoanManagement.codeFirstEntities;

namespace LoanManagement.MortgageTables
{
    public class MortgageFinancialOtherLaibilitiesType : FullAuditedEntity<int>
    {
        public int? FinancialOtherLaibilitiesTypeId { get; set; }
        public virtual FinancialOtherLaibilitiesType FinancialOtherLaibilitiesType { get; set; }
        public decimal MonthlyPayment { get; set; }
        public int? PersonalInformationId { get; set; }
        public virtual MortgageApplicationPersonalInformation PersonalInformation { get; set; }
    }
}
