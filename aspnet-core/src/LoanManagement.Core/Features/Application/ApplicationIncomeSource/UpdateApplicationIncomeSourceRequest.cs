using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.Features.Application.ApplicationIncomeSource
{
    public class UpdateApplicationIncomeSourceRequest: AddApplicationIncomeSourceRequest
    {
        public int Id { get; set; }
    }
}
