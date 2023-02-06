using Abp.Domain.Entities.Auditing;
using LoanManagement.codeFirstEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.MortgageTables
{
    public class MortgageAppliactionFinancialAccount : FullAuditedEntity<int>
    {
       // public List<MortgageFinancialAccountType> MortgageFinancialAccountType { get; set; }

        public int? PersonalInformationId { get; set; }
        public virtual MortgageApplicationPersonalInformation PersonalInformation { get; set; }
        public string totalAmount { get; set; }
    }
}
