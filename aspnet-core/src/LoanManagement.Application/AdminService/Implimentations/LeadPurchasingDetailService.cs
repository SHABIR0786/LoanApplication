using Abp.Domain.Repositories;
using LoanManagement.codeFirstEntities;
using LoanManagement.EntityFrameworkCore;
using LoanManagement.Features.LeadPurchasingDetail;
using LoanManagement.Services.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.Services.Implementation
{
    public class LeadPurchasingDetailService : Abp.Application.Services.ApplicationService, ILeadPurchasingDetailsService
    {
        private readonly IRepository<LeadApplicationDetailPurchasing, int> repository;

        public LeadPurchasingDetailService(IRepository<LeadApplicationDetailPurchasing,int> repository)
        {
            this.repository = repository;
        }
        public string Add(AddLeadPurchasingDetail request)
        {
            var entity = new LeadApplicationDetailPurchasing
            {
                BirthDate = request.BirthDate,
                CitizenshipId = request.CitizenshipId,
                ConformSsn = request.ConformSsn,
                ContractClosingDate = request.ContractClosingDate,
                ContractType = request.ContractType,
                CreditScore = request.CreditScore,
                CurrentAddress = request.CurrentAddress,
                CurrentCity = request.CurrentCity,
                CurrentMilitaryStatus = request.CurrentMilitaryStatus,
                CurrentReantingType = request.CurrentReantingType,
                CurrentStartLivingDate = request.CurrentStartLivingDate,
                CurrentStateId = request.CurrentStateId,
                CurrentUnit = request.CurrentUnit,
                CurrentZipCode = request.CurrentZipCode,
                DownPaymentAmount = request.DownPaymentAmount,
                DownPaymentPercentage = request.DownPaymentPercentage,
                EstimatedAnnualHomeInsurance = request.EstimatedAnnualHomeInsurance,
                EstimatedAnnualTax = request.EstimatedAnnualTax,
                EstimatedMonthlyExpenses = request.EstimatedMonthlyExpenses,
                EstimatedHomePrice = request.EstimatedHomePrice,
                Ethnicity = request.Ethnicity,
                Etsdate = request.Etsdate,
                IsApplyOwn = request.IsApplyOwn,
                IsCertify = request.IsCertify,
                IsEmployementHistory = request.IsEmployementHistory,
                IsEtsdateinYear = request.IsEtsdateinYear,
                IsMilitaryMember = request.IsMilitaryMember,
                IsOtherSourceOfIncome = request.IsOtherSourceOfIncome,
                IsReadThirdPartyConsent = request.IsReadThirdPartyConsent,
                IsReadEconsent = request.IsReadEconsent,
                IsSomeOneRefer = request.IsSomeOneRefer,
                IsValoanPreviously = request.IsValoanPreviously,
                IsWorkingWithEzalready = request.IsWorkingWithEzalready,
                MaritialStatus = request.MaritialStatus,
                MilitaryBranch = request.MilitaryBranch,
                MonthlyHoadues = request.MonthlyHoadues,
                NewHomeAddress = request.NewHomeAddress,
                NewHomeCity = request.NewHomeCity,
                NewHomeStateId = request.NewHomeStateId,
                NewHomeUnit = request.NewHomeUnit,
                NewHomeZipCode = request.NewHomeZipCode,
                NumberOfDependents = request.NumberOfDependents,
                PersonalEmailAddress = request.PersonalEmailAddress,
                PersonalLegalFirstName = request.PersonalLegalFirstName,
                PersonalMiddleInitial = request.PersonalMiddleInitial,
                PersonalLegalLastName = request.PersonalLegalLastName,
                PersonalPassword = request.PersonalPassword,
                PersonalPhoneNumber = request.PersonalPhoneNumber,
                PropertyEmailAddress = request.PropertyEmailAddress,
                PropertyLegalFirstName = request.PropertyLegalFirstName,
                PropertyLegalLastName = request.PropertyLegalLastName,
                PropertyMiddleInitial = request.PropertyMiddleInitial,
                PropertyPhoneNumber = request.PropertyPhoneNumber,
                Race = request.Race,
                Sex = request.Sex,
                SocialSecurityNumber = request.SocialSecurityNumber,
                Stage = request.Stage,
                TypeOfHome = request.TypeOfHome,
                TypeOfNewHome = request.TypeOfNewHome,
                WhoLivingInHome = request.WhoLivingInHome,
                WorkingOfficerName = request.WorkingOfficerName
            };
               repository.Insert(entity);


            UnitOfWorkManager.Current.SaveChanges();
            return entity.Id.ToString();
        }

        public string Delete(int id)
        {
            var obj =repository.GetAll().Where(s => s.Id == id).FirstOrDefault();

            if (obj == null)
            {
                return AppConsts.NoRecordFound;
            }

            repository.Delete(obj);

            UnitOfWorkManager.Current.SaveChanges();

            return AppConsts.SuccessfullyDeleted;
        }

        public List<UpdateLeadPurchasingDetail> GetAll()
        {
            return repository.GetAll().Select(d => new UpdateLeadPurchasingDetail()
            {
                Id = d.Id,
                BirthDate = d.BirthDate,
                CitizenshipId = d.CitizenshipId,
                ConformSsn = d.ConformSsn,
                ContractClosingDate = d.ContractClosingDate,
                ContractType = d.ContractType,
                CreditScore = d.CreditScore,
                CurrentAddress = d.CurrentAddress,
                CurrentCity = d.CurrentCity,
                CurrentMilitaryStatus = d.CurrentMilitaryStatus,
                CurrentReantingType = d.CurrentReantingType,
                CurrentStartLivingDate = d.CurrentStartLivingDate,
                CurrentStateId = d.CurrentStateId,
                CurrentUnit = d.CurrentUnit,
                CurrentZipCode = d.CurrentZipCode,
                DownPaymentAmount = d.DownPaymentAmount,
                DownPaymentPercentage = d.DownPaymentPercentage,
                EstimatedAnnualHomeInsurance = d.EstimatedAnnualHomeInsurance,
                EstimatedAnnualTax = d.EstimatedAnnualTax,
                EstimatedMonthlyExpenses = d.EstimatedMonthlyExpenses,
                EstimatedHomePrice = d.EstimatedHomePrice,
                Ethnicity = d.Ethnicity,
                Etsdate = d.Etsdate,
                IsApplyOwn = d.IsApplyOwn,
                IsCertify = d.IsCertify,
                IsEmployementHistory = d.IsEmployementHistory,
                IsEtsdateinYear = d.IsEtsdateinYear,
                IsMilitaryMember = d.IsMilitaryMember,
                IsOtherSourceOfIncome = d.IsOtherSourceOfIncome,
                IsReadThirdPartyConsent = d.IsReadThirdPartyConsent,
                IsReadEconsent = d.IsReadEconsent,
                IsSomeOneRefer = d.IsSomeOneRefer,
                IsValoanPreviously = d.IsValoanPreviously,
                IsWorkingWithEzalready = d.IsWorkingWithEzalready,
                MaritialStatus = d.MaritialStatus,
                MilitaryBranch = d.MilitaryBranch,
                MonthlyHoadues = d.MonthlyHoadues,
                NewHomeAddress = d.NewHomeAddress,
                NewHomeCity = d.NewHomeCity,
                NewHomeStateId = d.NewHomeStateId,
                NewHomeUnit = d.NewHomeUnit,
                NewHomeZipCode = d.NewHomeZipCode,
                NumberOfDependents = d.NumberOfDependents,
                PersonalEmailAddress = d.PersonalEmailAddress,
                PersonalLegalFirstName = d.PersonalLegalFirstName,
                PersonalMiddleInitial = d.PersonalMiddleInitial,
                PersonalLegalLastName = d.PersonalLegalLastName,
                PersonalPassword = d.PersonalPassword,
                PersonalPhoneNumber = d.PersonalPhoneNumber,
                PropertyEmailAddress = d.PropertyEmailAddress,
                PropertyLegalFirstName = d.PropertyLegalFirstName,
                PropertyLegalLastName = d.PropertyLegalLastName,
                PropertyMiddleInitial = d.PropertyMiddleInitial,
                PropertyPhoneNumber = d.PropertyPhoneNumber,
                Race = d.Race,
                Sex = d.Sex,
                SocialSecurityNumber = d.SocialSecurityNumber,
                Stage = d.Stage,
                TypeOfHome = d.TypeOfHome,
                TypeOfNewHome = d.TypeOfNewHome,
                WhoLivingInHome = d.WhoLivingInHome,
                WorkingOfficerName = d.WorkingOfficerName
            }).ToList();
        }

        public UpdateLeadPurchasingDetail GetById(int id)
        {
            return repository.GetAll().Where(s => s.Id == id).Select(d => new UpdateLeadPurchasingDetail()
            {
                Id = d.Id,
                BirthDate = d.BirthDate,
                CitizenshipId = d.CitizenshipId,
                ConformSsn = d.ConformSsn,
                ContractClosingDate = d.ContractClosingDate,
                ContractType = d.ContractType,
                CreditScore = d.CreditScore,
                CurrentAddress = d.CurrentAddress,
                CurrentCity = d.CurrentCity,
                CurrentMilitaryStatus = d.CurrentMilitaryStatus,
                CurrentReantingType = d.CurrentReantingType,
                CurrentStartLivingDate = d.CurrentStartLivingDate,
                CurrentStateId = d.CurrentStateId,
                CurrentUnit = d.CurrentUnit,
                CurrentZipCode = d.CurrentZipCode,
                DownPaymentAmount = d.DownPaymentAmount,
                DownPaymentPercentage = d.DownPaymentPercentage,
                EstimatedAnnualHomeInsurance = d.EstimatedAnnualHomeInsurance,
                EstimatedAnnualTax = d.EstimatedAnnualTax,
                EstimatedMonthlyExpenses = d.EstimatedMonthlyExpenses,
                EstimatedHomePrice = d.EstimatedHomePrice,
                Ethnicity = d.Ethnicity,
                Etsdate = d.Etsdate,
                IsApplyOwn = d.IsApplyOwn,
                IsCertify = d.IsCertify,
                IsEmployementHistory = d.IsEmployementHistory,
                IsEtsdateinYear = d.IsEtsdateinYear,
                IsMilitaryMember = d.IsMilitaryMember,
                IsOtherSourceOfIncome = d.IsOtherSourceOfIncome,
                IsReadThirdPartyConsent = d.IsReadThirdPartyConsent,
                IsReadEconsent = d.IsReadEconsent,
                IsSomeOneRefer = d.IsSomeOneRefer,
                IsValoanPreviously = d.IsValoanPreviously,
                IsWorkingWithEzalready = d.IsWorkingWithEzalready,
                MaritialStatus = d.MaritialStatus,
                MilitaryBranch = d.MilitaryBranch,
                MonthlyHoadues = d.MonthlyHoadues,
                NewHomeAddress = d.NewHomeAddress,
                NewHomeCity = d.NewHomeCity,
                NewHomeStateId = d.NewHomeStateId,
                NewHomeUnit = d.NewHomeUnit,
                NewHomeZipCode = d.NewHomeZipCode,
                NumberOfDependents = d.NumberOfDependents,
                PersonalEmailAddress = d.PersonalEmailAddress,
                PersonalLegalFirstName = d.PersonalLegalFirstName,
                PersonalMiddleInitial = d.PersonalMiddleInitial,
                PersonalLegalLastName = d.PersonalLegalLastName,
                PersonalPassword = d.PersonalPassword,
                PersonalPhoneNumber = d.PersonalPhoneNumber,
                PropertyEmailAddress = d.PropertyEmailAddress,
                PropertyLegalFirstName = d.PropertyLegalFirstName,
                PropertyLegalLastName = d.PropertyLegalLastName,
                PropertyMiddleInitial = d.PropertyMiddleInitial,
                PropertyPhoneNumber = d.PropertyPhoneNumber,
                Race = d.Race,
                Sex = d.Sex,
                SocialSecurityNumber = d.SocialSecurityNumber,
                Stage = d.Stage,
                TypeOfHome = d.TypeOfHome,
                TypeOfNewHome = d.TypeOfNewHome,
                WhoLivingInHome = d.WhoLivingInHome,
                WorkingOfficerName = d.WorkingOfficerName
            }).FirstOrDefault();
        }

        public string Update(UpdateLeadPurchasingDetail request)
        {

            var obj = repository.GetAll().Where(s => s.Id == request.Id).FirstOrDefault();

            if (obj == null)
            {
                return AppConsts.NoRecordFound;
            }

            obj.BirthDate = request.BirthDate;
            obj.CitizenshipId = request.CitizenshipId;
            obj.ConformSsn = request.ConformSsn;
            obj.ContractClosingDate = request.ContractClosingDate;
            obj.ContractType = request.ContractType;
            obj.CreditScore = request.CreditScore;
            obj.CurrentAddress = request.CurrentAddress;
            obj.CurrentCity = request.CurrentCity;
            obj.CurrentMilitaryStatus = request.CurrentMilitaryStatus;
            obj.CurrentReantingType = request.CurrentReantingType;
            obj.CurrentStartLivingDate = request.CurrentStartLivingDate;
            obj.CurrentStateId = request.CurrentStateId;
            obj.CurrentUnit = request.CurrentUnit;
            obj.CurrentZipCode = request.CurrentZipCode;
            obj.DownPaymentAmount = request.DownPaymentAmount;
            obj.DownPaymentPercentage = request.DownPaymentPercentage;
            obj.EstimatedAnnualHomeInsurance = request.EstimatedAnnualHomeInsurance;
            obj.EstimatedAnnualTax = request.EstimatedAnnualTax;
            obj.EstimatedMonthlyExpenses = request.EstimatedMonthlyExpenses;
            obj.EstimatedHomePrice = request.EstimatedHomePrice;
            obj.Ethnicity = request.Ethnicity;
            obj.Etsdate = request.Etsdate;
            obj.IsApplyOwn = request.IsApplyOwn;
            obj.IsCertify = request.IsCertify;
            obj.IsEmployementHistory = request.IsEmployementHistory;
            obj.IsEtsdateinYear = request.IsEtsdateinYear;
            obj.IsMilitaryMember = request.IsMilitaryMember;
            obj.IsOtherSourceOfIncome = request.IsOtherSourceOfIncome;
            obj.IsReadThirdPartyConsent = request.IsReadThirdPartyConsent;
            obj.IsReadEconsent = request.IsReadEconsent;
            obj.IsSomeOneRefer = request.IsSomeOneRefer;
            obj.IsValoanPreviously = request.IsValoanPreviously;
            obj.IsWorkingWithEzalready = request.IsWorkingWithEzalready;
            obj.MaritialStatus = request.MaritialStatus;
            obj.MilitaryBranch = request.MilitaryBranch;
            obj.MonthlyHoadues = request.MonthlyHoadues;
            obj.NewHomeAddress = request.NewHomeAddress;
            obj.NewHomeCity = request.NewHomeCity;
            obj.NewHomeStateId = request.NewHomeStateId;
            obj.NewHomeUnit = request.NewHomeUnit;
            obj.NewHomeZipCode = request.NewHomeZipCode;
            obj.NumberOfDependents = request.NumberOfDependents;
            obj.PersonalEmailAddress = request.PersonalEmailAddress;
            obj.PersonalLegalFirstName = request.PersonalLegalFirstName;
            obj.PersonalMiddleInitial = request.PersonalMiddleInitial;
            obj.PersonalLegalLastName = request.PersonalLegalLastName;
            obj.PersonalPassword = request.PersonalPassword;
            obj.PersonalPhoneNumber = request.PersonalPhoneNumber;
            obj.PropertyEmailAddress = request.PropertyEmailAddress;
            obj.PropertyLegalFirstName = request.PropertyLegalFirstName;
            obj.PropertyLegalLastName = request.PropertyLegalLastName;
            obj.PropertyMiddleInitial = request.PropertyMiddleInitial;
            obj.PropertyPhoneNumber = request.PropertyPhoneNumber;
            obj.Race = request.Race;
            obj.Sex = request.Sex;
            obj.SocialSecurityNumber = request.SocialSecurityNumber;
            obj.Stage = request.Stage;
            obj.TypeOfHome = request.TypeOfHome;
            obj.TypeOfNewHome = request.TypeOfNewHome;
            obj.WhoLivingInHome = request.WhoLivingInHome;
            obj.WorkingOfficerName = request.WorkingOfficerName;

            repository.Update(obj);

            UnitOfWorkManager.Current.SaveChanges();

            return AppConsts.SuccessfullyUpdated;
        }
    }
}
