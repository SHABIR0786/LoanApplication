using System;
using System.Collections.Generic;

namespace LoanManagement.Entities.Models
{
    public partial class Application
    {
        public Application()
        {
            ApplicationPersonalInformations = new HashSet<ApplicationPersonalInformation>();
        }

        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string LoanNoIdentifierB1B3 { get; set; } = null!;
        public string AgencyCaseNoB2 { get; set; } = null!;
        public int CreditTypeId { get; set; }
        public int? TotalBorrowers1a6 { get; set; }
        public string Initials { get; set; }

        public virtual CreditType CreditType { get; set; } = null!;
        public virtual ICollection<AdminLoandetail> AdminLoandetails { get; set; }
        public virtual ICollection<ApplicationPersonalInformation> ApplicationPersonalInformations { get; set; }
    }
}
