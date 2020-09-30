using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System.Collections.Generic;

namespace LoanManagement.Models
{
    public class PersonalInformation : FullAuditedEntity<long>
    {
        public bool IsApplyingWithCoBorrower { get; set; }
        public bool UseIncomeOfPersonOtherThanBorrower { get; set; }
        public bool AgreePrivacyPolicy { get; set; }
        public Borrower Borrower { get; set; }
        public Borrower CoBorrower { get; set; }


    }
}