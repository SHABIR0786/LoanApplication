using LoanManagement.BorrowerEmploymentInformations;
using LoanManagement.DatabaseServices.Interfaces;
using LoanManagement.LoanApplications;
using LoanManagement.LoanApplications.Dto;
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

        public UniformResidentialLoanController(
            IBorrowerEmploymentInformationAppService borrowerEmploymentInformationAppService,
            ILoanAppService loanAppService,
            IMortageService mortageService,
            IPropertyInformationService propertyInformationService)
        {
            _borrowerEmploymentInformationAppService = borrowerEmploymentInformationAppService;
            _loanAppService = loanAppService;
            _mortageService = mortageService;
            propertyInformationService = _propertyInformationService;
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
            {
                responseMessage = await _borrowerEmploymentInformationAppService.CreateOrUpdateAsync(input.BorrowerEmploymentInfromation);
                if (responseMessage.Error)
                    return BadRequest(responseMessage);
            }

            if (input.PropertyInformation != null)
                if (input.PropertyInformation.Id == default)
                    await _propertyInformationService.CreateAsync(input.PropertyInformation);
                else
                    await _propertyInformationService.UpdateAsync(input.PropertyInformation);

            await _loanAppService.UpdateAsync(input);

            return Json(responseMessage);
        }
    }
}
