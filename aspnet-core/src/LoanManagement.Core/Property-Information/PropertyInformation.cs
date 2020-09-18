using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations;

namespace LoanManagement.Property_Information
{
    public class PropertyInformation : FullAuditedEntity<long>
    {
        [Required] [StringLength(100)] public string Address { get; set; }
        public string NumberOfUnits { get; set; }
        public string LegalDescription { get; set; }
        public string YearBuilt { get; set; }
        public string PurposeOfLoan { get; set; }
        public string PurposeOfLoanExplain { get; set; }
        public string PropertyWillBe { get; set; }
        public string YearLotAcquired { get; set; }
        public double OriginalCost { get; set; }
        public double AmountExistingLiens { get; set; }
        public double PresentValueOfLot { get; set; }
        public double CostOfImprovements { get; set; }
        public string YearAcquiredRefinance { get; set; }
        public double OriginalCostRefinance { get; set; }
        public double AmountExistingLiensRefinance { get; set; }
        public string PurposeOfRefinance { get; set; }
        public string ImprovementsRefinance { get; set; }
        public string ImprovementCostRefinance { get; set; }
        public string TitleHeldNames { get; set; }
        public string TitleHeldManner { get; set; }
        public string SourceOfPayment { get; set; }
        public string EstateHeldIn { get; set; }
        public virtual LoanApplication LoanApplication { get; set; }
    }
}