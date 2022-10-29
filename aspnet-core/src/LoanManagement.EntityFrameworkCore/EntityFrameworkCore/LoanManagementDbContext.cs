using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using Abp.Zero.EntityFrameworkCore;
using LoanManagement.Authorization.Roles;
using LoanManagement.Authorization.Users;
using LoanManagement.codeFirstEntities;
using LoanManagement.Models;
using LoanManagement.MultiTenancy;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Declaration = LoanManagement.codeFirstEntities.Declaration;

namespace LoanManagement.EntityFrameworkCore
{
    public class LoanManagementDbContext : AbpZeroDbContext<Tenant, Role, User, LoanManagementDbContext>
    {
        /* Define a DbSet for each entity of the application */

        public virtual DbSet<Additionaldetail> Additionaldetails { get; set; }
        public virtual DbSet<Additionalincome> Additionalincomes { get; set; }
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<AdminDisclosure> Admindisclosures { get; set; }
        public virtual DbSet<AdminLoanapplicationdocument> AdminLoanapplicationdocuments { get; set; }
        public virtual DbSet<AdminLoandetail> AdminLoandetails { get; set; }
        public virtual DbSet<AdminLoanprogram> AdminLoanprograms { get; set; }
        public virtual DbSet<AdminLoanstatus> admin_loanstatus { get; set; }
        public virtual DbSet<AdminLoansummarystatus> AdminLoansummarystatuses { get; set; }
        //public virtual DbSet<AdminNotificationtype> AdminNotificationtypes { get; set; }
        //public virtual DbSet<AdminUser> AdminUsers { get; set; }
        public virtual DbSet<AdminUserenableddevice> AdminUserenableddevices { get; set; }
       // public virtual DbSet<AdminUsernotification> AdminUsernotifications { get; set; }
        public virtual DbSet<Application> Applications { get; set; }
        public virtual DbSet<ApplicationAdditionalEmployementDetail> ApplicationAdditionalEmployementDetails { get; set; }
        public virtual DbSet<ApplicationAdditionalEmployementIncomeDetail> ApplicationAdditionalEmployementIncomeDetails { get; set; }
        public virtual DbSet<ApplicationDeclarationQuestion> ApplicationDeclarationQuestions { get; set; }
        public virtual DbSet<ApplicationEmployementDetail> ApplicationEmployementDetails { get; set; }
        public virtual DbSet<ApplicationEmployementIncomeDetail> ApplicationEmployementIncomeDetails { get; set; }
        public virtual DbSet<ApplicationFinancialAsset> ApplicationFinancialAssets { get; set; }
        public virtual DbSet<ApplicationFinancialLaibility> ApplicationFinancialLaibilities { get; set; }
        public virtual DbSet<ApplicationFinancialOtherAsset> ApplicationFinancialOtherAssets { get; set; }
        public virtual DbSet<ApplicationFinancialOtherLaibility> ApplicationFinancialOtherLaibilities { get; set; }
        public virtual DbSet<ApplicationFinancialRealEstate> ApplicationFinancialRealEstates { get; set; }
        public virtual DbSet<ApplicationIncomeSource> ApplicationIncomeSources { get; set; }
        public virtual DbSet<ApplicationPersonalInformation> ApplicationPersonalInformations { get; set; }
        public virtual DbSet<ApplicationPreviousEmployementDetail> ApplicationPreviousEmployementDetails { get; set; }
        public virtual DbSet<Assettype> Assettypes { get; set; }
        public virtual DbSet<Borrower> Borrowers { get; set; }
        public virtual DbSet<Borroweremploymentinformation> Borroweremploymentinformations { get; set; }
        public virtual DbSet<Borrowermonthlyincome> Borrowermonthlyincomes { get; set; }
        public virtual DbSet<Borrowertype> Borrowertypes { get; set; }
        public virtual DbSet<CitizenshipType> CitizenshipTypes { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Consentdetail> Consentdetails { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<CountryState> CountryStates { get; set; }
        public virtual DbSet<CreditType> CreditTypes { get; set; }
        public virtual DbSet<Creditauthagreement> Creditauthagreements { get; set; }
        public virtual DbSet<Declaration> Declarations { get; set; }
        public virtual DbSet<DeclarationCategory> DeclarationCategories { get; set; }
        public virtual DbSet<DeclarationQuestion> DeclarationQuestions { get; set; }
        public virtual DbSet<Declarationborroweredemographicsinformation> Declarationborroweredemographicsinformations { get; set; }
        public virtual DbSet<DemographicInfoSource> DemographicInfoSources { get; set; }
        public virtual DbSet<DemographicInformation> DemographicInformations { get; set; }
        public virtual DbSet<Expense> Expenses { get; set; }
        public virtual DbSet<FinancialAccountType> FinancialAccountTypes { get; set; }
        public virtual DbSet<FinancialAssetsType> FinancialAssetsTypes { get; set; }
        public virtual DbSet<FinancialLaibilitiesType> FinancialLaibilitiesTypes { get; set; }
        public virtual DbSet<FinancialOtherLaibilitiesType> FinancialOtherLaibilitiesTypes { get; set; }
        public virtual DbSet<FinancialPropertyIntendedOccupancy> FinancialPropertyIntendedOccupancies { get; set; }
        public virtual DbSet<FinancialPropertyStatus> FinancialPropertyStatuses { get; set; }
        public virtual DbSet<Homebuying> Homebuyings { get; set; }
        public virtual DbSet<HousingType> HousingTypes { get; set; }
        public virtual DbSet<IncomeSource> IncomeSources { get; set; }
        public virtual DbSet<IncomeType> IncomeTypes { get; set; }
        public virtual DbSet<Incomesource1> Incomesources1 { get; set; }
        public virtual DbSet<LeadApplicationDetailPurchasing> LeadApplicationDetailPurchasings { get; set; }
        public virtual DbSet<LeadApplicationDetailRefinancing> LeadApplicationDetailRefinancings { get; set; }
        public virtual DbSet<LeadApplicationQuestion> LeadApplicationQuestions { get; set; }
        public virtual DbSet<LeadApplicationType> LeadApplicationTypes { get; set; }
        public virtual DbSet<LeadAssetsDetail> LeadAssetsDetails { get; set; }
        public virtual DbSet<LeadAssetsType> LeadAssetsTypes { get; set; }
        public virtual DbSet<LeadEmployementDetail> LeadEmployementDetails { get; set; }
        public virtual DbSet<LeadEmployementType> LeadEmployementTypes { get; set; }
        public virtual DbSet<LeadIncomeType> LeadIncomeTypes { get; set; }
        public virtual DbSet<LeadOwnerType> LeadOwnerTypes { get; set; }
        public virtual DbSet<LeadQuestionAnswer> LeadQuestionAnswers { get; set; }
        public virtual DbSet<LeadRefinancingIncomeDetail> LeadRefinancingIncomeDetails { get; set; }
        public virtual DbSet<LeadTaxesType> LeadTaxesTypes { get; set; }
        public virtual DbSet<LoanAndPropertyInformation> LoanAndPropertyInformations { get; set; }
        public virtual DbSet<LoanAndPropertyInformationGift> LoanAndPropertyInformationGifts { get; set; }
        public virtual DbSet<LoanAndPropertyInformationOtherMortageLoan> LoanAndPropertyInformationOtherMortageLoans { get; set; }
        public virtual DbSet<LoanAndPropertyInformationRentalIncome> LoanAndPropertyInformationRentalIncomes { get; set; }
        public virtual DbSet<LoanOriginatorInformation> LoanOriginatorInformations { get; set; }
        public virtual DbSet<LoanPropertyGiftType> LoanPropertyGiftTypes { get; set; }
        public virtual DbSet<LoanPropertyOccupancy> LoanPropertyOccupancies { get; set; }
        public virtual DbSet<Loanapplication> Loanapplications { get; set; }
        public virtual DbSet<Loandetail> Loandetails { get; set; }
        public virtual DbSet<Manualassetentry> Manualassetentries { get; set; }
        public virtual DbSet<MaritialStatus> MaritialStatuses { get; set; }
        public virtual DbSet<MilitaryService> MilitaryServices { get; set; }
        public virtual DbSet<MortageLoanOnProperty> MortageLoanOnProperties { get; set; }
        public virtual DbSet<MortageLoanType> MortageLoanTypes { get; set; }
        public virtual DbSet<Personaldetail> Personaldetails { get; set; }
        public virtual DbSet<Refinancehomebuying> Refinancehomebuyings { get; set; }
        public virtual DbSet<Sitesetting> Sitesettings { get; set; }
        public virtual DbSet<State> States { get; set; }
        public virtual DbSet<Stockandbond> Stockandbonds { get; set; }

        public LoanManagementDbContext(DbContextOptions<LoanManagementDbContext> options)
            : base(options)
        {
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Assettype>(assetType =>
            {
                assetType.HasData(new Assettype { Id = 1, Name = "Cash deposit on sales contract" },
                                  new Assettype { Id = 2, Name = "Certificate of Deposit" },
                                  new Assettype { Id = 3, Name = "Checking Account" },
                                  new Assettype { Id = 4, Name = "Gifts" },
                                  new Assettype { Id = 5, Name = "Gift of equity" },
                                  new Assettype { Id = 6, Name = "Money Market Fund" },
                                  new Assettype { Id = 7, Name = "Mutual Funds" },
                                  new Assettype { Id = 8, Name = "Net Proceeds from Real Estate Funds" },
                                  new Assettype { Id = 9, Name = "Real Estate Owned" },
                                  new Assettype { Id = 10, Name = "Retirement Funds" },
                                  new Assettype { Id = 11, Name = "Savings Account" },
                                  new Assettype { Id = 12, Name = "Stocks & Bonds" },
                                  new Assettype { Id = 13, Name = "Trust Account" });
            });

            modelBuilder.Entity<Borrowertype>(borrowerType =>
            {
                borrowerType.HasData(new Borrowertype { Id = 1, Name = "Borrower" },
                                     new Borrowertype { Id = 2, Name = "Co-Borrower" },
                                     new Borrowertype { Id = 3, Name = "Both" });
            });

            modelBuilder.Entity<IncomeSource>(incomeSources =>
            {
                incomeSources.HasData(new IncomeSource { Id = 1, IncomeSource1 = "Accessory Unit Income" },
                                      new IncomeSource { Id = 2, IncomeSource1 = "Alimony/Child Support" },
                                      new IncomeSource { Id = 3, IncomeSource1 = "Automobile/Expense Account" },
                                      new IncomeSource { Id = 4, IncomeSource1 = "Boarder Income" });
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

            modelBuilder.Entity<Sitesetting>(siteSetting =>
            {
                siteSetting.HasData(new Sitesetting
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