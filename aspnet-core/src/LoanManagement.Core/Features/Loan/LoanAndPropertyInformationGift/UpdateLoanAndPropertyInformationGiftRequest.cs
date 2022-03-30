using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.Features.Loan.LoanAndPropertyInformationGift
{
    public class UpdateLoanAndPropertyInformationGiftRequest: AddLoanAndPropertyInformationGiftRequest
    {
        public int Id { get; set; }
    }
}
