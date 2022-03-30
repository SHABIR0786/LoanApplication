using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.Features.Financial.PropertyIntendedOccupancy
{
    public class UpdatePropertyIntendedOccupancyRequest: AddPropertyIntendedOccupancyRequest
    {
        public int Id { get; set; }
    }
}
