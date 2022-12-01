using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;

namespace LoanManagement.codeFirstEntities
{
    public partial class Consentdetail : FullAuditedEntity<long>
    {
        public Consentdetail()
        {
            Loanapplications = new HashSet<Loanapplication>();
        }

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
