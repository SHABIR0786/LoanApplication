using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using LoanManagement.Authorization.Roles;
using LoanManagement.Authorization.Users;
using LoanManagement.MultiTenancy;
using LoanManagement.Borrower_Information;

namespace LoanManagement.EntityFrameworkCore
{
    public class LoanManagementDbContext : AbpZeroDbContext<Tenant, Role, User, LoanManagementDbContext>
    {
        /* Define a DbSet for each entity of the application */

        public DbSet<BorrowerEmploymentInformation> BorrowerEmploymentInformations { get; set; }
        public DbSet<BorrowerInformation> BorrowerInformations { get; set; }
        public DbSet<CoBorrowerEmploymentInformation> CoBorrowerEmploymentInformations { get; set; }
        public DbSet<CoBorrowerInformation> CoBorrowerInformations { get; set; }

        public LoanManagementDbContext(DbContextOptions<LoanManagementDbContext> options)
            : base(options)
        {
        }
    }
}
