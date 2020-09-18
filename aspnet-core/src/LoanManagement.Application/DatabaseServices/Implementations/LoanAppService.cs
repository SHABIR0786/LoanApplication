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
                    .Include(i => i.AssetAndLiablity)
                    .Include(i => i.DetailsOfTransaction)
                    .Include(i => i.BorrowerEmploymentInfo1)
                    .Include(i => i.BorrowerEmploymentInfo2)
                    .Include(i => i.BorrowerEmploymentInfo3)
                    .Include(i => i.MortgageType)
                    .Include(i => i.PropertyInfo)
                    .Include(i => i.BorrowerInfo)
                    .Include(i => i.CoBorrowerInfo)
                    .Include(i => i.CoBorrowerEmploymentInfo1)
                    .Include(i => i.CoBorrowerEmploymentInfo2)
                    .Include(i => i.CoBorrowerEmploymentInfo3)
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
                var loanApplication = new LoanApplication
                {
                    MortgageType = ObjectMapper.Map<MortgageType>(input.MortgageType),
                    PropertyInfo = ObjectMapper.Map<PropertyInformation>(input.PropertyInformation),

                    BorrowerInfo = ObjectMapper.Map<BorrowerInformation>(input.BorrowerInformation),
                    CoBorrowerInfo = ObjectMapper.Map<BorrowerInformation>(input.CoBorrowerInformation),

                    BorrowerEmploymentInfo1 = ObjectMapper.Map<BorrowerEmploymentInformation>(input.BorrowerEmploymentInformation1),
                    BorrowerEmploymentInfo2 = ObjectMapper.Map<BorrowerEmploymentInformation>(input.BorrowerEmploymentInformation2),
                    BorrowerEmploymentInfo3 = ObjectMapper.Map<BorrowerEmploymentInformation>(input.BorrowerEmploymentInformation3),

                    CoBorrowerEmploymentInfo1 = ObjectMapper.Map<BorrowerEmploymentInformation>(input.CoBorrowerEmploymentInformation1),
                    CoBorrowerEmploymentInfo2 = ObjectMapper.Map<BorrowerEmploymentInformation>(input.CoBorrowerEmploymentInformation2),
                    CoBorrowerEmploymentInfo3 = ObjectMapper.Map<BorrowerEmploymentInformation>(input.CoBorrowerEmploymentInformation3),
                };
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
                if (input.BorrowerInformation != null && input.BorrowerInformation.Id != default)
                    loanApplication.BorrowerInfoId = input.BorrowerInformation.Id;

                if (input.CoBorrowerInformation != null && input.CoBorrowerInformation.Id != default)
                    loanApplication.CoBorrowerInfoId = input.CoBorrowerInformation.Id;

                if (input.BorrowerEmploymentInformation1 != null && input.BorrowerEmploymentInformation1.Id != default)
                    loanApplication.BorrowerEmploymentInfoId1 = input.BorrowerEmploymentInformation1.Id;

                if (input.BorrowerEmploymentInformation2 != null && input.BorrowerEmploymentInformation2.Id != default)
                    loanApplication.BorrowerEmploymentInfoId2 = input.BorrowerEmploymentInformation2.Id;

                if (input.BorrowerEmploymentInformation3 != null && input.BorrowerEmploymentInformation3.Id != default)
                    loanApplication.BorrowerEmploymentInfoId3 = input.BorrowerEmploymentInformation3.Id;

                if (input.CoBorrowerEmploymentInformation1 != null && input.CoBorrowerEmploymentInformation1.Id != default)
                    loanApplication.BorrowerEmploymentInfoId1 = input.CoBorrowerEmploymentInformation1.Id;

                if (input.CoBorrowerEmploymentInformation2 != null && input.CoBorrowerEmploymentInformation2.Id != default)
                    loanApplication.CoBorrowerEmploymentInfoId2 = input.CoBorrowerEmploymentInformation2.Id;

                if (input.CoBorrowerEmploymentInformation3 != null && input.CoBorrowerEmploymentInformation3.Id != default)
                    loanApplication.CoBorrowerEmploymentInfoId3 = input.CoBorrowerEmploymentInformation3.Id;

                if (input.MortgageType != null && input.MortgageType.Id != default)
                    loanApplication.MortgageTypeId = input.MortgageType.Id;

                if (input.PropertyInformation != null && input.PropertyInformation.Id != default)
                    loanApplication.PropertyInfoId = input.PropertyInformation.Id;

                if (input.AssetAndLiablity != null && input.AssetAndLiablity.Id != default)
                    loanApplication.AssetAndLiablityId = input.AssetAndLiablity.Id;

                if (input.DetailsOfTransaction != null && input.DetailsOfTransaction.Id != default)
                    loanApplication.DetailsOfTransactionId = input.DetailsOfTransaction.Id;

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
