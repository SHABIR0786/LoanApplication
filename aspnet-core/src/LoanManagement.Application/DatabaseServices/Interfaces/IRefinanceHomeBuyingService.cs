using Abp.Application.Services;
using LoanManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanManagement.DatabaseServices.Interfaces
{
   public interface IRefinanceHomeBuyingService : IAsyncCrudAppService<RefinanceHomeBuyingDto, long?, PagedLoanApplicationResultRequestDto, RefinanceHomeBuyingDto, RefinanceHomeBuyingDto>
    {

    }
}
