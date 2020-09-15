using System;
using System.Data.Common;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Pomelo.EntityFrameworkCore.MySql.Storage;

namespace LoanManagement.EntityFrameworkCore
{
    public static class LoanManagementDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<LoanManagementDbContext> builder, string connectionString, IWebHostEnvironment webHostEnvironment = null)
        {
            builder.UseMySql(connectionString, mySqlOptions =>
            {
                mySqlOptions.ServerVersion(new Version(10, 3, 17), ServerType.MariaDb);
                mySqlOptions.EnableRetryOnFailure(
                    maxRetryCount: 10,
                    maxRetryDelay: TimeSpan.FromSeconds(30),
                    errorNumbersToAdd: null);
            });

            if(webHostEnvironment == null || webHostEnvironment.IsDevelopment())
            {
                builder.EnableSensitiveDataLogging();
                builder.EnableDetailedErrors();
                builder.ConfigureWarnings(option => option.Throw());
            }
        }

        public static void Configure(DbContextOptionsBuilder<LoanManagementDbContext> builder, DbConnection connection, IWebHostEnvironment webHostEnvironment = null)
        {
            builder.UseMySql(connection, mySqlOptions =>
            {
                mySqlOptions.ServerVersion(new Version(10, 3, 17), ServerType.MariaDb);
                mySqlOptions.EnableRetryOnFailure(
                    maxRetryCount: 10,
                    maxRetryDelay: TimeSpan.FromSeconds(30),
                    errorNumbersToAdd: null);
            });

            if (webHostEnvironment == null || webHostEnvironment.IsDevelopment())
            {
                builder.EnableSensitiveDataLogging();
                builder.EnableDetailedErrors();
                builder.ConfigureWarnings(option => option.Throw());
            }
        }
    }
}
