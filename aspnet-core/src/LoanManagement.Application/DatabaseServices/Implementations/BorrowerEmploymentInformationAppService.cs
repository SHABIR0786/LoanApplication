using Abp;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using LoanManagement.DatabaseServices.Interfaces;
using LoanManagement.Models;
using LoanManagement.ViewModels;
using System;
using System.Threading.Tasks;

namespace LoanManagement.DatabaseServices.Implementations
{
    public class BorrowerEmploymentInformationAppService : AbpServiceBase, IBorrowerEmploymentInformationAppService
    {
        private readonly IRepository<BorrowerEmploymentInformation, long> _repository;

        public BorrowerEmploymentInformationAppService(IRepository<BorrowerEmploymentInformation, long> repository)
        {
            _repository = repository;
        }

        public async Task<BorrowerEmploymentInformationDto> GetAsync(EntityDto<long?> input)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResultDto<BorrowerEmploymentInformationDto>> GetAllAsync(PagedLoanApplicationResultRequestDto input)
        {
            throw new NotImplementedException();
        }

        public async Task<BorrowerEmploymentInformationDto> CreateAsync(BorrowerEmploymentInformationDto input)
        {
            try
            {
                var additionalDetail = new BorrowerEmploymentInformation
                {
                    EmployersName = input.EmployersName,
                    EmployersAddress1 = input.EmployersAddress1,
                    EmployersAddress2 = input.EmployersAddress2,
                    IsSelfEmployed = input.IsSelfEmployed,
                    Position = input.Position,
                    City = input.City,
                    StateId = input.StateId,
                    ZipCode = input.ZipCode,
                    StartDate = input.StartDate,
                    EndDate = input.EndDate,
                    BorrowerTypeId = input.BorrowerTypeId,
                    LoanApplicationId = input.LoanApplicationId.Value
                };
                await _repository.InsertAsync(additionalDetail);
                await UnitOfWorkManager.Current.SaveChangesAsync();

                input.Id = additionalDetail.Id;
                return input;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<BorrowerEmploymentInformationDto> UpdateAsync(BorrowerEmploymentInformationDto input)
        {
            await _repository.UpdateAsync(input.Id.Value, additionalDetail =>
            {
                additionalDetail.EmployersName = input.EmployersName;
                additionalDetail.EmployersAddress1 = input.EmployersAddress1;
                additionalDetail.EmployersAddress2 = input.EmployersAddress2;
                additionalDetail.IsSelfEmployed = input.IsSelfEmployed;
                additionalDetail.Position = input.Position;
                additionalDetail.City = input.City;
                additionalDetail.StateId = input.StateId;
                additionalDetail.ZipCode = input.ZipCode;
                additionalDetail.StartDate = input.StartDate;
                additionalDetail.EndDate = input.EndDate;

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
