using LoanManagement.DatabaseServices.Interfaces;
using LoanManagement.Enums;
using LoanManagement.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace LoanManagement.Controllers
{
    [Route("api/[controller]/[action]")]
    public class UniformResidentialLoanController : LoanManagementControllerBase
    {
        private readonly IBorrowerEmploymentInformationAppService _borrowerEmploymentInformationAppService;
        private readonly ILoanAppService _loanAppService;
        private readonly IMortageService _mortageService;
        private readonly IPropertyInformationService _propertyInformationService;
        private readonly IBorrowerInformationAppService _borrowerInformationAppService;
        private readonly IAssetAndLiablityService _assetAndLiablityService;
        private readonly IDetailOfTransactionService _detailOfTransactionService;
        private readonly IGrossMonthlyIncomeService _grossMonthlyIncomeService;
        private readonly ICombinedMonthlyHousingExpenseService _combinedMonthlyHousingExpenseService;
        private readonly IOtherIncomeService _otherIncomeService;
        private readonly ILoanDetailServices _loanDetailServices;

        public UniformResidentialLoanController(
            IBorrowerEmploymentInformationAppService borrowerEmploymentInformationAppService,
            ILoanAppService loanAppService,
            IMortageService mortageService,
            IPropertyInformationService propertyInformationService,
            IBorrowerInformationAppService borrowerInformationAppService,
            IAssetAndLiablityService assetAndLiablityService,
            IDetailOfTransactionService detailOfTransactionService,
            IGrossMonthlyIncomeService grossMonthlyIncomeService,
            ICombinedMonthlyHousingExpenseService combinedMonthlyHousingExpenseService,
            IOtherIncomeService otherIncomeService,

            ILoanDetailServices loanDetailServices
        )
        {
            _borrowerEmploymentInformationAppService = borrowerEmploymentInformationAppService;
            _loanAppService = loanAppService;
            _mortageService = mortageService;
            _propertyInformationService = propertyInformationService;
            _borrowerInformationAppService = borrowerInformationAppService;
            _assetAndLiablityService = assetAndLiablityService;
            _detailOfTransactionService = detailOfTransactionService;
            _grossMonthlyIncomeService = grossMonthlyIncomeService;
            _combinedMonthlyHousingExpenseService = combinedMonthlyHousingExpenseService;
            _otherIncomeService = otherIncomeService;
            _loanDetailServices = loanDetailServices;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] LoanApplicationDto input)
        {
            try
            {
                if (input == null || !ModelState.IsValid)
                    return BadRequest(ModelState);

                if (input.Id == default)
                {
                    await _loanAppService.CreateAsync(input);
                }

                if (input.LoanDetails != null)
                {
                    if (input.LoanDetails.Id == default)
                        await _loanDetailServices.CreateAsync(input.LoanDetails);
                    else
                        await _loanDetailServices.UpdateAsync(input.LoanDetails);
                }

                if (input.MortgageType != null)
                {
                    if (input.MortgageType.Id == default)
                        await _mortageService.CreateAsync(input.MortgageType);
                    else
                        await _mortageService.UpdateAsync(input.MortgageType);
                }

                if (input.PropertyInformation != null)
                {
                    if (input.PropertyInformation.Id == default)
                        await _propertyInformationService.CreateAsync(input.PropertyInformation);
                    else
                        await _propertyInformationService.UpdateAsync(input.PropertyInformation);
                }

                if (input.BorrowerInformation != null)
                {
                    input.BorrowerInformation.BorrowerTypeId = (int)BorrowerType.Borrower;
                    if (input.BorrowerInformation.Id == default)
                        await _borrowerInformationAppService.CreateAsync(input.BorrowerInformation);
                    else
                        await _borrowerInformationAppService.UpdateAsync(input.BorrowerInformation);
                }

                if (input.CoBorrowerInformation != null)
                {
                    input.CoBorrowerInformation.BorrowerTypeId = (int)BorrowerType.CoBorrower;
                    if (input.CoBorrowerInformation.Id == default)
                        await _borrowerInformationAppService.CreateAsync(input.CoBorrowerInformation);
                    else
                        await _borrowerInformationAppService.UpdateAsync(input.CoBorrowerInformation);
                }

                // Borrower Employment Information Start
                if (input.BorrowerEmploymentInformation1 != null)
                {
                    input.BorrowerEmploymentInformation1.BorrowerTypeId = (int)BorrowerType.Borrower;
                    if (input.BorrowerEmploymentInformation1.Id == default)
                        await _borrowerEmploymentInformationAppService.CreateAsync(input.BorrowerEmploymentInformation1);
                    else
                        await _borrowerEmploymentInformationAppService.UpdateAsync(input.BorrowerEmploymentInformation1);
                }

                if (input.BorrowerEmploymentInformation2 != null)
                {
                    input.BorrowerEmploymentInformation2.BorrowerTypeId = (int)BorrowerType.Borrower;
                    if (input.BorrowerEmploymentInformation2.Id == default)
                        await _borrowerEmploymentInformationAppService.CreateAsync(input.BorrowerEmploymentInformation2);
                    else
                        await _borrowerEmploymentInformationAppService.UpdateAsync(input.BorrowerEmploymentInformation2);
                }

                if (input.BorrowerEmploymentInformation3 != null)
                {
                    input.BorrowerEmploymentInformation3.BorrowerTypeId = (int)BorrowerType.Borrower;
                    if (input.BorrowerEmploymentInformation3.Id == default)
                        await _borrowerEmploymentInformationAppService.CreateAsync(input.BorrowerEmploymentInformation3);
                    else
                        await _borrowerEmploymentInformationAppService.UpdateAsync(input.BorrowerEmploymentInformation3);
                }


                if (input.CoBorrowerEmploymentInformation1 != null)
                {
                    input.CoBorrowerEmploymentInformation1.BorrowerTypeId = (int)BorrowerType.CoBorrower;
                    if (input.CoBorrowerEmploymentInformation1.Id == default)
                        await _borrowerEmploymentInformationAppService.CreateAsync(input.CoBorrowerEmploymentInformation1);
                    else
                        await _borrowerEmploymentInformationAppService.UpdateAsync(input.CoBorrowerEmploymentInformation1);
                }

                if (input.CoBorrowerEmploymentInformation2 != null)
                {
                    input.CoBorrowerEmploymentInformation2.BorrowerTypeId = (int)BorrowerType.CoBorrower;
                    if (input.CoBorrowerEmploymentInformation2.Id == default)
                        await _borrowerEmploymentInformationAppService.CreateAsync(input.CoBorrowerEmploymentInformation2);
                    else
                        await _borrowerEmploymentInformationAppService.UpdateAsync(input.CoBorrowerEmploymentInformation2);
                }

                if (input.CoBorrowerEmploymentInformation3 != null)
                {
                    input.CoBorrowerEmploymentInformation3.BorrowerTypeId = (int)BorrowerType.CoBorrower;
                    if (input.CoBorrowerEmploymentInformation3.Id == default)
                        await _borrowerEmploymentInformationAppService.CreateAsync(input.CoBorrowerEmploymentInformation3);
                    else
                        await _borrowerEmploymentInformationAppService.UpdateAsync(input.CoBorrowerEmploymentInformation3);
                }
                // Borrower Employment Information End


                if (input.AssetAndLiability != null)
                {
                    if (input.AssetAndLiability.Id == default)
                        await _assetAndLiablityService.CreateAsync(input.AssetAndLiability);
                    else
                        await _assetAndLiablityService.UpdateAsync(input.AssetAndLiability);
                }

                if (input.DetailsOfTransaction != null)
                {
                    if (input.DetailsOfTransaction.Id == default)
                        await _detailOfTransactionService.CreateAsync(input.DetailsOfTransaction);
                    else
                        await _detailOfTransactionService.UpdateAsync(input.DetailsOfTransaction);
                }

                if (input.GrossMonthlyIncomeBorrower != null)
                {
                    input.GrossMonthlyIncomeBorrower.BorrowerTypeId = (int)BorrowerType.Borrower;
                    input.GrossMonthlyIncomeBorrower.LoanApplicationId = input.Id;
                    if (input.GrossMonthlyIncomeBorrower.Id == default)
                        await _grossMonthlyIncomeService.CreateAsync(input.GrossMonthlyIncomeBorrower);
                    else
                        await _grossMonthlyIncomeService.UpdateAsync(input.GrossMonthlyIncomeBorrower);
                }

                if (input.GrossMonthlyIncomeCoBorrower != null)
                {
                    input.GrossMonthlyIncomeCoBorrower.BorrowerTypeId = (int)BorrowerType.CoBorrower;
                    input.GrossMonthlyIncomeCoBorrower.LoanApplicationId = input.Id;
                    if (input.GrossMonthlyIncomeCoBorrower.Id == default)
                        await _grossMonthlyIncomeService.CreateAsync(input.GrossMonthlyIncomeCoBorrower);
                    else
                        await _grossMonthlyIncomeService.UpdateAsync(input.GrossMonthlyIncomeCoBorrower);
                }

                if (input.CombinedMonthlyHousingExpensePresent != null)
                {
                    input.CombinedMonthlyHousingExpensePresent.HousingExpenseTypeId = (int)HousingExpenseType.Present;
                    input.CombinedMonthlyHousingExpensePresent.LoanApplicationId = input.Id;
                    if (input.CombinedMonthlyHousingExpensePresent.Id == default)
                        await _combinedMonthlyHousingExpenseService.CreateAsync(input.CombinedMonthlyHousingExpensePresent);
                    else
                        await _combinedMonthlyHousingExpenseService.UpdateAsync(input.CombinedMonthlyHousingExpensePresent);
                }

                if (input.CombinedMonthlyHousingExpenseProposed != null)
                {
                    input.CombinedMonthlyHousingExpenseProposed.HousingExpenseTypeId = (int)HousingExpenseType.Proposed;
                    input.CombinedMonthlyHousingExpenseProposed.LoanApplicationId = input.Id;
                    if (input.CombinedMonthlyHousingExpenseProposed.Id == default)
                        await _combinedMonthlyHousingExpenseService.CreateAsync(input.CombinedMonthlyHousingExpenseProposed);
                    else
                        await _combinedMonthlyHousingExpenseService.UpdateAsync(input.CombinedMonthlyHousingExpenseProposed);
                }

                if (input.OtherIncomes != null && input.OtherIncomes.Any())
                {
                    foreach (var otherIncome in input.OtherIncomes)
                    {
                        if (otherIncome.Id == default)
                            await _otherIncomeService.CreateAsync(otherIncome);
                        else
                            await _otherIncomeService.UpdateAsync(otherIncome);
                    }
                }

                await _loanAppService.UpdateAsync(input);

                return Json(input);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] long? id)
        {
            if (!id.HasValue)
                return BadRequest(ModelState);

            return Json(await _loanAppService.GetAsync(new Abp.Application.Services.Dto.EntityDto<long>(id.Value)));
        }
    }
}
