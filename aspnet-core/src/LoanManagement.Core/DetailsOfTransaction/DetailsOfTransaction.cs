using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;

namespace LoanManagement.DetailsOfTransactions
{
    public class DetailsOfTransaction : FullAuditedEntity<long>, IMayHaveTenant
    {
        public decimal? PurchasePrice { get; set; }
        public decimal? Alterations { get; set; }
        public decimal? Land { get; set; }
        public decimal? Refinance { get; set; }
        public decimal? EstimatedPreparedItem { get; set; }
        public decimal? EstimatedClosingCost { get; set; }
        public decimal? FundingFee { get; set; }
        public decimal? Discount { get; set; }
        public decimal? TotalCost { get; set; }
        public decimal? SubOrdinateFinancing { get; set; }
        public decimal? BorrowersClosingCost { get; set; }
        public decimal? OtherCredits { get; set; }
        public decimal? LoanAmount { get; set; }
        public decimal? CashFrom { get; set; }
        public int? TenantId { get; set; }
    }
}
