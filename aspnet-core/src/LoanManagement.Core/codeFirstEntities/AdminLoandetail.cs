using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;

namespace LoanManagement.codeFirstEntities
{
    public partial class AdminLoandetail : FullAuditedEntity<int>
    {
        public AdminLoandetail()
        {
            AdminLoanapplicationdocuments = new HashSet<AdminLoanapplicationdocument>();
            AdminLoansummarystatuses = new HashSet<AdminLoansummarystatus>();
        }

        //public int UserId { get; set; }
        public int LoanApplicationId { get; set; }
        public string LoanNo { get; set; }
        public string MortageConsultant { get; set; }
        public string NmlsId { get; set; }
        public string BorrowerName { get; set; }
        public string PropertyAddress { get; set; }
        public int LoanProgramId { get; set; }
        public float? LoanAmount { get; set; }
        public string LoanPurpose { get; set; }
        public float? InterestRate { get; set; }
        public DateTime? ApplicationDate { get; set; }
        public DateTime? RateLockDate { get; set; }
        public DateTime? RateLockExpirationDate { get; set; }

        public virtual Application LoanApplication { get; set; }
        public virtual AdminLoanprogram LoanProgram { get; set; }
        //public virtual AdminUser User { get; set; }
        public virtual ICollection<AdminLoanapplicationdocument> AdminLoanapplicationdocuments { get; set; }
        public virtual ICollection<AdminLoansummarystatus> AdminLoansummarystatuses { get; set; }
    }
}
