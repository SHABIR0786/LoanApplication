﻿using System;
using System.Collections.Generic;

namespace LoanManagement.Entities.Models
{
    public partial class AdminLoanapplicationdocument
    {
        public int Id { get; set; }
        public int LoanId { get; set; }
        public int DisclosureId { get; set; }
        public int UserId { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string DocumentPath { get; set; }

        public virtual AdminDisclosure Disclosure { get; set; }
        public virtual AdminLoandetail Loan { get; set; }
        public virtual AdminUser User { get; set; }
    }
}
