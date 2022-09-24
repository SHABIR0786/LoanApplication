using Abp;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using LoanManagement.codeFirstEntities;
using LoanManagement.DatabaseServices.Interfaces;
using LoanManagement.Models;
using LoanManagement.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanManagement.DatabaseServices.Implementations
{
    public class BorrowerEmploymentInformationAppService : AbpServiceBase, IBorrowerEmploymentInformationAppService
    {
        private readonly IRepository<Borroweremploymentinformation, long> _repository;

        public BorrowerEmploymentInformationAppService(IRepository<Borroweremploymentinformation, long> repository)
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

        public async Task<List<Borroweremploymentinformation>> GetAllByLoanApplicationIdAsync(long loanApplicationId)
        {
            return await _repository.GetAll()
                .Where(i => i.LoanApplicationId == loanApplicationId)
                .Select(i => new Borroweremploymentinformation
                {
                    EmployersName = i.EmployersName,
                    EmployersAddress1 = i.EmployersAddress1,
                    EmployersAddress2 = i.EmployersAddress2,
                    IsSelfEmployed = i.IsSelfEmployed,
                    Position = i.Position,
                    City = i.City,
                    StateId = i.StateId,
                    ZipCode = i.ZipCode,
                    StartDate = i.StartDate,
                    EndDate = i.EndDate,
                    BorrowerTypeId = i.BorrowerTypeId,
                    Id = i.Id,
                    LoanApplicationId = i.LoanApplicationId
                })
                .ToListAsync();
        }

        public async Task<BorrowerEmploymentInformationDto> CreateAsync(BorrowerEmploymentInformationDto input)
        {
            try
            {
                var additionalDetail = new Borroweremploymentinformation
                {
                    EmployersName = input.EmployerName,
                    EmployersAddress1 = input.Address1,
                    EmployersAddress2 = input.Address2,
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
                additionalDetail.EmployersName = input.EmployerName;
                additionalDetail.EmployersAddress1 = input.Address1;
                additionalDetail.EmployersAddress2 = input.Address2;
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
