using Abp.Application.Services;
using Abp.Domain.Repositories;
using LoanManagement.MortgageServices.MortgageApplicationLoanProperty.Dto;
using LoanManagement.MortgageTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.MortgageServices.MortgageApplicationLoanProperty
{
    public class MortgageApplicationLoanPropertyService:AsyncCrudAppService<MortgageApplicationLoanPropertyInformation,MortgageApplicationLoanPropertyInformationDto,int>
    {
        private readonly IRepository<MortgageApplicationLoanPropertyInformation> _loanPropertyInfoRepository;
        private readonly IRepository<MortgageApplicationLoanPropertyOtherNewMortgageLoans> _otherNewMortgageLoansRepository;
        private readonly IRepository<MortgageApplicationLoanPropertyAddress> _propertyAddressRepository;
        private readonly IRepository<MortgageApplicationLoanPropertyRentalIncome> _rentalIncomeRepository;
        private readonly IRepository<MortgageApplicationLoanPropertyGiftsOrGrants> _giftsOrGrantsRepository;
        private readonly IRepository<MortgageApplicationLoanOriginatorInformation> _originatorInformationRepository;
        private readonly IRepository<MortgageApplicationMilitaryService> _militaryServiceRepository;
        public MortgageApplicationLoanPropertyService(IRepository<MortgageApplicationLoanPropertyInformation> loanPropertyInfoRepository,
            IRepository<MortgageApplicationLoanPropertyOtherNewMortgageLoans> otherNewMortgageLoansRepository,
            IRepository<MortgageApplicationLoanPropertyAddress> propertyAddressRepository,
            IRepository<MortgageApplicationLoanPropertyRentalIncome> rentalIncomeRepository,
            IRepository<MortgageApplicationLoanPropertyGiftsOrGrants> giftsOrGrantsRepository,
            IRepository<MortgageApplicationLoanOriginatorInformation> originatorInformationRepository,
            IRepository<MortgageApplicationMilitaryService> militaryServiceRepository) :base(loanPropertyInfoRepository)
        {
            this._loanPropertyInfoRepository= loanPropertyInfoRepository;
            this._otherNewMortgageLoansRepository= otherNewMortgageLoansRepository;
            this._propertyAddressRepository= propertyAddressRepository;
            this._rentalIncomeRepository= rentalIncomeRepository;
            this._giftsOrGrantsRepository= giftsOrGrantsRepository;
            this._originatorInformationRepository= originatorInformationRepository;
            this._militaryServiceRepository= militaryServiceRepository;
        }
        public async Task CreateMortgageApplicationLoanProperty(CreateMortgageLoanAndProperty createMortgageLoanAndProperty)
        {
            var propertyInfo = ObjectMapper.Map<MortgageApplicationLoanPropertyInformation>(createMortgageLoanAndProperty.LoanPropertyInfo);
            if(propertyInfo != null)
                await _loanPropertyInfoRepository.InsertAsync(propertyInfo);
            //Property Address
            var propertyAddress = ObjectMapper.Map<MortgageApplicationLoanPropertyAddress>(createMortgageLoanAndProperty.LoanPropertyInfo.PropertyAddress);
            if(propertyAddress!=null)
                await _propertyAddressRepository.InsertAsync(propertyAddress);
            //mortgageLoans
            var propertyMortgageLoans = ObjectMapper.Map<List<MortgageApplicationLoanPropertyOtherNewMortgageLoans>>(createMortgageLoanAndProperty.NewMortgageLoans);
            if(propertyMortgageLoans.Count>0)
                foreach (var item in propertyMortgageLoans)
                {
                    await _otherNewMortgageLoansRepository.InsertAsync(item);
                }
            //Rental Income
            var rentalIncome = ObjectMapper.Map<MortgageApplicationLoanPropertyRentalIncome>(createMortgageLoanAndProperty.RentalIncome);
            if (rentalIncome!=null)
                    await _rentalIncomeRepository.InsertAsync(rentalIncome);
            //Gifts Or Grants
            var giftsOrGrants = ObjectMapper.Map<List<MortgageApplicationLoanPropertyGiftsOrGrants>>(createMortgageLoanAndProperty.GiftsOrGrants);
            if (giftsOrGrants.Count > 0)
                foreach (var item in giftsOrGrants)
                {
                    await _giftsOrGrantsRepository.InsertAsync(item);
                }
        }
        public async Task CreateOriginatorInformation(MortgageApplicationLoanOriginatorInformationDto originatorInformationDto)
        {
            var originatorInfo = ObjectMapper.Map<MortgageApplicationLoanOriginatorInformation>(originatorInformationDto);
            if (originatorInfo != null)
                await _originatorInformationRepository.InsertAsync(originatorInfo);
        }
        public async Task CreateMilitaryService(MortgageApplicationMilitaryServiceDto militaryServiceDto)
        {
            var militaryService = ObjectMapper.Map<MortgageApplicationMilitaryService>(militaryServiceDto);
            if (militaryService != null)
                await _militaryServiceRepository.InsertAsync(militaryService);
        }
    }
}
