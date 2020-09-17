using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using AutoMapper;
using LoanManagement.Authorization.Users;
using LoanManagement.Borrower_Information;
using LoanManagement.LoanApplications.Dto;
using LoanManagement.AssetAndLiablities;
using LoanManagement.Roles.Dto;
using LoanManagement.Property_Information;
using LoanManagement.BorrowerEmploymentInformations.Dto;

namespace LoanManagement.LoanApplications
{
    public class LoanAppService : ILoanAppService
    {
        private readonly IRepository<MortgageType, long> _mortgageTypeRepository;
        private readonly IRepository<PropertyInformation, long> _propertyInformationRepository;
        private readonly IRepository<BorrowerInformation, long> _borrowerInformationRepository;
        private readonly IRepository<BorrowerEmploymentInformation, long> _borrowerEmploymentInformationRepository;
        //private readonly IRepository<AssetAndLiablity, long> _mortgageTypeRepository;
        // private readonly IRepository<DetailsOfTransaction, long> _mortgageTypeRepository;

        public LoanAppService(IRepository<MortgageType, long> mortgageTypeRepository,
            IRepository<PropertyInformation, long> propertyInformationRepository,
            IRepository<BorrowerInformation, long> borrowerInformationRepository,
            IRepository<BorrowerEmploymentInformation, long> borrowerEmploymentInformationRepository
            )
        {
            _mortgageTypeRepository = mortgageTypeRepository;
            _propertyInformationRepository = propertyInformationRepository;
            _borrowerInformationRepository = borrowerInformationRepository;
            _borrowerEmploymentInformationRepository = borrowerEmploymentInformationRepository;
        }
        public Task<LoanApplicationDto> GetAsync(EntityDto<int> input)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResultDto<LoanApplicationDto>> GetAllAsync(PagedLoanApplicationResultRequestDto input)
        {
            throw new NotImplementedException();
        }

        public async Task<LoanApplicationDto> CreateAsync(LoanApplicationDto input)
        {
            if (input.MortgageType != null)
            {


            }

            if (input.PropertyInformation != null)
            {

            }

            if (input.BorrowerInformation != null)
            {

            }
            if (input.CoBorrowerInformation != null)
            {

            }

            //BorrowerEmploymentInfromation
            if (input.BorrowerEmploymentInfromation != null)
            {
                if (input.BorrowerEmploymentInfromation.Id == 0)
                {
                     await CreateBorrowerEmploymentInformationAsync(input.BorrowerEmploymentInfromation);
                }
                else
                {
                    await UpdateBorrowerEmploymentInformationAsync(input.BorrowerEmploymentInfromation);
                }
            }

            if (input.CoBorrowerEmploymentInfromation != null)
            {

            }

            throw new NotImplementedException();
        }

        private async Task<ResponseMessagesDto> UpdateBorrowerEmploymentInformationAsync(CreateOrUpdateBorrowerEmploymentInformationDto input)
        {
            return null;
        }

        private async Task<ResponseMessagesDto> CreateBorrowerEmploymentInformationAsync(CreateOrUpdateBorrowerEmploymentInformationDto input)
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

        public Task<LoanApplicationDto> UpdateAsync(LoanApplicationDto input)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(EntityDto<int> input)
        {
            throw new NotImplementedException();
        }
    }
}
