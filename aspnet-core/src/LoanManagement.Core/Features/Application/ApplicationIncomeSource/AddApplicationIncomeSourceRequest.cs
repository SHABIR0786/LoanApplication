using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.Features.Application.ApplicationIncomeSource
{
    public class AddApplicationIncomeSourceRequest
    {
        public int? ApplicationPersonalInformationId { get; set; }
        public int IncomeSourceId1e1 { get; set; }
        public float? Amount1e2 { get; set; }
    }
}
