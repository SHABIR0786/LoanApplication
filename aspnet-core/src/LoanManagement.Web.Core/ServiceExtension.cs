﻿using LoanManagement.EntityFrameworkCore;
using LoanManagement.Services.Implementation;
using LoanManagement.Services.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddMortgageLoanServices(this IServiceCollection services)
        {
            services.AddDbContext<MortgagedbContext>();
            services.AddTransient<IApplicationService, ApplicationService>();
            services.AddTransient<ICreditTypeService, CreditTypeService>();
            services.AddTransient<IHousingTypeService, HousingTypeService>();
            services.AddTransient<IIncomeSourceService, IncomeSourceService>();
            services.AddTransient<ICitizenshipTypeService, CitizenshipTypeService>();
            services.AddTransient<ICityService, CityService>();
            services.AddTransient<ICountryService, CountryService>();
            services.AddTransient<IDeclarationService, DeclarationService>();
            services.AddTransient<IDemographicInformationService, DemographicInformationService>();
            services.AddTransient<IFinancialService, FinancialService>();
            services.AddTransient<IIncomeTypeService, IncomeTypeService>();
            services.AddTransient<ILoanService, LoanService>();
            services.AddTransient<IMaritalStatusService, MaritalStatusService>();
            services.AddTransient<IStateService, StateService>();

            return services;
        }
    }
}
