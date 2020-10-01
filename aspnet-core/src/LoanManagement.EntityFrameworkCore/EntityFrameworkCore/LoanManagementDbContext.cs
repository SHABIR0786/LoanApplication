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
        public DbSet<LoanDetail> LoanDetails { get; set; }
        public DbSet<PersonalDetail> PersonalDetails { get; set; }

        public LoanManagementDbContext(DbContextOptions<LoanManagementDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<LoanApplication>(loanApplication =>
            {
            });

            modelBuilder.Entity<BorrowerType>(borrowerEmploymentInformation =>
            {
                borrowerEmploymentInformation.HasData(new BorrowerType { Id = 1, Name = "Borrower" },
                                                      new BorrowerType { Id = 2, Name = "Co-Borrower" });
            });

        }
    }
}