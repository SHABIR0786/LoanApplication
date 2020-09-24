using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;

namespace LoanManagement.Models
{
    public class AssetAndLiablity : FullAuditedEntity<long>, IMayHaveTenant
    {
        public string AssetsCompletion { get; set; }
        public string Description { get; set; }
        public decimal? CashOrMarketValue { get; set; }
        public string CashDepositPurchaseHeldBy { get; set; }

        //first
        public string NameOfBank1 { get; set; }
        public string AddressOfBank1 { get; set; }
        public string BankAccountNo1 { get; set; }
        public decimal? Amount1 { get; set; }
        public string NameOfCompany1 { get; set; }
        public string AddressOfCompany1 { get; set; }
        public string CompanyAccountNo1 { get; set; }
        public decimal? MonthlyPayment1 { get; set; }
        public int? MonthsLeft1 { get; set; }
        public decimal? UnpaidBalance1 { get; set; }

        //second
        public string NameOfBank2 { get; set; }
        public string AddressOfBank2 { get; set; }
        public string BankAccountNo2 { get; set; }
        public decimal? BankAmount2 { get; set; }
        public string NameOfCompany2 { get; set; }
        public string AddressOfCompany2 { get; set; }
        public string CompanyAccountNo2 { get; set; }
        public decimal? MonthlyPayment2 { get; set; }
        public int? MonthsLeft2 { get; set; }
        public decimal? UnpaidBalance2 { get; set; }

        //third
        public string NameOfBank3 { get; set; }
        public string AddressOfBank3 { get; set; }
        public string BankAccountNo3 { get; set; }
        public decimal? BankAmount3 { get; set; }
        public string NameOfCompany3 { get; set; }
        public string AddressOfCompany3 { get; set; }
        public string CompanyAccountNo3 { get; set; }
        public decimal? MonthlyPayment3 { get; set; }
        public int? MonthsLeft3 { get; set; }
        public decimal? UnpaidBalance3 { get; set; }

        //fourth
        public string NameOfBank4 { get; set; }
        public string AddressOfBank4 { get; set; }
        public string BankAccountNo4 { get; set; }
        public decimal? BankAmount4 { get; set; }
        public string NameOfCompany4 { get; set; }
        public string AddressOfCompany4 { get; set; }
        public string CompanyAccountNo4 { get; set; }
        public decimal? MonthlyPayment4 { get; set; }
        public int? MonthsLeft4 { get; set; }
        public decimal? UnpaidBalance4 { get; set; }


        public string StockCompanyName { get; set; }
        public string StockCompanyNumber { get; set; }
        public string StockCompanyDescription { get; set; }
        public decimal? StockAmount { get; set; }
        public string NameOfCompany5 { get; set; }
        public string AddressOfCompany5 { get; set; }
        public string CompanyAccountNo5 { get; set; }
        public decimal? MonthlyPayment5 { get; set; }
        public int? MonthsLeft5 { get; set; }
        public decimal? UnpaidBalance5 { get; set; }


        public decimal? LifeInsuranceNetCashValue { get; set; }
        public decimal? SubtotalLiquidAssets { get; set; }
        public decimal? RealEstateOwned { get; set; }
        public decimal? RetirementFund { get; set; }
        public decimal? NetworthOfBussiness { get; set; }
        public string NameOfCompany6 { get; set; }
        public string AddressOfCompany6 { get; set; }
        public string CompanyAccountNo6 { get; set; }
        public decimal? MonthlyPayment6 { get; set; }
        public int? MonthsLeft6 { get; set; }
        public decimal? UnpaidBalance6 { get; set; }


        public string AutomobileMake { get; set; }
        public string AutomobileYear { get; set; }
        public decimal? AutomobileAmount { get; set; }
        public string MaintenancePaymentOwedTo { get; set; }
        public decimal? MaintenancePayment { get; set; }


        public string OtherAssets { get; set; }
        public decimal? OtherAssetsAmount { get; set; }
        public string JobRelatedExpenses { get; set; }
        public decimal? JobRelatedExpensesPayment { get; set; }


        public string AlternateName { get; set; }
        public string CreditorName { get; set; }
        public string AccountName { get; set; }
        public int? TenantId { get; set; }
    }
}
