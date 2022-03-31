using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.Features.Country
{
    public class UpdateCountryRequest: AddCountryRequest
    {
        public int Id { get; set; }
    }
}
