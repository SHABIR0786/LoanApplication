﻿using Abp;
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
    public class LoanAppService : AbpServiceBase, ILoanAppService
    {
        private readonly IRepository<LoanApplication, long> _repository;
        private readonly ILoanDetailServices _loanDetailServices;
        private readonly IAdditionalDetailsService _additionalDetailsService;
        private readonly IExpensesService _expensesService;
        private readonly IEConsentService _eConsentService;
        private readonly ICreditAuthAgreementService _creditAuthAgreementService;
        private readonly IEmploymentIncomeService _employmentIncomeService;
        private readonly IPersonalDetailService _personalDetailService;

        public LoanAppService(
            IRepository<LoanApplication, long> repository,
        ILoanDetailServices loanDetailServices,
        IAdditionalDetailsService additionalDetailsService,
        IExpensesService expensesService,
        IEConsentService eConsentService,
        ICreditAuthAgreementService creditAuthAgreementService,
        IEmploymentIncomeService employmentIncomeService,
        IPersonalDetailService personalDetailService
            )
        {
            _repository = repository;
            _loanDetailServices = loanDetailServices;
            _additionalDetailsService = additionalDetailsService;
            _expensesService = expensesService;
            _eConsentService = eConsentService;
            _creditAuthAgreementService = creditAuthAgreementService;
            _employmentIncomeService = employmentIncomeService;
            _personalDetailService = personalDetailService;
        }

        public async Task<LoanApplicationDto> GetAsync(EntityDto<long> input)
        {
            try
            {
                var result = await _repository.GetAllIncluding()
                    .FirstOrDefaultAsync(i => i.Id == input.Id);

                return ObjectMapper.Map<LoanApplicationDto>(result);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Task<PagedResultDto<LoanApplicationDto>> GetAllAsync(PagedLoanApplicationResultRequestDto input)
        {
            throw new NotImplementedException();
        }

        public async Task<LoanApplicationDto> CreateAsync(LoanApplicationDto input)
        {
            try
            {
                var loanApplication = new LoanApplication();
                await _repository.InsertAsync(loanApplication);
                await UnitOfWorkManager.Current.SaveChangesAsync();

                input.Id = loanApplication.Id;
                return input;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<LoanApplicationDto> UpdateAsync(LoanApplicationDto input)
        {
            await _repository.UpdateAsync(input.Id, loanApplication =>
            {
                if (input.LoanDetail != null)
                {
                    if (input.LoanDetail.Id == default)
                         _loanDetailServices.CreateAsync(input.LoanDetail);
                    else
                        _loanDetailServices.UpdateAsync(input.LoanDetail);
                }

                if (input.PersonalInformation != null)
                {
                    if (input.PersonalInformation.Id == default)
                        _personalDetailService.CreateAsync(input.PersonalInformation);
                    else
                        _personalDetailService.UpdateAsync(input.PersonalInformation);
                }

                if (input.AdditionalDetails != null)
                {
                    if (input.PersonalInformation.Id == default)
                        _additionalDetailsService.CreateAsync(input.AdditionalDetails);
                    else
                        _additionalDetailsService.UpdateAsync(input.AdditionalDetails);
                }

                if (input.Expenses != null)
                {
                    if (input.Expenses.Id == default)
                        _expensesService.CreateAsync(input.Expenses);
                    else
                        _expensesService.UpdateAsync(input.Expenses);
                }

                if (input.EConsent != null)
                {
                    if (input.EConsent.Id == default)
                        _eConsentService.CreateAsync(input.EConsent);
                    else
                        _eConsentService.UpdateAsync(input.EConsent);
                }

                if (input.CreditAuthAgreement != null)
                {
                    if (input.CreditAuthAgreement.Id == default)
                        _creditAuthAgreementService.CreateAsync(input.CreditAuthAgreement);
                    else
                        _creditAuthAgreementService.UpdateAsync(input.CreditAuthAgreement);
                }

                if (input.EmploymentIncome != null)
                {
                    if (input.EmploymentIncome.Id == default)
                        _employmentIncomeService.CreateAsync(input.EmploymentIncome);
                    else
                        _employmentIncomeService.UpdateAsync(input.EmploymentIncome);
                }
                return Task.CompletedTask;
            });

            await UnitOfWorkManager.Current.SaveChangesAsync();
            return input;
        }

        public Task DeleteAsync(EntityDto<long> input)
        {
            throw new NotImplementedException();
        }
    }
}
