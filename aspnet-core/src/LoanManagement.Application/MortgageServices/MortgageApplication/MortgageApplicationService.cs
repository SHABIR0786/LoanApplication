using Abp.Application.Services;
using Abp.Domain.Repositories;
using LoanManagement.MortgageServices.MortgageApplication.Dto;
using LoanManagement.MortgageTables;
using Microsoft.EntityFrameworkCore;
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
       // private readonly IRepository<MortgageApplicationTypeOfCredit> _applicationTypeOfCreditRepository;
        private readonly IRepository<MortgageApplicationOtherBorrower> _applicationOtherBorrowerRepository;
        private readonly IRepository<MortgageApplicationContactInformation> _applicationContactInformationRepository;
        private readonly IRepository<MortgageApplicationEmploymentDetail> _applicationEmploymentDetailRepository;
        private readonly IRepository<MortgageApplicationEmploymentIncomeDetail> _applicationEmploymentIncomeDetailRepository;
        private readonly IRepository<MortgageApplicationIncomeSource> _applicationIncomeSourceRepository;
        private readonly IRepository<MortgageApplicationAgreement> _applicationAgreementRepository;
        private readonly IRepository<MortgageApplicationQuestions> _questionRepository;
        public MortgageApplicationService(IRepository<MortgageApplications> applicationRepository,
            IRepository<MortgageApplicationPersonalInformation> applicationPersonalInformationRepository,
            IRepository<MortgageApplicationAlternateName> applicationAlternateNameRepository,
            IRepository<MortgageApplicationCurrentAddress> applicationCurrentAddressRepository,
           // IRepository<MortgageApplicationTypeOfCredit> applicationTypeOfCreditRepository,
            IRepository<MortgageApplicationOtherBorrower> applicationOtherBorrowerRepository,
            IRepository<MortgageApplicationContactInformation> applicationContactInformationRepository,
             IRepository<MortgageApplicationEmploymentDetail> applicationEmploymentDetailRepository,
             IRepository<MortgageApplicationEmploymentIncomeDetail> applicationEmploymentIncomeDetailRepository,
              IRepository<MortgageApplicationIncomeSource> applicationIncomeSourceRepository,
              IRepository<MortgageApplicationAgreement> applicationAgreementRepository,
              IRepository<MortgageApplicationQuestions> questionRepository

            ) : base(applicationRepository)
        {
            this._applicationRepository = applicationRepository;
            _applicationPersonalInformationRepository = applicationPersonalInformationRepository;
            _applicationOtherBorrowerRepository = applicationOtherBorrowerRepository;
            _applicationCurrentAddressRepository = applicationCurrentAddressRepository;
            _applicationContactInformationRepository = applicationContactInformationRepository;
            _applicationAlternateNameRepository = applicationAlternateNameRepository;
          //  _applicationTypeOfCreditRepository = applicationTypeOfCreditRepository;
            _applicationEmploymentDetailRepository = applicationEmploymentDetailRepository;
            _applicationEmploymentIncomeDetailRepository = applicationEmploymentIncomeDetailRepository;
            _applicationIncomeSourceRepository = applicationIncomeSourceRepository;
            _applicationAgreementRepository = applicationAgreementRepository;
            _questionRepository= questionRepository;
        }

        public async Task CreateMortgageLoanApplication(MortgageApplicationDto createMortgageLoanApplicationDto)
        {
            try
            {
                //application
                var application = ObjectMapper.Map<MortgageApplications>(createMortgageLoanApplicationDto);
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
                    createMortgageLoanApplicationDto.PersonalInformation.AlternateNames.PersonalInformationId = PersonalInformationId;                 
                }
                //contactInfo
                var applicationContactInfo = ObjectMapper.Map<MortgageApplicationContactInformation>(createMortgageLoanApplicationDto.PersonalInformation.ContactInformation);
                if (applicationContactInfo != null)
                    await _applicationContactInformationRepository.InsertAsync(applicationContactInfo);
                /////////Credittype
                //var applicationTypeOfCredit = ObjectMapper.Map<MortgageApplicationTypeOfCredit>(createMortgageLoanApplicationDto.PersonalInformation.TypeOfCredit);
                //if (applicationTypeOfCredit != null)
                //    await _applicationTypeOfCreditRepository.InsertAsync(applicationTypeOfCredit);
                ////Address
                 if(createMortgageLoanApplicationDto.PersonalInformation.Address.Count> 0)
                {
                    foreach (var item in createMortgageLoanApplicationDto.PersonalInformation.Address)
                    {
                        item.PersonalInformationId = createMortgageLoanApplicationDto.PersonalInformation.ContactInformation.PersonalInformationId;
                        var applicationCurrentAddress = ObjectMapper.Map<MortgageApplicationCurrentAddress>(item);
                        if (applicationCurrentAddress != null)
                            await _applicationCurrentAddressRepository.InsertAsync(applicationCurrentAddress);
                    }
                }

                var applicationAlternateName = ObjectMapper.Map<MortgageApplicationAlternateName>(createMortgageLoanApplicationDto.PersonalInformation.AlternateNames);
                if (applicationAlternateName != null)
                    await _applicationAlternateNameRepository.InsertAsync(applicationAlternateName);

                if (createMortgageLoanApplicationDto.OtherBorrowers.Count>0)
                {
                    foreach (var item in createMortgageLoanApplicationDto.OtherBorrowers)
                    {
                        var borrower = ObjectMapper.Map<MortgageApplicationPersonalInformation>(item);
                        borrower.BorrowerType = "Other";
                        await _applicationPersonalInformationRepository.InsertAsync(borrower);
                    }
                }
                //Employment Details
                if (createMortgageLoanApplicationDto.Employment.Count > 0)
                {
                    foreach (var item in createMortgageLoanApplicationDto.Employment)
                    {
                        item.PersonalInformationId = createMortgageLoanApplicationDto.PersonalInformation.ContactInformation.PersonalInformationId;

                        var applicationEmploymentDetail = ObjectMapper.Map<MortgageApplicationEmploymentDetail>(item);
                        if (applicationEmploymentDetail != null)
                        {
                            var currentEmploymentId = await _applicationEmploymentDetailRepository.InsertAndGetIdAsync(applicationEmploymentDetail);
                            item.GrossMonthlyIncome.EmploymentDetailId = currentEmploymentId;
                        }
                        var applicationEmploymentIncomeDetail = ObjectMapper.Map<MortgageApplicationEmploymentIncomeDetail>(item.GrossMonthlyIncome);
                        if (applicationEmploymentIncomeDetail != null)
                            await _applicationEmploymentIncomeDetailRepository.InsertAsync(applicationEmploymentIncomeDetail);
                    }            
                }
                //IncomeSource
                if (createMortgageLoanApplicationDto.IncomeOtherSources.Count > 0)
                {
                    foreach (var item in createMortgageLoanApplicationDto.IncomeOtherSources)
                    {
                        item.PersonalInformationId = createMortgageLoanApplicationDto.PersonalInformation.ContactInformation.PersonalInformationId;
                        var incomeSource = ObjectMapper.Map<MortgageApplicationIncomeSource>(item);
                         await _applicationIncomeSourceRepository.InsertAsync(incomeSource);
                    }
                }                             
            }
            catch (Exception e)
            {

                throw;
            }


        }
        public async Task CreateMortgageApplicationAgreement(MortgageApplicationAgreementDto agreementDto)
        {
            if (agreementDto != null)
            {
                var entity = ObjectMapper.Map<MortgageApplicationAgreement>(agreementDto);
                await _applicationAgreementRepository.InsertAsync(entity);
            }
        }
        public async Task MortgageApplicationQuestions(List<MortgageApplicationQuestionsDto> questions)
        {
            if(questions.Count>0)
            {
                foreach (var item in questions)
                {
                    var question = ObjectMapper.Map<MortgageApplicationQuestions>(item);
                    await _questionRepository.InsertAsync(question);
                }
            }
        }
        //public async Task CreateMortgageLoanApplication(MortgageApplicationDto createMortgageLoanApplicationDto)
        //{
        //    try
        //    {
        //        //application
        //        var application = ObjectMapper.Map<MortgageApplications>(createMortgageLoanApplicationDto);
        //        if (application != null)
        //        {
        //            var applicationId = await _applicationRepository.InsertAndGetIdAsync(application);
        //            createMortgageLoanApplicationDto.PersonalInformation.MortgageApplicationId = applicationId;
        //        }
        //        //personalInfo
        //        var applicationPersonalDetail = ObjectMapper.Map<MortgageApplicationPersonalInformation>(createMortgageLoanApplicationDto.PersonalInformation);
        //        if (applicationPersonalDetail != null)
        //        {
        //            var PersonalInformationId = await _applicationPersonalInformationRepository.InsertAndGetIdAsync(applicationPersonalDetail);
        //            createMortgageLoanApplicationDto.PersonalInformation.ContactInformation.PersonalInformationId = PersonalInformationId;
        //            createMortgageLoanApplicationDto.PersonalInformation.TypeOfCredit.PersonalInformationId = PersonalInformationId;
        //            createMortgageLoanApplicationDto.PersonalInformation.CurrentAddress.PersonalInformationId = PersonalInformationId;
        //            createMortgageLoanApplicationDto.PersonalInformation.FormerAddress.PersonalInformationId = PersonalInformationId;
        //            createMortgageLoanApplicationDto.PersonalInformation.MailingAddress.PersonalInformationId = PersonalInformationId;
        //            createMortgageLoanApplicationDto.PersonalInformation.AlternateNames.PersonalInformationId = PersonalInformationId;
        //            createMortgageLoanApplicationDto.CurrentEmployment.PersonalInformationId = PersonalInformationId;
        //            createMortgageLoanApplicationDto.AdditionalEmployment.PersonalInformationId = PersonalInformationId;
        //            createMortgageLoanApplicationDto.PreviousEmployment.PersonalInformationId = PersonalInformationId;
        //            createMortgageLoanApplicationDto.IncomeOtherSources.PersonalInformationId = PersonalInformationId;
        //        }
        //        //contackInfo
        //        var applicationContactInfo = ObjectMapper.Map<MortgageApplicationContactInformation>(createMortgageLoanApplicationDto.PersonalInformation.ContactInformation);
        //        if (applicationContactInfo != null)
        //            await _applicationContactInformationRepository.InsertAsync(applicationContactInfo);
        //        /////////Credittype
        //        var applicationTypeOfCredit = ObjectMapper.Map<MortgageApplicationTypeOfCredit>(createMortgageLoanApplicationDto.PersonalInformation.TypeOfCredit);
        //        if (applicationTypeOfCredit != null)
        //            await _applicationTypeOfCreditRepository.InsertAsync(applicationTypeOfCredit);
        //        ////
        //        var applicationCurrentAddress = ObjectMapper.Map<MortgageApplicationCurrentAddress>(createMortgageLoanApplicationDto.PersonalInformation.CurrentAddress);
        //        if (applicationCurrentAddress != null)
        //            await _applicationCurrentAddressRepository.InsertAsync(applicationCurrentAddress);
        //        var applicationFormerAddress = ObjectMapper.Map<MortgageApplicationFormerAddress>(createMortgageLoanApplicationDto.PersonalInformation.FormerAddress);
        //        if (applicationFormerAddress != null)
        //            await _applicationFormerAddressRepository.InsertAsync(applicationFormerAddress);

        //        var applicationMailingAddress = ObjectMapper.Map<MortgageApplicationMailingAddress>(createMortgageLoanApplicationDto.PersonalInformation.MailingAddress);
        //        if (applicationMailingAddress != null)
        //            await _applicationMailingAddressRepository.InsertAsync(applicationMailingAddress);

        //        var applicationAlternateName = ObjectMapper.Map<MortgageApplicationAlternateName>(createMortgageLoanApplicationDto.PersonalInformation.AlternateNames);
        //        if (applicationAlternateName != null)
        //            await _applicationAlternateNameRepository.InsertAsync(applicationAlternateName);

        //        if (createMortgageLoanApplicationDto.PersonalInformation.OtherBorrowers.Any())
        //        {
        //            foreach (var item in createMortgageLoanApplicationDto.PersonalInformation.OtherBorrowers)
        //            {
        //                var borrower = ObjectMapper.Map<MortgageApplicationOtherBorrower>(item);
        //                borrower.PersonalInformationId = createMortgageLoanApplicationDto.PersonalInformation.ContactInformation.PersonalInformationId;
        //                await _applicationOtherBorrowerRepository.InsertAsync(borrower);
        //            }
        //        }

        //        var applicationEmploymentDetail = ObjectMapper.Map<MortgageApplicationEmploymentDetail>(createMortgageLoanApplicationDto.CurrentEmployment);
        //        if (applicationEmploymentDetail != null)
        //        {
        //            var currentEmploymentId = await _applicationEmploymentDetailRepository.InsertAndGetIdAsync(applicationEmploymentDetail);
        //            createMortgageLoanApplicationDto.CurrentEmployment.GrossMonthlyIncome.EmploymentDetailId = currentEmploymentId;
        //        }
        //        var applicationEmploymentIncomeDetail = ObjectMapper.Map<MortgageApplicationEmploymentIncomeDetail>(createMortgageLoanApplicationDto.CurrentEmployment.GrossMonthlyIncome);
        //        if (applicationEmploymentIncomeDetail != null)
        //            await _applicationEmploymentIncomeDetailRepository.InsertAsync(applicationEmploymentIncomeDetail);
        //        //AdditionalEmployment
        //        var applicationAdditionalEmploymentDetail = ObjectMapper.Map<MortgageApplicationAdditionalEmploymentDetail>(createMortgageLoanApplicationDto.AdditionalEmployment);
        //        if (applicationAdditionalEmploymentDetail != null)
        //        {
        //            var additionalEmploymentId = await _applicationAdditionalEmploymentDetailRepository.InsertAndGetIdAsync(applicationAdditionalEmploymentDetail);
        //            createMortgageLoanApplicationDto.AdditionalEmployment.GrossMonthlyIncome.AdditionalEmploymentDetailId = additionalEmploymentId;
        //        }
        //        var applicationAdditionalEmploymentIncomeDetail = ObjectMapper.Map<MortgageApplicationAdditionalEmploymentIncomeDetail>(createMortgageLoanApplicationDto.AdditionalEmployment.GrossMonthlyIncome);
        //        if (applicationAdditionalEmploymentIncomeDetail != null)
        //            await _applicationAdditionalEmploymentIncomeDetailRepository.InsertAsync(applicationAdditionalEmploymentIncomeDetail);
        //        //PreviourEmployment
        //        var applicationPreviousEmploymentDetail = ObjectMapper.Map<MortgageApplicationPreviousEmploymentDetail>(createMortgageLoanApplicationDto.PreviousEmployment);
        //        if (applicationPreviousEmploymentDetail != null)
        //            await _applicationPreviousEmploymentDetailRepository.InsertAsync(applicationPreviousEmploymentDetail);
        //        //IncomeSource
        //        var incomeSource = ObjectMapper.Map<MortgageApplicationIncomeSource>(createMortgageLoanApplicationDto.IncomeOtherSources);
        //        var incomeSourceId = await _applicationIncomeSourceRepository.InsertAndGetIdAsync(incomeSource);
        //        if (createMortgageLoanApplicationDto.IncomeOtherSources.Sources.Any())
        //        {
        //            foreach (var item in createMortgageLoanApplicationDto.IncomeOtherSources.Sources)
        //            {
        //                var source = ObjectMapper.Map<MortgageApplicationSource>(item);
        //                source.IncomeSourceId = incomeSourceId;
        //                await _applicationSourceRepository.InsertAsync(source);
        //            }
        //        }
        //    }
        //    catch (Exception e)
        //    {

        //        throw;
        //    }


        //}
        //public async Task<CreateMortgageLoanApplicationDto> GetMortgageLoanApplication(int applicationId)
        //{
        //    try
        //    {
        //        var applicationDetail = new CreateMortgageLoanApplicationDto();
        //        var application = await _applicationRepository.GetAsync(applicationId);
        //        applicationDetail.MortgageApplication = ObjectMapper.Map<MortgageApplicationDto>(application);
        //        var personalDetail = await _applicationPersonalInformationRepository.GetAll().Where(x => x.MortgageApplicationId == applicationId).FirstOrDefaultAsync();
        //        applicationDetail.PersonalInformation = ObjectMapper.Map<MortgageApplicationPersonalInformationDto>(personalDetail);
        //        var alternateName = await _applicationAlternateNameRepository.GetAll().Where(x => x.PersonalInformationId == personalDetail.Id).FirstOrDefaultAsync();
        //        applicationDetail.PersonalInformation.AlternateNames = ObjectMapper.Map<MortgageApplicationAlternateNameDto>(alternateName);

        //        var currentAddress = await _applicationCurrentAddressRepository.GetAll().Where(x => x.PersonalInformationId == personalDetail.Id).FirstOrDefaultAsync();
        //        applicationDetail.PersonalInformation.CurrentAddress = ObjectMapper.Map<MortgageApplicationCurrentAddressDto>(currentAddress);

        //        var formerAddress = await _applicationFormerAddressRepository.GetAll().Where(x => x.PersonalInformationId == personalDetail.Id).FirstOrDefaultAsync();
        //        applicationDetail.PersonalInformation.FormerAddress = ObjectMapper.Map<MortgageApplicationFormerAddressDto>(formerAddress);

        //        var mailingAddress = await _applicationMailingAddressRepository.GetAll().Where(x => x.PersonalInformationId == personalDetail.Id).FirstOrDefaultAsync();
        //        applicationDetail.PersonalInformation.MailingAddress = ObjectMapper.Map<MortgageApplicationMailingAddressDto>(mailingAddress);

        //        var typeOfCredit = await _applicationTypeOfCreditRepository.GetAll().Where(x => x.PersonalInformationId == personalDetail.Id).FirstOrDefaultAsync();
        //        applicationDetail.PersonalInformation.TypeOfCredit = ObjectMapper.Map<MortgageApplicationTypeOfCreditDto>(typeOfCredit);

        //        var otherBorrowers = await _applicationOtherBorrowerRepository.GetAll().Where(x => x.PersonalInformationId == personalDetail.Id).ToListAsync();
        //        applicationDetail.PersonalInformation.OtherBorrowers = ObjectMapper.Map<List<MortgageApplicationOtherBorrowerDto>>(otherBorrowers);

        //        var contactInformation = await _applicationContactInformationRepository.GetAll().Where(x => x.PersonalInformationId == personalDetail.Id).FirstOrDefaultAsync();
        //        applicationDetail.PersonalInformation.ContactInformation = ObjectMapper.Map<MortgageApplicationContactInformationDto>(contactInformation);

        //        var currentEmploymentDetail = await _applicationEmploymentDetailRepository.GetAll().Where(x => x.PersonalInformationId == personalDetail.Id).FirstOrDefaultAsync();
        //        applicationDetail.CurrentEmployment = ObjectMapper.Map<MortgageApplicationEmploymentDetailDto>(currentEmploymentDetail);

        //        var currentEmploymentIncomeDetail = await _applicationEmploymentIncomeDetailRepository.GetAll().Where(x => x.EmploymentDetailId == currentEmploymentDetail.Id).FirstOrDefaultAsync();
        //        applicationDetail.CurrentEmployment.GrossMonthlyIncome = ObjectMapper.Map<MortgageApplicationEmploymentIncomeDetailDto>(currentEmploymentIncomeDetail);

        //        var additionalEmploymentDetail = await _applicationAdditionalEmploymentDetailRepository.GetAll().Where(x => x.PersonalInformationId == personalDetail.Id).FirstOrDefaultAsync();
        //        applicationDetail.AdditionalEmployment = ObjectMapper.Map<MortgageApplicationAdditionalEmploymentDetailDto>(additionalEmploymentDetail);

        //        var additionalEmploymentIncomeDetail = await _applicationAdditionalEmploymentIncomeDetailRepository.GetAll().Where(x => x.AdditionalEmploymentDetailId == additionalEmploymentDetail.Id).FirstOrDefaultAsync();
        //        applicationDetail.AdditionalEmployment.GrossMonthlyIncome = ObjectMapper.Map<MortgageApplicationAdditionalEmploymentIncomeDetailDto>(additionalEmploymentIncomeDetail);

        //        var previousEmploymentDetail = await _applicationPreviousEmploymentDetailRepository.GetAll().Where(x => x.PersonalInformationId == personalDetail.Id).FirstOrDefaultAsync();
        //        applicationDetail.PreviousEmployment = ObjectMapper.Map<MortgageApplicationPreviousEmploymentDetailDto>(previousEmploymentDetail);

        //        var incomesource = await _applicationIncomeSourceRepository.GetAll().Where(x => x.PersonalInformationId == personalDetail.Id).FirstOrDefaultAsync();
        //        applicationDetail.IncomeOtherSources = ObjectMapper.Map<MortgageApplicationIncomeSourceDto>(incomesource);

        //        var sources = await _applicationSourceRepository.GetAll().Where(x => x.IncomeSourceId == incomesource.Id).ToListAsync();
        //        applicationDetail.IncomeOtherSources.Sources = ObjectMapper.Map<List<MortgageApplicationSourceDto>>(sources);

        //        return applicationDetail;
        //    }
        //    catch (Exception e)
        //    {

        //        throw;
        //    }

        //}
    }
}
