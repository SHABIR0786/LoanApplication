using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.Features.MaritalStatus
{
    public class UpdateMaritalStatusRequest : AddMaritalStatusRequest
    {
        public int Id { get; set; }
    }
}
