using Abp;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using LoanManagement.Borrower_Information;
using LoanManagement.BorrowerEmploymentInformations.Dto;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
                     BorrowerType = i.BorrowerType
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
                    BorrowerType = i.BorrowerType
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

        public async Task<ResponseMessagesDto> UpdateAsync(CreateOrUpdateBorrowerEmploymentInformationDto input)
        {
            var result = await _borrowerEmploymentInformationRepository.UpdateAsync(input.Id, borrower =>
            {
                borrower.Id = input.Id;
                borrower.EmployersName1 = input.EmployersName1;
                borrower.EmployersAddress1 = input.EmployersAddress1;
                borrower.IsSelfEmployer1 = input.IsSelfEmployer1;
                borrower.YearOnThisJob1 = input.YearOnThisJob1;
                borrower.YearInThisLineOfWork1 = input.YearInThisLineOfWork1;
                borrower.Position1 = input.Position1;
                borrower.BusinessPhone1 = input.BusinessPhone1;
                borrower.EmployersName2 = input.EmployersName2;
                borrower.EmployersAddress2 = input.EmployersAddress2;
                borrower.IsSelfEmployer2 = input.IsSelfEmployer2;
                borrower.DateFromTo2 = input.DateFromTo2;
                borrower.MonthlyIncome2 = input.MonthlyIncome2;
                borrower.Position2 = input.Position2;
                borrower.BusinessPhone2 = input.BusinessPhone2;
                borrower.EmployersName3 = input.EmployersName3;
                borrower.EmployersAddress3 = input.EmployersAddress3;
                borrower.IsSelfEmployer3 = input.IsSelfEmployer3;
                borrower.DateFromTo3 = input.DateFromTo3;
                borrower.MonthlyIncome3 = input.MonthlyIncome3;
                borrower.Position3 = input.Position3;
                borrower.BusinessPhone3 = input.BusinessPhone3;
                borrower.BorrowerType = input.BorrowerType;
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
                BorrowerType = input.BorrowerType
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
