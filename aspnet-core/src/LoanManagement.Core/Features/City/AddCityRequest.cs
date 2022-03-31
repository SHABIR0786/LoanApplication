using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.Features.City
{
    public class AddCityRequest
    {
        public int StateId { get; set; }
        public string CityName { get; set; } = null!;
    }
}
