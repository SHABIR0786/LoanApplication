using Abp;
using Abp.Application.Services;
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
    public class HomeBuyingService : AbpServiceBase, IHomeBuyingService
    { 
        private readonly IRepository<HomeBuying, long?> _repository;
        private readonly IMapper _mapper;

        public HomeBuyingService(
          IRepository<HomeBuying, long?> repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        public async Task<BuyingHomeDto> CreateAsync(BuyingHomeDto input)
        {
            HomeBuying homeBuying = new HomeBuying();
            homeBuying.firstName = input.firstName;
            homeBuying.emailAddress = input.emailAddress;
            homeBuying.downPayment = input.downPayment;
            homeBuying.currentlyEmployed = input.currentlyEmployed;
            homeBuying.bankruptcyPastThreeYears = input.bankruptcyPastThreeYears;
            homeBuying.FirstTimeHomeBuying = input.FirstTimeHomeBuying;
            homeBuying.foreclosurePastTwoYears = input.foreclosurePastTwoYears;
            homeBuying.houseHoldIncome = input.houseHoldIncome;
            homeBuying.lastName = input.lastName;
            homeBuying.LateMortgagePayments = input.LateMortgagePayments;
            homeBuying.militarySevice = input.militarySevice;
            homeBuying.phoneNumber = input.phoneNumber;
            homeBuying.planToPurchase = input.planToPurchase;
            homeBuying.proofOfincome = input.proofOfincome;
            homeBuying.propertyLocated = input.propertyLocated;
            homeBuying.propertyType = input.propertyType;
            homeBuying.propertyUse = input.propertyUse;
            homeBuying.purchasePrice = input.purchasePrice;
            homeBuying.rateCredit = input.rateCredit;
            homeBuying.refferedBy = input.refferedBy;
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
