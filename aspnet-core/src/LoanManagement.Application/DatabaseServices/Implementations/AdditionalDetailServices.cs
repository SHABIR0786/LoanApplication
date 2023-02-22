using Abp;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using LoanManagement.codeFirstEntities;
using LoanManagement.DatabaseServices.Interfaces;
using LoanManagement.Models;
using LoanManagement.ViewModels;
using System;
using System.Threading.Tasks;

namespace LoanManagement.DatabaseServices.Implementations
{
    public class AdditionalDetailServices : AbpServiceBase, IAdditionalDetailServices
    {
        private readonly IRepository<Additionaldetail, long> _repository;

        public AdditionalDetailServices(IRepository<Additionaldetail, long> repository)
        {
            _repository = repository;
        }

        public Task<AdditionalDetailsDto> GetAsync(EntityDto<long?> input)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResultDto<AdditionalDetailsDto>> GetAllAsync(PagedLoanApplicationResultRequestDto input)
        {
            throw new NotImplementedException();
        }

        public async Task<AdditionalDetailsDto> CreateAsync(AdditionalDetailsDto input)
        {
            var additionalDetail = new Additionaldetail
            {
                NameOfIndividualsOnTitle = input.NameOfIndividualsOnTitle,
                NameOfIndividualsCoBorrowerOnTitle = input.NameOfIndividualsCoBorrowerOnTitle
            };
            await _repository.InsertAsync(additionalDetail);
            await UnitOfWorkManager.Current.SaveChangesAsync();

            input.Id = additionalDetail.Id;
            return input;
        }

        public async Task<AdditionalDetailsDto> UpdateAsync(AdditionalDetailsDto input)
        {
            await _repository.UpdateAsync(input.Id.Value, additionalDetail =>
            {
                additionalDetail.NameOfIndividualsOnTitle = input.NameOfIndividualsOnTitle;
                additionalDetail.NameOfIndividualsCoBorrowerOnTitle = input.NameOfIndividualsCoBorrowerOnTitle;
                return Task.CompletedTask;
            });

            await UnitOfWorkManager.Current.SaveChangesAsync();
            return input;
        }

        public Task DeleteAsync(EntityDto<long?> input)
        {
            throw new NotImplementedException();
        }
    }
}
