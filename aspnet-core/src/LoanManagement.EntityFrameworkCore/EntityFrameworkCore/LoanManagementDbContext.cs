using Abp.Zero.EntityFrameworkCore;
using LoanManagement.Authorization.Roles;
using LoanManagement.Authorization.Users;
using LoanManagement.Models;
using LoanManagement.MultiTenancy;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

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
        public DbSet<SiteSetting> SiteSettings { get; set; }
        public DbSet<State> States { get; set; }

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
                                  new AssetType { Id = 9, Name = "Real Estate Owned" },
                                  new AssetType { Id = 10, Name = "Retirement Funds" },
                                  new AssetType { Id = 11, Name = "Savings Account" },
                                  new AssetType { Id = 12, Name = "Stocks & Bonds" },
                                  new AssetType { Id = 13, Name = "Trust Account" });
            });

            modelBuilder.Entity<BorrowerType>(borrowerType =>
            {
                borrowerType.HasData(new BorrowerType { Id = 1, Name = "Borrower" },
                                     new BorrowerType { Id = 2, Name = "Co-Borrower" },
                                     new BorrowerType { Id = 3, Name = "Both" });
            });

            modelBuilder.Entity<IncomeSource>(incomeSources =>
            {
                incomeSources.HasData(new IncomeSource { Id = 1, Name = "Accessory Unit Income" },
                                      new IncomeSource { Id = 2, Name = "Alimony/Child Support" },
                                      new IncomeSource { Id = 3, Name = "Automobile/Expense Account" },
                                      new IncomeSource { Id = 4, Name = "Boarder Income" });
            });

            modelBuilder.Entity<State>(State =>
            {
                State.HasData(
                            new State { Id = 1, Name = "AL" },
                            new State { Id = 2, Name = "AK" },
                            new State { Id = 3, Name = "AS" },
                            new State { Id = 4, Name = "AZ" },
                            new State { Id = 5, Name = "AR" },
                            new State { Id = 6, Name = "CA" },
                            new State { Id = 7, Name = "CO" },
                            new State { Id = 8, Name = "CT" },
                            new State { Id = 9, Name = "DE" },
                            new State { Id = 10, Name = "DC" },
                            new State { Id = 11, Name = "FM" },
                            new State { Id = 12, Name = "FL" },
                            new State { Id = 13, Name = "GA" },
                            new State { Id = 14, Name = "GU" },
                            new State { Id = 15, Name = "HI" },
                            new State { Id = 16, Name = "ID" },
                            new State { Id = 17, Name = "IL" },
                            new State { Id = 18, Name = "IN" },
                            new State { Id = 19, Name = "IA" },
                            new State { Id = 20, Name = "KS" },
                            new State { Id = 21, Name = "KY" },
                            new State { Id = 22, Name = "LA" },
                            new State { Id = 23, Name = "ME" },
                            new State { Id = 24, Name = "MH" },
                            new State { Id = 25, Name = "MD" },
                            new State { Id = 26, Name = "MA" },
                            new State { Id = 27, Name = "MI" },
                            new State { Id = 28, Name = "MN" },
                            new State { Id = 29, Name = "MS" },
                            new State { Id = 30, Name = "MO" },
                            new State { Id = 31, Name = "MT" },
                            new State { Id = 32, Name = "NE" },
                            new State { Id = 33, Name = "NV" },
                            new State { Id = 34, Name = "NH" },
                            new State { Id = 35, Name = "NJ" },
                            new State { Id = 36, Name = "NM" },
                            new State { Id = 37, Name = "NY" },
                            new State { Id = 38, Name = "NC" },
                            new State { Id = 39, Name = "ND" },
                            new State { Id = 40, Name = "MP" },
                            new State { Id = 41, Name = "OH" },
                            new State { Id = 42, Name = "OK" },
                            new State { Id = 43, Name = "OR" },
                            new State { Id = 44, Name = "PW" },
                            new State { Id = 45, Name = "PA" },
                            new State { Id = 46, Name = "PR" },
                            new State { Id = 47, Name = "RI" },
                            new State { Id = 48, Name = "SC" },
                            new State { Id = 49, Name = "SD" },
                            new State { Id = 50, Name = "TN" },
                            new State { Id = 51, Name = "TX" },
                            new State { Id = 52, Name = "UT" },
                            new State { Id = 53, Name = "VT" },
                            new State { Id = 54, Name = "VI" },
                            new State { Id = 55, Name = "VA" },
                            new State { Id = 56, Name = "WA" },
                            new State { Id = 57, Name = "WV" },
                            new State { Id = 58, Name = "WI" },
                            new State { Id = 59, Name = "WY" });
            });

            modelBuilder.Entity<SiteSetting>(siteSetting =>
            {
                siteSetting.HasData(new SiteSetting
                {
                    Id = 1,
                    PageIdentifier = "app/home",
                    PageName = "Home page",
                    PageSetting = JsonConvert.SerializeObject(
                    new
                    {
                        MainCarousels = new[]
                        {
                            new
                            {
                                FilePath = "assets/img/house.png",
                                Header = "Best California Home Loans",
                                SubHeader = "Better Rate then banks, Better customer services"
                            }
                        },
                        FirstBlog = new
                        {
                            FilePath = "assets/img/house.png",
                            Header = "GET A NO-HASSLE LOAN FOR UP TO $697,650",
                            SubHeader = "Fast Closing FHA Loans",
                            Description = "Take Advantage of our FHA Elite Rates starting at",
                        },
                        SecondBlog = new
                        {
                            FilePath = "assets/img/living-room.png",
                            Header = "Conventional Jombo Rate",
                            SubHeader = "GET A NO-HASSLE LOAN FOR UP TO $697,650",
                            Description = "Save cash with a low-rate conventional loan up to"
                        },
                        ThirdBlog = new
                        {
                            FilePath = "assets/img/money.png",
                            Header = "Tap Into Your Equity",
                            SubHeader = "",
                            Description = "We offer unique programs that let you refinance up"
                        },
                        ForthBlog = new
                        {
                            FilePath = "assets/img/new-home.png",
                            Header = "Purchase Your Dream Home",
                            SubHeader = "",
                            Description = "Your dream home may no longer be a dream"
                        },
                        VideoSection = new
                        {
                            FilePath = "assets/img/Image 16.png",
                            Header = "Know about",
                            SubHeader = "YOUR INDEPENDENT MORTGAGE BROKER IN CALIFORNIA",
                            Description = "To make sure all borrowers get the best mortgage rate and loan program with excellent customer service and satisfaction."
                        },
                        KnowAboutHeader = "Tips For Getting A Home Mortgage In California",
                        ChecklistMainHeader = "How To Apply For Your Loan",
                        Checklist = new
                        {
                            Checklist1 = "Calculate Loan Rate",
                            Checklist2 = "Speak With An Expert",
                            Checklist3 = "Benefit Of Preapproval",
                            Checklist4 = "Get A Free Quote",
                        },
                        SloganImage = "assets/img/finance.png",
                        Slogan = "Work With A High-Tech Mortgage Loan Broker",
                        SloganChecklist = "Our easy-to-use online tools streamline the mortgage process.\n" +
                                           "Get mortgage estimates, instant rate quotes, and access to our online calculators.\n" +
                                           "Loan applications can be done entirely online(or via fax) on our secure portal.\n" +
                                           "Receive updates about your application – as well as helpful mortgage news – on your phone, tablet or laptop",
                        Testimonials = new[]
                        {
                            new
                            {
                                Comment = "Thank you for all your help in making the mortgage process go smoothly! my husband and i could n't have done it without you.",
                                Author = "Anne Davidson (San Francisco, CA)"
                            }
                        }
                    })
                });
            });
        }
    }
}