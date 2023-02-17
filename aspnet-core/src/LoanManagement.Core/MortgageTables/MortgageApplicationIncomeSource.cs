using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using LoanManagement.codeFirstEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.MortgageTables
{
    public class MortgageApplicationIncomeSource:FullAuditedEntity<int>
    {  
        public decimal MonthlyIncome { get; set; }
        public int? IncomeSourceId { get; set; }
        public virtual IncomeSource IncomeSource { get; set; }
        public int? PersonalInformationId { get; set; }
        public virtual MortgageApplicationPersonalInformation PersonalInformation { get; set; }
    }
}
