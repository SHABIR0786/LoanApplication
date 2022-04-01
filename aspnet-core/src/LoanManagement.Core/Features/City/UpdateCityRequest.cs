using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.Features.City
{
    public class UpdateCityRequest : AddCityRequest
    {
        public int Id { get; set; }
    }
}
