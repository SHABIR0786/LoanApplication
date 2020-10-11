using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoanManagement.Models
{
    public class Expense : FullAuditedEntity<long>
    {
        public bool? IsLiveWithFamilySelectRent { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal? Rent { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal? OtherHousingExpenses { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal? FirstMortgage { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal? SecondMortgage { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal? HazardInsurance { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal? RealEstateTaxes { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal? MortgageInsurance { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal? HomeOwnersAssociation { get; set; }
    }
}