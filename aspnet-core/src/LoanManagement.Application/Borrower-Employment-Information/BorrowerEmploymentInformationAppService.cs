using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using LoanManagement.Borrower_Information;
using LoanManagement.BorrowerEmploymentInformations.Dto;
using LoanManagement.BorrowerInformations;
using Microsoft.EntityFrameworkCore;

namespace LoanManagement.BorrowerEmploymentInformations
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
                     EmployersName1 = i.EmployersName1,
                     EmployersAddress1 = i.EmployersAddress1,
                     IsSelfEmployer1 = i.IsSelfEmployer1,
                     YearOnThisJob1 = i.YearOnThisJob1,
                     YearInThisLineOfWork1 = i.YearInThisLineOfWork1,
                     Position1 = i.Position1,
                     BusinessPhone1 = i.BusinessPhone1,
                     EmployersName2 = i.EmployersName2,
                     EmployersAddress2 = i.EmployersAddress2,
                     IsSelfEmployer2 = i.IsSelfEmployer2,
                     DateFromTo2 = i.DateFromTo2,
                     MonthlyIncome2 = i.MonthlyIncome2,
                     Position2 = i.Position2,
                     BusinessPhone2 = i.BusinessPhone2,
                     EmployersName3 = i.EmployersName3,
                     EmployersAddress3 = i.EmployersAddress3,
                     IsSelfEmployer3 = i.IsSelfEmployer3,
                     DateFromTo3 = i.DateFromTo3,
                     MonthlyIncome3 = i.MonthlyIncome3,
                     Position3 = i.Position3,
                     BusinessPhone3 = i.BusinessPhone3,
                     BorrowerTypeId = i.BorrowerTypeId
                 })
                 .FirstOrDefaultAsync();
            return result;
        }

        public async Task<PagedResultDto<BorrowerEmploymentInformationDto>> GetPaginatedAllAsync(PagedBorrowerEmploymentInformationDtoResultRequestDto input)
        {
            var filteredBorrower = _borrowerEmploymentInformationRepository.GetAll()
                .Where(i => i.IsDeleted == false && (!input.TenantId.HasValue || i.TenantId == input.TenantId))
                .WhereIf(!string.IsNullOrWhiteSpace(input.Keyword),
                    x => x.EmployersName1.Contains(input.Keyword));

            var pagedAndFilteredBorrowers = filteredBorrower
                .OrderBy(i => i.EmployersName1)
                .PageBy(input);

            var totalCount = filteredBorrower.Count();

            return new PagedResultDto<BorrowerEmploymentInformationDto>(
                totalCount: totalCount,
                items: await pagedAndFilteredBorrowers.Select(i => new BorrowerEmploymentInformationDto()
                {
                    Id = i.Id,
                    EmployersName1 = i.EmployersName1,
                    EmployersAddress1 = i.EmployersAddress1,
                    IsSelfEmployer1 = i.IsSelfEmployer1,
                    YearOnThisJob1 = i.YearOnThisJob1,
                    YearInThisLineOfWork1 = i.YearInThisLineOfWork1,
                    Position1 = i.Position1,
                    BusinessPhone1 = i.BusinessPhone1,
                    EmployersName2 = i.EmployersName2,
                    EmployersAddress2 = i.EmployersAddress2,
                    IsSelfEmployer2 = i.IsSelfEmployer2,
                    DateFromTo2 = i.DateFromTo2,
                    MonthlyIncome2 = i.MonthlyIncome2,
                    Position2 = i.Position2,
                    BusinessPhone2 = i.BusinessPhone2,
                    EmployersName3 = i.EmployersName3,
                    EmployersAddress3 = i.EmployersAddress3,
                    IsSelfEmployer3 = i.IsSelfEmployer3,
                    DateFromTo3 = i.DateFromTo3,
                    MonthlyIncome3 = i.MonthlyIncome3,
                    Position3 = i.Position3,
                    BusinessPhone3 = i.BusinessPhone3,
                    BorrowerTypeId = i.BorrowerTypeId
                })
                    .ToListAsync());
        }

        public async Task<ResponseMessagesDto> CreateOrUpdateAsync(CreateOrUpdateBorrowerEmploymentInformationDto input)
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

        private async Task<ResponseMessagesDto> UpdateAsync(CreateOrUpdateBorrowerEmploymentInformationDto input)
        {
            return null;
        }

        private async Task<ResponseMessagesDto> CreateAsync(CreateOrUpdateBorrowerEmploymentInformationDto input)
        {
            var result = await _borrowerEmploymentInformationRepository.InsertAsync(new BorrowerEmploymentInformation()
            {
                Id = input.Id,
                EmployersName1 = input.EmployersName1,
                EmployersAddress1 = input.EmployersAddress1,
                IsSelfEmployer1 = input.IsSelfEmployer1,
                YearOnThisJob1 = input.YearOnThisJob1,
                YearInThisLineOfWork1 = input.YearInThisLineOfWork1,
                Position1 = input.Position1,
                BusinessPhone1 = input.BusinessPhone1,
                EmployersName2 = input.EmployersName2,
                EmployersAddress2 = input.EmployersAddress2,
                IsSelfEmployer2 = input.IsSelfEmployer2,
                DateFromTo2 = input.DateFromTo2,
                MonthlyIncome2 = input.MonthlyIncome2,
                Position2 = input.Position2,
                BusinessPhone2 = input.BusinessPhone2,
                EmployersName3 = input.EmployersName3,
                EmployersAddress3 = input.EmployersAddress3,
                IsSelfEmployer3 = input.IsSelfEmployer3,
                DateFromTo3 = input.DateFromTo3,
                MonthlyIncome3 = input.MonthlyIncome3,
                Position3 = input.Position3,
                BusinessPhone3 = input.BusinessPhone3,
                BorrowerTypeId = input.BorrowerTypeId
            });

            await UnitOfWorkManager.Current.SaveChangesAsync();

            if (result.Id != 0)
            {
                return new ResponseMessagesDto()
                {
                    Id = result.Id,
                    SuccessMessage = AppConsts.SuccessfullyInserted,
                    Success = true,
                    Error = false,
                };
            }
            return new ResponseMessagesDto()
            {
                Id = 0,
                ErrorMessage = AppConsts.InsertFailure,
                Success = false,
                Error = true,
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
