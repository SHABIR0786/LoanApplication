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
    public class LoanAppService : AbpServiceBase, ILoanAppService
    {
        private readonly IRepository<LoanApplication, long> _repository;
        private readonly ILoanDetailServices _loanDetailServices;
        private readonly IAdditionalDetailService _additionalDetailsService;
        private readonly IExpenseService _expensesService;
        private readonly IEConsentService _eConsentService;
        private readonly ICreditAuthAgreementService _creditAuthAgreementService;
        private readonly IEmploymentIncomeService _employmentIncomeService;
        private readonly IPersonalDetailService _personalDetailService;
        private readonly IDeclarationService _declarationService;

        public LoanAppService(
            IRepository<LoanApplication, long> repository,
            ILoanDetailServices loanDetailServices,
            IAdditionalDetailService additionalDetailsService,
            IExpenseService expensesService,
            IEConsentService eConsentService,
            ICreditAuthAgreementService creditAuthAgreementService,
            IEmploymentIncomeService employmentIncomeService,
            IPersonalDetailService personalDetailService,
            IDeclarationService declarationService
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
            _declarationService = declarationService;
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
            await _repository.UpdateAsync(input.Id, async loanApplication =>
            {
                #region Loadn App
                if (input.Id == 0)
                {
                    var loanApplicationOb = new LoanApplication();
                    await _repository.InsertAsync(loanApplicationOb);
                    await UnitOfWorkManager.Current.SaveChangesAsync();
                    input.Id = loanApplication.Id;
                }
                #endregion
                #region Loan Detail
                if (input.LoanDetails != null)
                {
                    if (input.LoanDetails.Id == default)
                    {
                        input.LoanDetails = await _loanDetailServices.CreateAsync(input.LoanDetails);
                        loanApplication.LoanDetailId = input.LoanDetails.Id;
                    }
                    else
                        await _loanDetailServices.UpdateAsync(input.LoanDetails);
                }
                #endregion

                #region Personal Information
                if (input.PersonalInformation != null)
                {
                    if (input.PersonalInformation.Id == default)
                    {
                        input.PersonalInformation = await _personalDetailService.CreateAsync(input.PersonalInformation);
                        loanApplication.PersonalDetailId = input.PersonalInformation.Id;
                    }
                    else
                        await _personalDetailService.UpdateAsync(input.PersonalInformation);
                }
                #endregion

                #region Additional Details
                if (input.AdditionalDetails != null)
                {
                    if (input.AdditionalDetails.Id == default)
                    {
                        input.AdditionalDetails = await _additionalDetailsService.CreateAsync(input.AdditionalDetails);
                        loanApplication.AdditionalDetailsId = input.AdditionalDetails.Id;
                    }
                    else
                        await _additionalDetailsService.UpdateAsync(input.AdditionalDetails);
                }
                #endregion

                #region Expenses
                if (input.Expenses != null)
                {
                    if (input.Expenses.Id == default)
                    {
                        input.Expenses = await _expensesService.CreateAsync(input.Expenses);
                        loanApplication.ExpenseId = input.Expenses.Id;
                    }
                    else
                        await _expensesService.UpdateAsync(input.Expenses);
                }
                #endregion

                #region EConsent
                if (input.EConsent != null)
                {
                    if (input.EConsent.Id == default)
                    {
                        input.EConsent = await _eConsentService.CreateAsync(input.EConsent);
                        loanApplication.ConsentDetailId = input.EConsent.Id;
                    }
                    else
                        await _eConsentService.UpdateAsync(input.EConsent);
                }
                #endregion

                #region Credit AuthAgreement
                if (input.OrderCredit != null)
                {
                    if (input.OrderCredit.Id == default)
                    {
                        input.OrderCredit = await _creditAuthAgreementService.CreateAsync(input.OrderCredit);
                        loanApplication.CreditAuthAgreementId = input.OrderCredit.Id;
                    }
                    else
                        await _creditAuthAgreementService.UpdateAsync(input.OrderCredit);
                }
                #endregion

                #region Declaration
                if (input.Declaration != null)
                {
                    if (input.Declaration.Id == default)
                    {
                        input.Declaration = await _declarationService.CreateAsync(input.Declaration);
                        loanApplication.DeclarationId = input.Declaration.Id;
                    }
                    else
                        await _declarationService.UpdateAsync(input.Declaration);
                }
                #endregion

                #region Employment Income
                if (input.EmploymentIncome != null)
                {
                    input.EmploymentIncome.LoanApplicationId = input.Id;
                    input.EmploymentIncome = await _employmentIncomeService.CreateAsync(input.EmploymentIncome);
                }
                #endregion
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
