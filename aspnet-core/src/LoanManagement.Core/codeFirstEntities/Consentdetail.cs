using Abp.Domain.Entities;
using System;
using System.Collections.Generic;

namespace LoanManagement.codeFirstEntities
{
    public partial class Consentdetail : Entity<long>
    {
        public Consentdetail()
        {
            Loanapplications = new HashSet<Loanapplication>();
        }

        public long Id { get; set; }
        public bool? AgreeEconsent { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool? CoborrowerAgreeEconsent { get; set; }
        public string CoborrowerFirstName { get; set; }
        public string CoborrowerLastName { get; set; }
        public string CoborrowerEmail { get; set; }

        public virtual ICollection<Loanapplication> Loanapplications { get; set; }
    }
}
