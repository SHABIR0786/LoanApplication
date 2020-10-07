using Abp.Zero.EntityFrameworkCore;
using LoanManagement.Authorization.Roles;
using LoanManagement.Authorization.Users;
using LoanManagement.Models;
using LoanManagement.MultiTenancy;
using Microsoft.EntityFrameworkCore;

namespace LoanManagement.EntityFrameworkCore
{
    public class LoanManagementDbContext : AbpZeroDbContext<Tenant, Role, User, LoanManagementDbContext>
    {
        /* Define a DbSet for each entity of the application */

        public DbSet<Address> Addresses { get; set; }
        public DbSet<BorrowerEmploymentInformation> BorrowerEmploymentInformations { get; set; }
        public DbSet<LoanApplication> LoanApplications { get; set; }
        public DbSet<AdditionalDetail> AdditionalDetails { get; set; }
        public DbSet<AdditionalIncome> AdditionalIncomes { get; set; }
        public DbSet<Borrower> Borrowers { get; set; }
        public DbSet<BorrowerMonthlyIncome> BorrowerMonthlyIncomes { get; set; }
        public DbSet<BorrowerType> BorrowerTypes { get; set; }
        public DbSet<ConsentDetail> ConsentDetails { get; set; }
        public DbSet<CreditAuthAgreement> CreditAuthAgreements { get; set; }
        public DbSet<Declaration> Declarations { get; set; }
        public DbSet<DeclarationBorrowereDemographicsInformation> DeclarationBorrowereDemographicsInformations { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<ManualAssetEntry> ManualAssetEntries { get; set; }
        public DbSet<StockAndBond> StockAndBonds { get; set; }
        public DbSet<LoanDetail> LoanDetails { get; set; }
        public DbSet<PersonalDetail> PersonalDetails { get; set; }

        public LoanManagementDbContext(DbContextOptions<LoanManagementDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AssetType>(assetType =>
            {
                assetType.HasData(new AssetType { Id = 1, Name = "Cash deposit on sales contract" },
                                  new AssetType { Id = 2, Name = "Certificate of Deposit" },
                                  new AssetType { Id = 3, Name = "Checking Account" },
                                  new AssetType { Id = 4, Name = "Gifts" },
                                  new AssetType { Id = 5, Name = "Gift of equity" },
                                  new AssetType { Id = 6, Name = "Money Market Fund" },
                                  new AssetType { Id = 7, Name = "Mutual Funds" },
                                  new AssetType { Id = 8, Name = "Net Proceeds from Real Estate Funds" },
                                  new AssetType { Id = 9, Name = "Retirement Funds" },
                                  new AssetType { Id = 10, Name = "Savings Account" },
                                  new AssetType { Id = 11, Name = "Stocks & Bonds" },
                                  new AssetType { Id = 12, Name = "Trust Account" });
            });

            modelBuilder.Entity<BorrowerType>(borrowerEmploymentInformation =>
            {
                borrowerEmploymentInformation.HasData(new BorrowerType { Id = 1, Name = "Borrower" },
                                                      new BorrowerType { Id = 2, Name = "Co-Borrower" });
            });

        }
    }
}