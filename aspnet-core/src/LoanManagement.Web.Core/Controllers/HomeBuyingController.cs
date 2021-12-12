using System;
using System.Collections.Generic;
using System.Text;
using Abp.Runtime.Validation;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using LoanManagement.Models;

namespace LoanManagement.Controllers
{
    [Route("api/[controller]/[action]")]
    public class HomeBuyingController : LoanManagementControllerBase
    {
        [DisableValidation]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] HomeBuying input)
        {
            try
            {
                if (input == null || !ModelState.IsValid)
                    return BadRequest(ModelState);

                //if (!input.Id.HasValue || input.Id.Value == default)
                //{
                //    input = await _loanAppService.CreateAsync(input);
                //}

                //await _loanAppService.UpdateAsync(input);

                return Json(input);
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }
    }
}
