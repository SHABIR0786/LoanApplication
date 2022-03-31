using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.Features.Application.ApplicationFinancialAsset
{
    public class AddApplicationFinancialAssetRequest
    {
        public int? ApplicationPersonalInformationId { get; set; }
        public int FinancialAccountTypeId2a1 { get; set; }
        public string FinancialInstitution2a2 { get; set; }
        public string AccountNumber2a3 { get; set; }
        public float? Value2a4 { get; set; }
    }
}
