using Abp;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using LoanManagement.DatabaseServices.Interfaces;
using LoanManagement.Models;
using LoanManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.DatabaseServices.Implementations
{
    public class HomeBuyingService : AbpServiceBase,IHomeBuyingService
    {
        private readonly IRepository<HomeBuying, long> _repository;
        public HomeBuyingService(
            IRepository<HomeBuying, long> repository)
        {
            _repository = repository;
        }

        public async Task CreateAsync(HomeBuying input)
        {
            await _repository.InsertAsync(input);
            await UnitOfWorkManager.Current.SaveChangesAsync();
        }
    }
}
