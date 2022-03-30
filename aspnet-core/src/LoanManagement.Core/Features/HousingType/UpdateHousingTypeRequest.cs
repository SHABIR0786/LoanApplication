using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.Features.HousingType
{
    public class UpdateHousingTypeRequest : AddHousingTypeRequest
    {
        public int Id { get; set; }
    }
}
