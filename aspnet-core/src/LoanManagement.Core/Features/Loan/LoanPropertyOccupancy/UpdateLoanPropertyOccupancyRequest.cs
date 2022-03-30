using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.Features.Loan.LoanPropertyOccupancy
{
    public class UpdateLoanPropertyOccupancyRequest : AddLoanPropertyOccupancyRequest
    {
        public int Id { get; set; }
    }
}
