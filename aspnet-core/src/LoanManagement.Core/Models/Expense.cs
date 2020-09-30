using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System.Collections.Generic;

namespace LoanManagement.Models
{
    public class Expense : FullAuditedEntity<long>
    {
        public string IsLiveWithFamilySelectRent { get; set; }
        public int? Rent { get; set; }
        public int? OtherHousingExpenses { get; set; }
        public int? FirstMortgage { get; set; }
        public int? SecondMortgage { get; set; }
        public int? HazardInsurance { get; set; }
        public int? RealEstateTaxes { get; set; }
        public int? MortgageInsurance { get; set; }
        public int? HomeOwnersAssociation { get; set; }

    }
}