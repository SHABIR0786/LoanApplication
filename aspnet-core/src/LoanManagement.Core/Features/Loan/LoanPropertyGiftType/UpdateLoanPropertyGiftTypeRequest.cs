using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.Features.Loan.LoanPropertyGiftType
{
    public class UpdateLoanPropertyGiftTypeRequest: AddLoanPropertyGiftTypeRequest
    {
        public int Id { get; set; }
    }
}
