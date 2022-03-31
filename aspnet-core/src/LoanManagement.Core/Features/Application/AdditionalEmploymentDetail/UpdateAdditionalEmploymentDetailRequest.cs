using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.Features.Application.AdditionalEmploymentDetail
{
    public class UpdateAdditionalEmploymentDetailRequest : AddAdditionalEmploymentDetailRequest
    {
        public int Id { get; set; }
    }
}
