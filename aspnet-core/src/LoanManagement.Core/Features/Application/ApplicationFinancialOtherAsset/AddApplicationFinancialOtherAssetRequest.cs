using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.Features.Application.ApplicationFinancialOtherAsset
{
    public class AddApplicationFinancialOtherAssetRequest
    {
        public int? ApplicationPersonalInformationId { get; set; }
        public int FinancialAssetsTypesId2b1 { get; set; }
        public float? Value2b2 { get; set; }
    }
}
