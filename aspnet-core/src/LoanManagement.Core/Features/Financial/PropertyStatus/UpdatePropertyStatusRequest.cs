using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.Features.Financial.PropertyStatus
{
    public class UpdatePropertyStatusRequest: AddPropertyStatusRequest
    {
        public int Id { get; set; }
    }
}
