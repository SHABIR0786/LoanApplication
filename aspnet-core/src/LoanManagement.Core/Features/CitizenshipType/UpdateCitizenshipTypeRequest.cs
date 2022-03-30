using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.Features.CitizenshipType
{
    public class UpdateCitizenshipTypeRequest: AddCitizenshipTypeRequest
    {
        public int Id { get; set; }
    }
}
