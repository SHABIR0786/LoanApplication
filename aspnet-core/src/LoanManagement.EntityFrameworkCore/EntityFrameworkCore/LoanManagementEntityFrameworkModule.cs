using Abp.EntityFrameworkCore.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Zero.EntityFrameworkCore;
using LoanManagement.EntityFrameworkCore.Seed;
using Microsoft.AspNetCore.Hosting;

namespace LoanManagement.EntityFrameworkCore
{
    [DependsOn(
        typeof(LoanManagementCoreModule),
        typeof(AbpZeroCoreEntityFrameworkCoreModule))]
    public class LoanManagementEntityFrameworkModule : AbpModule
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public LoanManagementEntityFrameworkModule(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        /* Used it tests to skip dbcontext registration, in order to use in-memory database of EF Core */
        public bool SkipDbContextRegistration { get; set; }

        public bool SkipDbSeed { get; set; }

        public override void PreInitialize()
        {
            if (!SkipDbContextRegistration)
            {
                Configuration.Modules.AbpEfCore().AddDbContext<LoanManagementDbContext>(options =>
                {
                    if (options.ExistingConnection != null)
                    {
                        LoanManagementDbContextConfigurer.Configure(options.DbContextOptions, options.ExistingConnection, _webHostEnvironment);
                    }
                    else
                    {
                        LoanManagementDbContextConfigurer.Configure(options.DbContextOptions, options.ConnectionString, _webHostEnvironment);
                    }
                });
            }
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(LoanManagementEntityFrameworkModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            if (!SkipDbSeed)
            {
                SeedHelper.SeedHostDb(IocManager);
            }
        }
    }
}
