using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.Features.Loan.LoanAndPropertyInformationGift
{
    public class AddLoanAndPropertyInformationGiftRequest
    {
        public int? ApplicationPersonalInformationId { get; set; }
        public int? LoanPropertyGiftTypeId4d1 { get; set; }
        public ulong? Deposited4d2 { get; set; }
        public string Source4d3 { get; set; }
        public float? Value4d4 { get; set; }
    }
}
