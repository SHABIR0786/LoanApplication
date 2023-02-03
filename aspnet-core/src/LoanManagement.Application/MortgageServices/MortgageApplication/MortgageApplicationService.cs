using Abp.Application.Services;
using Abp.Domain.Repositories;
using LoanManagement.MortgageServices.MortgageApplication.Dto;
using LoanManagement.MortgageTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.MortgageServices.MortgageApplication
{
    public class MortgageApplicationService : AsyncCrudAppService<MortgageApplications, MortgageApplicationDto, int>
    {
        private readonly IRepository<MortgageApplications> _applicationRepository;
        private readonly IRepository<MortgageApplicationPersonalInformation> _applicationPersonalInformationRepository;
        private readonly IRepository<MortgageApplicationAlternateName> _applicationAlternateNameRepository;
        private readonly IRepository<MortgageApplicationCurrentAddress> _applicationCurrentAddressRepository;
        private readonly IRepository<MortgageApplicationFormerAddress> _applicationFormerAddressRepository;
        private readonly IRepository<MortgageApplicationMailingAddress> _applicationMailingAddressRepository;
        private readonly IRepository<MortgageApplicationTypeOfCredit> _applicationTypeOfCreditRepository;
        private readonly IRepository<MortgageApplicationOtherBorrower> _applicationOtherBorrowerRepository;
        private readonly IRepository<MortgageApplicationContactInformation> _applicationContactInformationRepository;
        private readonly IRepository<MortgageApplicationEmploymentDetail> _applicationEmploymentDetailRepository;
        private readonly IRepository<MortgageApplicationAdditionalEmploymentDetail> _applicationAdditionalEmploymentDetailRepository;
        private readonly IRepository<MortgageApplicationEmploymentIncomeDetail> _applicationEmploymentIncomeDetailRepository;
        private readonly IRepository<MortgageApplicationAdditionalEmploymentIncomeDetail> _applicationAdditionalEmploymentIncomeDetailRepository;
        private readonly IRepository<MortgageApplicationPreviousEmploymentDetail> _applicationPreviousEmploymentDetailRepository;
        private readonly IRepository<MortgageApplicationIncomeSource> _applicationIncomeSourceRepository;
        private readonly IRepository<MortgageApplicationSource> _applicationSourceRepository;
        public MortgageApplicationService(IRepository<MortgageApplications> applicationRepository,
            IRepository<MortgageApplicationPersonalInformation> applicationPersonalInformationRepository,
            IRepository<MortgageApplicationAlternateName> applicationAlternateNameRepository,
            IRepository<MortgageApplicationCurrentAddress> applicationCurrentAddressRepository,
            IRepository<MortgageApplicationFormerAddress> applicationFormerAddressRepository,
            IRepository<MortgageApplicationMailingAddress> applicationMailingAddressRepository,
            IRepository<MortgageApplicationTypeOfCredit> applicationTypeOfCreditRepository,
            IRepository<MortgageApplicationOtherBorrower> applicationOtherBorrowerRepository,
            IRepository<MortgageApplicationContactInformation> applicationContactInformationRepository,
             IRepository<MortgageApplicationEmploymentDetail> applicationEmploymentDetailRepository,
             IRepository<MortgageApplicationAdditionalEmploymentDetail> applicationAdditionalEmploymentDetailRepository,
             IRepository<MortgageApplicationEmploymentIncomeDetail> applicationEmploymentIncomeDetailRepository,
             IRepository<MortgageApplicationAdditionalEmploymentIncomeDetail> applicationAdditionalEmploymentIncomeDetailRepository,
             IRepository<MortgageApplicationPreviousEmploymentDetail> applicationPreviousEmploymentDetailRepository,
             IRepository<MortgageApplicationSource> applicationSourceRepository,
              IRepository<MortgageApplicationIncomeSource> applicationIncomeSourceRepository

            ) : base(applicationRepository)
        {
            this._applicationRepository = applicationRepository;
            _applicationPersonalInformationRepository = applicationPersonalInformationRepository;
            _applicationOtherBorrowerRepository = applicationOtherBorrowerRepository;
            _applicationMailingAddressRepository = applicationMailingAddressRepository;
            _applicationFormerAddressRepository = applicationFormerAddressRepository;
            _applicationCurrentAddressRepository = applicationCurrentAddressRepository;
            _applicationContactInformationRepository = applicationContactInformationRepository;
            _applicationAlternateNameRepository = applicationAlternateNameRepository;
            _applicationTypeOfCreditRepository = applicationTypeOfCreditRepository;
            _applicationEmploymentDetailRepository = applicationEmploymentDetailRepository;
            _applicationEmploymentIncomeDetailRepository = applicationEmploymentIncomeDetailRepository;
            _applicationAdditionalEmploymentDetailRepository = applicationAdditionalEmploymentDetailRepository;
            _applicationAdditionalEmploymentIncomeDetailRepository = applicationAdditionalEmploymentIncomeDetailRepository;
            _applicationPreviousEmploymentDetailRepository = applicationPreviousEmploymentDetailRepository;
            _applicationIncomeSourceRepository = applicationIncomeSourceRepository;
            _applicationSourceRepository = applicationSourceRepository;
        }

        public async Task CreateMortgageLoanApplication(CreateMortgageLoanApplicationDto createMortgageLoanApplicationDto)
        {
            try
            {
                //application
                var application = ObjectMapper.Map<MortgageApplications>(createMortgageLoanApplicationDto.MortgageApplication);
                if (application != null)
                {
                    var applicationId = await _applicationRepository.InsertAndGetIdAsync(application);
                    createMortgageLoanApplicationDto.PersonalInformation.MortgageApplicationId = applicationId;
                }
                //personalInfo
                var applicationPersonalDetail = ObjectMapper.Map<MortgageApplicationPersonalInformation>(createMortgageLoanApplicationDto.PersonalInformation);
                if (applicationPersonalDetail != null)
                {
                    var PersonalInformationId = await _applicationPersonalInformationRepository.InsertAndGetIdAsync(applicationPersonalDetail);
                    createMortgageLoanApplicationDto.PersonalInformation.ContactInformation.PersonalInformationId = PersonalInformationId;
                    createMortgageLoanApplicationDto.PersonalInformation.TypeOfCredit.PersonalInformationId = PersonalInformationId;
                    createMortgageLoanApplicationDto.PersonalInformation.CurrentAddress.PersonalInformationId = PersonalInformationId;
                    createMortgageLoanApplicationDto.PersonalInformation.FormerAddress.PersonalInformationId = PersonalInformationId;
                    createMortgageLoanApplicationDto.PersonalInformation.MailingAddress.PersonalInformationId = PersonalInformationId;
                    createMortgageLoanApplicationDto.PersonalInformation.AlternateNames.PersonalInformationId = PersonalInformationId;
                    createMortgageLoanApplicationDto.CurrentEmployment.PersonalInformationId = PersonalInformationId;
                    createMortgageLoanApplicationDto.AdditionalEmployment.PersonalInformationId = PersonalInformationId;
                    createMortgageLoanApplicationDto.PreviousEmployment.PersonalInformationId = PersonalInformationId;
                    createMortgageLoanApplicationDto.IncomeOtherSources.PersonalInformationId = PersonalInformationId;
                }
                //contackInfo
                var applicationContactInfo = ObjectMapper.Map<MortgageApplicationContactInformation>(createMortgageLoanApplicationDto.PersonalInformation.ContactInformation);
                if (applicationContactInfo != null)
                    await _applicationContactInformationRepository.InsertAsync(applicationContactInfo);
                /////////Credittype
                var applicationTypeOfCredit = ObjectMapper.Map<MortgageApplicationTypeOfCredit>(createMortgageLoanApplicationDto.PersonalInformation.TypeOfCredit);
                if (applicationTypeOfCredit != null)
                    await _applicationTypeOfCreditRepository.InsertAsync(applicationTypeOfCredit);
                ////
                var applicationCurrentAddress = ObjectMapper.Map<MortgageApplicationCurrentAddress>(createMortgageLoanApplicationDto.PersonalInformation.CurrentAddress);
                if (applicationCurrentAddress != null)
                    await _applicationCurrentAddressRepository.InsertAsync(applicationCurrentAddress);
                var applicationFormerAddress = ObjectMapper.Map<MortgageApplicationFormerAddress>(createMortgageLoanApplicationDto.PersonalInformation.FormerAddress);
                if (applicationFormerAddress != null)
                    await _applicationFormerAddressRepository.InsertAsync(applicationFormerAddress);

                var applicationMailingAddress = ObjectMapper.Map<MortgageApplicationMailingAddress>(createMortgageLoanApplicationDto.PersonalInformation.MailingAddress);
                if (applicationMailingAddress != null)
                    await _applicationMailingAddressRepository.InsertAsync(applicationMailingAddress);

                var applicationAlternateName = ObjectMapper.Map<MortgageApplicationAlternateName>(createMortgageLoanApplicationDto.PersonalInformation.AlternateNames);
                if (applicationAlternateName != null)
                    await _applicationAlternateNameRepository.InsertAsync(applicationAlternateName);

                if (createMortgageLoanApplicationDto.PersonalInformation.OtherBorrowers.Any())
                {
                    foreach (var item in createMortgageLoanApplicationDto.PersonalInformation.OtherBorrowers)
                    {
                        var borrower=ObjectMapper.Map<MortgageApplicationOtherBorrower>(item);
                        borrower.PersonalInformationId = createMortgageLoanApplicationDto.PersonalInformation.ContactInformation.PersonalInformationId;
                        await _applicationOtherBorrowerRepository.InsertAsync(borrower);
                    }
                }

                var applicationEmploymentDetail = ObjectMapper.Map<MortgageApplicationEmploymentDetail>(createMortgageLoanApplicationDto.CurrentEmployment);
                if (applicationEmploymentDetail != null)
                {
                    var currentEmploymentId = await _applicationEmploymentDetailRepository.InsertAndGetIdAsync(applicationEmploymentDetail);
                    createMortgageLoanApplicationDto.CurrentEmployment.GrossMonthlyIncome.EmploymentDetailId = currentEmploymentId;
                }
                var applicationEmploymentIncomeDetail = ObjectMapper.Map<MortgageApplicationEmploymentIncomeDetail>(createMortgageLoanApplicationDto.CurrentEmployment.GrossMonthlyIncome);
                if (applicationEmploymentIncomeDetail != null)
                    await _applicationEmploymentIncomeDetailRepository.InsertAsync(applicationEmploymentIncomeDetail);
                //AdditionalEmployment
                var applicationAdditionalEmploymentDetail = ObjectMapper.Map<MortgageApplicationAdditionalEmploymentDetail>(createMortgageLoanApplicationDto.AdditionalEmployment);
                if (applicationAdditionalEmploymentDetail != null)
                {
                   var additionalEmploymentId= await _applicationAdditionalEmploymentDetailRepository.InsertAndGetIdAsync(applicationAdditionalEmploymentDetail);
                    createMortgageLoanApplicationDto.AdditionalEmployment.GrossMonthlyIncome.AdditionalEmploymentDetailId= additionalEmploymentId;
                }
                var applicationAdditionalEmploymentIncomeDetail = ObjectMapper.Map<MortgageApplicationAdditionalEmploymentIncomeDetail>(createMortgageLoanApplicationDto.AdditionalEmployment.GrossMonthlyIncome);
                if (applicationAdditionalEmploymentIncomeDetail != null)
                    await _applicationAdditionalEmploymentIncomeDetailRepository.InsertAsync(applicationAdditionalEmploymentIncomeDetail);
                //PreviourEmployment
                var applicationPreviousEmploymentDetail = ObjectMapper.Map<MortgageApplicationPreviousEmploymentDetail>(createMortgageLoanApplicationDto.PreviousEmployment);
                if (applicationPreviousEmploymentDetail != null)
                    await _applicationPreviousEmploymentDetailRepository.InsertAsync(applicationPreviousEmploymentDetail);
                //IncomeSource
                var incomeSource = ObjectMapper.Map<MortgageApplicationIncomeSource>(createMortgageLoanApplicationDto.IncomeOtherSources);
                var incomeSourceId= await _applicationIncomeSourceRepository.InsertAndGetIdAsync(incomeSource);
                if (createMortgageLoanApplicationDto.IncomeOtherSources.Sources.Any())
                {
                    foreach (var item in createMortgageLoanApplicationDto.IncomeOtherSources.Sources)
                    {
                        var source = ObjectMapper.Map<MortgageApplicationSource>(item);
                        source.IncomeSourceId = incomeSourceId;
                        await _applicationSourceRepository.InsertAsync(source);
                    }
                }
            }
            catch (Exception e)
            {

                throw;
            }


        }
        //public async Task<CreateMortgageLoanApplicationDto> GetMortgageLoanApplication(int applicationId)
        //{
        //    var applicationDetail = new CreateMortgageLoanApplicationDto();
        //    var application=await _applicationRepository.GetAsync(applicationId);
        //    applicationDetail.MortgageApplication =ObjectMapper.Map<MortgageApplicationDto>(application);
        //    var personalDetail



        //    return applicationDetail;
        //}
    }
}
