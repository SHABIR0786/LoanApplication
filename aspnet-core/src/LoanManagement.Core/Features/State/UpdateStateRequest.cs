using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.Features.State
{
    public class UpdateStateRequest: AddStateRequest
    {
        public long Id { get; set; }
    }
}
