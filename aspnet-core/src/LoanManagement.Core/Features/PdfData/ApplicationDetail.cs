using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.Features.PdfData
{
    public class ApplicationDetail
    {
        public DateTime Date { get; set; }
        public string LoanNoIdentifierB1B3 { get; set; } = null!;
        public string AgencyCaseNoB2 { get; set; } = null!;
        public string CreditType { get; set; }
        public int? TotalBorrowers1a6 { get; set; }
        public string Initials { get; set; }
    }
}
