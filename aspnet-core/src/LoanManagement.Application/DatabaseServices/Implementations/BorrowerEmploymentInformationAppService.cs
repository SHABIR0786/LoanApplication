using Abp;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using LoanManagement.DatabaseServices.Interfaces;
using LoanManagement.Models;
using LoanManagement.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanManagement.DatabaseServices.Implementations
{
    public class BorrowerEmploymentInformationAppService : AbpServiceBase, IBorrowerEmploymentInformationAppService
    {
        private readonly IRepository<BorrowerEmploymentInformation, long> _borrowerEmploymentInformationRepository;

        public BorrowerEmploymentInformationAppService(IRepository<BorrowerEmploymentInformation, long> borrowerEmploymentInformationRepository)
        {
            _borrowerEmploymentInformationRepository = borrowerEmploymentInformationRepository;
        }

        public async Task<BorrowerEmploymentInformationDto> GetAsync(EntityDto<long> input)
        {
            var result = await _borrowerEmploymentInformationRepository.GetAll()
                 .Where(i => i.Id == input.Id)
                 .Select(i =>
                 new BorrowerEmploymentInformationDto()
                 {
                     Id = i.Id,
                     EmployersName = i.EmployersName,
                     EmployersAddress = i.EmployersAddress,
                     IsSelfEmployer = i.IsSelfEmployer,
                     YearOnThisJob = i.YearOnThisJob,
                     YearInThisLineOfWork = i.YearInThisLineOfWork,
                     Position = i.Position,
                     BusinessPhone = i.BusinessPhone
                 })
                 .FirstOrDefaultAsync();
            return result;
        }

        //public async Task<List<BorrowerEmploymentInformation>> GetAllAsync(long? tenantId)
        //{
        //    var result = await _borrowerEmploymentInformationRepository.GetAllListAsync();
        //    return result;
        //}

        public Task<PagedResultDto<BorrowerEmploymentInformationDto>> GetAllAsync(PagedLoanApplicationResultRequestDto input)
        {
            throw new System.NotImplementedException();
        }

        public async Task<BorrowerEmploymentInformationDto> CreateAsync(BorrowerEmploymentInformationDto input)
        {
            var borrowerEmploymentInformation = new BorrowerEmploymentInformation()
            {
                EmployersName = input.EmployersName,
                EmployersAddress = input.EmployersAddress,
                IsSelfEmployer = input.IsSelfEmployer,
                YearOnThisJob = input.YearOnThisJob,
                YearInThisLineOfWork = input.YearInThisLineOfWork,
                Position = input.Position,
                BusinessPhone = input.BusinessPhone,
                BorrowerTypeId = input.BorrowerTypeId
            };
            await _borrowerEmploymentInformationRepository.InsertAsync(borrowerEmploymentInformation);
            await UnitOfWorkManager.Current.SaveChangesAsync();
            input.Id = borrowerEmploymentInformation.Id;
            return input;
        }

        public async Task<BorrowerEmploymentInformationDto> UpdateAsync(BorrowerEmploymentInformationDto input)
        {
            await _borrowerEmploymentInformationRepository.UpdateAsync(input.Id, borrower =>
            {
                borrower.Id = input.Id;
                borrower.EmployersName = input.EmployersName;
                borrower.EmployersAddress = input.EmployersAddress;
                borrower.IsSelfEmployer = input.IsSelfEmployer;
                borrower.YearOnThisJob = input.YearOnThisJob;
                borrower.YearInThisLineOfWork = input.YearInThisLineOfWork;
                borrower.Position = input.Position;
                borrower.BusinessPhone = input.BusinessPhone;
                borrower.BorrowerTypeId = input.BorrowerTypeId;
                return Task.CompletedTask;
            });
            await UnitOfWorkManager.Current.SaveChangesAsync();
            return input;
        }

        public Task DeleteAsync(EntityDto<long> input)
        {
            throw new System.NotImplementedException();
        }
    }
}
