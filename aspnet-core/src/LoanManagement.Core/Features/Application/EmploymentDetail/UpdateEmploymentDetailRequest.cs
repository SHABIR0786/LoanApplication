using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.Features.Application.EmploymentDetail
{
    public class UpdateEmploymentDetailRequest : AddEmploymentDetailRequest
    {
        public int Id { get; set; }
    }
}
