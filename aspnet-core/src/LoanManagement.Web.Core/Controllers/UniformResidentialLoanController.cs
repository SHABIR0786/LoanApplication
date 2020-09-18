using LoanManagement.DatabaseServices.Interfaces;
using LoanManagement.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LoanManagement.Controllers
{
    [Route("api/[controller]/[action]")]
    public class UniformResidentialLoanController : LoanManagementControllerBase
    {
        private readonly ILoanAppService _loanAppService;
        private readonly IMortageService _mortageService;
        private readonly IPropertyInformationService _propertyInformationService;
        private readonly IBorrowerInformationAppService _borrowerInformationAppService;
        private readonly IAssetAndLiablityService _assetAndLiablityService;
        private readonly IDetailOfTransactionService _detailOfTransactionService;

        public UniformResidentialLoanController(
            IBorrowerEmploymentInformationAppService borrowerEmploymentInformationAppService,
            ILoanAppService loanAppService,
            IMortageService mortageService,
            IPropertyInformationService propertyInformationService,
            IBorrowerInformationAppService borrowerInformationAppService,
            IAssetAndLiablityService assetAndLiablityService,
            IDetailOfTransactionService detailOfTransactionService)
        {
            _loanAppService = loanAppService;
            _mortageService = mortageService;
            _propertyInformationService = propertyInformationService;
            _borrowerInformationAppService = borrowerInformationAppService;
            _assetAndLiablityService = assetAndLiablityService;
            _detailOfTransactionService = detailOfTransactionService;
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

            if (input.BorrowerEmploymentInfromation != null)
                await _borrowerEmploymentInformationAppService.CreateOrUpdateAsync(input.BorrowerEmploymentInfromation);

            if (input.BorrowerEmploymentInfromation != null)
                await _borrowerEmploymentInformationAppService.CreateOrUpdateAsync(input.BorrowerEmploymentInfromation);

            if (input.PropertyInformation != null)
                if (input.PropertyInformation.Id == default)
                    await _propertyInformationService.CreateAsync(input.PropertyInformation);
                else
                    await _propertyInformationService.UpdateAsync(input.PropertyInformation);

            if (input.BorrowerInformation != null)
                await _borrowerInformationAppService.CreateOrUpdateAsync(input.BorrowerInformation);

            if (input.CoBorrowerInformation != null)
                await _borrowerInformationAppService.CreateOrUpdateAsync(input.CoBorrowerInformation);

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

            await _loanAppService.UpdateAsync(input);

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] long id)
        {
            if (id == null)
                return BadRequest(ModelState);

            return Json(await _loanAppService.GetAsync(new Abp.Application.Services.Dto.EntityDto<long>(id)));
        }
    }
}
