using Abp;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using AutoMapper;
using LoanManagement.DatabaseServices.Interfaces;
using LoanManagement.Models;
using LoanManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.DatabaseServices.Implementations
{
    public class RefinanceHomeBuyingService : AbpServiceBase, IRefinanceHomeBuyingService
    {
        private readonly IRepository<RefinanceHomeBuying, long?> _repository;
        private readonly IMapper _mapper;

        public RefinanceHomeBuyingService(
          IRepository<RefinanceHomeBuying, long?> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<RefinanceHomeBuyingDto> CreateAsync(RefinanceHomeBuyingDto input)
        {
            RefinanceHomeBuying refinanceHomeBuying = new RefinanceHomeBuying();
            refinanceHomeBuying.propertyLocated = input.propertyLocated;
            refinanceHomeBuying.propertyType = input.propertyType;
            refinanceHomeBuying.PropertyUse = input.propertyType;
            refinanceHomeBuying.WantRefinance = input.propertyType;
            refinanceHomeBuying.HomePrice = input.HomePrice;
            refinanceHomeBuying.Owe = input.Owe;
            refinanceHomeBuying.CashBorrow = input.CashBorrow;
            refinanceHomeBuying.FHALoan = input.FHALoan;
            refinanceHomeBuying.militarySevice = input.militarySevice;
            refinanceHomeBuying.foreclosurePastTwoYears = input.foreclosurePastTwoYears;
            refinanceHomeBuying.bankruptcyPastThreeYears = input.bankruptcyPastThreeYears;
            refinanceHomeBuying.LateMortgagePayments = input.LateMortgagePayments; 
            refinanceHomeBuying.currentEmployed = input.currentEmployed;
            refinanceHomeBuying.houseHoldIncome = input.houseHoldIncome;
            refinanceHomeBuying.proofOfincome = input.proofOfincome;
            refinanceHomeBuying.rateCredit = input.rateCredit;
            refinanceHomeBuying.firstName = input.firstName;
            refinanceHomeBuying.lastName = input.lastName;
            refinanceHomeBuying.emailAddress = input.emailAddress;
            refinanceHomeBuying.phoneNumber = input.phoneNumber;
            refinanceHomeBuying.refferedBy = input.refferedBy;
            await _repository.InsertAsync(refinanceHomeBuying);
            await UnitOfWorkManager.Current.SaveChangesAsync();
            return input;
        }

        public Task DeleteAsync(EntityDto<long?> input)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResultDto<RefinanceHomeBuyingDto>> GetAllAsync(PagedLoanApplicationResultRequestDto input)
        {
            throw new NotImplementedException();
        }

        public Task<RefinanceHomeBuyingDto> GetAsync(EntityDto<long?> input)
        {
            throw new NotImplementedException();
        }

        public Task<RefinanceHomeBuyingDto> UpdateAsync(RefinanceHomeBuyingDto input)
        {
            throw new NotImplementedException();
        }
    }
}
