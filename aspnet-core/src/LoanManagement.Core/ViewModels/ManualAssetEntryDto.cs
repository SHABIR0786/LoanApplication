using Abp.Application.Services.Dto;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoanManagement.ViewModels
{
    public class ManualAssetEntryDto : EntityDto<long?>
    {
        public long AssetTypeId { get; set; }
        //public long AssetTypeId { get; set; }
        public string AccountNumber { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal? CashValue { get; set; }
        public string Address { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public int? StateId { get; set; }
        [StringLength(9)]
        public string ZipCode { get; set; }

        /// <summary>
        /// Valid for
        /// 1) Cash deposit on sales contract
        /// 2) Gifts
        /// 3) Gift of equity
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Valid for
        /// 1) Certificate of Deposit
        /// 2) Money Market Fund
        /// 3) Mutual Funds
        /// 4) Net Proceeds from Real Estate Funds
        /// 5) Retirement Funds
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Valid for
        /// 1) Checking Account
        /// </summary>
        public string BankName { get; set; }
        /// <summary>
        /// Valid for
        /// 1) Real Estate Owned
        /// 2) Savings Account
        /// </summary>
        public string PropertyStatus { get; set; }
        /// <summary>
        /// Valid for Real Estate Owned
        /// </summary>
        public string PropertyIsUsedAs { get; set; }
        /// <summary>
        /// Valid for Real Estate Owned
        /// </summary>
        public string PropertyType { get; set; }
        /// <summary>
        /// Valid for Real Estate Owned
        /// </summary>
        [Column(TypeName = "decimal(18,2)")]
        public decimal? PresentMarketValue { get; set; }
        /// <summary>
        /// Valid for Real Estate Owned
        /// </summary>
        [Column(TypeName = "decimal(18,2)")]
        public decimal? OutstandingMortgageBalance { get; set; }
        /// <summary>
        /// Valid for Real Estate Owned
        /// </summary>
        [Column(TypeName = "decimal(18,2)")]
        public decimal? MonthlyMortgagePayment { get; set; }
        /// <summary>
        /// Valid for Real Estate Owned
        /// </summary>
        [Column(TypeName = "decimal(18,2)")]
        public decimal? PurchasePrice { get; set; }
        /// <summary>
        /// Valid for Real Estate Owned
        /// </summary>
        [Column(TypeName = "decimal(18,2)")]
        public decimal? GrossRentalIncome { get; set; }
        /// <summary>
        /// Valid for Real Estate Owned
        /// </summary>
        [Column(TypeName = "decimal(18,2)")]
        public decimal? TaxesInsuranceAndOther { get; set; }
        public long LoanApplicationId { get; set; }
        public int BorrowerTypeId { get; set; }
        /// <summary>
        /// Valid for Stock And Bonds
        /// </summary>
        public List<StockAndBondViewModel> StockAndBonds { get; set; }
    }
}
