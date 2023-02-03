using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.MortgageTables
{
    public class MortgageApplicationIncomeSource:FullAuditedEntity<int>
    {
        public decimal totalAmount { get; set; }
        public int? PersonalInformationId { get; set; }
        public virtual MortgageApplicationPersonalInformation PersonalInformation { get; set; }
    }
}
