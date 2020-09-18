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

        public async Task<LoanApplicationDto> GetAsync(EntityDto<long> input)
        {
            try
            {
                var result = await _repository.FirstOrDefaultAsync(x => x.Id == input.Id);
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
                //if (input.BorrowerEmploymentInfromation != null && input.BorrowerEmploymentInfromation.Id != default)
                //    loanApplication.BorrowerEmploymentInfoId = input.BorrowerEmploymentInfromation.Id;

                //if (input.BorrowerInformation != null && input.BorrowerInformation.Id != default)
                //    loanApplication.BorrowerInfoId = input.BorrowerInformation.Id;

                //if (input.CoBorrowerEmploymentInfromation != null && input.CoBorrowerEmploymentInfromation.Id != default)
                //    loanApplication.CoBorrowerEmploymentInfoId = input.CoBorrowerEmploymentInfromation.Id;

                //if (input.CoBorrowerInformation != null && input.CoBorrowerInformation.Id != default)
                //    loanApplication.CoBorrowerInfoId = input.CoBorrowerInformation.Id;

                //if (input.MortgageType != null && input.MortgageType.Id != default)
                //    loanApplication.MortgageTypeId = input.MortgageType.Id;

                //if (input.PropertyInformation != null && input.PropertyInformation.Id != default)
                //    loanApplication.PropertyInfoId = input.PropertyInformation.Id;

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
