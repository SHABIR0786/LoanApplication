using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoanManagement.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LoanManagement.Web.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanController : LoanManagementControllerBase
    {
    }
}
