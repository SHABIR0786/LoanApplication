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

        public DbSet<BorrowerEmploymentInformation> BorrowerEmploymentInformation { get; set; }
        public DbSet<BorrowerInformation> BorrowerInformation { get; set; }
        public DbSet<LoanApplication> LoanApplications { get; set; }
        public DbSet<MortgageType> MortgageTypes { get; set; }
        public DbSet<PropertyInformation> PropertyInformation { get; set; }
        public DbSet<AssetAndLiablity> AssetAndLiablities { get; set; }
        public DbSet<DetailsOfTransaction> DetailsOfTransactions { get; set; }

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
                    .HasOne(i => i.BorrowerEmploymentInfo1)
                    .WithMany(i => i.BorrowerLoanApplication1)
                    .HasForeignKey(i => i.BorrowerEmploymentInfoId1)
                    .OnDelete(DeleteBehavior.Restrict);

                loanApplication
                    .HasOne(i => i.BorrowerEmploymentInfo2)
                    .WithMany(i => i.BorrowerLoanApplication2)
                    .HasForeignKey(i => i.BorrowerEmploymentInfoId2)
                    .OnDelete(DeleteBehavior.Restrict);

                loanApplication
                    .HasOne(i => i.BorrowerEmploymentInfo3)
                    .WithMany(i => i.BorrowerLoanApplication3)
                    .HasForeignKey(i => i.BorrowerEmploymentInfoId3)
                    .OnDelete(DeleteBehavior.Restrict);

                loanApplication
                    .HasOne(i => i.CoBorrowerEmploymentInfo1)
                    .WithMany(i => i.CoBorrowerLoanApplication1)
                    .HasForeignKey(i => i.CoBorrowerEmploymentInfoId1)
                    .OnDelete(DeleteBehavior.Restrict);

                loanApplication
                    .HasOne(i => i.CoBorrowerEmploymentInfo2)
                    .WithMany(i => i.CoBorrowerLoanApplication2)
                    .HasForeignKey(i => i.CoBorrowerEmploymentInfoId2)
                    .OnDelete(DeleteBehavior.Restrict);

                loanApplication
                    .HasOne(i => i.CoBorrowerEmploymentInfo3)
                    .WithMany(i => i.CoBorrowerLoanApplication3)
                    .HasForeignKey(i => i.CoBorrowerEmploymentInfoId3)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}