using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.Features.Application.ApplicationFinancialOtherAsset
{
    public class UpdateApplicationFinancialOtherAssetRequest: AddApplicationFinancialOtherAssetRequest
    {
        public int Id { get; set; }
    }
}
