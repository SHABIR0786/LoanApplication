using Abp.Domain.Entities;
using System;
using System.Collections.Generic;

namespace LoanManagement.codeFirstEntities
{
    public partial class Additionalincome : Entity<long>
    {
        public long Id { get; set; }
        public decimal? Amount { get; set; }
        public int? IncomeSourceId { get; set; }
        public int? BorrowerTypeId { get; set; }
        public long LoanApplicationId { get; set; }

        public virtual Borrowertype BorrowerType { get; set; }
        public virtual Incomesource1 IncomeSource { get; set; }
        public virtual Loanapplication LoanApplication { get; set; }
    }
}
