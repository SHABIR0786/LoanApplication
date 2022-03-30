using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.Features.IncomeType
{
    public class UpdateIncomeTypeRequest: AddIncomeTypeRequest
    {
        public int Id { get; set; }
    }
}
