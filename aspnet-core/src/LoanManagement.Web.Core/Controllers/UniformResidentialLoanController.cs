using LoanManagement.DatabaseServices.Interfaces;
using LoanManagement.Enums;
using LoanManagement.ViewModels;
using Microsoft.AspNetCore.Mvc;
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

        public UniformResidentialLoanController(
            IBorrowerEmploymentInformationAppService borrowerEmploymentInformationAppService,
            ILoanAppService loanAppService,
            IMortageService mortageService,
            IPropertyInformationService propertyInformationService,
            IBorrowerInformationAppService borrowerInformationAppService,
            IAssetAndLiablityService assetAndLiablityService,
            IDetailOfTransactionService detailOfTransactionService,
            IGrossMonthlyIncomeService grossMonthlyIncomeService,
            ICombinedMonthlyHousingExpenseService combinedMonthlyHousingExpenseService)
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
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] LoanApplicationDto input)
        {
            if (input == null || !ModelState.IsValid)
                return BadRequest(ModelState);

            var responseMessage = new ResponseMessagesDto();

            if (input.Id == default)
            {
                await _loanAppService.CreateAsync(input);
            }

            if (input.MortgageType != null)
                if (input.MortgageType.Id == default)
                    await _mortageService.CreateAsync(input.MortgageType);
                else
                    await _mortageService.UpdateAsync(input.MortgageType);

            if (input.BorrowerEmploymentInformation1 != null)
            {
                input.BorrowerEmploymentInformation1.BorrowerTypeId = (int)BorrowerType.Borrower;
                await _borrowerEmploymentInformationAppService.CreateOrUpdateAsync(input.BorrowerEmploymentInformation1);
            }

            if (input.BorrowerEmploymentInformation2 != null)
            {
                input.BorrowerEmploymentInformation1.BorrowerTypeId = (int)BorrowerType.Borrower;
                await _borrowerEmploymentInformationAppService.CreateOrUpdateAsync(input.BorrowerEmploymentInformation2);
            }

            if (input.BorrowerEmploymentInformation3 != null)
            {
                input.BorrowerEmploymentInformation1.BorrowerTypeId = (int)BorrowerType.Borrower;
                await _borrowerEmploymentInformationAppService.CreateOrUpdateAsync(input.BorrowerEmploymentInformation3);
            }

            if (input.CoBorrowerEmploymentInformation1 != null)
            {
                input.BorrowerEmploymentInformation1.BorrowerTypeId = (int)BorrowerType.CoBorrower;
                await _borrowerEmploymentInformationAppService.CreateOrUpdateAsync(input.CoBorrowerEmploymentInformation1);
            }

            if (input.CoBorrowerEmploymentInformation2 != null)
            {
                input.BorrowerEmploymentInformation1.BorrowerTypeId = (int)BorrowerType.CoBorrower;
                await _borrowerEmploymentInformationAppService.CreateOrUpdateAsync(input.CoBorrowerEmploymentInformation2);
            }

            if (input.CoBorrowerEmploymentInformation3 != null)
            {
                input.BorrowerEmploymentInformation1.BorrowerTypeId = (int)BorrowerType.CoBorrower;
                await _borrowerEmploymentInformationAppService.CreateOrUpdateAsync(input.CoBorrowerEmploymentInformation3);
            }

            if (input.PropertyInformation != null)
                if (input.PropertyInformation.Id == default)
                    await _propertyInformationService.CreateAsync(input.PropertyInformation);
                else
                    await _propertyInformationService.UpdateAsync(input.PropertyInformation);

            if (input.BorrowerInformation != null)
            {
                input.BorrowerEmploymentInformation1.BorrowerTypeId = (int)BorrowerType.Borrower;
                await _borrowerInformationAppService.CreateOrUpdateAsync(input.BorrowerInformation);
            }

            if (input.CoBorrowerInformation != null)
            {
                input.BorrowerEmploymentInformation1.BorrowerTypeId = (int)BorrowerType.CoBorrower;
                await _borrowerInformationAppService.CreateOrUpdateAsync(input.CoBorrowerInformation);
            }

            if (input.AssetAndLiablity != null)
            {
                if (input.AssetAndLiablity.Id == default)
                    await _assetAndLiablityService.CreateAsync(input.AssetAndLiablity);
                else
                    await _assetAndLiablityService.UpdateAsync(input.AssetAndLiablity);
            }

            if (input.DetailsOfTransaction != null)
                if (input.DetailsOfTransaction.Id == default)
                    await _detailOfTransactionService.CreateAsync(input.DetailsOfTransaction);
                else
                    await _detailOfTransactionService.UpdateAsync(input.DetailsOfTransaction);

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
                input.GrossMonthlyIncomeCoBorrower.BorrowerTypeId = (int)BorrowerType.Borrower;
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

            await _loanAppService.UpdateAsync(input);

            return Ok();
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
