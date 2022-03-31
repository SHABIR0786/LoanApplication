using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.Features.Loan.LoanAndPropertyInformation
{
    public class UpdateLoanAndPropertyInformationRequest: AddLoanAndPropertyInformationRequest
    {
        public int Id { get; set; }
    }
}
