using Abp.Domain.Entities.Auditing;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoanManagement.Models
{
    public class PersonalDetail : FullAuditedEntity<long>
    {
        public bool? IsApplyingWithCoBorrower { get; set; }
        public bool? UseIncomeOfPersonOtherThanBorrower { get; set; }
        public bool? AgreePrivacyPolicy { get; set; }
        public long? BorrowerId { get; set; }
        public long? CoBorrowerId { get; set; }

        public Borrower Borrower { get; set; }
        public Borrower CoBorrower { get; set; }

        public List<Address> Addresses { get; set; }
        public bool IsMailingAddressSameAsResidential { get; set; }
    public Address ResidentialAddress { get; set; }
     public List<Address> PreviousAddresses { get; set; }
      public Address MailingAddress { get; set; }
    }
}