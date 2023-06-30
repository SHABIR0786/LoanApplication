using Abp;
using Abp.Application.Services;
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
    public class HomeBuyingService : AbpServiceBase, IHomeBuyingService
    { 
        private readonly IRepository<Homebuying, long?> _repository;
        private readonly IMapper _mapper;

        public HomeBuyingService(
          IRepository<Homebuying, long?> repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        public async Task<BuyingHomeDto> CreateAsync(BuyingHomeDto input)
        {
            Homebuying homeBuying = new Homebuying();
            homeBuying.FirstName = input.firstName;
            homeBuying.EmailAddress = input.emailAddress;
            homeBuying.DownPayment = input.downPayment;
            homeBuying.CurrentlyEmployed = input.currentEmployed;
            homeBuying.BankruptcyPastThreeYears = input.bankruptcyPastThreeYears;
            homeBuying.FirstTimeHomeBuying = input.FirstTimeHomeBuying;
            homeBuying.ForeclosurePastTwoYears = input.foreclosurePastTwoYears;
            homeBuying.HouseHoldIncome = input.houseHoldIncome;
            homeBuying.LastName = input.lastName;
            homeBuying.LateMortgagePayments = input.LateMortgagePayments;
            homeBuying.MilitarySevice = input.militarySevice;
            homeBuying.PhoneNumber = input.phoneNumber;
            homeBuying.PlanToPurchase = input.planToPurchase;
            homeBuying.ProofOfincome = input.proofOfincome;
            homeBuying.PropertyLocated = input.propertyLocated;
            homeBuying.PropertyType = input.propertyType;
            homeBuying.PropertyUse = input.propertyUse;
            homeBuying.PurchasePrice = Convert.ToDecimal(input.purchasePrice);
            homeBuying.RateCredit = input.rateCredit;
            homeBuying.RefferedBy = input.refferedBy;
            await _repository.InsertAsync(homeBuying);
            await UnitOfWorkManager.Current.SaveChangesAsync();
            return input;
        }

        public Task DeleteAsync(EntityDto<long?> input)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResultDto<BuyingHomeDto>> GetAllAsync(PagedLoanApplicationResultRequestDto input)
        {
            throw new NotImplementedException();
        }

        public Task<BuyingHomeDto> GetAsync(EntityDto<long?> input)
        {
            throw new NotImplementedException();
        }

        public Task<BuyingHomeDto> UpdateAsync(BuyingHomeDto input)
        {
            throw new NotImplementedException();
        }

   

    }
}
