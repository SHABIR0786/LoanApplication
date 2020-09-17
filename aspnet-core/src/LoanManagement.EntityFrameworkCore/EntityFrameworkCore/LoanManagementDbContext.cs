using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using LoanManagement.Authorization.Roles;
using LoanManagement.Authorization.Users;
using LoanManagement.MultiTenancy;
using LoanManagement.Borrower_Information;
using LoanManagement.Property_Information;
using LoanManagement.AssetAndLiablities;

namespace LoanManagement.EntityFrameworkCore
{
    public class LoanManagementDbContext : AbpZeroDbContext<Tenant, Role, User, LoanManagementDbContext>
    {
        /* Define a DbSet for each entity of the application */

        public DbSet<BorrowerEmploymentInformation> BorrowerEmploymentInformation { get; set; }
        public DbSet<BorrowerInformation> BorrowerInformation { get; set; }
        public DbSet<LoanApplication> LoanApplications { get; set; }
        public DbSet<MortgageType> MortgageTypes { get; set; }
        public DbSet<PropertyInformation> PropertyInformation { get; set; }
        public DbSet<AssetAndLiablity> AssetAndLiablities { get; set; }

        public LoanManagementDbContext(DbContextOptions<LoanManagementDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<LoanApplication>(loanApplication =>
            {
                loanApplication
                    .HasOne(i => i.MortgageType)
                    .WithOne(i => i.LoanApplication)
                    .HasForeignKey<LoanApplication>(i => i.MortgageTypeId);

                loanApplication
                    .HasOne(i => i.PropertyInfo)
                    .WithOne(i => i.LoanApplication)
                    .HasForeignKey<LoanApplication>(i => i.PropertyInfoId);

                loanApplication
                    .HasOne(i => i.BorrowerInfo)
                    .WithMany(i => i.BorrowerLoanApplication)
                    .HasForeignKey(i => i.BorrowerInfoId)
                    .OnDelete(DeleteBehavior.Restrict);

                loanApplication
                    .HasOne(i => i.CoBorrowerInfo)
                    .WithMany(i => i.CoBorrowerLoanApplication)
                    .HasForeignKey(i => i.CoBorrowerInfoId)
                    .OnDelete(DeleteBehavior.Restrict);

                loanApplication
                    .HasOne(i => i.BorrowerEmploymentInfo)
                    .WithMany(i => i.BorrowerLoanApplication)
                    .HasForeignKey(i => i.BorrowerEmploymentInfoId)
                    .OnDelete(DeleteBehavior.Restrict);

                loanApplication
                    .HasOne(i => i.CoBorrowerEmploymentInfo)
                    .WithMany(i => i.CoBorrowerLoanApplication)
                    .HasForeignKey(i => i.CoBorrowerEmploymentInfoId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}