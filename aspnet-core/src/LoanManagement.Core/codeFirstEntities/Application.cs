using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;

namespace LoanManagement.codeFirstEntities
{
    public partial class Application: FullAuditedEntity<int>
    {
        public Application()
        {
            AdminLoandetails = new HashSet<AdminLoandetail>();
            ApplicationPersonalInformations = new HashSet<ApplicationPersonalInformation>();
        }

        public DateTime Date { get; set; }
        public string LoanNoIdentifierB1B3 { get; set; }
        public string AgencyCaseNoB2 { get; set; }
        public int CreditTypeId { get; set; }
        public int? TotalBorrowers1a6 { get; set; }
        public string Initials { get; set; }

        public virtual CreditType CreditType { get; set; }
        public virtual ICollection<AdminLoandetail> AdminLoandetails { get; set; }
        public virtual ICollection<ApplicationPersonalInformation> ApplicationPersonalInformations { get; set; }
    }
}
