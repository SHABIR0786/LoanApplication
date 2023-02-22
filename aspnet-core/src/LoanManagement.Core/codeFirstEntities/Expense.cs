using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;

namespace LoanManagement.codeFirstEntities
{
    public partial class Expense : FullAuditedEntity<long>
    {
        public Expense()
        {
            Loanapplications = new HashSet<Loanapplication>();
        }

        public bool? IsLiveWithFamilySelectRent { get; set; }
        public decimal? Rent { get; set; }
        public decimal? OtherHousingExpenses { get; set; }
        public decimal? FirstMortgage { get; set; }
        public decimal? SecondMortgage { get; set; }
        public decimal? HazardInsurance { get; set; }
        public decimal? RealEstateTaxes { get; set; }
        public decimal? MortgageInsurance { get; set; }
        public decimal? HomeOwnersAssociation { get; set; }

        public virtual ICollection<Loanapplication> Loanapplications { get; set; }
    }
}
