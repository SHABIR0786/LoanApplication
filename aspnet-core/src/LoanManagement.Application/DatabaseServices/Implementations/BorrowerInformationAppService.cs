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
                     BorrowerType = i.BorrowerType.Name,
                     PresentAddress = i.PresentAddress
                 })
                 .FirstOrDefaultAsync();
            return result;
        }

        public async Task<BorrowerInformationDto> CreateAsync(BorrowerInformationDto input)
        {
            var borrowerInformation = new BorrowerInformation
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
                BorrowerTypeId = input.BorrowerTypeId,
                TenantId = input.TenantId
            };

            await _borrowerInformationRepository.InsertAsync(borrowerInformation);
            await UnitOfWorkManager.Current.SaveChangesAsync();
            input.Id = borrowerInformation.Id;
            return input;
        }

        public async Task<BorrowerInformationDto> UpdateAsync(BorrowerInformationDto input)
        {
            await _borrowerInformationRepository.UpdateAsync(input.Id, borrowerInformation =>
            {
                borrowerInformation.BorrowersName = input.BorrowersName;
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
                borrowerInformation.BorrowerTypeId = input.BorrowerTypeId;
                borrowerInformation.TenantId = input.TenantId;
                return Task.CompletedTask;
            });

            await UnitOfWorkManager.Current.SaveChangesAsync();
            return input;
        }

        //public async Task<List<BorrowerInformation>> GetAllAsync(long? tenantId)
        //{
        //    var result = await _borrowerInformationRepository.GetAllListAsync();
        //    return result;
        //}

        public Task<PagedResultDto<BorrowerInformationDto>> GetAllAsync(PagedLoanApplicationResultRequestDto input)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteAsync(EntityDto<long> input)
        {
            throw new System.NotImplementedException();
        }
    }
}