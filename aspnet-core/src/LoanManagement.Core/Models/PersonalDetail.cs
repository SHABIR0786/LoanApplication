using Abp.Domain.Entities;
using System.Collections.Generic;

namespace LoanManagement.Models
{
    public class PersonalDetail : Entity<long>
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
        public bool? CoBorrowerIsMailingAddressSameAsResidential { get; set; }

        public Borrower Borrower { get; set; }
        public Borrower CoBorrower { get; set; }
        public List<Address> Addresses { get; set; }
        public LoanApplication LoanApplication { get; set; }
    }
}