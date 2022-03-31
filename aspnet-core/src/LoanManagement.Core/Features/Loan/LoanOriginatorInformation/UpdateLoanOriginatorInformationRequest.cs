using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.Features.Loan.LoanOriginatorInformation
{
    public class UpdateLoanOriginatorInformationRequest: AddLoanOriginatorInformationRequest
    {
        public int Id { get; set; }
    }
}
