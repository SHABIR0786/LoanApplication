using Abp.Domain.Entities.Auditing;
using LoanManagement.codeFirstEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.MortgageTables
{
    public class MortgageApplicationLoanPropertyGiftsOrGrants:FullAuditedEntity<int>
    {
        public int? PersonalInformationId { get; set; }
        public virtual MortgageApplicationPersonalInformation PersonalInformation { get; set; }
        public int? AssetTypeId { get; set; }
        public virtual Assettype AssetType { get; set; }
        public bool IsDeposited { get; set; }
        public string Source { get; set; }
        public decimal MarketValue { get; set; }
    }
}
