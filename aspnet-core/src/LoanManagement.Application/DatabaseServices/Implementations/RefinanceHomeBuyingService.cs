using Abp;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using AutoMapper;
using LoanManagement.codeFirstEntities;
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
        private readonly IRepository<Refinancehomebuying, long?> _repository;
        private readonly IMapper _mapper;

        public RefinanceHomeBuyingService(
          IRepository<Refinancehomebuying, long?> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<RefinanceHomeBuyingDto> CreateAsync(RefinanceHomeBuyingDto input)
        {
            Refinancehomebuying refinanceHomeBuying = new Refinancehomebuying();
            refinanceHomeBuying.PropertyLocated = input.propertyLocated;
            refinanceHomeBuying.PropertyLocated = input.propertyType;
            refinanceHomeBuying.PropertyUse = input.propertyType;
            refinanceHomeBuying.WantRefinance = input.propertyType;
            refinanceHomeBuying.HomePrice = input.HomePrice;
            refinanceHomeBuying.Owe = input.Owe;
            refinanceHomeBuying.CashBorrow = input.CashBorrow;
            refinanceHomeBuying.Fhaloan = input.FHALoan;
            refinanceHomeBuying.MilitarySevice = input.militarySevice;
            refinanceHomeBuying.ForeclosurePastTwoYears = input.foreclosurePastTwoYears;
            refinanceHomeBuying.BankruptcyPastThreeYears = input.bankruptcyPastThreeYears;
            refinanceHomeBuying.LateMortgagePayments = input.LateMortgagePayments; 
            refinanceHomeBuying.CurrentEmployed = input.currentEmployed;
            refinanceHomeBuying.HouseHoldIncome = input.houseHoldIncome;
            refinanceHomeBuying.ProofOfincome = input.proofOfincome;
            refinanceHomeBuying.RateCredit = input.rateCredit;
            refinanceHomeBuying.FirstName = input.firstName;
            refinanceHomeBuying.LastName = input.lastName;
            refinanceHomeBuying.EmailAddress = input.emailAddress;
            refinanceHomeBuying.PhoneNumber = input.phoneNumber;
            refinanceHomeBuying.RefferedBy = input.refferedBy;
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
