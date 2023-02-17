using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.MortgageTables
{
    public class MortgageAppliactionFinancialLiability : FullAuditedEntity<int>
    {
        //public List<MortgageFinancialLaibilitiesType> MortgageFinancialLaibilitiesType { get; set; }
        public decimal TotalAmount { get; set; }

        public int? PersonalInformationId { get; set; }
        public virtual MortgageApplicationPersonalInformation PersonalInformation { get; set; }
    }
}
