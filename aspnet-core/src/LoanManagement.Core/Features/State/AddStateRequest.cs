using LoanManagement.codeFirstEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.Features.State
{
    public class AddStateRequest
    {
        public int CountryId { get; set; }

        //public virtual CountryState Country { get; set; }
        public string StateName { get; set; } = null!;
    }
}
