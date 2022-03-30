using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.Features.IncomeSource
{
    public class UpdateIncomeSourceRequest : AddIncomeSourceRequest
    {
        public int Id { get; set; }
    }
}
