using System;

namespace LoanManagement.Features.Application
{
    public class InsertApplicationRequest
    {
        public DateTime Date { get; set; }
        public string LoanNoIdentifierB1B3 { get; set; } = null!;
        public string AgencyCaseNoB2 { get; set; } = null!;
        public int CreditTypeId { get; set; }
        public int? TotalBorrowers1a6 { get; set; }
        public string Initials { get; set; }

    }
}
