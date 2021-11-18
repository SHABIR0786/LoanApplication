using Abp;
using Abp.Application.Services.Dto;
using LoanManagement.DatabaseServices.Interfaces;
using LoanManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanManagement.DatabaseServices.Implementations
{
    public class EmploymentIncomeService : AbpServiceBase, IEmploymentIncomeService
    {
        private readonly IBorrowerEmploymentInformationAppService _borrowerEmploymentInformationRepository;
        private readonly IBorrowerMonthlyIncomeServices _borrowerMonthlyIncomeRepository;
        private readonly IAdditionalIncomeService _additionalIncomeService;

        public EmploymentIncomeService(
            IBorrowerEmploymentInformationAppService borrowerEmploymentInformationRepository,
            IBorrowerMonthlyIncomeServices borrowerMonthlyIncomeRepository,
            IAdditionalIncomeService additionalIncomeService
            )
        {
            _borrowerEmploymentInformationRepository = borrowerEmploymentInformationRepository;
            _borrowerMonthlyIncomeRepository = borrowerMonthlyIncomeRepository;
            _additionalIncomeService = additionalIncomeService;
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
                if (input.BorrowerMonthlyIncome != null && !input.BorrowerMonthlyIncome.IsNull())
                {
                    input.BorrowerMonthlyIncome.LoanApplicationId = input.LoanApplicationId;
                    if (!input.BorrowerMonthlyIncome.Id.HasValue || input.BorrowerMonthlyIncome.Id.Value == default)
                    {
                        await _borrowerMonthlyIncomeRepository.CreateAsync(input.BorrowerMonthlyIncome);
                    }
                    else
                        await _borrowerMonthlyIncomeRepository.UpdateAsync(input.BorrowerMonthlyIncome);
                }
                #endregion

                #region Co-Borrower Monthly Income
                if (input.CoBorrowerMonthlyIncome != null && !input.CoBorrowerMonthlyIncome.IsNull())
                {
                    input.CoBorrowerMonthlyIncome.LoanApplicationId = input.LoanApplicationId;
                    if (!input.CoBorrowerMonthlyIncome.Id.HasValue || input.CoBorrowerMonthlyIncome.Id.Value == default)
                        await _borrowerMonthlyIncomeRepository.CreateAsync(input.CoBorrowerMonthlyIncome);
                    else
                        await _borrowerMonthlyIncomeRepository.UpdateAsync(input.CoBorrowerMonthlyIncome);
                }
                #endregion

                #region Employment Information

                if (input.BorrowerEmploymentInfo != null && input.BorrowerEmploymentInfo.Any())
                    foreach (var borrowerEmploymentInfo in input.BorrowerEmploymentInfo.Where(i =>
                    !string.IsNullOrEmpty(i.Address1) ||
                    !string.IsNullOrEmpty(i.Address2) ||
                    !string.IsNullOrEmpty(i.EmployerName) ||
                    i.EndDate.HasValue ||
                    i.IsSelfEmployed.HasValue ||
                    !string.IsNullOrEmpty(i.Position) ||
                    i.StartDate.HasValue ||
                    i.ZipCode.HasValue))
                    {
                        borrowerEmploymentInfo.LoanApplicationId = input.LoanApplicationId;
                        if (!borrowerEmploymentInfo.Id.HasValue || borrowerEmploymentInfo.Id.Value == default)
                        {
                            if (!borrowerEmploymentInfo.IsNull())
                                await _borrowerEmploymentInformationRepository.CreateAsync(borrowerEmploymentInfo);
                        }
                        else
                            await _borrowerEmploymentInformationRepository.UpdateAsync(borrowerEmploymentInfo);
                    }

                if (input.CoBorrowerEmploymentInfo != null && input.CoBorrowerEmploymentInfo.Any())
                    foreach (var borrowerEmploymentInfo in input.CoBorrowerEmploymentInfo.Where(i =>
                    !string.IsNullOrEmpty(i.Address1) ||
                    !string.IsNullOrEmpty(i.Address2) ||
                    !string.IsNullOrEmpty(i.EmployerName) ||
                    i.EndDate.HasValue ||
                    i.IsSelfEmployed.HasValue ||
                    !string.IsNullOrEmpty(i.Position) ||
                    i.StartDate.HasValue ||
                    i.ZipCode.HasValue))
                    {
                        borrowerEmploymentInfo.LoanApplicationId = input.LoanApplicationId;
                        if (!borrowerEmploymentInfo.Id.HasValue || borrowerEmploymentInfo.Id.Value == default)
                        {
                            if (!borrowerEmploymentInfo.IsNull())
                                await _borrowerEmploymentInformationRepository.CreateAsync(borrowerEmploymentInfo);
                        }
                        else
                            await _borrowerEmploymentInformationRepository.UpdateAsync(borrowerEmploymentInfo);
                    }

                #endregion

                if (input.AdditionalIncomes != null && input.AdditionalIncomes.Any())
                {
                    foreach (var additionalIncome in input.AdditionalIncomes.Where(i => i.Amount.HasValue || (i.IncomeSourceId.HasValue && i.IncomeSourceId.Value != 0)))
                    {
                        additionalIncome.LoanApplicationId = input.LoanApplicationId.Value;
                        if (!additionalIncome.Id.HasValue || additionalIncome.Id.Value == default)
                        {
                            if (!additionalIncome.IsNull())
                                await _additionalIncomeService.CreateAsync(additionalIncome);
                        }
                        else
                            await _additionalIncomeService.UpdateAsync(additionalIncome);
                    }
                }

                return input;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<EmploymentIncomeDto> UpdateAsync(EmploymentIncomeDto input)
        {
            try
            {
                #region Borrower Monthly Income
                if (input.BorrowerMonthlyIncome != null && !input.BorrowerMonthlyIncome.IsNull())
                {
                    input.BorrowerMonthlyIncome.LoanApplicationId = input.LoanApplicationId;
                    if (input.BorrowerMonthlyIncome.Id.HasValue)
                    {
                        await _borrowerMonthlyIncomeRepository.UpdateAsync(input.BorrowerMonthlyIncome);
                    }
                        
                }
                #endregion

                #region Co-Borrower Monthly Income
                if (input.CoBorrowerMonthlyIncome != null && !input.CoBorrowerMonthlyIncome.IsNull())
                {
                    input.CoBorrowerMonthlyIncome.LoanApplicationId = input.LoanApplicationId;
                    if (input.CoBorrowerMonthlyIncome.Id.HasValue)
                    {
                        await _borrowerMonthlyIncomeRepository.UpdateAsync(input.CoBorrowerMonthlyIncome);
                    }
             
                }
                #endregion

                #region Employment Information

                if (input.BorrowerEmploymentInfo != null && input.BorrowerEmploymentInfo.Any())
                    foreach (var borrowerEmploymentInfo in input.BorrowerEmploymentInfo.Where(i =>
                    !string.IsNullOrEmpty(i.Address1) ||
                    !string.IsNullOrEmpty(i.Address2) ||
                    !string.IsNullOrEmpty(i.EmployerName) ||
                    i.EndDate.HasValue ||
                    i.IsSelfEmployed.HasValue ||
                    !string.IsNullOrEmpty(i.Position) ||
                    i.StartDate.HasValue ||
                    i.ZipCode.HasValue))
                    {
                        borrowerEmploymentInfo.LoanApplicationId = input.LoanApplicationId;
                        if (!borrowerEmploymentInfo.Id.HasValue || borrowerEmploymentInfo.Id.Value == default)
                        {
                            if (!borrowerEmploymentInfo.IsNull())
                                await _borrowerEmploymentInformationRepository.CreateAsync(borrowerEmploymentInfo);
                        }
                        else
                            await _borrowerEmploymentInformationRepository.UpdateAsync(borrowerEmploymentInfo);
                    }

                if (input.CoBorrowerEmploymentInfo != null && input.CoBorrowerEmploymentInfo.Any())
                    foreach (var borrowerEmploymentInfo in input.CoBorrowerEmploymentInfo.Where(i =>
                    !string.IsNullOrEmpty(i.Address1) ||
                    !string.IsNullOrEmpty(i.Address2) ||
                    !string.IsNullOrEmpty(i.EmployerName) ||
                    i.EndDate.HasValue ||
                    i.IsSelfEmployed.HasValue ||
                    !string.IsNullOrEmpty(i.Position) ||
                    i.StartDate.HasValue ||
                    i.ZipCode.HasValue))
                    {
                        borrowerEmploymentInfo.LoanApplicationId = input.LoanApplicationId;
                        if (borrowerEmploymentInfo.Id.HasValue)
                        {
                            await _borrowerEmploymentInformationRepository.UpdateAsync(borrowerEmploymentInfo);
                        }
                    }

                #endregion

                if (input.AdditionalIncomes != null && input.AdditionalIncomes.Any())
                {
                    foreach (var additionalIncome in input.AdditionalIncomes.Where(i => i.Amount.HasValue || (i.IncomeSourceId.HasValue && i.IncomeSourceId.Value != 0)))
                    {
                        additionalIncome.LoanApplicationId = input.LoanApplicationId.Value;
                        if (additionalIncome.Id.HasValue)
                        {
                            await _additionalIncomeService.UpdateAsync(additionalIncome);
                        }
                    }
                }

                return input;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public Task DeleteAsync(EntityDto<long?> input)
        {
            throw new NotImplementedException();
        }
    }
}
