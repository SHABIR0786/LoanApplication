using Abp.Domain.Entities;
using System;
using System.Collections.Generic;

namespace LoanManagement.codeFirstEntities
{
    public partial class Expense : Entity<long>
    {
        public Expense()
        {
            Loanapplications = new HashSet<Loanapplication>();
        }

        public long Id { get; set; }
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
