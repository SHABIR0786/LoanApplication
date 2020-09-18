using LoanManagement.BorrowerEmploymentInformations;
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

        public UniformResidentialLoanController(IBorrowerEmploymentInformationAppService borrowerEmploymentInformationAppService, ILoanAppService loanAppService)
        {
            _borrowerEmploymentInformationAppService = borrowerEmploymentInformationAppService;
            _loanAppService = loanAppService;
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

            if (input.BorrowerEmploymentInfromation != null)
            {
                responseMessage = await _borrowerEmploymentInformationAppService.CreateOrUpdateAsync(input.BorrowerEmploymentInfromation);
                if (responseMessage.Error)
                    return BadRequest(responseMessage);
            }

            await _loanAppService.UpdateAsync(input);

            return Json(responseMessage);
        }
    }
}
