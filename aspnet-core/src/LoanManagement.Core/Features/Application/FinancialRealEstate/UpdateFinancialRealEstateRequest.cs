using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.Features.Application.FinancialRealEstate
{
    public class UpdateFinancialRealEstateRequest: AddFinancialRealEstateRequest
    {
        public int Id { get; set; }
    }
}
