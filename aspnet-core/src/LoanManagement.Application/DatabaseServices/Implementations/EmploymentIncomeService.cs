using Abp;
using Abp.Application.Services.Dto;
using LoanManagement.DatabaseServices.Interfaces;
using LoanManagement.ViewModels;
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

        public Task<EmploymentIncomeDto> GetAsync(EntityDto<long?> input)
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
                    input.BorrowerMonthlyIncome.LoanApplicationId = input.LoanApplicationId;
                    if (input.BorrowerMonthlyIncome.Id == default)
                    {
                        await _borrowerMonthlyIncomeRepository.CreateAsync(input.BorrowerMonthlyIncome);
                    }
                    else
                        await _borrowerMonthlyIncomeRepository.UpdateAsync(input.BorrowerMonthlyIncome);
                }
                #endregion

                #region Co-Borrower Monthly Income
                if (input.CoBorrowerMonthlyIncome != null)
                {
                    input.CoBorrowerMonthlyIncome.LoanApplicationId = input.LoanApplicationId;
                    if (input.CoBorrowerMonthlyIncome.Id == default)
                        await _borrowerMonthlyIncomeRepository.CreateAsync(input.CoBorrowerMonthlyIncome);
                    else
                        await _borrowerMonthlyIncomeRepository.UpdateAsync(input.CoBorrowerMonthlyIncome);
                }
                #endregion

                #region Employment Information

                foreach (var borrowerEmploymentInfo in input.BorrowerEmploymentInfo)
                {
                    borrowerEmploymentInfo.LoanApplicationId = input.LoanApplicationId;
                    if (borrowerEmploymentInfo.Id == default)
                        await _borrowerEmploymentInformationRepository.CreateAsync(borrowerEmploymentInfo);
                    else
                        await _borrowerEmploymentInformationRepository.UpdateAsync(borrowerEmploymentInfo);
                }

                #endregion

                return input;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Task<EmploymentIncomeDto> UpdateAsync(EmploymentIncomeDto input)
        {
            return null;
        }

        public Task DeleteAsync(EntityDto<long?> input)
        {
            throw new NotImplementedException();
        }
    }
}
