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
    public class LoanAppService : AbpServiceBase, ILoanAppService
    {
        private readonly IRepository<LoanApplication, long> _repository;

        public LoanAppService(IRepository<LoanApplication, long> repository)
        {
            _repository = repository;
        }

        public async Task<LoanApplicationDto> GetAsync(EntityDto<long> input)
        {
            try
            {
                var result = await _repository.GetAllIncluding()
                    .FirstOrDefaultAsync(i => i.Id == input.Id);

                return ObjectMapper.Map<LoanApplicationDto>(result);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Task<PagedResultDto<LoanApplicationDto>> GetAllAsync(PagedLoanApplicationResultRequestDto input)
        {
            throw new NotImplementedException();
        }

        public async Task<LoanApplicationDto> CreateAsync(LoanApplicationDto input)
        {
            try
            {
                var loanApplication = new LoanApplication();
                await _repository.InsertAsync(loanApplication);
                await UnitOfWorkManager.Current.SaveChangesAsync();

                input.Id = loanApplication.Id;
                return input;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<LoanApplicationDto> UpdateAsync(LoanApplicationDto input)
        {
            await _repository.UpdateAsync(input.Id, loanApplication =>
            {
                //if (input.BorrowerInformation != null && input.BorrowerInformation.Id != default)
                //    loanApplication.BorrowerInfoId = input.BorrowerInformation.Id;

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
