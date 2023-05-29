using System;
using System.Collections.Generic;

namespace  LoanManagement.Features.AdminLoanApplicationDocument
{
    public partial class AddAdminLoanApplicationDocument
    {
         public int LoanId { get; set; }
        public int DisclosureId { get; set; }
        public long? UserId { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string DocumentPath { get; set; }
    }
}
