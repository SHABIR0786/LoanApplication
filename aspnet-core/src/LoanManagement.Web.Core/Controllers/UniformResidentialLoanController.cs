using LoanManagement.LoanApplications;
using LoanManagement.LoanApplications.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LoanManagement.Controllers
{
    [Route("api/[controller]/[action]")]
    public class UniformResidentialLoanController : LoanManagementControllerBase
    {
        private readonly ILoanAppService _loanAppService;

        public UniformResidentialLoanController(ILoanAppService loanAppService)
        {
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

            return Json(await _loanAppService.UpdateAsync(input));
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
