using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanManagement.AssetAndLiablity.Dto
{
    public class CreateOrUpdateAssetAndLiablityDto : EntityDto<long>
    {
        public string AssetsCompletion { get; set; }
        public string Description { get; set; }
        public Decimal? CashOrMarketValue { get; set; }
        public string CashDepositPurchaseHeldBy { get; set; }
        public string NameOfBank1 { get; set; }
        public string AddressOfBank1 { get; set; }
        public string BankAccountNo1 { get; set; }
        public Decimal? Amount1 { get; set; }
        public string NameOfCompany1 { get; set; }
        public string AddressOfCompany1 { get; set; }
        public string CompanyAccountNo1 { get; set; }
        public string PaymentMethod1 { get; set; }
        public Decimal? UnpaidBalance1 { get; set; }

        //second
        public string NameOfBank2 { get; set; }
        public string AddressOfBank2 { get; set; }
        public string BankAccountNo2 { get; set; }
        public Decimal? BankAmount2 { get; set; }
        public string NameOfCompany2 { get; set; }
        public string AddressOfCompany2 { get; set; }
        public string CompanyAccountNo2 { get; set; }
        public string PaymentMethod2 { get; set; }
        public Decimal UnpaidBalance2 { get; set; }

        //third

        public string NameOfBank3 { get; set; }
        public string AddressOfBank3 { get; set; }
        public string BankAccountNo3 { get; set; }
        public Decimal? BankAmount3 { get; set; }
        public string NameOfCompany3 { get; set; }
        public string AddressOfCompany3 { get; set; }
        public string CompanyAccountNo3 { get; set; }
        public string PaymentMethod3 { get; set; }
        public Decimal? UnpaidBalance3 { get; set; }


        public string NameOfBank4 { get; set; }
        public string AddressOfBank4 { get; set; }
        public string BankAccountNo4 { get; set; }
        public Decimal? BankAmount4 { get; set; }
        public string NameOfCompany4 { get; set; }
        public string AddressOfCompany4 { get; set; }
        public string CompanyAccountNo4 { get; set; }
        public string PaymentMethod4 { get; set; }
        public Decimal? UnpaidBalance4 { get; set; }

        public string NameOfCompany5 { get; set; }
        public string AddressOfCompany5 { get; set; }
        public string CompanyAccountNo5 { get; set; }
        public string PaymentMethod5 { get; set; }
        public Decimal UnpaidBalance5 { get; set; }

        public string NameOfCompany6 { get; set; }
        public string AddressOfCompany6 { get; set; }
        public string CompanyAccountNo6 { get; set; }
        public string PaymentMethod6 { get; set; }
        public Decimal? UnpaidBalance6 { get; set; }


        public string StockBondCompanyDescription { get; set; }
        public decimal? LifeInsuranceNetCashValue { get; set; }
        public decimal? SubtotalLiquidAssets { get; set; }
        public decimal? RealEstateOwned { get; set; }
        public decimal? RetirementFund { get; set; }
        public decimal? NetworthOfBussiness { get; set; }
        public decimal? AutomobileOwned { get; set; }
        public decimal? OtherAssests { get; set; }
        public decimal? TotalAssests { get; set; }
        public decimal? SeparateMaintenancePaymentsOwedTo { get; set; }
        public decimal? JobRelatedExpense { get; set; }
        public decimal? TotalMoneyPayment { get; set; }
        public decimal? NetWorth { get; set; }
        public decimal? TotalLiablities { get; set; }

        public string AlternateName { get; set; }
        public string CreditorName { get; set; }
        public string AccountName { get; set; }
        public int? TenantId { get; set; }
    }
}
