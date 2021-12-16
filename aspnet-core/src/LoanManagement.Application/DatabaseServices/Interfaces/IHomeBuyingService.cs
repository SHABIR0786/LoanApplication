using Abp.Application.Services.Dto;
using LoanManagement.Models;
using LoanManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.DatabaseServices.Interfaces
{
    public interface IHomeBuyingService
    {
        Task CreateAsync(HomeBuying input);
    }
}
