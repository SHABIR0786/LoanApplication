using LoanManagement.Configuration;
using LoanManagement.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace LoanManagement.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class LoanManagementDbContextFactory : IDesignTimeDbContextFactory<LoanManagementDbContext>
    {
        public LoanManagementDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<LoanManagementDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            LoanManagementDbContextConfigurer.Configure(builder, configuration.GetConnectionString(LoanManagementConsts.ConnectionStringName));

            return new LoanManagementDbContext(builder.Options);
        }
    }
}
