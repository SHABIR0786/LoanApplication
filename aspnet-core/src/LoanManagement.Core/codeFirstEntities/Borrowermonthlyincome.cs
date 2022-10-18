using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;

namespace LoanManagement.codeFirstEntities
{
    public partial class Borrowermonthlyincome : FullAuditedEntity<long>
    {
        public decimal? Base { get; set; }
        public decimal? Overtime { get; set; }
        public decimal? Bonuses { get; set; }
        public decimal? Commissions { get; set; }
        public decimal? Dividends { get; set; }
        public int BorrowerTypeId { get; set; }
        public long LoanApplicationId { get; set; }

        public virtual Borrowertype BorrowerType { get; set; }
        public virtual Loanapplication LoanApplication { get; set; }
    }
}
