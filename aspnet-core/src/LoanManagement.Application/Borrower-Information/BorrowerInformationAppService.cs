using Abp;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanManagement.BorrowerInformations
{
    public class BorrowerInformationAppService : AbpServiceBase, IBorrowerInformationAppService
    {
        private readonly IRepository<BorrowerInformation, long> _borrowerInformationRepository;

        public BorrowerInformationAppService(IRepository<BorrowerInformation, long> borrowerInformationRepository)
        {
            _borrowerInformationRepository = borrowerInformationRepository;
        }
        public async Task<BorrowerInformationDto> GetAsync(EntityDto<long> input)
        {
            var result = await _borrowerInformationRepository.GetAll()
                 .Where(i => i.Id == input.Id)
                 .Select(i =>
                 new BorrowerInformationDto()
                 {
                     Id = i.Id,
                     BorrowersName = i.BorrowersName,
                     BorrowerType = i.BorrowerType,
                     PresentAddress = i.PresentAddress
                 })
                 .FirstOrDefaultAsync();
            return result;
        }

        public async Task<PagedResultDto<BorrowerInformationDto>> GetPaginatedAllAsync(PagedBorrowerInformationDtoResultRequestDto input)
        {
            var filteredBorrower = _borrowerInformationRepository.GetAll()
                .Where(i => i.IsDeleted == false && (!input.TenantId.HasValue || i.TenantId == input.TenantId))
                .WhereIf(!string.IsNullOrWhiteSpace(input.Keyword),
                    x => x.BorrowersName.Contains(input.Keyword));

            var pagedAndFilteredBorrowers = filteredBorrower
                .OrderBy(i => i.BorrowersName)
                .PageBy(input);

            var totalCount = filteredBorrower.Count();

            return new PagedResultDto<BorrowerInformationDto>(
                totalCount: totalCount,
                items: await pagedAndFilteredBorrowers.Select(i => new BorrowerInformationDto()
                {
                    Id = i.Id,
                    BorrowersName = i.BorrowersName
                })
                    .ToListAsync());
        }

        public async Task<ResponseMessagesDto> CreateOrUpdateAsync(CreateOrUpdateBorrowerInformationDto input)
        {
            ResponseMessagesDto result;
            if (input.Id == 0)
            {
                result = await CreateBorrowerInformationAsync(input);
            }
            else
            {
                result = await UpdateBorrowerInformationAsync(input);
            }
            return result;
        }

        private async Task<ResponseMessagesDto> UpdateBorrowerInformationAsync(CreateOrUpdateBorrowerInformationDto input)
        {
            throw new NotImplementedException();
        }

        private async Task<ResponseMessagesDto> CreateBorrowerInformationAsync(CreateOrUpdateBorrowerInformationDto input)
        {
            var result = await _borrowerInformationRepository.InsertAsync(new BorrowerInformation()
            {
                BorrowersName = input.BorrowersName,
                SocialSecurityNumber = input.SocialSecurityNumber,
                HomePhone = input.HomePhone,
                DOB = input.DOB,
                YearsSchool = input.YearsSchool,
                Marital = input.Marital,
                PresentAddress = input.PresentAddress,
                PresentAddressType = input.PresentAddressType,
                PresentAddressNoOfYears = input.PresentAddressNoOfYears,
                MailingAddress = input.MailingAddress,
                FormerAddressModel = input.FormerAddressModel,
                FormerAddressType = input.FormerAddressType,
                FormerAddressNoOfYears = input.FormerAddressNoOfYears,
                BorrowerType = input.BorrowerType,
                TenantId = input.TenantId
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
            await _borrowerInformationRepository.UpdateAsync(new BorrowerInformation { IsDeleted = true });
            return new ResponseMessagesDto()
            {
                Id = input.Id,
                SuccessMessage = AppConsts.SuccessfullyDeleted,
                Success = true,
                Error = false,
            };
        }

        public async Task<List<BorrowerInformation>> GetAllAsync(long? tenantId)
        {
            var result = await _borrowerInformationRepository.GetAllListAsync();
            return result;
        }
    }
}
