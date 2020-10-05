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
        public Borrower Borrower { get; set; }
        public Borrower CoBorrower { get; set; }
        public List<Address> Addresses { get; set; }

        [ForeignKey("LoanApplicationId")]
        public LoanApplication LoanApplication { get; set; }
        public long LoanApplicationId { get; set; }

    }
}