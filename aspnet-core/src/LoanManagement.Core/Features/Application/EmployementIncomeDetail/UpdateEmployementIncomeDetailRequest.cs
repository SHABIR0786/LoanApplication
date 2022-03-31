using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.Features.Application.EmployementIncomeDetail
{
    public class UpdateEmployementIncomeDetailRequest: AddEmployementIncomeDetailRequest
    {
        public int Id { get; set; }
    }
}
