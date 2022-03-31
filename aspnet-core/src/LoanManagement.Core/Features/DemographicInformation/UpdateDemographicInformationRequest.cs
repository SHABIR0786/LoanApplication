using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.Features.DemographicInformation
{
    public class UpdateDemographicInformationRequest : AddDemographicInformationRequest
    {
        public int Id { get; set; }
    }
}
