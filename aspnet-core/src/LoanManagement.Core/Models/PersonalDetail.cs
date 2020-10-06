using Abp.Domain.Entities.Auditing;
using System.Collections.Generic;

namespace LoanManagement.Models
{
    public class PersonalDetail : FullAuditedEntity<long>
    {
        public PersonalDetail()
        {
            Addresses = new List<Address>();
        }

        public bool? IsApplyingWithCoBorrower { get; set; }
        public bool? UseIncomeOfPersonOtherThanBorrower { get; set; }
        public bool? AgreePrivacyPolicy { get; set; }
        public long? BorrowerId { get; set; }
        public long? CoBorrowerId { get; set; }
        public bool? IsMailingAddressSameAsResidential { get; set; }

        public Borrower Borrower { get; set; }
        public Borrower CoBorrower { get; set; }
        public List<Address> Addresses { get; set; }
    }
}