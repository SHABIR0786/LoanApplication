﻿using LoanManagement.DatabaseServices.Interfaces;
using LoanManagement.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LoanManagement.Controllers
{
    [Route("api/[controller]/[action]")]
    public class SiteSettingController : LoanManagementControllerBase
    {
        private readonly ISiteSettingServices _siteSettingServices;

        public SiteSettingController(ISiteSettingServices siteSettingServices)
        {
            _siteSettingServices = siteSettingServices;
        }

        [HttpPost]
        public async Task<IActionResult> All([FromBody] PagedLoanApplicationResultRequestDto dto)
        {
            if (dto == null || !ModelState.IsValid)
                return BadRequest();

            return Json(await _siteSettingServices.GetAllAsync(dto));
        }
    }
}
