using Abp.Domain.Entities.Auditing;
using LoanManagement.codeFirstEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.MortgageTables
{
    public class MortgageAppliactionFinancialOtherLiability : FullAuditedEntity<int>
    {
       // public List<MortgageFinancialOtherLaibilitiesType> MortgageFinancialOtherLaibilitiesType { get; set; }

        public int? PersonalInformationId { get; set; }
        public virtual MortgageApplicationPersonalInformation PersonalInformation { get; set; }
    }
}
