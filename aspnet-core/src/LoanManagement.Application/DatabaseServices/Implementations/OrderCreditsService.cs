using Abp;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using LoanManagement.DatabaseServices.Interfaces;
using LoanManagement.Models;
using LoanManagement.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace LoanManagement.DatabaseServices.Implementations
{
    public class OrderCreditsService : AbpServiceBase, IOrderDetailsService
    {
        private readonly IRepository<OrderCredits, long> _repository;

        public OrderCreditsService(IRepository<OrderCredits, long> repository)
        {
            _repository = repository;
        }

        public async Task<OrderCreditsDto> GetAsync(EntityDto<long> input)
        {
           throw new NotImplementedException();
        }

        public Task<PagedResultDto<OrderCreditsDto>> GetAllAsync(PagedLoanApplicationResultRequestDto input)
        {
            throw new NotImplementedException();
        }

        public async Task<OrderCreditsDto> CreateAsync(OrderCreditsDto input)
       {
            try
            {
                var orderCredits = new OrderCredits
                {
                 AgreeCreditAuthAgreement = input.AgreeCreditAuthAgreement,

                };
                await _repository.InsertAsync(orderCredits);
                await UnitOfWorkManager.Current.SaveChangesAsync();

                input.Id = orderCredits.Id;
                return input;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public async Task<OrderCreditsDto> UpdateAsync(OrderCreditsDto input)
        {
            await _repository.UpdateAsync(input.Id, orderCredits =>
            {

               orderCredits. AgreeCreditAuthAgreement = input.AgreeCreditAuthAgreement;
                return Task.CompletedTask;
            });

            await UnitOfWorkManager.Current.SaveChangesAsync();
            return input;
        }

        public Task DeleteAsync(EntityDto<long> input)
        {
            throw new NotImplementedException();
        }
    }
}
