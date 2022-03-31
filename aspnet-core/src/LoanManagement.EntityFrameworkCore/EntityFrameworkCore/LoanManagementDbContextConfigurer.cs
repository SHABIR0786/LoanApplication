using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using System;
using System.Data.Common;

namespace LoanManagement.EntityFrameworkCore
{
    public static class LoanManagementDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<LoanManagementDbContext> builder, string connectionString, ILoggerFactory loggerFactory = null, IWebHostEnvironment webHostEnvironment = null)
        {

            builder.UseMySql(connectionString, null);

            if (webHostEnvironment == null || webHostEnvironment.IsDevelopment())
            {
                builder.UseLoggerFactory(loggerFactory);
                builder.EnableSensitiveDataLogging();
                builder.EnableDetailedErrors();
                builder.ConfigureWarnings(option => option.Throw());
            }
        }

        public static void Configure(DbContextOptionsBuilder<LoanManagementDbContext> builder, DbConnection connection, ILoggerFactory loggerFactory = null, IWebHostEnvironment webHostEnvironment = null)
        {
            builder.UseMySql(connection, null);

            if (webHostEnvironment == null || webHostEnvironment.IsDevelopment())
            {
                builder.UseLoggerFactory(loggerFactory);
                builder.EnableSensitiveDataLogging();
                builder.EnableDetailedErrors();
                builder.ConfigureWarnings(option => option.Throw());
            }
        }
    }
}
