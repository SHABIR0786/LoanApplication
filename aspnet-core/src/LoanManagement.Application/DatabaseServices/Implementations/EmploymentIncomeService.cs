using Abp;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using LoanManagement.DatabaseServices.Interfaces;
using LoanManagement.Models;
using LoanManagement.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace LoanManagement.DatabaseServices.Implementations
{
    public class EmploymentIncomeService : AbpServiceBase, IEmploymentIncomeService
    {
        private readonly IBorrowerEmploymentInformationAppService _borrowerEmploymentInformationRepository;
        private readonly IBorrowerMonthlyIncomeServices _borrowerMonthlyIncomeRepository;

        public EmploymentIncomeService(
            IBorrowerEmploymentInformationAppService borrowerEmploymentInformationRepository,
            IBorrowerMonthlyIncomeServices borrowerMonthlyIncomeRepository
            )
        {
            _borrowerEmploymentInformationRepository = borrowerEmploymentInformationRepository;
            _borrowerMonthlyIncomeRepository = borrowerMonthlyIncomeRepository;
        }

        public async Task<EmploymentIncomeDto> GetAsync(EntityDto<long> input)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResultDto<EmploymentIncomeDto>> GetAllAsync(PagedLoanApplicationResultRequestDto input)
        {
            throw new NotImplementedException();
        }

        public async Task<EmploymentIncomeDto> CreateAsync(EmploymentIncomeDto input)
        {
            try
            {
                #region Borrower Monthly Income
                if (input.BorrowerMonthlyIncome != null)
                {
                    if (input.BorrowerMonthlyIncome.Id == default)
                        await _borrowerMonthlyIncomeRepository.CreateAsync(input.BorrowerMonthlyIncome);
                    else
                        await _borrowerMonthlyIncomeRepository.UpdateAsync(input.BorrowerMonthlyIncome);
                }
                #endregion
                #region Co-Borrower Monthly Income
                if (input.CoBorrowerMonthlyIncome != null)
                {
                    if (input.CoBorrowerMonthlyIncome.Id == default)
                        await _borrowerMonthlyIncomeRepository.CreateAsync(input.CoBorrowerMonthlyIncome);
                    else
                        await _borrowerMonthlyIncomeRepository.UpdateAsync(input.CoBorrowerMonthlyIncome);
                }
                #endregion
                #region Borrower Employment Information
                if (input.BorrowerEmploymentInformations != null)
                {
                    if (input.BorrowerEmploymentInformations.Id == default)
                        await _borrowerEmploymentInformationRepository.CreateAsync(input.BorrowerEmploymentInformations);
                    else
                        await _borrowerEmploymentInformationRepository.UpdateAsync(input.BorrowerEmploymentInformations);
                }
                #endregion

                #region Co-BorrowerEmploymentInformation
                if (input.CoBorrowerEmploymentInformations != null)
                {
                    if (input.CoBorrowerMonthlyIncome.Id == default)
                        await _borrowerEmploymentInformationRepository.CreateAsync(input.CoBorrowerEmploymentInformations);
                    else
                        await _borrowerEmploymentInformationRepository.UpdateAsync(input.CoBorrowerEmploymentInformations);
                }
                #region
                return input;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<EmploymentIncomeDto> UpdateAsync(EmploymentIncomeDto input)
        {
            //await _repository.UpdateAsync(input.Id, employmentIncome =>
            //{
            //    return Task.CompletedTask;
            //});

            //await UnitOfWorkManager.Current.SaveChangesAsync();
            return null;
        }

        public Task DeleteAsync(EntityDto<long> input)
        {
            throw new NotImplementedException();
        }
    }
}
