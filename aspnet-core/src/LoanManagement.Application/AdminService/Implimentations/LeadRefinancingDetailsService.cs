using Abp.Domain.Repositories;
using LoanManagement.codeFirstEntities;
using LoanManagement.EntityFrameworkCore;
using LoanManagement.Features.LeadRefinancingDetails;
using LoanManagement.Services.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.Services.Implementation
{
    public class LeadRefinancingDetailsService : Abp.Application.Services.ApplicationService, ILeadRefinancingDetailsService
    {
        private readonly IRepository<LeadApplicationDetailRefinancing, int> repository;

        public LeadRefinancingDetailsService(IRepository<LeadApplicationDetailRefinancing,int> repository)
        {
            this.repository = repository;
        }
        public string Add(AddLeadRefinancingDetails request)
        {
            var entity = new LeadApplicationDetailRefinancing
            {
                BirthDate = request.BirthDate,
                CitizenshipId = request.CitizenshipId,
                ConformSsn = request.ConformSsn,
                CreditScore = request.CreditScore,
                CurrentAddress = request.CurrentAddress,
                CurrentCity = request.CurrentCity,
                CurrentMilitaryStatus = request.CurrentMilitaryStatus,
                CurrentReantingType = request.CurrentReantingType,
                CurrentStartLivingDate = request.CurrentStartLivingDate,
                CurrentStateId = request.CurrentStateId,
                CurrentUnit = request.CurrentUnit,
                CurrentZipCode = request.CurrentZipCode,
                EstimatedAnnualHomeInsurance = request.EstimatedAnnualHomeInsurance,
                EstimatedAnnualTax = request.EstimatedAnnualTax,
                EstimatedMonthlyExpenses = request.EstimatedMonthlyExpenses,
                Ethnicity = request.Ethnicity,
                Etsdate = request.Etsdate,
                IsApplyOwn = request.IsApplyOwn,
                IsCertify = request.IsCertify,
                IsEmployementHistory = request.IsEmployementHistory,
                IsEtsdateinYear = request.IsEtsdateinYear,
                IsMilitaryMember = request.IsMilitaryMember,
                IsReadThirdPartyConsent = request.IsReadThirdPartyConsent,
                IsReadEconsent = request.IsReadEconsent,
                IsValoanPreviously = request.IsValoanPreviously,
                IsWorkingWithEzalready = request.IsWorkingWithEzalready,
                MaritialStatus = request.MaritialStatus,
                MilitaryBranch = request.MilitaryBranch,
                MonthlyHoadues = request.MonthlyHoadues,
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
                TypeOfHome = request.TypeOfHome,
                WhoLivingInHome = request.WhoLivingInHome,
                WorkingOfficerName = request.WorkingOfficerName,
                CurrentlyUsingHomeAs = request.CurrentlyUsingHomeAs,
                FirstDependantAge = request.FirstDependantAge,
                IsAddressSameAsPrimaryBorrower = request.IsAddressSameAsPrimaryBorrower,
                IsCoBorrowerHaveShareIncome = request.IsCoBorrowerHaveShareIncome,
                IsCurrentlyLivingOnRefinancingProperty = request.IsCurrentlyLivingOnRefinancingProperty,
                IsLegalSpouse = request.IsLegalSpouse,
                IsSomeoneRefer = request.IsSomeoneRefer,
                NewLoanEstimateAmount = request.NewLoanEstimateAmount,
                ObjectiveReason = request.ObjectiveReason,
                OrignalPurchasedPrice = request.OrignalPurchasedPrice,
                PersonalAddress = request.PersonalAddress,
                PersonalCity = request.PersonalCity,
                PersonalReantingType = request.PersonalReantingType,
                PersonalStartLivingDate = request.PersonalStartLivingDate,
                PersonalStateId = request.PersonalStateId,
                PersonalUnit = request.PersonalUnit,
                PersonalZipCode = request.PersonalZipCode,
                PropertCashOutAmount = request.PropertCashOutAmount,
                PropertyAddress = request.PropertyAddress,
                PropertyCity = request.PropertyCity,
                PropertyCountryId = request.PropertyCountryId,
                PropertyEstimatedValue = request.PropertyEstimatedValue,
                PropertyLoanBalance = request.PropertyLoanBalance,
                PropertyPassword = request.PropertyPassword,
                PropertyStateId = request.PropertyStateId,
                PropertyUnit = request.PropertyUnit,
                PropertyZip = request.PropertyZip,
                RefferedBy = request.RefferedBy,
                YearHomePurchased = request.YearHomePurchased
            };
              repository.Insert(entity);

            UnitOfWorkManager.Current.SaveChanges();
            return entity.Id.ToString();
        }

        public string Delete(int id)
        {
            var obj = repository.GetAll().Where(s => s.Id == id).FirstOrDefault();

            if (obj == null)
            {
                return AppConsts.NoRecordFound;
            }

           repository.Delete(obj);
            UnitOfWorkManager.Current.SaveChanges();

            return AppConsts.SuccessfullyDeleted;
        }

        public List<UpdateLeadRefinancingDetails> GetAll()
        {
            return repository.GetAll().Select(d => new UpdateLeadRefinancingDetails()
            {
                Id = d.Id,
                BirthDate = d.BirthDate,
                CitizenshipId = d.CitizenshipId,
                ConformSsn = d.ConformSsn,
                CreditScore = d.CreditScore,
                CurrentAddress = d.CurrentAddress,
                CurrentCity = d.CurrentCity,
                CurrentMilitaryStatus = d.CurrentMilitaryStatus,
                CurrentReantingType = d.CurrentReantingType,
                CurrentStartLivingDate = d.CurrentStartLivingDate,
                CurrentStateId = d.CurrentStateId,
                CurrentUnit = d.CurrentUnit,
                CurrentZipCode = d.CurrentZipCode,
                EstimatedAnnualHomeInsurance = d.EstimatedAnnualHomeInsurance,
                EstimatedAnnualTax = d.EstimatedAnnualTax,
                EstimatedMonthlyExpenses = d.EstimatedMonthlyExpenses,
                Ethnicity = d.Ethnicity,
                Etsdate = d.Etsdate,
                IsApplyOwn = d.IsApplyOwn,
                IsCertify = d.IsCertify,
                IsEmployementHistory = d.IsEmployementHistory,
                IsEtsdateinYear = d.IsEtsdateinYear,
                IsMilitaryMember = d.IsMilitaryMember,
                IsReadThirdPartyConsent = d.IsReadThirdPartyConsent,
                IsReadEconsent = d.IsReadEconsent,
                IsValoanPreviously = d.IsValoanPreviously,
                IsWorkingWithEzalready = d.IsWorkingWithEzalready,
                MaritialStatus = d.MaritialStatus,
                MilitaryBranch = d.MilitaryBranch,
                MonthlyHoadues = d.MonthlyHoadues,
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
                TypeOfHome = d.TypeOfHome,
                WhoLivingInHome = d.WhoLivingInHome,
                WorkingOfficerName = d.WorkingOfficerName,
                CurrentlyUsingHomeAs = d.CurrentlyUsingHomeAs,
                FirstDependantAge = d.FirstDependantAge,
                IsAddressSameAsPrimaryBorrower = d.IsAddressSameAsPrimaryBorrower,
                IsCoBorrowerHaveShareIncome = d.IsCoBorrowerHaveShareIncome,
                IsCurrentlyLivingOnRefinancingProperty = d.IsCurrentlyLivingOnRefinancingProperty,
                IsLegalSpouse = d.IsLegalSpouse,
                IsSomeoneRefer = d.IsSomeoneRefer,
                NewLoanEstimateAmount = d.NewLoanEstimateAmount,
                ObjectiveReason = d.ObjectiveReason,
                OrignalPurchasedPrice = d.OrignalPurchasedPrice,
                PersonalAddress = d.PersonalAddress,
                PersonalCity = d.PersonalCity,
                PersonalReantingType = d.PersonalReantingType,
                PersonalStartLivingDate = d.PersonalStartLivingDate,
                PersonalStateId = d.PersonalStateId,
                PersonalUnit = d.PersonalUnit,
                PersonalZipCode = d.PersonalZipCode,
                PropertCashOutAmount = d.PropertCashOutAmount,
                PropertyAddress = d.PropertyAddress,
                PropertyCity = d.PropertyCity,
                PropertyCountryId = d.PropertyCountryId,
                PropertyEstimatedValue = d.PropertyEstimatedValue,
                PropertyLoanBalance = d.PropertyLoanBalance,
                PropertyPassword = d.PropertyPassword,
                PropertyStateId = d.PropertyStateId,
                PropertyUnit = d.PropertyUnit,
                PropertyZip = d.PropertyZip,
                RefferedBy = d.RefferedBy,
                YearHomePurchased = d.YearHomePurchased
            }).ToList();
        }

        public UpdateLeadRefinancingDetails GetById(int id)
        {
            return repository.GetAll().Where(s => s.Id == id).Select(d => new UpdateLeadRefinancingDetails()
            {
                Id = d.Id,
                BirthDate = d.BirthDate,
                CitizenshipId = d.CitizenshipId,
                ConformSsn = d.ConformSsn,
                CreditScore = d.CreditScore,
                CurrentAddress = d.CurrentAddress,
                CurrentCity = d.CurrentCity,
                CurrentMilitaryStatus = d.CurrentMilitaryStatus,
                CurrentReantingType = d.CurrentReantingType,
                CurrentStartLivingDate = d.CurrentStartLivingDate,
                CurrentStateId = d.CurrentStateId,
                CurrentUnit = d.CurrentUnit,
                CurrentZipCode = d.CurrentZipCode,
                EstimatedAnnualHomeInsurance = d.EstimatedAnnualHomeInsurance,
                EstimatedAnnualTax = d.EstimatedAnnualTax,
                EstimatedMonthlyExpenses = d.EstimatedMonthlyExpenses,
                Ethnicity = d.Ethnicity,
                Etsdate = d.Etsdate,
                IsApplyOwn = d.IsApplyOwn,
                IsCertify = d.IsCertify,
                IsEmployementHistory = d.IsEmployementHistory,
                IsEtsdateinYear = d.IsEtsdateinYear,
                IsMilitaryMember = d.IsMilitaryMember,
                IsReadThirdPartyConsent = d.IsReadThirdPartyConsent,
                IsReadEconsent = d.IsReadEconsent,
                IsValoanPreviously = d.IsValoanPreviously,
                IsWorkingWithEzalready = d.IsWorkingWithEzalready,
                MaritialStatus = d.MaritialStatus,
                MilitaryBranch = d.MilitaryBranch,
                MonthlyHoadues = d.MonthlyHoadues,
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
                TypeOfHome = d.TypeOfHome,
                WhoLivingInHome = d.WhoLivingInHome,
                WorkingOfficerName = d.WorkingOfficerName,
                CurrentlyUsingHomeAs = d.CurrentlyUsingHomeAs,
                FirstDependantAge = d.FirstDependantAge,
                IsAddressSameAsPrimaryBorrower = d.IsAddressSameAsPrimaryBorrower,
                IsCoBorrowerHaveShareIncome = d.IsCoBorrowerHaveShareIncome,
                IsCurrentlyLivingOnRefinancingProperty = d.IsCurrentlyLivingOnRefinancingProperty,
                IsLegalSpouse = d.IsLegalSpouse,
                IsSomeoneRefer = d.IsSomeoneRefer,
                NewLoanEstimateAmount = d.NewLoanEstimateAmount,
                ObjectiveReason = d.ObjectiveReason,
                OrignalPurchasedPrice = d.OrignalPurchasedPrice,
                PersonalAddress = d.PersonalAddress,
                PersonalCity = d.PersonalCity,
                PersonalReantingType = d.PersonalReantingType,
                PersonalStartLivingDate = d.PersonalStartLivingDate,
                PersonalStateId = d.PersonalStateId,
                PersonalUnit = d.PersonalUnit,
                PersonalZipCode = d.PersonalZipCode,
                PropertCashOutAmount = d.PropertCashOutAmount,
                PropertyAddress = d.PropertyAddress,
                PropertyCity = d.PropertyCity,
                PropertyCountryId = d.PropertyCountryId,
                PropertyEstimatedValue = d.PropertyEstimatedValue,
                PropertyLoanBalance = d.PropertyLoanBalance,
                PropertyPassword = d.PropertyPassword,
                PropertyStateId = d.PropertyStateId,
                PropertyUnit = d.PropertyUnit,
                PropertyZip = d.PropertyZip,
                RefferedBy = d.RefferedBy,
                YearHomePurchased = d.YearHomePurchased
            }).FirstOrDefault();
        }

        public string Update(UpdateLeadRefinancingDetails request)
        {

            var obj = repository.GetAll().Where(s => s.Id == request.Id).FirstOrDefault();

            if (obj == null)
            {
                return AppConsts.NoRecordFound;
            }

            obj.BirthDate = request.BirthDate;
            obj.CitizenshipId = request.CitizenshipId;
            obj.ConformSsn = request.ConformSsn;
            obj.CreditScore = request.CreditScore;
            obj.CurrentAddress = request.CurrentAddress;
            obj.CurrentCity = request.CurrentCity;
            obj.CurrentMilitaryStatus = request.CurrentMilitaryStatus;
            obj.CurrentReantingType = request.CurrentReantingType;
            obj.CurrentStartLivingDate = request.CurrentStartLivingDate;
            obj.CurrentStateId = request.CurrentStateId;
            obj.CurrentUnit = request.CurrentUnit;
            obj.CurrentZipCode = request.CurrentZipCode;
            obj.EstimatedAnnualHomeInsurance = request.EstimatedAnnualHomeInsurance;
            obj.EstimatedAnnualTax = request.EstimatedAnnualTax;
            obj.EstimatedMonthlyExpenses = request.EstimatedMonthlyExpenses;
            obj.Ethnicity = request.Ethnicity;
            obj.Etsdate = request.Etsdate;
            obj.IsApplyOwn = request.IsApplyOwn;
            obj.IsCertify = request.IsCertify;
            obj.IsEmployementHistory = request.IsEmployementHistory;
            obj.IsEtsdateinYear = request.IsEtsdateinYear;
            obj.IsMilitaryMember = request.IsMilitaryMember;
            obj.IsReadThirdPartyConsent = request.IsReadThirdPartyConsent;
            obj.IsReadEconsent = request.IsReadEconsent;
            obj.IsValoanPreviously = request.IsValoanPreviously;
            obj.IsWorkingWithEzalready = request.IsWorkingWithEzalready;
            obj.MaritialStatus = request.MaritialStatus;
            obj.MilitaryBranch = request.MilitaryBranch;
            obj.MonthlyHoadues = request.MonthlyHoadues;
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
            obj.TypeOfHome = request.TypeOfHome;
            obj.WhoLivingInHome = request.WhoLivingInHome;
            obj.WorkingOfficerName = request.WorkingOfficerName;
            obj.CurrentlyUsingHomeAs = request.CurrentlyUsingHomeAs;
            obj.FirstDependantAge = request.FirstDependantAge;
            obj.IsAddressSameAsPrimaryBorrower = request.IsAddressSameAsPrimaryBorrower;
            obj.IsCoBorrowerHaveShareIncome = request.IsCoBorrowerHaveShareIncome;
            obj.IsCurrentlyLivingOnRefinancingProperty = request.IsCurrentlyLivingOnRefinancingProperty;
            obj.IsLegalSpouse = request.IsLegalSpouse;
            obj.IsSomeoneRefer = request.IsSomeoneRefer;
            obj.NewLoanEstimateAmount = request.NewLoanEstimateAmount;
            obj.ObjectiveReason = request.ObjectiveReason;
            obj.OrignalPurchasedPrice = request.OrignalPurchasedPrice;
            obj.PersonalAddress = request.PersonalAddress;
            obj.PersonalCity = request.PersonalCity;
            obj.PersonalReantingType = request.PersonalReantingType;
            obj.PersonalStartLivingDate = request.PersonalStartLivingDate;
            obj.PersonalStateId = request.PersonalStateId;
            obj.PersonalUnit = request.PersonalUnit;
            obj.PersonalZipCode = request.PersonalZipCode;
            obj.PropertCashOutAmount = request.PropertCashOutAmount;
            obj.PropertyAddress = request.PropertyAddress;
            obj.PropertyCity = request.PropertyCity;
            obj.PropertyCountryId = request.PropertyCountryId;
            obj.PropertyEstimatedValue = request.PropertyEstimatedValue;
            obj.PropertyLoanBalance = request.PropertyLoanBalance;
            obj.PropertyPassword = request.PropertyPassword;
            obj.PropertyStateId = request.PropertyStateId;
            obj.PropertyUnit = request.PropertyUnit;
            obj.PropertyZip = request.PropertyZip;
            obj.RefferedBy = request.RefferedBy;
            obj.YearHomePurchased = request.YearHomePurchased;

            repository.Update(obj);
            UnitOfWorkManager.Current.SaveChanges();

            return AppConsts.SuccessfullyUpdated;
        }
    }
}
