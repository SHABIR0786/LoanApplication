using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.Features.Application.PreviousEmployementDetail
{
    public class UpdatePreviousEmployementDetailRequest : AddPreviousEmployementDetailRequest
    {
        public int Id { get; set; }
    }
}
