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
        private readonly ILoanDetailServices _loanDetailServices;

        public UniformResidentialLoanController(
            IBorrowerEmploymentInformationAppService borrowerEmploymentInformationAppService,
            ILoanAppService loanAppService,

            ILoanDetailServices loanDetailServices
        )
        {
            _borrowerEmploymentInformationAppService = borrowerEmploymentInformationAppService;
            _loanAppService = loanAppService;
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
