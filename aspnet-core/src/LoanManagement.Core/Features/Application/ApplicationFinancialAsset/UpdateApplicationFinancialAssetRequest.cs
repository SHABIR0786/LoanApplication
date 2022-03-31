using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.Features.Application.ApplicationFinancialAsset
{
    public class UpdateApplicationFinancialAssetRequest: AddApplicationFinancialAssetRequest
    {
        public int Id { get; set; }
    }
}
