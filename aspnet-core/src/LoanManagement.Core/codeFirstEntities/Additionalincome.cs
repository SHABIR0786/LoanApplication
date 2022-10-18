using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;

namespace LoanManagement.codeFirstEntities
{
    public partial class Additionalincome :  FullAuditedEntity<long>
    {
        public decimal? Amount { get; set; }
        public int? IncomeSourceId { get; set; }
        public int? BorrowerTypeId { get; set; }
        public long LoanApplicationId { get; set; }

        public virtual Borrowertype BorrowerType { get; set; }
        public virtual Incomesource1 IncomeSource { get; set; }
        public virtual Loanapplication LoanApplication { get; set; }
    }
}
