using Abp;
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

        public async Task<PagedResultDto<BorrowerEmploymentInformationDto>> GetPaginatedAllAsync(PagedBorrowerEmploymentInformationDtoResultRequestDto input)
        {
            var filteredBorrower = _borrowerEmploymentInformationRepository.GetAll()
                .Where(i => i.IsDeleted == false && (!input.TenantId.HasValue || i.TenantId == input.TenantId))
                .WhereIf(!string.IsNullOrWhiteSpace(input.Keyword),
                    x => x.EmployersName.Contains(input.Keyword));

            var pagedAndFilteredBorrowers = filteredBorrower
                .OrderBy(i => i.EmployersName)
                .PageBy(input);

            var totalCount = filteredBorrower.Count();

            return new PagedResultDto<BorrowerEmploymentInformationDto>(
                totalCount: totalCount,
                items: await pagedAndFilteredBorrowers.Select(i => new BorrowerEmploymentInformationDto()
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
                .ToListAsync());
        }

        public async Task<ResponseMessagesDto> CreateOrUpdateAsync(BorrowerEmploymentInformationDto input)
        {
            ResponseMessagesDto result;
            if (input.Id == 0)
            {
                result = await CreateAsync(input);
            }
            else
            {
                result = await UpdateAsync(input);
            }
            return result;
        }

        public async Task<ResponseMessagesDto> UpdateAsync(BorrowerEmploymentInformationDto input)
        {
            var result = await _borrowerEmploymentInformationRepository.UpdateAsync(input.Id, borrower =>
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

            return new ResponseMessagesDto()
            {
                Id = result.Id,
                SuccessMessage = AppConsts.SuccessfullyUpdated,
                Success = true,
                Error = false,
            };
        }

        private async Task<ResponseMessagesDto> CreateAsync(BorrowerEmploymentInformationDto input)
        {
            var borrowerEmploymentInformation = new BorrowerEmploymentInformation()
            {
                Id = input.Id,
                EmployersName = input.EmployersName,
                EmployersAddress = input.EmployersAddress,
                IsSelfEmployer = input.IsSelfEmployer,
                YearOnThisJob = input.YearOnThisJob,
                YearInThisLineOfWork = input.YearInThisLineOfWork,
                Position = input.Position,
                BusinessPhone = input.BusinessPhone,
                BorrowerTypeId = input.BorrowerTypeId
            };
            var result = await _borrowerEmploymentInformationRepository.InsertAsync(borrowerEmploymentInformation);

            await UnitOfWorkManager.Current.SaveChangesAsync();

            result.Id = borrowerEmploymentInformation.Id;

            return new ResponseMessagesDto()
            {
                Id = result.Id,
                SuccessMessage = AppConsts.SuccessfullyInserted,
                Success = true,
                Error = false,
            };
        }

        public async Task<ResponseMessagesDto> DeleteAsync(EntityDto<long> input)
        {
            await _borrowerEmploymentInformationRepository.UpdateAsync(new BorrowerEmploymentInformation { IsDeleted = true });
            return new ResponseMessagesDto()
            {
                Id = input.Id,
                SuccessMessage = AppConsts.SuccessfullyDeleted,
                Success = true,
                Error = false,
            };
        }

        public async Task<List<BorrowerEmploymentInformation>> GetAllAsync(long? tenantId)
        {
            var result = await _borrowerEmploymentInformationRepository.GetAllListAsync();
            return result;
        }
    }
}
