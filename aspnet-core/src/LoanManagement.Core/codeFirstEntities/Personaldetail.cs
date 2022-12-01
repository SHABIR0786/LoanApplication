using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;

namespace LoanManagement.codeFirstEntities
{
    public partial class Personaldetail: FullAuditedEntity<long>
    {
        public Personaldetail()
        {
            Addresses = new HashSet<Address>();
        }

        public long Id { get; set; }
        public bool? IsApplyingWithCoBorrower { get; set; }
        public bool? UseIncomeOfPersonOtherThanBorrower { get; set; }
        public bool? AgreePrivacyPolicy { get; set; }
        public long? BorrowerId { get; set; }
        public long? CoBorrowerId { get; set; }
        public bool? IsMailingAddressSameAsResidential { get; set; }
        public bool? CoBorrowerIsMailingAddressSameAsResidential { get; set; }
        public bool? CoBorrowerResidentialAddressSameAsBorrowerResidential { get; set; }

        public virtual Borrower Borrower { get; set; }
        public virtual Borrower CoBorrower { get; set; }
        public virtual Loanapplication Loanapplication { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
    }
}
