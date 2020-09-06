using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using LoanManagement.EntityFrameworkCore;
using LoanManagement.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace LoanManagement.Web.Tests
{
    [DependsOn(
        typeof(LoanManagementWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class LoanManagementWebTestModule : AbpModule
    {
        public LoanManagementWebTestModule(LoanManagementEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(LoanManagementWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(LoanManagementWebMvcModule).Assembly);
        }
    }
}