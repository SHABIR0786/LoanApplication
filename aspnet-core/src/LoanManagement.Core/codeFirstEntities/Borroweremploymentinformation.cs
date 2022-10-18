using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;

namespace LoanManagement.codeFirstEntities
{
    public partial class Borroweremploymentinformation : FullAuditedEntity<long>
    {
        public string EmployersName { get; set; }
        public string EmployersAddress1 { get; set; }
        public string EmployersAddress2 { get; set; }
        public bool? IsSelfEmployed { get; set; }
        public string Position { get; set; }
        public string City { get; set; }
        public int? StateId { get; set; }
        public int? ZipCode { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int BorrowerTypeId { get; set; }
        public long LoanApplicationId { get; set; }

        public virtual Borrowertype BorrowerType { get; set; }
        public virtual Loanapplication LoanApplication { get; set; }
    }
}
