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

        public async Task<ResponseMessagesDto> CreateOrUpdateAsync(BorrowerInformationDto input)
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

        private async Task<ResponseMessagesDto> UpdateBorrowerInformationAsync(BorrowerInformationDto input)
        {
            var result = await _borrowerInformationRepository.UpdateAsync(input.Id, borrowerInformation =>
            {
                borrowerInformation.SocialSecurityNumber = input.SocialSecurityNumber;
                borrowerInformation.HomePhone = input.HomePhone;
                borrowerInformation.DOB = input.DOB;
                borrowerInformation.YearsSchool = input.YearsSchool;
                borrowerInformation.Marital = input.Marital;
                borrowerInformation.PresentAddress = input.PresentAddress;
                borrowerInformation.PresentAddressType = input.PresentAddressType;
                borrowerInformation.PresentAddressNoOfYears = input.PresentAddressNoOfYears;
                borrowerInformation.MailingAddress = input.MailingAddress;
                borrowerInformation.FormerAddressModel = input.FormerAddressModel;
                borrowerInformation.FormerAddressType = input.FormerAddressType;
                borrowerInformation.FormerAddressNoOfYears = input.FormerAddressNoOfYears;
                borrowerInformation.BorrowerType = input.BorrowerType;
                borrowerInformation.TenantId = input.TenantId;

                return Task.CompletedTask;
            });

            await UnitOfWorkManager.Current.SaveChangesAsync();

            if (result.Id != 0)
            {
                return new ResponseMessagesDto()
                {
                    Id = result.Id,
                    SuccessMessage = AppConsts.SuccessfullyUpdated,
                    Success = true,
                    Error = false,
                };
            }
            return new ResponseMessagesDto()
            {
                Id = 0,
                ErrorMessage = AppConsts.UpdateFailure,
                Success = false,
                Error = true,
            };
        }

        private async Task<ResponseMessagesDto> CreateBorrowerInformationAsync(BorrowerInformationDto input)
        {
            var borrowerInformation = ObjectMapper.Map<BorrowerInformation>(input);
            var result = await _borrowerInformationRepository.InsertAsync(borrowerInformation);

            await UnitOfWorkManager.Current.SaveChangesAsync();

            input.Id = borrowerInformation.Id;

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
