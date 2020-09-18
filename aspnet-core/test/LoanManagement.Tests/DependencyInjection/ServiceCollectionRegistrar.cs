using Abp.Dependency;
using Castle.MicroKernel.Registration;
using Castle.Windsor.MsDependencyInjection;
using LoanManagement.EntityFrameworkCore;
using LoanManagement.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace LoanManagement.Tests.DependencyInjection
{
    public static class ServiceCollectionRegistrar
    {
        public static void Register(IIocManager iocManager)
        {
            var services = new ServiceCollection();

            IdentityRegistrar.Register(services);

            services.AddEntityFrameworkInMemoryDatabase();

            var serviceProvider = WindsorRegistrationHelper.CreateServiceProvider(iocManager.IocContainer, services);

            var builder = new DbContextOptionsBuilder<LoanManagementDbContext>();
            builder.UseInMemoryDatabase(Guid.NewGuid().ToString()).UseInternalServiceProvider(serviceProvider);

            iocManager.IocContainer.Register(
                Component
                    .For<DbContextOptions<LoanManagementDbContext>>()
                    .Instance(builder.Options)
                    .LifestyleSingleton()
            );
        }
    }
}
