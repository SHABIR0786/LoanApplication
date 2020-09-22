using Abp.Application.Services;
using LoanManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.DatabaseServices.Interfaces
{
    public interface IOtherIncomeService : IAsyncCrudAppService<OtherIncomeDto, long, PagedLoanApplicationResultRequestDto, OtherIncomeDto, OtherIncomeDto>
    {
    }
}