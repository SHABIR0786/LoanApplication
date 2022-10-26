using System;
using System.Collections.Generic;

namespace  LoanManagement.Features.AdminLoanDetail
{
    public partial class AddAdminLoanDetail
    {
       //  public int UserId { get; set; }
        public int LoanApplicationId { get; set; }
        public string LoanNo { get; set; }
        public string MortageConsultant { get; set; }
        public string NmlsId { get; set; }
        public string BorrowerName { get; set; }
        public string PropertyAddress { get; set; }
        public int LoanProgramId { get; set; }
        public float? LoanAmount { get; set; }
        public string LoanPurpose { get; set; }
        public float? InterestRate { get; set; }
        public DateTime? ApplicationDate { get; set; }
        public DateTime? RateLockDate { get; set; }
        public DateTime? RateLockExpirationDate { get; set; }

    }
}
