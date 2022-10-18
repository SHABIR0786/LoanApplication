using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;

namespace LoanManagement.codeFirstEntities
{
    public partial class Manualassetentry : FullAuditedEntity<long>
    {
        public Manualassetentry()
        {
            Stockandbonds = new HashSet<Stockandbond>();
        }

        public long AssetTypeId { get; set; }
        public string AccountNumber { get; set; }
        public decimal? CashValue { get; set; }
        public string Address { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public int StateId { get; set; }
        public string ZipCode { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string BankName { get; set; }
        public string PropertyStatus { get; set; }
        public string PropertyIsUsedAs { get; set; }
        public string PropertyType { get; set; }
        public decimal? PresentMarketValue { get; set; }
        public decimal? OutstandingMortgageBalance { get; set; }
        public decimal? MonthlyMortgagePayment { get; set; }
        public decimal? PurchasePrice { get; set; }
        public decimal? GrossRentalIncome { get; set; }
        public decimal? TaxesInsuranceAndOther { get; set; }
        public long LoanApplicationId { get; set; }
        public int BorrowerTypeId { get; set; }

        public virtual Assettype AssetType { get; set; }
        public virtual Borrowertype BorrowerType { get; set; }
        public virtual Loanapplication LoanApplication { get; set; }
        public virtual State State { get; set; }
        public virtual ICollection<Stockandbond> Stockandbonds { get; set; }
    }
}
