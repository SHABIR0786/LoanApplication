using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;

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
        public string RefinanceYearAcquired { get; set; }
        public double RefinanceOriginalCost { get; set; }
        public double RefinanceAmountExistingLiens { get; set; }
        public string RefinancePurpose { get; set; }
        public string RefinanceImprovements { get; set; }
        public string RefinanceImprovementsExtras { get; set; }
        public string TitleHeldNames { get; set; }
        public string TitleHeldManner { get; set; }
        public string SourceOfPayment { get; set; }
        public string EstateWillHeldIn { get; set; }
        public virtual LoanApplication LoanApplication { get; set; }
    }
}