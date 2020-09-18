using Abp;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using LoanManagement.LoanApplications.Dto;
using LoanManagement.Roles.Dto;
using System;
using System.Threading.Tasks;

namespace LoanManagement.LoanApplications
{
    public class LoanAppService : AbpServiceBase, ILoanAppService
    {
        private readonly IRepository<LoanApplication, long> _repository;

        public LoanAppService(IRepository<LoanApplication, long> repository)
        {
            _repository = repository;
        }

        public Task<LoanApplicationDto> GetAsync(EntityDto<long> input)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResultDto<LoanApplicationDto>> GetAllAsync(PagedLoanApplicationResultRequestDto input)
        {
            throw new NotImplementedException();
        }

        public async Task<LoanApplicationDto> CreateAsync(LoanApplicationDto input)
        {
            var loanApplication = new LoanApplication
            {

            };
            await _repository.InsertAsync(loanApplication);

            await UnitOfWorkManager.Current.SaveChangesAsync();

            input.Id = loanApplication.Id;
            return input;
        }

        public async Task<LoanApplicationDto> UpdateAsync(LoanApplicationDto input)
        {
            await _repository.UpdateAsync(input.Id, loanApplication =>
            {
                if (input.BorrowerEmploymentInfromation != null && input.BorrowerEmploymentInfromation.Id != default)
                    loanApplication.BorrowerEmploymentInfoId = input.BorrowerEmploymentInfromation.Id;

                if (input.BorrowerInformation != null && input.BorrowerInformation.Id != default)
                    loanApplication.BorrowerInfoId = input.BorrowerInformation.Id;

                if (input.CoBorrowerEmploymentInfromation != null && input.CoBorrowerEmploymentInfromation.Id != default)
                    loanApplication.CoBorrowerEmploymentInfoId = input.CoBorrowerEmploymentInfromation.Id;

                if (input.CoBorrowerInformation != null && input.CoBorrowerInformation.Id != default)
                    loanApplication.CoBorrowerInfoId = input.CoBorrowerInformation.Id;

                if (input.MortgageType != null && input.MortgageType.Id != default)
                    loanApplication.MortgageTypeId = input.MortgageType.Id;

                if (input.PropertyInformation != null && input.PropertyInformation.Id != default)
                    loanApplication.PropertyInfoId = input.PropertyInformation.Id;

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
