using Microsoft.EntityFrameworkCore;
using System.Linq;

using LoanManagement.Services.Interface;
using LoanManagement.EntityFrameworkCore;
using System.Collections.Generic;
using LoanManagement.Features.Loan.LoanPropertyGiftType;
using LoanManagement.Features.Loan.LoanPropertyOccupancy;
using LoanManagement.Features.Loan.MortageLoanType;
using LoanManagement.Features.Loan.LoanAndPropertyInformationGift;
using LoanManagement.Features.Loan.LoanAndPropertyInformation;
using LoanManagement.Features.Loan.LoanOriginatorInformation;
using LoanManagement.Features.Loan.LoanAndPropertyInformationOtherMortageLoan;
using LoanManagement.Features.Loan.LoanAndPropertyInformationRentalIncome;
using LoanManagement.Features.Loan.MortageLoanOnProperty;
using LoanManagement.Features.PdfData;
using LoanManagement.Features.Application.MilitaryService;
using System.Net.Mail;
using Pdf = iTextSharp.text.pdf;
using System.IO;
using System;
using Abp.Runtime.Validation;
using LoanManagement.CredcoServices;
using LoanManagement.Data;
using LoanManagement.DatabaseServices.Interfaces;
using LoanManagement.Enums;
using LoanManagement.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Abp.Domain.Repositories;
using LoanManagement.codeFirstEntities;

namespace LoanManagement.Services.Implementation
{
	public class LoanService : Abp.Application.Services.ApplicationService, ILoanService
	{
		private readonly IRepository<LoanPropertyGiftType, int> repository;
		public IWebHostEnvironment _hostingEnvironment;
		private readonly IRepository<LoanPropertyOccupancy, int> loanPropertyOccupancyRepo;
		private readonly IRepository<MortageLoanType, int> mortageLoanTypeRepo;
		private readonly IRepository<LoanAndPropertyInformationGift, int> loanAndPropertyInformationGiftRepo;
		private readonly IRepository<LoanAndPropertyInformation, int> loanAndPropertyInformationRepo;
		private readonly IRepository<LoanOriginatorInformation, int> loanOriginatorInformationRepo;
		private readonly IRepository<LoanAndPropertyInformationOtherMortageLoan, int> loanAndPropertyInformationOtherMortageLoanRepo;
		private readonly IRepository<LoanAndPropertyInformationRentalIncome, int> loanAndPropertyInformationRentalIncomeRepo;
		private readonly IRepository<MortageLoanOnProperty, int> mortageLoanOnPropertyRepo;

		public LoanService(IRepository<LoanPropertyGiftType,int> repository, IWebHostEnvironment hostingEnvironment,
			IRepository<LoanPropertyOccupancy,int> loanPropertyOccupancyRepo,
			IRepository<MortageLoanType,int> mortageLoanTypeRepo,
			IRepository<LoanAndPropertyInformationGift,int> loanAndPropertyInformationGiftRepo,
			IRepository<LoanAndPropertyInformation,int> loanAndPropertyInformationRepo,
			IRepository<LoanOriginatorInformation,int> loanOriginatorInformationRepo,
			IRepository<LoanAndPropertyInformationOtherMortageLoan,int> loanAndPropertyInformationOtherMortageLoanRepo,
			IRepository<LoanAndPropertyInformationRentalIncome,int> loanAndPropertyInformationRentalIncomeRepo,
			IRepository<MortageLoanOnProperty,int> mortageLoanOnPropertyRepo)
		{
			this.repository = repository;
			_hostingEnvironment = hostingEnvironment;
			this.loanPropertyOccupancyRepo = loanPropertyOccupancyRepo;
			this.mortageLoanTypeRepo = mortageLoanTypeRepo;
			this.loanAndPropertyInformationGiftRepo = loanAndPropertyInformationGiftRepo;
			this.loanAndPropertyInformationRepo = loanAndPropertyInformationRepo;
			this.loanOriginatorInformationRepo = loanOriginatorInformationRepo;
			this.loanAndPropertyInformationOtherMortageLoanRepo = loanAndPropertyInformationOtherMortageLoanRepo;
			this.loanAndPropertyInformationRentalIncomeRepo = loanAndPropertyInformationRentalIncomeRepo;
			this.mortageLoanOnPropertyRepo = mortageLoanOnPropertyRepo;
		}

		#region Loan Property Gift Type

		public string AddLoanPropertyGiftType(AddLoanPropertyGiftTypeRequest request)
		{
			repository.Insert(new codeFirstEntities.LoanPropertyGiftType()
			{
				LoanPropertyGiftType1 = request.LoanPropertyGiftType1
			});

            UnitOfWorkManager.Current.SaveChanges();
            return AppConsts.SuccessfullyInserted;
		}

		public string UpdateLoanPropertyGiftType(UpdateLoanPropertyGiftTypeRequest request)
		{
			var objLoanPropertyGiftType = repository.GetAll().Where(s => s.Id == request.Id).FirstOrDefault();

			if (objLoanPropertyGiftType == null)
			{
				return AppConsts.NoRecordFound;
			}

			objLoanPropertyGiftType.LoanPropertyGiftType1 = request.LoanPropertyGiftType1;

			repository.Update(objLoanPropertyGiftType);
            UnitOfWorkManager.Current.SaveChanges();

            return AppConsts.SuccessfullyUpdated;
		}

		public string DeleteLoanPropertyGiftType(int id)
		{
			var objLoanPropertyGiftType = repository.GetAll().Where(s => s.Id == id).FirstOrDefault();

			if (objLoanPropertyGiftType == null)
			{
				return AppConsts.NoRecordFound;
			}

			repository.Delete(objLoanPropertyGiftType);
            UnitOfWorkManager.Current.SaveChanges();

            return AppConsts.SuccessfullyDeleted;
		}

		public List<UpdateLoanPropertyGiftTypeRequest> GetLoanPropertyGiftTypes()
		{
			return repository.GetAll().Select(d => new UpdateLoanPropertyGiftTypeRequest()
			{
				Id = d.Id,
				LoanPropertyGiftType1 = d.LoanPropertyGiftType1
			}).ToList();
		}

		public UpdateLoanPropertyGiftTypeRequest GetLoanPropertyGiftTypeById(int id)
		{
			return repository.GetAll().Where(s => s.Id == id).Select(d => new UpdateLoanPropertyGiftTypeRequest()
			{
				Id = d.Id,
				LoanPropertyGiftType1 = d.LoanPropertyGiftType1
			}).FirstOrDefault();
		}

		#endregion

		#region Loan Property Occupancy

		public string AddLoanPropertyOccupancy(AddLoanPropertyOccupancyRequest request)
		{
			loanPropertyOccupancyRepo.Insert(new codeFirstEntities.LoanPropertyOccupancy()
			{
				LoanPropertyOccupancy1 = request.LoanPropertyOccupancy1
			});

            UnitOfWorkManager.Current.SaveChanges();
            return AppConsts.SuccessfullyInserted;
		}

		public string UpdateLoanPropertyOccupancy(UpdateLoanPropertyOccupancyRequest request)
		{
			var objLoanPropertyOccupancy = loanPropertyOccupancyRepo.GetAll().Where(s => s.Id == request.Id).FirstOrDefault();

			if (objLoanPropertyOccupancy == null)
			{
				return AppConsts.NoRecordFound;
			}

			objLoanPropertyOccupancy.LoanPropertyOccupancy1 = request.LoanPropertyOccupancy1;

			loanPropertyOccupancyRepo.Update(objLoanPropertyOccupancy);
            UnitOfWorkManager.Current.SaveChanges();

            return AppConsts.SuccessfullyUpdated;
		}

		public string DeleteLoanPropertyOccupancy(int id)
		{
			var objLoanPropertyOccupancy = loanPropertyOccupancyRepo.GetAll().Where(s => s.Id == id).FirstOrDefault();

			if (objLoanPropertyOccupancy == null)
			{
				return AppConsts.NoRecordFound;
			}

			loanPropertyOccupancyRepo.Delete(objLoanPropertyOccupancy);
            UnitOfWorkManager.Current.SaveChanges();

            return AppConsts.SuccessfullyDeleted;
		}

		public List<UpdateLoanPropertyOccupancyRequest> GetLoanPropertyOccupancies()
		{
			return loanPropertyOccupancyRepo.GetAll().Select(d => new UpdateLoanPropertyOccupancyRequest()
			{
				Id = d.Id,
				LoanPropertyOccupancy1 = d.LoanPropertyOccupancy1
			}).ToList();
		}

		public UpdateLoanPropertyOccupancyRequest GetLoanPropertyOccupancyById(int id)
		{
			return loanPropertyOccupancyRepo.GetAll().Where(s => s.Id == id).Select(d => new UpdateLoanPropertyOccupancyRequest()
			{
				Id = d.Id,
				LoanPropertyOccupancy1 = d.LoanPropertyOccupancy1
			}).FirstOrDefault();
		}

		#endregion

		#region Mortage Loan Type

		public string AddMortageLoanType(AddMortageLoanTypeRequest request)
		{
			mortageLoanTypeRepo.Insert(new codeFirstEntities.MortageLoanType()
			{
				MortageLoanTypesId = request.MortageLoanTypesId
			});

            UnitOfWorkManager.Current.SaveChanges();
            return AppConsts.SuccessfullyInserted;
		}

		public string UpdateMortageLoanType(UpdateMortageLoanTypeRequest request)
		{
			var objMortageLoanType = mortageLoanTypeRepo.GetAll().Where(s => s.Id == request.Id).FirstOrDefault();

			if (objMortageLoanType == null)
			{
				return AppConsts.NoRecordFound;
			}

			objMortageLoanType.MortageLoanTypesId = request.MortageLoanTypesId;

			mortageLoanTypeRepo.Update(objMortageLoanType);
            UnitOfWorkManager.Current.SaveChanges();

            return AppConsts.SuccessfullyUpdated;
		}

		public string DeleteMortageLoanType(int id)
		{
			var objMortageLoanType = mortageLoanTypeRepo.GetAll().Where(s => s.Id == id).FirstOrDefault();

			if (objMortageLoanType == null)
			{
				return AppConsts.NoRecordFound;
			}

			mortageLoanTypeRepo.Delete(objMortageLoanType);
            UnitOfWorkManager.Current.SaveChanges();

            return AppConsts.SuccessfullyDeleted;
		}

		public List<UpdateMortageLoanTypeRequest> GetMortageLoanTypes()
		{
			return mortageLoanTypeRepo.GetAll().Select(d => new UpdateMortageLoanTypeRequest()
			{
				Id = d.Id,
				MortageLoanTypesId = d.MortageLoanTypesId
			}).ToList();
		}

		public UpdateMortageLoanTypeRequest GetMortageLoanTypeById(int id)
		{
			return mortageLoanTypeRepo.GetAll().Where(s => s.Id == id).Select(d => new UpdateMortageLoanTypeRequest()
			{
				Id = d.Id,
				MortageLoanTypesId = d.MortageLoanTypesId
			}).FirstOrDefault();
		}

		#endregion

		#region Loan And Property Information Gift

		public string AddLoanAndPropertyInformationGift(AddLoanAndPropertyInformationGiftRequest request)
		{
            loanAndPropertyInformationGiftRepo.Insert(new codeFirstEntities.LoanAndPropertyInformationGift()
			{
				ApplicationPersonalInformationId = request.ApplicationPersonalInformationId,
				Deposited4d2 = request.Deposited4d2,
				LoanPropertyGiftTypeId4d1 = request.LoanPropertyGiftTypeId4d1,
				Source4d3 = request.Source4d3,
				Value4d4 = request.Value4d4
			});

            UnitOfWorkManager.Current.SaveChanges();
            return AppConsts.SuccessfullyInserted;
		}

		public string UpdateLoanAndPropertyInformationGift(UpdateLoanAndPropertyInformationGiftRequest request)
		{
			var objLoanAndPropertyInformationGift = loanAndPropertyInformationGiftRepo.GetAll().Where(s => s.Id == request.Id).FirstOrDefault();

			if (objLoanAndPropertyInformationGift == null)
			{
				return AppConsts.NoRecordFound;
			}

			objLoanAndPropertyInformationGift.ApplicationPersonalInformationId = request.ApplicationPersonalInformationId;
			objLoanAndPropertyInformationGift.Deposited4d2 = request.Deposited4d2;
			objLoanAndPropertyInformationGift.LoanPropertyGiftTypeId4d1 = request.LoanPropertyGiftTypeId4d1;
			objLoanAndPropertyInformationGift.Source4d3 = request.Source4d3;
			objLoanAndPropertyInformationGift.Value4d4 = request.Value4d4;
			loanAndPropertyInformationGiftRepo.Update(objLoanAndPropertyInformationGift);
            UnitOfWorkManager.Current.SaveChanges();
            

			return AppConsts.SuccessfullyUpdated;
		}

		public string DeleteLoanAndPropertyInformationGift(int id)
		{
			var objLoanAndPropertyInformationGift = loanAndPropertyInformationGiftRepo.GetAll().Where(s => s.Id == id).FirstOrDefault();

			if (objLoanAndPropertyInformationGift == null)
			{
				return AppConsts.NoRecordFound;
			}

			loanAndPropertyInformationGiftRepo.Delete(objLoanAndPropertyInformationGift);
            UnitOfWorkManager.Current.SaveChanges();

            return AppConsts.SuccessfullyDeleted;
		}

		public List<UpdateLoanAndPropertyInformationGiftRequest> GetLoanAndPropertyInformationGifts()
		{
			return loanAndPropertyInformationGiftRepo.GetAll().Select(d => new UpdateLoanAndPropertyInformationGiftRequest()
			{
				Id = d.Id,
				ApplicationPersonalInformationId = d.ApplicationPersonalInformationId,
				Deposited4d2 = d.Deposited4d2,
				LoanPropertyGiftTypeId4d1 = d.LoanPropertyGiftTypeId4d1,
				Source4d3 = d.Source4d3,
				Value4d4 = d.Value4d4
			}).ToList();
		}

		public UpdateLoanAndPropertyInformationGiftRequest GetLoanAndPropertyInformationGiftById(int id)
		{
			return loanAndPropertyInformationGiftRepo.GetAll().Where(s => s.Id == id).Select(d => new UpdateLoanAndPropertyInformationGiftRequest()
			{
				Id = d.Id,
				ApplicationPersonalInformationId = d.ApplicationPersonalInformationId,
				Deposited4d2 = d.Deposited4d2,
				LoanPropertyGiftTypeId4d1 = d.LoanPropertyGiftTypeId4d1,
				Source4d3 = d.Source4d3,
				Value4d4 = d.Value4d4
			}).FirstOrDefault();
		}

		#endregion

		#region Loan And Property Information

		public string AddLoanAndPropertyInformation(AddLoanAndPropertyInformationRequest request)
		{
			loanAndPropertyInformationRepo.Insert(new codeFirstEntities.LoanAndPropertyInformation()
			{
				ApplicationPersonalInformationId = request.ApplicationPersonalInformationId,
				CityId4a33 = request.CityId4a33,
				CountryId4a36 = request.CountryId4a36,
				FhaSecondaryResidance4a61 = request.FhaSecondaryResidance4a61,
				IsManufacturedHome4a8 = request.IsManufacturedHome4a8,
				IsMixedUseProperty4a7 = request.IsMixedUseProperty4a7,
				LoanAmount4a1 = request.LoanAmount4a1,
				LoanPropertyOccupancyId4a6 = request.LoanPropertyOccupancyId4a6,
				LoanPurpose4a2 = request.LoanPurpose4a2,
				PropertyNumberUnits4a4 = request.PropertyNumberUnits4a4,
				PropertyStreet4a31 = request.PropertyStreet4a31,
				PropertyUnitNo4a32 = request.PropertyUnitNo4a32,
				PropertyValue4a5 = request.PropertyValue4a5,
				PropertyZip4a35 = request.PropertyZip4a35,
				StateId4a34 = request.StateId4a34
			});

            UnitOfWorkManager.Current.SaveChanges();
            return AppConsts.SuccessfullyInserted;
		}

		public string UpdateLoanAndPropertyInformation(UpdateLoanAndPropertyInformationRequest request)
		{
			var objLoanAndPropertyInformation = loanAndPropertyInformationRepo.GetAll().Where(s => s.Id == request.Id).FirstOrDefault();

			if (objLoanAndPropertyInformation == null)
			{
				return AppConsts.NoRecordFound;
			}

			objLoanAndPropertyInformation.ApplicationPersonalInformationId = request.ApplicationPersonalInformationId;
			objLoanAndPropertyInformation.CityId4a33 = request.CityId4a33;
			objLoanAndPropertyInformation.CountryId4a36 = request.CountryId4a36;
			objLoanAndPropertyInformation.FhaSecondaryResidance4a61 = request.FhaSecondaryResidance4a61;
			objLoanAndPropertyInformation.IsManufacturedHome4a8 = request.IsManufacturedHome4a8;
			objLoanAndPropertyInformation.IsMixedUseProperty4a7 = request.IsMixedUseProperty4a7;
			objLoanAndPropertyInformation.LoanAmount4a1 = request.LoanAmount4a1;
			objLoanAndPropertyInformation.LoanPropertyOccupancyId4a6 = request.LoanPropertyOccupancyId4a6;
			objLoanAndPropertyInformation.LoanPurpose4a2 = request.LoanPurpose4a2;
			objLoanAndPropertyInformation.PropertyNumberUnits4a4 = request.PropertyNumberUnits4a4;
			objLoanAndPropertyInformation.PropertyStreet4a31 = request.PropertyStreet4a31;
			objLoanAndPropertyInformation.PropertyUnitNo4a32 = request.PropertyUnitNo4a32;
			objLoanAndPropertyInformation.PropertyValue4a5 = request.PropertyValue4a5;
			objLoanAndPropertyInformation.PropertyZip4a35 = request.PropertyZip4a35;
			objLoanAndPropertyInformation.StateId4a34 = request.StateId4a34;

			loanAndPropertyInformationRepo.Update(objLoanAndPropertyInformation);
            UnitOfWorkManager.Current.SaveChanges();

            return AppConsts.SuccessfullyUpdated;
		}

		public string DeleteLoanAndPropertyInformation(int id)
		{
			var objLoanAndPropertyInformation = loanAndPropertyInformationRepo.GetAll().Where(s => s.Id == id).FirstOrDefault();

			if (objLoanAndPropertyInformation == null)
			{
				return AppConsts.NoRecordFound;
			}

			loanAndPropertyInformationRepo.Delete(objLoanAndPropertyInformation);
            UnitOfWorkManager.Current.SaveChanges();

            return AppConsts.SuccessfullyDeleted;
		}

		public List<UpdateLoanAndPropertyInformationRequest> GetLoanAndPropertyInformations()
		{
			return loanAndPropertyInformationRepo.GetAll().Select(d => new UpdateLoanAndPropertyInformationRequest()
			{
				Id = d.Id,
				ApplicationPersonalInformationId = d.ApplicationPersonalInformationId,
				CityId4a33 = d.CityId4a33,
				CountryId4a36 = d.CountryId4a36,
				FhaSecondaryResidance4a61 = d.FhaSecondaryResidance4a61,
				IsManufacturedHome4a8 = d.IsManufacturedHome4a8,
				IsMixedUseProperty4a7 = d.IsMixedUseProperty4a7,
				LoanAmount4a1 = d.LoanAmount4a1,
				LoanPropertyOccupancyId4a6 = d.LoanPropertyOccupancyId4a6,
				LoanPurpose4a2 = d.LoanPurpose4a2,
				PropertyNumberUnits4a4 = d.PropertyNumberUnits4a4,
				PropertyStreet4a31 = d.PropertyStreet4a31,
				PropertyUnitNo4a32 = d.PropertyUnitNo4a32,
				PropertyValue4a5 = d.PropertyValue4a5,
				PropertyZip4a35 = d.PropertyZip4a35,
				StateId4a34 = d.StateId4a34
			}).ToList();
		}

		public UpdateLoanAndPropertyInformationRequest GetLoanAndPropertyInformationById(int id)
		{
			return loanAndPropertyInformationRepo.GetAll().Where(s => s.Id == id).Select(d => new UpdateLoanAndPropertyInformationRequest()
			{
				Id = d.Id,
				ApplicationPersonalInformationId = d.ApplicationPersonalInformationId,
				CityId4a33 = d.CityId4a33,
				CountryId4a36 = d.CountryId4a36,
				FhaSecondaryResidance4a61 = d.FhaSecondaryResidance4a61,
				IsManufacturedHome4a8 = d.IsManufacturedHome4a8,
				IsMixedUseProperty4a7 = d.IsMixedUseProperty4a7,
				LoanAmount4a1 = d.LoanAmount4a1,
				LoanPropertyOccupancyId4a6 = d.LoanPropertyOccupancyId4a6,
				LoanPurpose4a2 = d.LoanPurpose4a2,
				PropertyNumberUnits4a4 = d.PropertyNumberUnits4a4,
				PropertyStreet4a31 = d.PropertyStreet4a31,
				PropertyUnitNo4a32 = d.PropertyUnitNo4a32,
				PropertyValue4a5 = d.PropertyValue4a5,
				PropertyZip4a35 = d.PropertyZip4a35,
				StateId4a34 = d.StateId4a34
			}).FirstOrDefault();
		}

		#endregion

		#region Loan Originator Information

		public string AddLoanOriginatorInformation(AddLoanOriginatorInformationRequest request)
		{
            loanOriginatorInformationRepo.Insert(new codeFirstEntities.LoanOriginatorInformation()
			{
				ApplicationPersonalInformationId = request.ApplicationPersonalInformationId,
				Address92 = request.Address92,
				Date910 = request.Date910,
				Email98 = request.Email98,
				OrganizationName91 = request.OrganizationName91,
				OrganizationNmlsrId93 = request.OrganizationNmlsrId93,
				OrganizationStateLicence94 = request.OrganizationStateLicence94,
				OriginatorName95 = request.OriginatorName95,
				OriginatorNmlsrId96 = request.OriginatorNmlsrId96,
				OriginatorStateLicense97 = request.OriginatorStateLicense97,
				Phone99 = request.Phone99
			});

            UnitOfWorkManager.Current.SaveChanges();
            return AppConsts.SuccessfullyInserted;
		}

		public string UpdateLoanOriginatorInformation(UpdateLoanOriginatorInformationRequest request)
		{
			var objLoanOriginatorInformation = loanOriginatorInformationRepo.GetAll().Where(s => s.Id == request.Id).FirstOrDefault();

			if (objLoanOriginatorInformation == null)
			{
				return AppConsts.NoRecordFound;
			}

			objLoanOriginatorInformation.ApplicationPersonalInformationId = request.ApplicationPersonalInformationId;
			objLoanOriginatorInformation.Address92 = request.Address92;
			objLoanOriginatorInformation.Date910 = request.Date910;
			objLoanOriginatorInformation.Email98 = request.Email98;
			objLoanOriginatorInformation.OrganizationName91 = request.OrganizationName91;
			objLoanOriginatorInformation.OrganizationNmlsrId93 = request.OrganizationNmlsrId93;
			objLoanOriginatorInformation.OrganizationStateLicence94 = request.OrganizationStateLicence94;
			objLoanOriginatorInformation.OriginatorName95 = request.OriginatorName95;
			objLoanOriginatorInformation.OriginatorNmlsrId96 = request.OriginatorNmlsrId96;
			objLoanOriginatorInformation.OriginatorStateLicense97 = request.OriginatorStateLicense97;
			objLoanOriginatorInformation.Phone99 = request.Phone99;

			loanOriginatorInformationRepo.Update(objLoanOriginatorInformation);
            UnitOfWorkManager.Current.SaveChanges();

            return AppConsts.SuccessfullyUpdated;
		}

		public string DeleteLoanOriginatorInformation(int id)
		{
			var objLoanOriginatorInformation = loanOriginatorInformationRepo.GetAll().Where(s => s.Id == id).FirstOrDefault();

			if (objLoanOriginatorInformation == null)
			{
				return AppConsts.NoRecordFound;
			}

			loanOriginatorInformationRepo.Delete(objLoanOriginatorInformation);
            UnitOfWorkManager.Current.SaveChanges();

            return AppConsts.SuccessfullyDeleted;
		}

		public List<UpdateLoanOriginatorInformationRequest> GetLoanOriginatorInformations()
		{
			return loanOriginatorInformationRepo.GetAll().Select(d => new UpdateLoanOriginatorInformationRequest()
			{
				Id = d.Id,
				ApplicationPersonalInformationId = d.ApplicationPersonalInformationId,
				Address92 = d.Address92,
				Date910 = d.Date910,
				Email98 = d.Email98,
				OrganizationName91 = d.OrganizationName91,
				OrganizationNmlsrId93 = d.OrganizationNmlsrId93,
				OrganizationStateLicence94 = d.OrganizationStateLicence94,
				OriginatorName95 = d.OriginatorName95,
				OriginatorNmlsrId96 = d.OriginatorNmlsrId96,
				OriginatorStateLicense97 = d.OriginatorStateLicense97,
				Phone99 = d.Phone99
			}).ToList();
		}

		public UpdateLoanOriginatorInformationRequest GetLoanOriginatorInformationById(int id)
		{
			return loanOriginatorInformationRepo.GetAll().Where(s => s.Id == id).Select(d => new UpdateLoanOriginatorInformationRequest()
			{
				Id = d.Id,
				ApplicationPersonalInformationId = d.ApplicationPersonalInformationId,
				Address92 = d.Address92,
				Date910 = d.Date910,
				Email98 = d.Email98,
				OrganizationName91 = d.OrganizationName91,
				OrganizationNmlsrId93 = d.OrganizationNmlsrId93,
				OrganizationStateLicence94 = d.OrganizationStateLicence94,
				OriginatorName95 = d.OriginatorName95,
				OriginatorNmlsrId96 = d.OriginatorNmlsrId96,
				OriginatorStateLicense97 = d.OriginatorStateLicense97,
				Phone99 = d.Phone99
			}).FirstOrDefault();
		}

		#endregion

		#region Loan And Property Information Other Mortage Loan

		public string AddLoanAndPropertyInformationOtherMortageLoan(AddLoanAndPropertyInformationOtherMortageLoanRequest request)
		{
			loanAndPropertyInformationOtherMortageLoanRepo.Insert(new codeFirstEntities.LoanAndPropertyInformationOtherMortageLoan()
			{
				ApplicationPersonalInformationId = request.ApplicationPersonalInformationId,
				CreditAmount4b5 = request.CreditAmount4b5,
				CreditorName4b1 = request.CreditorName4b1,
				LienType4b2 = request.LienType4b2,
				LoanAmount4b4 = request.LoanAmount4b4,
				MonthlyPayment4b3 = request.MonthlyPayment4b3
			});

            UnitOfWorkManager.Current.SaveChanges();
            return AppConsts.SuccessfullyInserted;
		}

		public string UpdateLoanAndPropertyInformationOtherMortageLoan(UpdateLoanAndPropertyInformationOtherMortageLoanRequest request)
		{
			var objLoanAndPropertyInformationOtherMortageLoan =loanAndPropertyInformationOtherMortageLoanRepo.GetAll().Where(s => s.Id == request.Id).FirstOrDefault();

			if (objLoanAndPropertyInformationOtherMortageLoan == null)
			{
				return AppConsts.NoRecordFound;
			}

			objLoanAndPropertyInformationOtherMortageLoan.ApplicationPersonalInformationId = request.ApplicationPersonalInformationId;
			objLoanAndPropertyInformationOtherMortageLoan.CreditAmount4b5 = request.CreditAmount4b5;
			objLoanAndPropertyInformationOtherMortageLoan.CreditorName4b1 = request.CreditorName4b1;
			objLoanAndPropertyInformationOtherMortageLoan.LienType4b2 = request.LienType4b2;
			objLoanAndPropertyInformationOtherMortageLoan.LoanAmount4b4 = request.LoanAmount4b4;
			objLoanAndPropertyInformationOtherMortageLoan.MonthlyPayment4b3 = request.MonthlyPayment4b3;

			loanAndPropertyInformationOtherMortageLoanRepo.Update(objLoanAndPropertyInformationOtherMortageLoan);

            UnitOfWorkManager.Current.SaveChanges();

            return AppConsts.SuccessfullyUpdated;
		}

		public string DeleteLoanAndPropertyInformationOtherMortageLoan(int id)
		{
			var objLoanAndPropertyInformationOtherMortageLoan = loanAndPropertyInformationOtherMortageLoanRepo.GetAll().Where(s => s.Id == id).FirstOrDefault();

			if (objLoanAndPropertyInformationOtherMortageLoan == null)
			{
				return AppConsts.NoRecordFound;
			}

			loanAndPropertyInformationOtherMortageLoanRepo.Delete(objLoanAndPropertyInformationOtherMortageLoan);

            UnitOfWorkManager.Current.SaveChanges();

            return AppConsts.SuccessfullyDeleted;
		}

		public List<UpdateLoanAndPropertyInformationOtherMortageLoanRequest> GetLoanAndPropertyInformationOtherMortageLoans()
		{
			return loanAndPropertyInformationOtherMortageLoanRepo.GetAll().Select(d => new UpdateLoanAndPropertyInformationOtherMortageLoanRequest()
			{
				Id = d.Id,
				ApplicationPersonalInformationId = d.ApplicationPersonalInformationId,
				CreditAmount4b5 = d.CreditAmount4b5,
				CreditorName4b1 = d.CreditorName4b1,
				LienType4b2 = d.LienType4b2,
				LoanAmount4b4 = d.LoanAmount4b4,
				MonthlyPayment4b3 = d.MonthlyPayment4b3
			}).ToList();
		}

		public UpdateLoanAndPropertyInformationOtherMortageLoanRequest GetLoanAndPropertyInformationOtherMortageLoanById(int id)
		{
			return loanAndPropertyInformationOtherMortageLoanRepo.GetAll().Where(s => s.Id == id).Select(d => new UpdateLoanAndPropertyInformationOtherMortageLoanRequest()
			{
				Id = d.Id,
				ApplicationPersonalInformationId = d.ApplicationPersonalInformationId,
				CreditAmount4b5 = d.CreditAmount4b5,
				CreditorName4b1 = d.CreditorName4b1,
				LienType4b2 = d.LienType4b2,
				LoanAmount4b4 = d.LoanAmount4b4,
				MonthlyPayment4b3 = d.MonthlyPayment4b3
			}).FirstOrDefault();
		}

		#endregion

		#region Loan And Property InformationRental Income

		public string AddLoanAndPropertyInformationRentalIncome(AddLoanAndPropertyInformationRentalIncomeRequest request)
		{
            loanAndPropertyInformationRentalIncomeRepo.Insert(new codeFirstEntities.LoanAndPropertyInformationRentalIncome()
			{
				ApplicationPersonalInformationId = request.ApplicationPersonalInformationId,
				ExpectedMonthlyIncome4c1 = request.ExpectedMonthlyIncome4c1,
				LenderExpectedMonthlyIncome4c2 = request.LenderExpectedMonthlyIncome4c2
			});


            UnitOfWorkManager.Current.SaveChanges();
            return AppConsts.SuccessfullyInserted;
		}

		public string UpdateLoanAndPropertyInformationRentalIncome(UpdateLoanAndPropertyInformationRentalIncomeRequest request)
		{
			var objLoanAndPropertyInformationRentalIncome =loanAndPropertyInformationRentalIncomeRepo.GetAll().Where(s => s.Id == request.Id).FirstOrDefault();

			if (objLoanAndPropertyInformationRentalIncome == null)
			{
				return AppConsts.NoRecordFound;
			}

			objLoanAndPropertyInformationRentalIncome.ApplicationPersonalInformationId = request.ApplicationPersonalInformationId;
			objLoanAndPropertyInformationRentalIncome.ExpectedMonthlyIncome4c1 = request.ExpectedMonthlyIncome4c1;
			objLoanAndPropertyInformationRentalIncome.LenderExpectedMonthlyIncome4c2 = request.LenderExpectedMonthlyIncome4c2;

			loanAndPropertyInformationRentalIncomeRepo.Update(objLoanAndPropertyInformationRentalIncome);

            UnitOfWorkManager.Current.SaveChanges();

            return AppConsts.SuccessfullyUpdated;
		}

		public string DeleteLoanAndPropertyInformationRentalIncome(int id)
		{
			var objLoanAndPropertyInformationRentalIncome = loanAndPropertyInformationRentalIncomeRepo.GetAll().Where(s => s.Id == id).FirstOrDefault();

			if (objLoanAndPropertyInformationRentalIncome == null)
			{
				return AppConsts.NoRecordFound;
			}

			loanAndPropertyInformationRentalIncomeRepo.Delete(objLoanAndPropertyInformationRentalIncome);

            UnitOfWorkManager.Current.SaveChanges();

            return AppConsts.SuccessfullyDeleted;
		}

		public List<UpdateLoanAndPropertyInformationRentalIncomeRequest> GetLoanAndPropertyInformationRentalIncomes()
		{
			return loanAndPropertyInformationRentalIncomeRepo.GetAll().Select(d => new UpdateLoanAndPropertyInformationRentalIncomeRequest()
			{
				Id = d.Id,
				ApplicationPersonalInformationId = d.ApplicationPersonalInformationId,
				ExpectedMonthlyIncome4c1 = d.ExpectedMonthlyIncome4c1,
				LenderExpectedMonthlyIncome4c2 = d.LenderExpectedMonthlyIncome4c2
			}).ToList();
		}

		public UpdateLoanAndPropertyInformationRentalIncomeRequest GetLoanAndPropertyInformationRentalIncomeById(int id)
		{
			return loanAndPropertyInformationRentalIncomeRepo.GetAll().Where(s => s.Id == id).Select(d => new UpdateLoanAndPropertyInformationRentalIncomeRequest()
			{
				Id = d.Id,
				ApplicationPersonalInformationId = d.ApplicationPersonalInformationId,
				ExpectedMonthlyIncome4c1 = d.ExpectedMonthlyIncome4c1,
				LenderExpectedMonthlyIncome4c2 = d.LenderExpectedMonthlyIncome4c2
			}).FirstOrDefault();
		}

		#endregion

		#region Mortage Loan On Property

		public string AddMortageLoanOnProperty(AddMortageLoanOnPropertyRequest request)
		{
			mortageLoanOnPropertyRepo.Insert(new codeFirstEntities.MortageLoanOnProperty()
			{
				AccountNumber3a10 = request.AccountNumber3a10,
				ApplicationFinancialRealEstateId = request.ApplicationFinancialRealEstateId,
				CreditLimit3a15 = request.CreditLimit3a15,
				CreditorName3a9 = request.CreditorName3a9,
				MonthlyMortagePayment3a11 = request.MonthlyMortagePayment3a11,
				MortageLoanTypesId3a14 = request.MortageLoanTypesId3a14,
				PaidOff3a13 = request.PaidOff3a13,
				UnpaidBalance3a12 = request.UnpaidBalance3a12
			});


            UnitOfWorkManager.Current.SaveChanges();
            return AppConsts.SuccessfullyInserted;
		}

		public string UpdateMortageLoanOnProperty(UpdateMortageLoanOnPropertyRequest request)
		{
			var objMortageLoanOnProperty = mortageLoanOnPropertyRepo.GetAll().Where(s => s.Id == request.Id).FirstOrDefault();

			if (objMortageLoanOnProperty == null)
			{
				return AppConsts.NoRecordFound;
			}

			objMortageLoanOnProperty.AccountNumber3a10 = request.AccountNumber3a10;
			objMortageLoanOnProperty.ApplicationFinancialRealEstateId = request.ApplicationFinancialRealEstateId;
			objMortageLoanOnProperty.CreditLimit3a15 = request.CreditLimit3a15;
			objMortageLoanOnProperty.CreditorName3a9 = request.CreditorName3a9;
			objMortageLoanOnProperty.MonthlyMortagePayment3a11 = request.MonthlyMortagePayment3a11;
			objMortageLoanOnProperty.MortageLoanTypesId3a14 = request.MortageLoanTypesId3a14;
			objMortageLoanOnProperty.PaidOff3a13 = request.PaidOff3a13;
			objMortageLoanOnProperty.UnpaidBalance3a12 = request.UnpaidBalance3a12;

			mortageLoanOnPropertyRepo.Update(objMortageLoanOnProperty);

            UnitOfWorkManager.Current.SaveChanges();

            return AppConsts.SuccessfullyUpdated;
		}

		public string DeleteMortageLoanOnProperty(int id)
		{
			var objMortageLoanOnProperty = mortageLoanOnPropertyRepo.GetAll().Where(s => s.Id == id).FirstOrDefault();

			if (objMortageLoanOnProperty == null)
			{
				return AppConsts.NoRecordFound;
			}

			mortageLoanOnPropertyRepo.Delete(objMortageLoanOnProperty);

            UnitOfWorkManager.Current.SaveChanges();

            return AppConsts.SuccessfullyDeleted;
		}

		public List<UpdateMortageLoanOnPropertyRequest> GetMortageLoanOnProperties()
		{
			return mortageLoanOnPropertyRepo.GetAll().Select(d => new UpdateMortageLoanOnPropertyRequest()
			{
				Id = d.Id,
				AccountNumber3a10 = d.AccountNumber3a10,
				ApplicationFinancialRealEstateId = d.ApplicationFinancialRealEstateId,
				CreditLimit3a15 = d.CreditLimit3a15,
				CreditorName3a9 = d.CreditorName3a9,
				MonthlyMortagePayment3a11 = d.MonthlyMortagePayment3a11,
				MortageLoanTypesId3a14 = d.MortageLoanTypesId3a14,
				PaidOff3a13 = d.PaidOff3a13,
				UnpaidBalance3a12 = d.UnpaidBalance3a12
			}).ToList();
		}

		public UpdateMortageLoanOnPropertyRequest GetMortageLoanOnPropertyById(int id)
		{
			return mortageLoanOnPropertyRepo.GetAll().Where(s => s.Id == id).Select(d => new UpdateMortageLoanOnPropertyRequest()
			{
				Id = d.Id,
				AccountNumber3a10 = d.AccountNumber3a10,
				ApplicationFinancialRealEstateId = d.ApplicationFinancialRealEstateId,
				CreditLimit3a15 = d.CreditLimit3a15,
				CreditorName3a9 = d.CreditorName3a9,
				MonthlyMortagePayment3a11 = d.MonthlyMortagePayment3a11,
				MortageLoanTypesId3a14 = d.MortageLoanTypesId3a14,
				PaidOff3a13 = d.PaidOff3a13,
				UnpaidBalance3a12 = d.UnpaidBalance3a12
			}).FirstOrDefault();
		}

		#endregion

		public GetPdfDataModel GetLoanApplicationDetail(long id)
		{
			return new GetPdfDataModel();
			//return _dbContext.ApplicationPersonalInformations.Where(s => s.ApplicationId == id).Select(d => new GetPdfDataModel()
			//{
			//	Id = d.Id,
			//	Ages1a81 = d.Ages1a81,
			//	AlternateFirstName1a21 = d.AlternateFirstName1a21,
			//	AlternateLastName1a23 = d.AlternateLastName1a23,
			//	AlternateMiddleName1a22 = d.AlternateMiddleName1a22,
			//	AlternateSuffix1a24 = d.AlternateSuffix1a24,
			//	ApplicationId = d.ApplicationId,
			//	CellPhone1a10 = d.CellPhone1a10,
			//	CitizenshipType1a5 = d.CitizenshipTypeId1a5Navigation.CitizenshipType1,
			//	CurrentCity1a133 = d.CurrentCityId1a133Navigation.CityName,
			//	CurrentCountry1a136 = d.CurrentCountryId1a136Navigation.CountryName,
			//	CurrentHousingType1a141 = d.CurrentHousingTypeId1a141Navigation.HousingType1,
			//	CurrentMonths1a15 = d.CurrentMonths1a15,
			//	CurrentRent1a142 = d.CurrentRent1a142,
			//	CurrentState1a134 = d.CurrentStateId1a134Navigation.StateName,
			//	CurrentStreet1a131 = d.CurrentStreet1a131,
			//	CurrentUnit1a132 = d.CurrentUnit1a132,
			//	CurrentYears1a14 = d.CurrentYears1a14,
			//	CurrentZip1a135 = d.CurrentZip1a135,
			//	Dependents1a8 = d.Dependents1a8,
			//	Dob1a4 = d.Dob1a4,
			//	Email1a12 = d.Email1a12,
			//	Ext1a111 = d.Ext1a111,
			//	FirstName1a1 = d.FirstName1a1,
			//	FormerCity1a153 = d.FormerCityId1a153Navigation.CityName,
			//	FormerHousingType1a161 = d.FormerCountryId1a156Navigation.CountryName,
			//	FormerCountry1a156 = d.FormerHousingTypeId1a161Navigation.HousingType1,
			//	FormerMonths1a161 = d.FormerMonths1a161,
			//	FormerRent1a162 = d.FormerRent1a162,
			//	FormerState1a154 = d.FormerStateId1a154Navigation.StateName,
			//	FormerStreet1a151 = d.FormerStreet1a151,
			//	FormerUnit1a152 = d.FormerUnit1a152,
			//	FormerYears1a16 = d.FormerYears1a16,
			//	FormerZip1a155 = d.FormerZip1a155,
			//	HomePhone1a9 = d.HomePhone1a9,
			//	LastName1a3 = d.LastName1a3,
			//	MailingCity1a173 = d.MailingCityId1a173Navigation.CityName,
			//	MailingCountry1a176 = d.MailingCountryId1a176Navigation.CountryName,
			//	MailingState1a174 = d.MailingStateId1a174Navigation.StateName,
			//	MailingStreet1a171 = d.MailingStreet1a171,
			//	MailingUnit1a172 = d.MailingUnit1a172,
			//	MailingZip1a175 = d.MailingZip1a175,
			//	MaritialStatusId1a7 = d.MaritialStatusId1a7,
			//	MiddleName1a2 = d.MiddleName1a2,
			//	Ssn1a3 = d.Ssn1a3,
			//	Suffix1a4 = d.Suffix1a4,
			//	WorkPhone1a11 = d.WorkPhone1a11,
			//	Application = new ApplicationDetail()
			//	{
			//		AgencyCaseNoB2 = d.Application.AgencyCaseNoB2,
			//		CreditType = d.Application.CreditType.CreditType1,
			//		Date = d.Application.Date,
			//		Initials = d.Application.Initials,
			//		LoanNoIdentifierB1B3 = d.Application.LoanNoIdentifierB1B3,
			//		TotalBorrowers1a6 = d.Application.TotalBorrowers1a6
			//	},
			//	DeclarationQuestions = d.ApplicationDeclarationQuestions.Select(data => new Features.PdfData.ApplicationDeclarationQuestion()
			//		{
			//			Question = data.DeclarationQuestion.Question,
			//			Answer = data.DeclarationQuestion.ApplicationDeclarationQuestions.Where(x=>x.DeclarationQuestionId == data.Id).FirstOrDefault().Description5a,
			//			IsParent = data.DeclarationQuestion.ParentQuestionId > 0,
			//			YesNo = false
			//	}).ToList(),
			//	ApplicationEmployementDetails = d.ApplicationEmployementDetails.Select(x => new ApplicationEmployementDetail()
			//	{
			//		ApplicationPersonalInformationId = x.ApplicationPersonalInformationId,
			//		City1b43 = x.CityId1b43Navigation.CityName,
			//		Country1b46 = x.CountryId1b46Navigation.CountryName,
			//		EmployerBusinessName1b2 = x.EmployerBusinessName1b2,
			//		IsEmployedBySomeone1b8 = x.IsEmployedBySomeone1b8,
			//		IsOwnershipLessThan251b91 = x.IsOwnershipLessThan251b91,
			//		IsSelfEmployed1b9 = x.IsSelfEmployed1b9,
			//		MonthlyIncome1b92 = x.MonthlyIncome1b92,
			//		Phone1b3 = x.Phone1b3,
			//		PositionTitle1b5 = x.PositionTitle1b5,
			//		StartDate1b6 = x.StartDate1b6,
			//		State1b44 = x.StateId1b44Navigation.StateName,
			//		Street1b41 = x.Street1b41,
			//		Unit1b42 = x.Unit1b42,
			//		WorkingMonths = x.WorkingMonths,
			//		WorkingYears1b7 = x.WorkingYears1b7,
			//		Zip1b45 = x.Zip1b45
			//	}).ToList(),
			//	ApplicationFinancialAssets = d.ApplicationFinancialAssets.Select(x => new Features.PdfData.ApplicationFinancialAsset()
			//	{
			//		AccountNumber2a3 = x.AccountNumber2a3,
			//		FinancialAccountType2a1 = x.FinancialAccountTypeId2a1Navigation.FinancialAccountType1,
			//		FinancialInstitution2a2 = x.FinancialInstitution2a2,
			//		Value2a4 = x.Value2a4
			//	}).ToList(),
			//	ApplicationFinancialLaibilities = d.ApplicationFinancialLaibilities.Select(x => new ApplicationFinancialLiabilityDetail()
			//	{
			//		AccountNumber2c3 = x.AccountNumber2c3,
			//		ApplicationPersonalInformationId = x.ApplicationPersonalInformationId,
			//		CompanyName2c2 = x.CompanyName2c2,
			//		MonthlyValue2c6 = x.MonthlyValue2c6,
			//		PaidOff2c5 = x.PaidOff2c5,
			//		UnpaidBalance2c4 = x.UnpaidBalance2c4,
			//		FinancialLaibilitiesType2c1 = x.FinancialLaibilitiesType2c1Navigation.FinancialLaibilitiesType1
			//	}).ToList(),
			//	AdditionalEmploymentDetails = d.ApplicationAdditionalEmployementDetails.Select(x => new AdditionalEmploymentDetail()
			//	{
			//		City = x.City.CityName,
			//		Country = x.Country.CountryName,
			//		EmployerBusinessName = x.EmployerBusinessName,
			//		IsEmployedBySomeone = x.IsEmployedBySomeone != null && x.IsEmployedBySomeone == 1 ? true : false,
			//		IsOwnershipLessThan25 = (x.IsOwnershipLessThan25 != null && x.IsOwnershipLessThan25 == 1) ? true : false,
			//		IsSelfEmployed = x.IsSelfEmployed != null && x.IsSelfEmployed == 1 ? true : false,
			//		MonthlyIncome = x.MonthlyIncome,
			//		Phone = x.Phone,
			//		ApplicationPersonalInformationId = x.ApplicationPersonalInformationId,
			//		PositionTitle = x.PositionTitle,
			//		StartDate = x.StartDate,
			//		State = x.State.StateName,
			//		Street = x.Street,
			//		Unit = x.Unit,
			//		WorkingMonths = x.WorkingMonths,
			//		WorkingYears = x.WorkingYears,
			//		Zip = x.Zip,
			//		EmployementIncomeDetail = x.ApplicationAdditionalEmployementIncomeDetails.Select(i => new AdditionalEmployementIncomeDetail()
			//		{
			//			Amount = i.Amount,
			//			ApplicationAdditionalEmployementDetails = i.ApplicationAdditionalEmployementDetails,
			//			Id = i.Id,
			//			IncomeType = i.IncomeType.IncomeType1
			//		}).ToList()
			//	}).ToList(),
			//	ApplicationFinancialOtherAssets = d.ApplicationFinancialOtherAssets.Select(x => new ApplicationFinancialOtherAssetDetail()
			//	{
			//		ApplicationPersonalInformationId = x.ApplicationPersonalInformationId,
			//		FinancialAssetsType2b1 = x.FinancialAssetsTypesId2b1Navigation.FinancialCreditType,
			//		Value2b2 = x.Value2b2
			//	}).ToList(),
			//	ApplicationFinancialOtherLaibilities = d.ApplicationFinancialOtherLaibilities.Select(x => new ApplicationFinancialOtherLaibilityDetail()
			//	{
			//		ApplicationPersonalInformationId = x.ApplicationPersonalInformationId,
			//		FinancialOtherLaibilityType2d1 = x.FinancialOtherLaibilitiesTypeId2d1Navigation.FinancialOtherLaibilitiesType1,
			//		MonthlyPayment2d2 = x.MonthlyPayment2d2
			//	}).ToList(),
			//	ApplicationFinancialRealEstates = d.ApplicationFinancialRealEstates.Select(x => new FinancialRealEstateDetail()
			//	{
			//		ApplicationPersonalInformationId = x.ApplicationPersonalInformationId,
			//		City3a23 = x.CityId3a23Navigation.CityName,
			//		Country3a26 = x.CountryId3a26Navigation.CountryName,
			//		FinancialPropertyIntendedOccupancy3a5 = x.FinancialPropertyIntendedOccupancyId3a5Navigation.FinancialPropertyIntendedOccupancy1,
			//		FinancialPropertyStatus3a4 = x.FinancialPropertyStatusId3a4Navigation.FinancialPropertyStatus1,
			//		MonthlyMortagePayment3a6 = x.MonthlyMortagePayment3a6,
			//		MonthlyRentalIncome3a7 = x.MonthlyRentalIncome3a7,
			//		NetMonthlyRentalIncome3a8 = x.NetMonthlyRentalIncome3a8,
			//		PropertyValue3a3 = x.PropertyValue3a3,
			//		State3a24 = x.StateId3a24Navigation.StateName,
			//		Street3a21 = x.Street3a21,
			//		UnitNo3a22 = x.UnitNo3a22,
			//		Zip3a25 = x.Zip3a25,
			//		MortageLoanOnPropertyDetails = x.MortageLoanOnPropertyDetails.Select(m => new MortageLoanOnPropertyDetail()
			//		{
			//			AccountNumber3a10 = m.AccountNumber3a10,
			//			ApplicationFinancialRealEstateId = m.ApplicationFinancialRealEstateId,
			//			CreditLimit3a15 = m.CreditLimit3a15,
			//			CreditorName3a9 = m.CreditorName3a9,
			//			Id = m.Id,
			//			MonthlyMortagePayment3a11 = m.MonthlyMortagePayment3a11,
			//			MortageLoanType3a14 = m.MortageLoanTypesId3a14Navigation.MortageLoanTypesId,
			//			PaidOff3a13 = m.PaidOff3a13,
			//			UnpaidBalance3a12 = m.UnpaidBalance3a12
			//		}).ToList()
			//	}).ToList(),
			//	ApplicationIncomeSources = d.ApplicationIncomeSources.Select(x => new Features.PdfData.ApplicationIncomeSourceDetail()
			//	{
			//		Amount1e2 = x.Amount1e2,
			//		ApplicationPersonalInformationId = x.ApplicationPersonalInformationId,
			//		IncomeSource1e1 = x.IncomeSourceId1e1Navigation.IncomeSource1
			//	}).ToList(),
			//	ApplicationPreviousEmployementDetails = d.ApplicationPreviousEmployementDetails.Select(x => new Features.PdfData.PreviousEmployementDetail()
			//	{
			//		ApplicationPersonalInformationId = x.ApplicationPersonalInformationId,
			//		City1d33 = x.CityId1d33Navigation.CityName,
			//		Country1d36 = x.CountryId1d36Navigation.CountryName,
			//		EmployerBusinessName1d2 = x.EmployerBusinessName1d2,
			//		EndDate1d6 = x.EndDate1d6,
			//		GrossMonthlyIncome1d8 = x.GrossMonthlyIncome1d8,
			//		IsSelfEmployed1d7 = x.IsSelfEmployed1d7,
			//		PositionTitle1d4 = x.PositionTitle1d4,
			//		StartDate1d5 = x.StartDate1d5,
			//		StateId1d34 = x.StateId1d34Navigation.StateName,
			//		Street1d31 = x.Street1d31,
			//		Unit1d32 = x.Unit1d32,
			//		Zip1d35 = x.Zip1d35
			//	}).ToList(),
			//	DemographicInformations = d.DemographicInformations.Select(x => new Features.PdfData.DemographicInformationDetail()
			//	{
			//		ApplicationPersonalInformationId = x.ApplicationPersonalInformationId,
			//		DemographicInfoSource87 = x.DemographicInfoSourceId87Navigation.Value,
			//		Ethnicity81 = x.Ethnicity81,
			//		Gender82 = x.Gender82,
			//		IsEthnicityByObservation84 = x.IsEthnicityByObservation84,
			//		IsGenderByObservation85 = x.IsGenderByObservation85,
			//		IsRaceByObservation86 = x.IsRaceByObservation86,
			//		Race83 = x.Race83
			//	}).ToList(),
			//	LoanAndPropertyInformationGifts = d.LoanAndPropertyInformationGifts.Select(x => new Features.PdfData.LoanAndPropertyInformationGiftDetail()
			//	{
			//		ApplicationPersonalInformationId = x.ApplicationPersonalInformationId,
			//		Deposited4d2 = x.Deposited4d2,
			//		LoanPropertyGiftType4d1 = x.LoanPropertyGiftTypeId4d1Navigation.LoanPropertyGiftType1,
			//		Source4d3 = x.Source4d3,
			//		Value4d4 = x.Value4d4
			//	}).ToList(),
			//	LoanAndPropertyInformationOtherMortageLoans = d.LoanAndPropertyInformationOtherMortageLoans.Select(x => new UpdateLoanAndPropertyInformationOtherMortageLoanRequest()
			//	{
			//		ApplicationPersonalInformationId = x.ApplicationPersonalInformationId,
			//		CreditAmount4b5 = x.CreditAmount4b5,
			//		CreditorName4b1 = x.CreditorName4b1,
			//		Id = x.Id,
			//		LienType4b2 = x.LienType4b2,
			//		LoanAmount4b4 = x.LoanAmount4b4,
			//		MonthlyPayment4b3 = x.MonthlyPayment4b3
			//	}).ToList(),
			//	LoanAndPropertyInformationRentalIncomes = d.LoanAndPropertyInformationRentalIncomes.Select(x => new UpdateLoanAndPropertyInformationRentalIncomeRequest()
			//	{
			//		ApplicationPersonalInformationId = x.ApplicationPersonalInformationId,
			//		ExpectedMonthlyIncome4c1 = x.ExpectedMonthlyIncome4c1,
			//		Id = x.Id,
			//		LenderExpectedMonthlyIncome4c2 = x.LenderExpectedMonthlyIncome4c2
			//	}).ToList(),
			//	LoanAndPropertyInformations = d.LoanAndPropertyInformations.Select(x => new LoanAndPropertyInformationDetail()
			//	{
			//		ApplicationPersonalInformationId = x.ApplicationPersonalInformationId,
			//		City4a33 = x.CityId4a33Navigation.CityName,
			//		Country4a36 = x.CountryId4a36Navigation.CountryName,
			//		FhaSecondaryResidance4a61 = x.FhaSecondaryResidance4a61,
			//		IsManufacturedHome4a8 = x.IsManufacturedHome4a8,
			//		IsMixedUseProperty4a7 = x.IsMixedUseProperty4a7,
			//		LoanAmount4a1 = x.LoanAmount4a1,
			//		LoanPropertyOccupancy4a6 = x.LoanPropertyOccupancyId4a6Navigation.LoanPropertyOccupancy1,
			//		LoanPurpose4a2 = x.LoanPurpose4a2,
			//		PropertyNumberUnits4a4 = x.PropertyNumberUnits4a4,
			//		PropertyStreet4a31 = x.PropertyStreet4a31,
			//		PropertyUnitNo4a32 = x.PropertyUnitNo4a32,
			//		PropertyValue4a5 = x.PropertyValue4a5,
			//		PropertyZip4a35 = x.PropertyZip4a35,
			//		State4a34 = x.StateId4a34Navigation.StateName
			//	}).ToList(),
			//	LoanOriginatorInformations = d.LoanOriginatorInformations.Select(x => new UpdateLoanOriginatorInformationRequest()
			//	{
			//		Address92 = x.Address92,
			//		ApplicationPersonalInformationId = x.ApplicationPersonalInformationId,
			//		Date910 = x.Date910,
			//		Email98 = x.Email98,
			//		Id = x.Id,
			//		OrganizationName91 = x.OrganizationName91,
			//		OrganizationNmlsrId93 = x.OrganizationNmlsrId93,
			//		OrganizationStateLicence94 = x.OrganizationStateLicence94,
			//		OriginatorName95 = x.OriginatorName95,
			//		OriginatorNmlsrId96 = x.OriginatorNmlsrId96,
			//		OriginatorStateLicense97 = x.OriginatorStateLicense97,
			//		Phone99 = x.Phone99
			//	}).ToList(),
			//	MilitaryServices = d.MilitaryServices.Select(x => new UpdateMilitaryServiceRequest()
			//	{
			//		ApplicationPersonalInformationId = x.ApplicationPersonalInformationId,
			//		CurrentlyServing7a2 = x.CurrentlyServing7a2,
			//		DateOfServiceExpiration7a3 = x.DateOfServiceExpiration7a3,
			//		Id = x.Id,
			//		NonActivatedMember7a2 = x.NonActivatedMember7a2,
			//		Retired7a2 = x.Retired7a2,
			//		ServedInForces7a1 = x.ServedInForces7a1,
			//		SurvivingSpouse7a21 = x.SurvivingSpouse7a21
			//	}).ToList(),
			//}).FirstOrDefault();
		}

		public dynamic CreatePdfNew(long Id)
		{
			var mailMessage = new MailMessage();
			mailMessage.To.Add(new MailAddress("wmartin@ezonlinemortgage.com"));
			mailMessage.To.Add(new MailAddress("shabir.abdulmajeed786@gmail.com"));
			mailMessage.From = new MailAddress("loanapplicationmail@gmail.com");
			mailMessage.Subject = "Home Buying Funnel Form New Lead";
			string pdfTemplate = @"Borrower_v28.pdf";
			var pdfReader = new Pdf.PdfReader(pdfTemplate);
			var (fileName, path) = CreateFileName(Id);
			// MemoryStream memoryStream = new MemoryStream();
			var fileStream = new FileStream(path, FileMode.Create);
			var pdfStamper = new Pdf.PdfStamper(pdfReader, fileStream);
			double assetsTotalCash = 0;

			try
			{
				var pdfFormFields = pdfStamper.AcroFields;
				List<string> fieldValues = new List<string>();
				foreach (var item in pdfFormFields.Fields.Keys)
                {
					fieldValues.Add(item.ToString());
                }
				var orderedList = new List<string>();
				orderedList = fieldValues.OrderBy(x => x).ToList();
				var data = GetLoanApplicationDetail(Id);
				pdfFormFields.SetField("topmostSubform[0].Page1[0]._1a_Name[0]", $"{StringExtensions.FirstCharToUpper(data.FirstName1a1)}, {StringExtensions.FirstCharToUpper(data.MiddleName1a2)}, {StringExtensions.FirstCharToUpper(data.LastName1a3)}, {StringExtensions.FirstCharToUpper(data.Suffix1a4)}");
				pdfFormFields.SetField("topmostSubform[0].Page1[0]._1a_Security_1[0]", data.Ssn1a3?.Substring(0, 3));
				pdfFormFields.SetField("topmostSubform[0].Page1[0]._1a_Security_2[0]", data.Ssn1a3?.Substring(3, 2));
				pdfFormFields.SetField("topmostSubform[0].Page1[0]._1a_Security_3[0]", data.Ssn1a3?.Substring(5, 4));
				pdfFormFields.SetField("topmostSubform[0].Page1[0]._1a_Alt_Name[0]", $"{StringExtensions.FirstCharToUpper(data.AlternateFirstName1a21)}, {StringExtensions.FirstCharToUpper(data.AlternateMiddleName1a22)}, {StringExtensions.FirstCharToUpper(data.AlternateLastName1a23)}, {StringExtensions.FirstCharToUpper(data.AlternateSuffix1a24)}");
				pdfFormFields.SetField("topmostSubform[0].Page1[0]._1a_Birth_1[0]", data.Dob1a4?.ToString().Substring(5, 2));
				pdfFormFields.SetField("topmostSubform[0].Page1[0]._1a_Birth_2[0]", data.Dob1a4?.ToString().Substring(8, 2));
				pdfFormFields.SetField("topmostSubform[0].Page1[0]._1a_Birth_3[0]", data.Dob1a4?.ToString().Substring(0, 4));
				//pdfFormFields.SetField("topmostSubform[0].Page1[0].credit[0].individual[0]._1a_Individual[0]", (data.PersonalInformation.IsApplyingWithCoBorrower != null && data.PersonalInformation.IsApplyingWithCoBorrower == true) ? "1" : "0");

				//if ((data.PersonalInformation.IsApplyingWithCoBorrower != null && data.PersonalInformation.IsApplyingWithCoBorrower == true))
				//{
				//    pdfFormFields.SetField("topmostSubform[0].Page1[0].credit[0].joint[0]._1a_Joint[0]", "1");
				//}
				//else
				//{
				//    pdfFormFields.SetField("topmostSubform[0].Page1[0].credit[0].individual[0]._1a_Individual[0]", "1");
				//}

				pdfFormFields.SetField("topmostSubform[0].Page1[0].credit[0].joint[0]._1a_Borrowers_Number[0]", "1");
				if (data.CitizenshipType1a5 == "U.S. Citizen")
				{
					pdfFormFields.SetField("topmostSubform[0].Page1[0].citizenship[0].citizen[0]._1a_US_Citizen[0]", "1");
				}
				if (data.CitizenshipType1a5 == "Permanent Resident Alien")
				{
					pdfFormFields.SetField("topmostSubform[0].Page1[0].citizenship[0].permanent[0]._1a_Permanent_Resident_Alien[0]", "1");
				}
				else
				{
					pdfFormFields.SetField("topmostSubform[0].Page1[0].citizenship[0].non_permanent[0]._1a_Non_Permanent_Resident_Alien[0]", "1");
				}

				pdfFormFields.SetField("topmostSubform[0].Page1[0].credit[0].joint[0]._1a_Initials[0]", data.Application.Initials ?? " ");

				//pdfFormFields.SetField("topmostSubform[0].Page1[0]._1a_Borrower_s_Name[0]", $"{data.PersonalInformation.CoBorrower.FirstName ?? ""}, {data.PersonalInformation.CoBorrower.MiddleInitial ?? ""}, {data.PersonalInformation.CoBorrower.LastName ?? ""}, {data.PersonalInformation.CoBorrower.Suffix ?? ""}");

				if (data.MaritialStatusId1a7.ToString() == "1")
				{
					pdfFormFields.SetField("topmostSubform[0].Page1[0].marital-status[0].married[0]._1a_Married[0]", "1");
				}
				else if (data.MaritialStatusId1a7.ToString() == "2")
				{
					pdfFormFields.SetField("topmostSubform[0].Page1[0].marital-status[0].unmarried[0]._1a_Unmarried[0]", "1");
				}
				else if (data.MaritialStatusId1a7.ToString() == "3")
				{
					pdfFormFields.SetField("topmostSubform[0].Page1[0].marital-status[0].separated[0]._1a_Separated[0]", "1");
				}


				pdfFormFields.SetField("topmostSubform[0].Page1[0]._1a_Dependents[0]", data.Dependents1a8?.ToString());

				pdfFormFields.SetField("topmostSubform[0].Page1[0]._1a_PhoneH1[0]", data.HomePhone1a9?.Substring(0, 3));
				pdfFormFields.SetField("topmostSubform[0].Page1[0]._1a_PhoneH2[0]", data.HomePhone1a9?.Substring(3, 3));
				pdfFormFields.SetField("topmostSubform[0].Page1[0]._1a_PhoneH3[0]", data.HomePhone1a9?.Substring(6, 3));

				pdfFormFields.SetField("topmostSubform[0].Page1[0]._1a_PhoneC1[0]", data.CellPhone1a10?.Substring(0, 3));
				pdfFormFields.SetField("topmostSubform[0].Page1[0]._1a_PhoneC2[0]", data.CellPhone1a10?.Substring(3, 3));
				pdfFormFields.SetField("topmostSubform[0].Page1[0]._1a_PhoneC3[0]", data.CellPhone1a10?.Substring(6, 4));

				pdfFormFields.SetField("topmostSubform[0].Page1[0]._1a_Email[0]", data.Email1a12);
				pdfFormFields.SetField("topmostSubform[0].Page1[0]._1a_Address_City[0]", data.CurrentCity1a133);
				pdfFormFields.SetField("topmostSubform[0].Page1[0]._1a_Address_State[0]", data.CurrentState1a134);
				pdfFormFields.SetField("topmostSubform[0].Page1[0]._1a_Address_Zip[0]", data.CurrentZip1a135 ?? "");
				pdfFormFields.SetField("topmostSubform[0].Page1[0]._1a_Address_St[0]", data.CurrentStreet1a131);
				pdfFormFields.SetField("topmostSubform[0].Page1[0]._1a_Address_Years[0]", data.CurrentYears1a14?.ToString() ?? "");
				pdfFormFields.SetField("topmostSubform[0].Page1[0]._1a_Address_Months[0]", data.CurrentMonths1a15?.ToString() ?? "");

				//if (data.Expenses.IsLiveWithFamilySelectRent == true)
				//            {
				//            }
				//            else
				//            {
				//                pdfFormFields.SetField("topmostSubform[0].Page1[0].housing_current[0].own[0]._1a_Current_Own[0]", "True");
				//            }

				pdfFormFields.SetField("topmostSubform[0].Page1[0]._1a_Address_St[0]", data.CurrentStreet1a131);

				if (string.IsNullOrEmpty(data.FormerCity1a153) && string.IsNullOrEmpty(data.FormerStreet1a151) && string.IsNullOrEmpty(data.FormerState1a154) &&
					string.IsNullOrEmpty(data.FormerZip1a155) && string.IsNullOrEmpty(data.FormerYears1a16?.ToString()) && string.IsNullOrEmpty(data.FormerMonths1a161?.ToString()))
				{
					pdfFormFields.SetField("topmostSubform[0].Page1[0]._1a_Former_Address_City[0]", data.FormerCity1a153);
					pdfFormFields.SetField("topmostSubform[0].Page1[0]._1a_FormerAddress_St[0]", data.FormerStreet1a151);
					pdfFormFields.SetField("topmostSubform[0].Page1[0]._1a_Former_Address_State[0]", data.FormerState1a154);
					pdfFormFields.SetField("topmostSubform[0].Page1[0]._1a_Former_Address_Zip[0]", data.FormerZip1a155 ?? "");
					pdfFormFields.SetField("topmostSubform[0].Page1[0]._1a_Former_Address_Years[0]", data.FormerYears1a16?.ToString() ?? "");
					pdfFormFields.SetField("topmostSubform[0].Page1[0]._1a_Former_Address_Months[0]", data.FormerMonths1a161?.ToString() ?? "");
				}
				else
				{
					var FormerAddress = pdfFormFields.GetAppearanceStates("topmostSubform[0].Page1[0]._1a_Does_Not_Apply1[0]");
					pdfFormFields.SetField("topmostSubform[0].Page1[0]._1a_Does_Not_Apply1[0]", FormerAddress[0]);
				}

				if (!string.IsNullOrEmpty(data.MailingCity1a173) && !string.IsNullOrEmpty(data.MailingState1a174) && (data.MailingState1a174 != data.CurrentState1a134 && data.MailingCity1a173 != data.CurrentCity1a133))
				{
					pdfFormFields.SetField("topmostSubform[0].Page1[0]._1a_Mail_Address_City[0]", data.MailingCity1a173);
					pdfFormFields.SetField("topmostSubform[0].Page1[0]._1a_Mail_Address_State[0]", data.MailingState1a174);
					pdfFormFields.SetField("topmostSubform[0].Page1[0]._1a_Mail_Address_Zip[0]", data.MailingZip1a175 ?? "");
					pdfFormFields.SetField("topmostSubform[0].Page1[0]._1a_Mail_Address_St[0]", data.MailingStreet1a171);
				}
				else
				{
					var MailAddress = pdfFormFields.GetAppearanceStates("topmostSubform[0].Page1[0]._1a_Does_Not_Apply2[0]");
					pdfFormFields.SetField("topmostSubform[0].Page1[0]._1a_Does_Not_Apply2[0]", MailAddress[0]);
				}


				if (data.AdditionalEmploymentDetails.Count > 0)
				{
					pdfFormFields.SetField("topmostSubform[0].Page1[0]._1b_Employer[0]", data.AdditionalEmploymentDetails[0].EmployerBusinessName);

					pdfFormFields.SetField("topmostSubform[0].Page1[0]._1b_City[0]", data.AdditionalEmploymentDetails[0].City);
					pdfFormFields.SetField("topmostSubform[0].Page1[0]._1b_State[0]", data.AdditionalEmploymentDetails[0].State);
					pdfFormFields.SetField("topmostSubform[0].Page1[0]._1b_Zip[0]", data.AdditionalEmploymentDetails[0].Zip?.ToString());
					pdfFormFields.SetField("topmostSubform[0].Page1[0]._1b_Address[0]", data.AdditionalEmploymentDetails[0].Street);
					pdfFormFields.SetField("topmostSubform[0].Page1[0]._1b_Position[0]", data.AdditionalEmploymentDetails[0].PositionTitle);
					pdfFormFields.SetField("topmostSubform[0].Page1[0]._1b_Employment_Start_Day[0]", data.AdditionalEmploymentDetails[0].StartDate.ToString().Substring(8, 2));
					pdfFormFields.SetField("topmostSubform[0].Page1[0]._1b_Employment_Start_Month[0]", data.AdditionalEmploymentDetails[0].StartDate.ToString().Substring(5, 2));
					pdfFormFields.SetField("topmostSubform[0].Page1[0]._1b_Employment_Start_Year[0]", data.AdditionalEmploymentDetails[0].StartDate.ToString().Substring(0, 4));
					var baseIncome = data.AdditionalEmploymentDetails[0].EmployementIncomeDetail.FirstOrDefault(s => s.IncomeType.ToLower() == "base").Amount;
					var bonus = data.AdditionalEmploymentDetails[0].EmployementIncomeDetail.FirstOrDefault(s => s.IncomeType.ToLower() == "bonus").Amount;
					var overtime = data.AdditionalEmploymentDetails[0].EmployementIncomeDetail.FirstOrDefault(s => s.IncomeType.ToLower() == "overtime").Amount;
					var commission = data.AdditionalEmploymentDetails[0].EmployementIncomeDetail.FirstOrDefault(s => s.IncomeType.ToLower() == "commissions").Amount;
					var dividend = data.AdditionalEmploymentDetails[0].EmployementIncomeDetail.FirstOrDefault(s => s.IncomeType.ToLower() == "dividend").Amount;

					pdfFormFields.SetField("topmostSubform[0].Page1[0]._1b_Employment_Years[0]", data.AdditionalEmploymentDetails[1].WorkingYears?.ToString());
					pdfFormFields.SetField("topmostSubform[0].Page1[0]._1b_Employment_Months[0]", data.AdditionalEmploymentDetails[1].WorkingMonths?.ToString());
					pdfFormFields.SetField("topmostSubform[0].Page1[0]._1b_Monthly_Income_Loss[0]", data.AdditionalEmploymentDetails[0].EmployementIncomeDetail.FirstOrDefault(s => s.IncomeType.ToLower() == "base").Amount?.ToString() ?? "");
					pdfFormFields.SetField("topmostSubform[0].Page1[0]._1b_Base[0]", baseIncome?.ToString() ?? "");
					pdfFormFields.SetField("topmostSubform[0].Page1[0]._1b_Bonus[0]", bonus?.ToString() ?? "");
					pdfFormFields.SetField("topmostSubform[0].Page1[0]._1b_Overtime[0]", overtime?.ToString() ?? "");
					pdfFormFields.SetField("topmostSubform[0].Page1[0]._1b_Commission[0]", commission?.ToString() ?? "");
					pdfFormFields.SetField("topmostSubform[0].Page1[0]._1b_Other[0]", dividend?.ToString() ?? "");

					var IncomeTotal = baseIncome + bonus + overtime + commission + dividend;

					pdfFormFields.SetField("topmostSubform[0].Page1[0]._1b_IncomeTotal[0]", IncomeTotal.ToString());
					if (data.AdditionalEmploymentDetails[0].IsSelfEmployed.HasValue && data.AdditionalEmploymentDetails[0].IsSelfEmployed == true)
					{
						var SelfEmployeed = pdfFormFields.GetAppearanceStates("topmostSubform[0].Page1[0]._1b_Owner[0]");
						pdfFormFields.SetField("topmostSubform[0].Page1[0]._1b_Owner[0]", SelfEmployeed[0]);
					}
				}

				// Page 2 started from here ..
				// Page 2 C section
				if (data.AdditionalEmploymentDetails.Count > 1)
				{
					pdfFormFields.SetField("topmostSubform[0].Page2[0]._1c_Employer[0]", data.AdditionalEmploymentDetails[1].EmployerBusinessName);

					pdfFormFields.SetField("topmostSubform[0].Page2[0]._1c_City[0]", data.AdditionalEmploymentDetails[1].City);
					pdfFormFields.SetField("topmostSubform[0].Page2[0]._1c_State[0]", data.AdditionalEmploymentDetails[1].State);
					pdfFormFields.SetField("topmostSubform[0].Page2[0]._1c_Zip[0]", data.AdditionalEmploymentDetails[1].Zip);
					pdfFormFields.SetField("topmostSubform[0].Page2[0]._1c_Address[0]", data.AdditionalEmploymentDetails[1].Street);
					pdfFormFields.SetField("topmostSubform[0].Page2[0]._1c_Position[0]", data.AdditionalEmploymentDetails[1].PositionTitle);
					pdfFormFields.SetField("topmostSubform[0].Page2[0]._1c_Employment_Start_Day[0]", data.AdditionalEmploymentDetails[1].StartDate.ToString().Substring(8, 2));
					pdfFormFields.SetField("topmostSubform[0].Page2[0]._1c_Employment_Start_Month[0]", data.AdditionalEmploymentDetails[1].StartDate.ToString().Substring(5, 2));
					pdfFormFields.SetField("topmostSubform[0].Page2[0]._1c_Employment_Start_Year[0]", data.AdditionalEmploymentDetails[1].StartDate.ToString().Substring(0, 4));
					var baseIncome = data.AdditionalEmploymentDetails[1].EmployementIncomeDetail.FirstOrDefault(s => s.IncomeType.ToLower() == "base").Amount;
					var bonus = data.AdditionalEmploymentDetails[1].EmployementIncomeDetail.FirstOrDefault(s => s.IncomeType.ToLower() == "bonus").Amount;
					var overtime = data.AdditionalEmploymentDetails[1].EmployementIncomeDetail.FirstOrDefault(s => s.IncomeType.ToLower() == "overtime").Amount;
					var commission = data.AdditionalEmploymentDetails[1].EmployementIncomeDetail.FirstOrDefault(s => s.IncomeType.ToLower() == "commissions").Amount;
					var dividend = data.AdditionalEmploymentDetails[1].EmployementIncomeDetail.FirstOrDefault(s => s.IncomeType.ToLower() == "dividend").Amount;

					pdfFormFields.SetField("topmostSubform[0].Page2[0]._1c_Employment_Years[0]", data.AdditionalEmploymentDetails[1].WorkingYears?.ToString());
					pdfFormFields.SetField("topmostSubform[0].Page2[0]._1c_Employment_Months[0]", data.AdditionalEmploymentDetails[1].WorkingMonths?.ToString());
					pdfFormFields.SetField("topmostSubform[0].Page2[0]._1c_Monthly_Income_Loss[0]", baseIncome.ToString() ?? "");
					pdfFormFields.SetField("topmostSubform[0].Page2[0]._1c_Base[0]", baseIncome.ToString() ?? "");
					pdfFormFields.SetField("topmostSubform[0].Page2[0]._1c_Bonus[0]", bonus.ToString() ?? "");
					pdfFormFields.SetField("topmostSubform[0].Page2[0]._1c_Overtime[0]", overtime.ToString() ?? "");
					pdfFormFields.SetField("topmostSubform[0].Page2[0]._1c_Commission[0]", commission.ToString() ?? "");
					pdfFormFields.SetField("topmostSubform[0].Page2[0]._1c_Other[0]", dividend.ToString() ?? "");

					var IncomeTotal = baseIncome + bonus + overtime + commission + dividend;

					pdfFormFields.SetField("topmostSubform[0].Page2[0]._1c_IncomeTotal[0]", IncomeTotal.ToString());
					if (data.AdditionalEmploymentDetails[1].IsSelfEmployed.HasValue && data.AdditionalEmploymentDetails[1].IsSelfEmployed == true)
					{
						var SelfEmployeed = pdfFormFields.GetAppearanceStates("topmostSubform[0].Page2[0]._1c_Owner[0]");
						pdfFormFields.SetField("topmostSubform[0].Page2[0]._1c_Owner[0]", SelfEmployeed[0]);
					}
				}

				// Page 2 End C Section

				if (data.ApplicationPreviousEmployementDetails.Count > 0)
				{
					pdfFormFields.SetField("topmostSubform[0].Page2[0]._1d_State[0]", data.ApplicationPreviousEmployementDetails[0].StateId1d34);
				}
				else
				{
				}


				if (data.ApplicationIncomeSources.Count > 0)
				{
				}
				else
				{
				}


				// Page 3 is started from here...
				double totalCash = 0;
				if (data.ApplicationFinancialAssets != null)
				{
					if (data.ApplicationFinancialAssets.Count > 0)
					{
						pdfFormFields.SetField("topmostSubform[0].Page3[0].Table2a[0].TR1[0]._2a_Account1[0]", data.ApplicationFinancialAssets[0].AccountNumber2a3);
						pdfFormFields.SetField("topmostSubform[0].Page3[0].Table2a[0].TR1[0]._2a_Account_Type1[0]", data.ApplicationFinancialAssets[0].FinancialAccountType2a1);
						pdfFormFields.SetField("topmostSubform[0].Page3[0].Table2a[0].TR1[0]._2a_Cash1[0]", data.ApplicationFinancialAssets[0].Value2a4?.ToString());
						pdfFormFields.SetField("topmostSubform[0].Page3[0].Table2a[0].TR1[0]._2a_Financial1[0]", data.ApplicationFinancialAssets[0].FinancialInstitution2a2);
						pdfFormFields.SetField("topmostSubform[0].Page3[0].Table2b[0].TR1[0]._2b_Asset_Type1[0]", data.ApplicationFinancialOtherAssets[0].FinancialAssetsType2b1);
						pdfFormFields.SetField("topmostSubform[0].Page3[0].Table2b[0].TR1[0]._2b_Cash1[0]", data.ApplicationFinancialOtherAssets[0].Value2b2?.ToString());
						totalCash = totalCash + data.ApplicationFinancialAssets[0].Value2a4 ?? 0;
						assetsTotalCash = assetsTotalCash + data.ApplicationFinancialOtherAssets[0].Value2b2 ?? 0;
					}

					if (data.ApplicationFinancialAssets.Count > 1)
					{
						pdfFormFields.SetField("topmostSubform[0].Page3[0].Table2a[0].TR2[0]._2a_Account2[0]", data.ApplicationFinancialAssets[1].AccountNumber2a3);
						pdfFormFields.SetField("topmostSubform[0].Page3[0].Table2a[0].TR2[0]._2a_Account_Type2[0]", data.ApplicationFinancialAssets[1].FinancialAccountType2a1);
						pdfFormFields.SetField("topmostSubform[0].Page3[0].Table2a[0].TR2[0]._2a_Cash2[0]", data.ApplicationFinancialAssets[1].Value2a4?.ToString());
						pdfFormFields.SetField("topmostSubform[0].Page3[0].Table2a[0].TR2[0]._2a_Financial2[0]", data.ApplicationFinancialAssets[1].FinancialInstitution2a2);
						pdfFormFields.SetField("topmostSubform[0].Page3[0].Table2b[0].TR2[0]._2b_Asset_Type2[0]", data.ApplicationFinancialOtherAssets[1].FinancialAssetsType2b1);
						pdfFormFields.SetField("topmostSubform[0].Page3[0].Table2b[0].TR2[0]._2b_Cash2[0]", data.ApplicationFinancialOtherAssets[1].Value2b2?.ToString());
						totalCash = totalCash + data.ApplicationFinancialAssets[0].Value2a4 ?? 0;
						assetsTotalCash = assetsTotalCash + data.ApplicationFinancialOtherAssets[0].Value2b2 ?? 0;
					}
					if (data.ApplicationFinancialAssets.Count > 2)
					{
						pdfFormFields.SetField("topmostSubform[0].Page3[0].Table2a[0].TR3[0]._2a_Account3[0]", data.ApplicationFinancialAssets[2].AccountNumber2a3);
						pdfFormFields.SetField("topmostSubform[0].Page3[0].Table2a[0].TR3[0]._2a_Account_Type3[0]", data.ApplicationFinancialAssets[2].FinancialAccountType2a1);
						pdfFormFields.SetField("topmostSubform[0].Page3[0].Table2a[0].TR3[0]._2a_Cash3[0]", data.ApplicationFinancialAssets[2].Value2a4?.ToString());
						pdfFormFields.SetField("topmostSubform[0].Page3[0].Table2a[0].TR3[0]._2a_Financial3[0]", data.ApplicationFinancialAssets[2].FinancialInstitution2a2);
						pdfFormFields.SetField("topmostSubform[0].Page3[0].Table2b[0].TR3[0]._2b_Asset_Type3[0]", data.ApplicationFinancialOtherAssets[2].FinancialAssetsType2b1);
						pdfFormFields.SetField("topmostSubform[0].Page3[0].Table2b[0].TR3[0]._2b_Cash3[0]", data.ApplicationFinancialOtherAssets[2].Value2b2?.ToString());
						totalCash = totalCash + data.ApplicationFinancialAssets[0].Value2a4 ?? 0;
						assetsTotalCash = assetsTotalCash + data.ApplicationFinancialOtherAssets[0].Value2b2 ?? 0;
					}

					if (data.ApplicationFinancialAssets.Count > 3)
					{
						pdfFormFields.SetField("topmostSubform[0].Page3[0].Table2a[0].TR4[0]._2a_Account4[0]", data.ApplicationFinancialAssets[3].AccountNumber2a3);
						pdfFormFields.SetField("topmostSubform[0].Page3[0].Table2a[0].TR4[0]._2a_Account_Type4[0]", data.ApplicationFinancialAssets[3].FinancialAccountType2a1);
						pdfFormFields.SetField("topmostSubform[0].Page3[0].Table2a[0].TR4[0]._2a_Cash4[0]", data.ApplicationFinancialAssets[3].Value2a4?.ToString());
						pdfFormFields.SetField("topmostSubform[0].Page3[0].Table2a[0].TR4[0]._2a_Financial4[0]", data.ApplicationFinancialAssets[3].FinancialInstitution2a2);
						pdfFormFields.SetField("topmostSubform[0].Page3[0].Table2b[0].TR4[0]._2b_Asset_Type4[0]", data.ApplicationFinancialOtherAssets[3].FinancialAssetsType2b1);
						pdfFormFields.SetField("topmostSubform[0].Page3[0].Table2b[0].TR4[0]._2b_Cash4[0]", data.ApplicationFinancialOtherAssets[3].Value2b2?.ToString());
						totalCash = totalCash + data.ApplicationFinancialAssets[0].Value2a4 ?? 0;
						assetsTotalCash = assetsTotalCash + data.ApplicationFinancialOtherAssets[0].Value2b2 ?? 0;
					}

					if (data.ApplicationFinancialAssets.Count > 4)
					{
						pdfFormFields.SetField("topmostSubform[0].Page3[0].Table2a[0].TR5[0]._2a_Account5[0]", data.ApplicationFinancialAssets[4].AccountNumber2a3);
						pdfFormFields.SetField("topmostSubform[0].Page3[0].Table2a[0].TR5[0]._2a_Account_Type5[0]", data.ApplicationFinancialAssets[4].FinancialAccountType2a1);
						pdfFormFields.SetField("topmostSubform[0].Page3[0].Table2a[0].TR5[0]._2a_Cash5[0]", data.ApplicationFinancialAssets[4].Value2a4?.ToString());
						pdfFormFields.SetField("topmostSubform[0].Page3[0].Table2a[0].TR5[0]._2a_Financial5[0]", data.ApplicationFinancialAssets[4].FinancialInstitution2a2);
						totalCash = totalCash + data.ApplicationFinancialAssets[0].Value2a4 ?? 0;
					}


					pdfFormFields.SetField("topmostSubform[0].Page3[0].Table2a[0].TR6[0]._2a_Total_Cash[0]", totalCash.ToString());

					pdfFormFields.SetField("topmostSubform[0].Page3[0].Table2b[0].TR5[0]._2b_TotalCash[0]", assetsTotalCash.ToString());
					if (data.ApplicationFinancialLaibilities != null)
					{
						if (data.ApplicationFinancialLaibilities.Count > 0)
						{
							pdfFormFields.SetField("topmostSubform[0].Page3[0].Table2c[0].TR1[0]._2c_Account1[0]", data.ApplicationFinancialLaibilities[0].AccountNumber2c3);
							pdfFormFields.SetField("topmostSubform[0].Page3[0].Table2c[0].TR1[0]._2c_Account_Type1[0]", data.ApplicationFinancialLaibilities[0].FinancialLaibilitiesType2c1);
							pdfFormFields.SetField("topmostSubform[0].Page3[0].Table2c[0].TR1[0]._2c_Company1[0]", data.ApplicationFinancialLaibilities[0].CompanyName2c2);
							pdfFormFields.SetField("topmostSubform[0].Page3[0].Table2c[0].TR1[0]._2c_Monthly1[0]", data.ApplicationFinancialLaibilities[0].MonthlyValue2c6?.ToString());
							pdfFormFields.SetField("topmostSubform[0].Page3[0].Table2c[0].TR1[0]._2c_Paid_Off1[0]", data.ApplicationFinancialLaibilities[0].PaidOff2c5?.ToString());
							pdfFormFields.SetField("topmostSubform[0].Page3[0].Table2c[0].TR1[0]._2c_Unpaid1[0]", data.ApplicationFinancialLaibilities[0].UnpaidBalance2c4?.ToString());
						}
						if (data.ApplicationFinancialLaibilities.Count > 1)
						{

							pdfFormFields.SetField("topmostSubform[0].Page3[0].Table2c[0].TR2[0]._2c_Account2[0]", data.ApplicationFinancialLaibilities[1].AccountNumber2c3);
							pdfFormFields.SetField("topmostSubform[0].Page3[0].Table2c[0].TR2[0]._2c_Account_Type2[0]", data.ApplicationFinancialLaibilities[0].FinancialLaibilitiesType2c1);
							pdfFormFields.SetField("topmostSubform[0].Page3[0].Table2c[0].TR2[0]._2c_Company2[0]", data.ApplicationFinancialLaibilities[1].CompanyName2c2);
							pdfFormFields.SetField("topmostSubform[0].Page3[0].Table2c[0].TR2[0]._2c_Monthly2[0]", data.ApplicationFinancialLaibilities[1].MonthlyValue2c6?.ToString());
							pdfFormFields.SetField("topmostSubform[0].Page3[0].Table2c[0].TR2[0]._2c_Paid_Off2[0]", data.ApplicationFinancialLaibilities[1].PaidOff2c5?.ToString());
							pdfFormFields.SetField("topmostSubform[0].Page3[0].Table2c[0].TR2[0]._2c_Unpaid2[0]", data.ApplicationFinancialLaibilities[1].UnpaidBalance2c4?.ToString());
						}
						if (data.ApplicationFinancialLaibilities.Count > 2)
						{

							pdfFormFields.SetField("topmostSubform[0].Page3[0].Table2c[0].TR3[0]._2c_Account3[0]", data.ApplicationFinancialLaibilities[2].AccountNumber2c3);
							pdfFormFields.SetField("topmostSubform[0].Page3[0].Table2c[0].TR3[0]._2c_Account_Type3[0]", data.ApplicationFinancialLaibilities[0].FinancialLaibilitiesType2c1);
							pdfFormFields.SetField("topmostSubform[0].Page3[0].Table2c[0].TR3[0]._2c_Company3[0]", data.ApplicationFinancialLaibilities[2].CompanyName2c2);
							pdfFormFields.SetField("topmostSubform[0].Page3[0].Table2c[0].TR3[0]._2c_Monthly3[0]", data.ApplicationFinancialLaibilities[2].MonthlyValue2c6?.ToString());
							pdfFormFields.SetField("topmostSubform[0].Page3[0].Table2c[0].TR3[0]._2c_Paid_Off3[0]", data.ApplicationFinancialLaibilities[2].PaidOff2c5?.ToString());
							pdfFormFields.SetField("topmostSubform[0].Page3[0].Table2c[0].TR3[0]._2c_Unpaid3[0]", data.ApplicationFinancialLaibilities[2].UnpaidBalance2c4?.ToString());
						}
						if (data.ApplicationFinancialLaibilities.Count > 3)
						{
							pdfFormFields.SetField("topmostSubform[0].Page3[0].Table2c[0].TR4[0]._2c_Account4[0]", data.ApplicationFinancialLaibilities[3].AccountNumber2c3);
							pdfFormFields.SetField("topmostSubform[0].Page3[0].Table2c[0].TR4[0]._2c_Account_Type4[0]", data.ApplicationFinancialLaibilities[0].FinancialLaibilitiesType2c1);
							pdfFormFields.SetField("topmostSubform[0].Page3[0].Table2c[0].TR4[0]._2c_Company4[0]", data.ApplicationFinancialLaibilities[3].CompanyName2c2);
							pdfFormFields.SetField("topmostSubform[0].Page3[0].Table2c[0].TR4[0]._2c_Monthly4[0]", data.ApplicationFinancialLaibilities[3].MonthlyValue2c6?.ToString());
							pdfFormFields.SetField("topmostSubform[0].Page3[0].Table2c[0].TR4[0]._2c_Paid_Off4[0]", data.ApplicationFinancialLaibilities[3].PaidOff2c5?.ToString());
							pdfFormFields.SetField("topmostSubform[0].Page3[0].Table2c[0].TR4[0]._2c_Unpaid4[0]", data.ApplicationFinancialLaibilities[3].UnpaidBalance2c4?.ToString());
						}
						if (data.ApplicationFinancialLaibilities.Count > 4)
						{

							pdfFormFields.SetField("topmostSubform[0].Page3[0].Table2c[0].TR5[0]._2c_Account5[0]", data.ApplicationFinancialLaibilities[4].AccountNumber2c3);
							pdfFormFields.SetField("topmostSubform[0].Page3[0].Table2c[0].TR5[0]._2c_Account_Type5[0]", data.ApplicationFinancialLaibilities[0].FinancialLaibilitiesType2c1);
							pdfFormFields.SetField("topmostSubform[0].Page3[0].Table2c[0].TR5[0]._2c_Company5[0]", data.ApplicationFinancialLaibilities[4].CompanyName2c2);
							pdfFormFields.SetField("topmostSubform[0].Page3[0].Table2c[0].TR5[0]._2c_Monthly5[0]", data.ApplicationFinancialLaibilities[4].MonthlyValue2c6?.ToString());
							pdfFormFields.SetField("topmostSubform[0].Page3[0].Table2c[0].TR5[0]._2c_Paid_Off5[0]", data.ApplicationFinancialLaibilities[4].PaidOff2c5?.ToString());
							pdfFormFields.SetField("topmostSubform[0].Page3[0].Table2c[0].TR5[0]._2c_Unpaid5[0]", data.ApplicationFinancialLaibilities[4].UnpaidBalance2c4?.ToString());
						}
					}
					else
					{
						pdfFormFields.SetField("topmostSubform[0].Page3[0]._2b_Does_Not_Apply[0]", "1");
					}
				}
				else
				{
					pdfFormFields.SetField("topmostSubform[0].Page3[0]._2d_Does_Not_Apply[0]", "1");
				}

				// Page 3 ended here ..

				// Page 4 start from here ..
				if (data.ApplicationFinancialRealEstates != null && data.ApplicationFinancialRealEstates.Count != 0)
				{
					if (data.ApplicationFinancialRealEstates.Count > 0)
					{

						if (data.ApplicationFinancialRealEstates[0].MortageLoanOnPropertyDetails.Count > 0)
						{
							pdfFormFields.SetField("topmostSubform[0].Page4[0].Table3a[0].TR1[0]._3a_Account1[0]", data.ApplicationFinancialRealEstates[0].MortageLoanOnPropertyDetails[0].AccountNumber3a10);
							pdfFormFields.SetField("topmostSubform[0].Page4[0].Table3a[0].TR1[0]._3a_Creditor1[0]", data.ApplicationFinancialRealEstates[0].MortageLoanOnPropertyDetails[0].CreditorName3a9);
							pdfFormFields.SetField("topmostSubform[0].Page4[0].Table3a[0].TR1[0]._3a_Monthly_Mortgage1[0]", (data.ApplicationFinancialRealEstates[0].MortageLoanOnPropertyDetails[0].MonthlyMortagePayment3a11 ?? 0).ToString());
							pdfFormFields.SetField("topmostSubform[0].Page4[0].Table3a[0].TR1[0]._3a_Paid_Off1[0]", (data.ApplicationFinancialRealEstates[0].MortageLoanOnPropertyDetails[0].PaidOff3a13 ?? 0).ToString());
							pdfFormFields.SetField("topmostSubform[0].Page4[0].Table3a[0].TR1[0]._3a_Type1[0]", data.ApplicationFinancialRealEstates[0].MortageLoanOnPropertyDetails[0].MortageLoanType3a14);
							pdfFormFields.SetField("topmostSubform[0].Page4[0].Table3a[0].TR1[0]._3a_Unpaid1[0]", (data.ApplicationFinancialRealEstates[0].MortageLoanOnPropertyDetails[0].UnpaidBalance3a12 ?? 0).ToString());
						}
						else if (data.ApplicationFinancialRealEstates[0].MortageLoanOnPropertyDetails.Count > 0)
						{
							pdfFormFields.SetField("topmostSubform[0].Page4[0].Table3a[0].TR2[0]._3a_Account2[0]", data.ApplicationFinancialRealEstates[0].MortageLoanOnPropertyDetails[1].AccountNumber3a10);
							pdfFormFields.SetField("topmostSubform[0].Page4[0].Table3a[0].TR2[0]._3a_Creditor2[0]", data.ApplicationFinancialRealEstates[0].MortageLoanOnPropertyDetails[1].CreditorName3a9);
							pdfFormFields.SetField("topmostSubform[0].Page4[0].Table3a[0].TR2[0]._3a_Monthly_Mortgage2[0]", data.ApplicationFinancialRealEstates[0].MortageLoanOnPropertyDetails[1].MonthlyMortagePayment3a11.ToString());
							pdfFormFields.SetField("topmostSubform[0].Page4[0].Table3a[0].TR2[0]._3a_Paid_Off2[0]", data.ApplicationFinancialRealEstates[0].MortageLoanOnPropertyDetails[1].PaidOff3a13.ToString());
							pdfFormFields.SetField("topmostSubform[0].Page4[0].Table3a[0].TR2[0]._3a_Type2[0]", data.ApplicationFinancialRealEstates[0].MortageLoanOnPropertyDetails[1].MortageLoanType3a14);
							pdfFormFields.SetField("topmostSubform[0].Page4[0].Table3a[0].TR2[0]._3a_Unpaid2[0]", data.ApplicationFinancialRealEstates[0].MortageLoanOnPropertyDetails[1].UnpaidBalance3a12.ToString());
						}
					}
					if (data.ApplicationFinancialRealEstates.Count > 1)
					{
						if (data.ApplicationFinancialRealEstates[1].MortageLoanOnPropertyDetails.Count > 0)
						{
							pdfFormFields.SetField("topmostSubform[0].Page4[0].Table3a[0].TR1[0]._3b_Account1[0]", data.ApplicationFinancialRealEstates[1].MortageLoanOnPropertyDetails[0].AccountNumber3a10);
							pdfFormFields.SetField("topmostSubform[0].Page4[0].Table3a[0].TR1[0]._3b_Creditor1[0]", data.ApplicationFinancialRealEstates[1].MortageLoanOnPropertyDetails[0].CreditorName3a9);
							pdfFormFields.SetField("topmostSubform[0].Page4[0].Table3a[0].TR1[0]._3b_Monthly_Mortgage1[0]", (data.ApplicationFinancialRealEstates[1].MortageLoanOnPropertyDetails[0].MonthlyMortagePayment3a11 ?? 0).ToString());
							pdfFormFields.SetField("topmostSubform[0].Page4[0].Table3a[0].TR1[0]._3b_Paid_Off1[0]", (data.ApplicationFinancialRealEstates[1].MortageLoanOnPropertyDetails[0].PaidOff3a13 ?? 0).ToString());
							pdfFormFields.SetField("topmostSubform[0].Page4[0].Table3a[0].TR1[0]._3b_Type1[0]", data.ApplicationFinancialRealEstates[1].MortageLoanOnPropertyDetails[0].MortageLoanType3a14);
							pdfFormFields.SetField("topmostSubform[0].Page4[0].Table3a[0].TR1[0]._3b_Unpaid1[0]", (data.ApplicationFinancialRealEstates[1].MortageLoanOnPropertyDetails[0].UnpaidBalance3a12 ?? 0).ToString());
						}
						else if (data.ApplicationFinancialRealEstates[1].MortageLoanOnPropertyDetails.Count > 0)
						{
							pdfFormFields.SetField("topmostSubform[0].Page4[0].Table3a[0].TR2[0]._3b_Account2[0]", data.ApplicationFinancialRealEstates[1].MortageLoanOnPropertyDetails[1].AccountNumber3a10);
							pdfFormFields.SetField("topmostSubform[0].Page4[0].Table3a[0].TR2[0]._3b_Creditor2[0]", data.ApplicationFinancialRealEstates[1].MortageLoanOnPropertyDetails[1].CreditorName3a9);
							pdfFormFields.SetField("topmostSubform[0].Page4[0].Table3a[0].TR2[0]._3b_Monthly_Mortgage2[0]", data.ApplicationFinancialRealEstates[1].MortageLoanOnPropertyDetails[1].MonthlyMortagePayment3a11.ToString());
							pdfFormFields.SetField("topmostSubform[0].Page4[0].Table3a[0].TR2[0]._3b_Paid_Off2[0]", data.ApplicationFinancialRealEstates[1].MortageLoanOnPropertyDetails[1].PaidOff3a13.ToString());
							pdfFormFields.SetField("topmostSubform[0].Page4[0].Table3a[0].TR2[0]._3b_Type2[0]", data.ApplicationFinancialRealEstates[1].MortageLoanOnPropertyDetails[1].MortageLoanType3a14);
							pdfFormFields.SetField("topmostSubform[0].Page4[0].Table3a[0].TR2[0]._3b_Unpaid2[0]", data.ApplicationFinancialRealEstates[1].MortageLoanOnPropertyDetails[1].UnpaidBalance3a12.ToString());
						}
					}
					if (data.ApplicationFinancialRealEstates.Count > 2)
					{
						if (data.ApplicationFinancialRealEstates[2].MortageLoanOnPropertyDetails.Count > 0)
						{
							pdfFormFields.SetField("topmostSubform[0].Page4[0].Table3a[0].TR1[0]._3c_Account1[0]", data.ApplicationFinancialRealEstates[2].MortageLoanOnPropertyDetails[0].AccountNumber3a10);
							pdfFormFields.SetField("topmostSubform[0].Page4[0].Table3a[0].TR1[0]._3c_Creditor1[0]", data.ApplicationFinancialRealEstates[2].MortageLoanOnPropertyDetails[0].CreditorName3a9);
							pdfFormFields.SetField("topmostSubform[0].Page4[0].Table3a[0].TR1[0]._3c_Monthly_Mortgage1[0]", (data.ApplicationFinancialRealEstates[2].MortageLoanOnPropertyDetails[0].MonthlyMortagePayment3a11 ?? 0).ToString());
							pdfFormFields.SetField("topmostSubform[0].Page4[0].Table3a[0].TR1[0]._3c_Paid_Off1[0]", (data.ApplicationFinancialRealEstates[2].MortageLoanOnPropertyDetails[0].PaidOff3a13 ?? 0).ToString());
							pdfFormFields.SetField("topmostSubform[0].Page4[0].Table3a[0].TR1[0]._3c_Type1[0]", data.ApplicationFinancialRealEstates[2].MortageLoanOnPropertyDetails[0].MortageLoanType3a14);
							pdfFormFields.SetField("topmostSubform[0].Page4[0].Table3a[0].TR1[0]._3c_Unpaid1[0]", (data.ApplicationFinancialRealEstates[2].MortageLoanOnPropertyDetails[0].UnpaidBalance3a12 ?? 0).ToString());
						}
						else if (data.ApplicationFinancialRealEstates[2].MortageLoanOnPropertyDetails.Count > 0)
						{
							pdfFormFields.SetField("topmostSubform[0].Page4[0].Table3a[0].TR2[0]._3c_Account2[0]", data.ApplicationFinancialRealEstates[2].MortageLoanOnPropertyDetails[1].AccountNumber3a10);
							pdfFormFields.SetField("topmostSubform[0].Page4[0].Table3a[0].TR2[0]._3c_Creditor2[0]", data.ApplicationFinancialRealEstates[2].MortageLoanOnPropertyDetails[1].CreditorName3a9);
							pdfFormFields.SetField("topmostSubform[0].Page4[0].Table3a[0].TR2[0]._3c_Monthly_Mortgage2[0]", data.ApplicationFinancialRealEstates[2].MortageLoanOnPropertyDetails[1].MonthlyMortagePayment3a11.ToString());
							pdfFormFields.SetField("topmostSubform[0].Page4[0].Table3a[0].TR2[0]._3c_Paid_Off2[0]", data.ApplicationFinancialRealEstates[2].MortageLoanOnPropertyDetails[1].PaidOff3a13.ToString());
							pdfFormFields.SetField("topmostSubform[0].Page4[0].Table3a[0].TR2[0]._3c_Type2[0]", data.ApplicationFinancialRealEstates[2].MortageLoanOnPropertyDetails[1].MortageLoanType3a14);
							pdfFormFields.SetField("topmostSubform[0].Page4[0].Table3a[0].TR2[0]._3c_Unpaid2[0]", data.ApplicationFinancialRealEstates[2].MortageLoanOnPropertyDetails[1].UnpaidBalance3a12.ToString());
						}
					}
				}
				else
				{
					pdfFormFields.SetField("topmostSubform[0].Page4[0]._3_Do_Not_Own[0]", "1");
				}

				if (data.ApplicationFinancialRealEstates != null && data.ApplicationFinancialRealEstates.Count > 0 && !String.IsNullOrEmpty(data.ApplicationFinancialRealEstates[0].City3a23) && !String.IsNullOrEmpty(data.ApplicationFinancialRealEstates[0].State3a24) && !String.IsNullOrEmpty(data.ApplicationFinancialRealEstates[0].Zip3a25))
				{
					pdfFormFields.SetField("topmostSubform[0].Page4[0]._3a_Address_City[0]", data.ApplicationFinancialRealEstates[0]?.City3a23);
					pdfFormFields.SetField("topmostSubform[0].Page4[0]._3a_Address_St[0]", data.ApplicationFinancialRealEstates[0]?.Street3a21);
					pdfFormFields.SetField("topmostSubform[0].Page4[0]._3a_Address_State[0]", data.ApplicationFinancialRealEstates[0]?.State3a24);
					pdfFormFields.SetField("topmostSubform[0].Page4[0]._3a_Address_Zip[0]", data.ApplicationFinancialRealEstates[0]?.Zip3a25);
					pdfFormFields.SetField("topmostSubform[0].Page4[0]._3a_Monthly_Expenses[0]", data.ApplicationFinancialRealEstates[0]?.MonthlyMortagePayment3a6?.ToString());
					pdfFormFields.SetField("topmostSubform[0].Page4[0]._3a_Monthly_Rent[0]", data.ApplicationFinancialRealEstates[0]?.MonthlyRentalIncome3a7?.ToString());
					pdfFormFields.SetField("topmostSubform[0].Page4[0]._3a_Net_Monthly[0]", data.ApplicationFinancialRealEstates[0]?.NetMonthlyRentalIncome3a8?.ToString());
					pdfFormFields.SetField("topmostSubform[0].Page4[0]._3a_Status[0]", data.ApplicationFinancialRealEstates[0]?.FinancialPropertyStatus3a4);
					pdfFormFields.SetField("topmostSubform[0].Page4[0]._3a_Value[0]", data.ApplicationFinancialRealEstates[0]?.PropertyValue3a3.ToString());
				}
				else
				{
					pdfFormFields.SetField("topmostSubform[0].Page4[0]._3a_Mortgage_Does_Not_Apply[0]", "1");
				}

				if (data.ApplicationFinancialRealEstates != null && data.ApplicationFinancialRealEstates.Count > 1 && !String.IsNullOrEmpty(data.ApplicationFinancialRealEstates[1].FinancialPropertyStatus3a4) && data.ApplicationFinancialRealEstates[1].PropertyValue3a3 != null)
				{

					pdfFormFields.SetField("topmostSubform[0].Page4[0]._3b_Address_City[0]", data.ApplicationFinancialRealEstates[1].City3a23);
					pdfFormFields.SetField("topmostSubform[0].Page4[0]._3b_Address_St[0]", data.ApplicationFinancialRealEstates[1].Street3a21);
					pdfFormFields.SetField("topmostSubform[0].Page4[0]._3b_Address_State[0]", data.ApplicationFinancialRealEstates[1].State3a24);
					pdfFormFields.SetField("topmostSubform[0].Page4[0]._3b_Address_Zip[0]", data.ApplicationFinancialRealEstates[1].Zip3a25);
					pdfFormFields.SetField("topmostSubform[0].Page4[0]._3b_Monthly_Expenses[0]", data.ApplicationFinancialRealEstates[1]?.MonthlyMortagePayment3a6.ToString());
					pdfFormFields.SetField("topmostSubform[0].Page4[0]._3b_Monthly_Rent[0]", data.ApplicationFinancialRealEstates[1].MonthlyRentalIncome3a7.ToString());
					pdfFormFields.SetField("topmostSubform[0].Page4[0]._3b_Net_Monthly[0]", data.ApplicationFinancialRealEstates[1].NetMonthlyRentalIncome3a8.ToString());
					pdfFormFields.SetField("topmostSubform[0].Page4[0]._3b_Status[0]", data.ApplicationFinancialRealEstates[1].FinancialPropertyStatus3a4);
					pdfFormFields.SetField("topmostSubform[0].Page4[0]._3b_Value[0]", data.ApplicationFinancialRealEstates[1].PropertyValue3a3.ToString());
				}
				else
				{
					pdfFormFields.SetField("topmostSubform[0].Page4[0]._3b_Mortgage_Does_Not_Apply[0]", "0");
				}


				if (data.ApplicationFinancialRealEstates != null && data.ApplicationFinancialRealEstates.Count > 2 && !String.IsNullOrEmpty(data.ApplicationFinancialRealEstates[2].City3a23) && !String.IsNullOrEmpty(data.ApplicationFinancialRealEstates[2].Street3a21.ToString()))
				{
					pdfFormFields.SetField("topmostSubform[0].Page4[0]._3c_Address_City[0]", data.ApplicationFinancialRealEstates[2].City3a23);
					pdfFormFields.SetField("topmostSubform[0].Page4[0]._3c_Address_St[0]", data.ApplicationFinancialRealEstates[2].Street3a21);
					pdfFormFields.SetField("topmostSubform[0].Page4[0]._3c_Address_State[0]", data.ApplicationFinancialRealEstates[2].State3a24);
					pdfFormFields.SetField("topmostSubform[0].Page4[0]._3c_Address_Zip[0]", data.ApplicationFinancialRealEstates[2].Zip3a25);
					pdfFormFields.SetField("topmostSubform[0].Page4[0]._3c_Monthly_Expenses[0]", data.ApplicationFinancialRealEstates[2]?.MonthlyMortagePayment3a6.ToString());
					pdfFormFields.SetField("topmostSubform[0].Page4[0]._3c_Monthly_Rent[0]", data.ApplicationFinancialRealEstates[2].MonthlyRentalIncome3a7.ToString());
					pdfFormFields.SetField("topmostSubform[0].Page4[0]._3c_Mortgage_Does_Not_Apply[0]", "1");
					pdfFormFields.SetField("topmostSubform[0].Page4[0]._3c_Net_Monthly[0]", data.ApplicationFinancialRealEstates[2].NetMonthlyRentalIncome3a8.ToString());
					pdfFormFields.SetField("topmostSubform[0].Page4[0]._3c_Status[0]", data.ApplicationFinancialRealEstates[2].FinancialPropertyStatus3a4);
					pdfFormFields.SetField("topmostSubform[0].Page4[0]._3c_Value[0]", data.ApplicationFinancialRealEstates[2].PropertyValue3a3.ToString());
				}

				// Page 4 ended here ..

				// Page 5 starts here ..
				if (data.LoanAndPropertyInformations != null && data.LoanAndPropertyInformations.Count > 0)
				{
					pdfFormFields.SetField("topmostSubform[0].Page5[0]._4a_Address_City[0]", data.LoanAndPropertyInformations[0].City4a33);
					pdfFormFields.SetField("topmostSubform[0].Page5[0]._4a_Address_State[0]", data.LoanAndPropertyInformations[0].State4a34);
					pdfFormFields.SetField("topmostSubform[0].Page5[0]._4a_FHA[0]", "1");
					pdfFormFields.SetField("topmostSubform[0].Page5[0]._4a_Loan_Amount[0]", data.LoanAndPropertyInformations[0].LoanAmount4a1?.ToString());
					pdfFormFields.SetField("topmostSubform[0].Page5[0]._4a_Value[0]", data.LoanAndPropertyInformations[0].PropertyValue4a5.ToString());
				}

				if (data.LoanAndPropertyInformationOtherMortageLoans[0].LoanAmount4b4 != null && data.LoanAndPropertyInformationOtherMortageLoans[0].MonthlyPayment4b3 != null)
				{
					pdfFormFields.SetField("topmostSubform[0].Page5[0]._4b_Table[0].TR1[0]._4b_Amount1[0]", data.LoanAndPropertyInformationOtherMortageLoans[0].LoanAmount4b4.ToString());
					pdfFormFields.SetField("topmostSubform[0].Page5[0]._4b_Table[0].TR1[0]._4b_Monthly1[0]", data.LoanAndPropertyInformationOtherMortageLoans[0].MonthlyPayment4b3.ToString());
					pdfFormFields.SetField("topmostSubform[0].Page5[0]._4b_Table[0].TR2[0]._4b_Amount2[0]", data.LoanAndPropertyInformationOtherMortageLoans[0].CreditAmount4b5.ToString());
				}
				else
				{
					pdfFormFields.SetField("topmostSubform[0].Page5[0]._4b_Does_Not_Apply[0]", "1");
				}

				if (false)
				{ }
				else
				{
					pdfFormFields.SetField("topmostSubform[0].Page5[0]._4c_Does_Not_Apply[0]", "1");
				}

				if (data.LoanAndPropertyInformationGifts != null && data.LoanAndPropertyInformationGifts[0]?.Value4d4 != 0 && !String.IsNullOrEmpty(data.LoanAndPropertyInformationGifts[0]?.LoanPropertyGiftType4d1))
				{
					pdfFormFields.SetField("topmostSubform[0].Page5[0]._4d_Table[0].TR1[0]._4d_Cash1[0]", data.LoanAndPropertyInformationGifts[0].Value4d4.ToString());
					pdfFormFields.SetField("topmostSubform[0].Page5[0]._4d_Table[0].TR1[0]._4d_Source1[0]", data.LoanAndPropertyInformationGifts[0].LoanPropertyGiftType4d1.ToString());
				}
				else
				{
					pdfFormFields.SetField("topmostSubform[0].Page5[0]._4d_Does_Not_Apply[0]", "1");
				}

				if (data.LoanAndPropertyInformations[0].LoanPurpose4a2 == "1")
				{
					pdfFormFields.SetField("topmostSubform[0].Page5[0].loan_purpose[0].purchase[0]._4a_Purchase[0]", "1");
				}
				else if (data.LoanAndPropertyInformations[0].LoanPurpose4a2 == "2")
				{
					pdfFormFields.SetField("topmostSubform[0].Page5[0].loan_purpose[0].other[0]._4a_Purpose_other_spec[0]", "1");
				}
				else if (data.LoanAndPropertyInformations[0].LoanPurpose4a2 == "3")
				{
					pdfFormFields.SetField("topmostSubform[0].Page5[0].loan_purpose[0].refinance[0]._4a_Refinance[0]", "1");
				}

				if (data.LoanAndPropertyInformations[0].LoanPropertyOccupancy4a6 == "1")
				{
					pdfFormFields.SetField("topmostSubform[0].Page5[0].occupancy[0].primary[0]._4a_Primary[0]", "1");
				}
				else if (data.LoanAndPropertyInformations[0].LoanPropertyOccupancy4a6 == "2")
				{
					pdfFormFields.SetField("topmostSubform[0].Page5[0].occupancy[0].secondary[0]._4a_SecondHome[0]", "1");
				}
				else if (data.LoanAndPropertyInformations[0].LoanPropertyOccupancy4a6 == "3")
				{
					pdfFormFields.SetField("topmostSubform[0].Page5[0].occupancy[0].invest[0]._4a_Investment[0]", "1");
				}

                // Page 5 ended here ..

                // Page 6 starts here ..
                #region Page 6

                if (!(data.DeclarationQuestions.Where(x=>x.Question.Contains("5a.1.0")).FirstOrDefault().YesNo ?? false))
                    pdfFormFields.SetField("topmostSubform[0].Page6[0]._5aA_primary[0].no[0]._5aA_primary_no[0]", "1");
                else
                    pdfFormFields.SetField("topmostSubform[0].Page6[0]._5aA_primary[0].yes[0]._5aA_primary_yes[0]", "1");


                if (!(data.DeclarationQuestions.Where(x => x.Question.Contains("5a.1.1")).FirstOrDefault().YesNo ?? false))
                    pdfFormFields.SetField("topmostSubform[0].Page6[0]._5aI[0].no[0]._5bI_no[0]", "1");
                else
                    pdfFormFields.SetField("topmostSubform[0].Page6[0]._5aI[0].yes[0]._5bI_yes[0]", "1");


				if (!(data.DeclarationQuestions.Where(x => x.Question.Contains("5a.2")).FirstOrDefault().YesNo ?? false))
					pdfFormFields.SetField("topmostSubform[0].Page6[0]._5aB[0].no[0]._5aB_no[0]", "1");
				else
					pdfFormFields.SetField("topmostSubform[0].Page6[0]._5aB[0].yes[0]._5aB_yes[0]", "1");


				if (!(data.DeclarationQuestions.Where(x => x.Question.Contains("5a.3.0")).FirstOrDefault().YesNo ?? false))
                    pdfFormFields.SetField("topmostSubform[0].Page6[0]._5aC[0].no[0]._5aC_no[0]", "1");
                else
                    pdfFormFields.SetField("topmostSubform[0].Page6[0]._5aC[0].yes[0]._5aC_yes[0]", "1");
                

                if (!(data.DeclarationQuestions.Where(x => x.Question.Contains("5a.4.1")).FirstOrDefault().YesNo ?? false))
                    pdfFormFields.SetField("topmostSubform[0].Page6[0]._5aD2[0].no[0]._5aD2_no[0]", "1");
                else
					pdfFormFields.SetField("topmostSubform[0].Page6[0]._5aD2[0].yes[0]._5aD2_yes[0]", "1");
                

                if (!(data.DeclarationQuestions.Where(x => x.Question.Contains("5a.4.2")).FirstOrDefault().YesNo ?? false))
                    pdfFormFields.SetField("topmostSubform[0].Page6[0]._5aD1[0].no[0]._5aD1_no[0]", "1");
                else
                    pdfFormFields.SetField("topmostSubform[0].Page6[0]._5aD1[0].yes[0]._5aD1_yes[0]", "1");
                

				if(!(data.DeclarationQuestions.Where(x => x.Question.Contains("5a.5")).FirstOrDefault().YesNo ?? false))
					pdfFormFields.SetField("topmostSubform[0].Page6[0]._5aE[0].no[0]._5aE_no[0]", "1");
                else
					pdfFormFields.SetField("topmostSubform[0].Page6[0]._5aE[0].yes[0]._5aE_yes[0]", "1");

                
				if (!(data.DeclarationQuestions.Where(x => x.Question.Contains("5b.1")).FirstOrDefault().YesNo ?? false))
                    pdfFormFields.SetField("topmostSubform[0].Page6[0]._5bF[0].no[0]._5bF_no[0]", "1");
                else
                    pdfFormFields.SetField("topmostSubform[0].Page6[0]._5bF[0].yes[0]._5bF_yes[0]", "1");
                
				
				if (!(data.DeclarationQuestions.Where(x => x.Question.Contains("5b.2")).FirstOrDefault().YesNo ?? false))
                    pdfFormFields.SetField("topmostSubform[0].Page6[0]._5bG[0].no[0]._5bG_no[0]", "1");
                else
                    pdfFormFields.SetField("topmostSubform[0].Page6[0]._5bG[0].yes[0]._5bG_yes[0]", "1");


                if (!(data.DeclarationQuestions.Where(x => x.Question.Contains("5b.3")).FirstOrDefault().YesNo ?? false))
                    pdfFormFields.SetField("topmostSubform[0].Page6[0]._5bH[0].no[0]._5bH_no[0]", "1");
                else
                    pdfFormFields.SetField("topmostSubform[0].Page6[0]._5bH[0].yes[0]._5bH_yes[0]", "1");
               
				
                if (!(data.DeclarationQuestions.Where(x => x.Question.Contains("5b.4")).FirstOrDefault().YesNo ?? false))
                    pdfFormFields.SetField("topmostSubform[0].Page6[0]._5aI[0].no[0]._5bI_no[0]", "1");
                else
                    pdfFormFields.SetField("topmostSubform[0].Page6[0]._5aI[0].yes[0]._5bI_yes[0]", "1");

				
				if (!(data.DeclarationQuestions.Where(x => x.Question.Contains("5b.5")).FirstOrDefault().YesNo ?? false))
                    pdfFormFields.SetField("topmostSubform[0].Page6[0]._5bJ[0].no[0]._5bJ_no[0]", "1");
                else
                    pdfFormFields.SetField("topmostSubform[0].Page6[0]._5bJ[0].yes[0]._5bJ_yes[0]", "1");


                if (!(data.DeclarationQuestions.Where(x => x.Question.Contains("5b.6")).FirstOrDefault().YesNo ?? false))
                    pdfFormFields.SetField("topmostSubform[0].Page6[0]._5bK[0].no[0]._5bK_no[0]", "1");
                else
                    pdfFormFields.SetField("topmostSubform[0].Page6[0]._5bK[0].yes[0]._5bK_yes[0]", "1");
				

                if (!(data.DeclarationQuestions.Where(x => x.Question.Contains("5b.7")).FirstOrDefault().YesNo ?? false))
                    pdfFormFields.SetField("topmostSubform[0].Page6[0]._5bL[0].no[0]._5bL_no[0]", "1");
                else
                    pdfFormFields.SetField("topmostSubform[0].Page6[0]._5bL[0].yes[0]._5bL_yes[0]", "1");


                if (!(data.DeclarationQuestions.Where(x => x.Question.Contains("5b.8.0")).FirstOrDefault().YesNo ?? false))
                    pdfFormFields.SetField("topmostSubform[0].Page6[0]._5bM[0].no[0]._5bM_no[0]", "1");
                else
                    pdfFormFields.SetField("topmostSubform[0].Page6[0]._5bM[0].yes[0]._5bM_yes[0]", "1");

				if (data.DeclarationQuestions.Where(x => x.Question.Contains("5b.8.1.1")).FirstOrDefault().YesNo ?? false)
					pdfFormFields.SetField("topmostSubform[0].Page6[0]._5bM_type[0].ch7[0]._5bM_ch7[0]", "1");
				if (data.DeclarationQuestions.Where(x => x.Question.Contains("5b.8.1.2")).FirstOrDefault().YesNo ?? false)
					pdfFormFields.SetField("topmostSubform[0].Page6[0]._5bM_type[0].ch11[0]._5bM_ch11[0]", "1");
                if (data.DeclarationQuestions.Where(x => x.Question.Contains("5b.8.1.3")).FirstOrDefault().YesNo ?? false)
					pdfFormFields.SetField("topmostSubform[0].Page6[0]._5bM_type[0].ch12[0]._5bM_ch12[0]", "1");
				if (data.DeclarationQuestions.Where(x => x.Question.Contains("5b.8.1.4")).FirstOrDefault().YesNo ?? false)
					pdfFormFields.SetField("topmostSubform[0].Page6[0]._5bM_type[0].ch13[0]._5bM_ch13[0]", "1");

                #endregion
                // Page 6 ends here ..

                if (data.DemographicInformations != null)
				{
					foreach (var ethnic in data.DemographicInformations)
					{
						switch (ethnic.Ethnicity81?.ToLower())
						{
							case "hispanicorlatino":
								{
									var HispanicOrLatino = pdfFormFields.GetAppearanceStates("topmostSubform[0].Page8[0].ethnicity[0].hispanic[0]._8_hispanic[0]");
									pdfFormFields.SetField("topmostSubform[0].Page8[0].ethnicity[0].hispanic[0]._8_hispanic[0]", HispanicOrLatino[0]);
								}
								break;
							case "mexican":
								{
									var Mexican = pdfFormFields.GetAppearanceStates("topmostSubform[0].Page8[0].ethnicity[0].hispanic[0].hispanic[0].mexican[0]._8_ethnicity_Mexican[0]");
									pdfFormFields.SetField("topmostSubform[0].Page8[0].ethnicity[0].hispanic[0].hispanic[0].mexican[0]._8_ethnicity_Mexican[0]", Mexican[0]);
								}
								break;
							case "puertorican":
								{
									var PuertoRican = pdfFormFields.GetAppearanceStates("topmostSubform[0].Page8[0].ethnicity[0].hispanic[0].hispanic[0].puertorican[0]._8_ethnicity_Puerto_Rican[0]");
									pdfFormFields.SetField("topmostSubform[0].Page8[0].ethnicity[0].hispanic[0].hispanic[0].puertorican[0]._8_ethnicity_Puerto_Rican[0]", PuertoRican[0]);
								};
								break;
							case "cuban":
								{
									var Cuban = pdfFormFields.GetAppearanceStates("topmostSubform[0].Page8[0].ethnicity[0].hispanic[0].hispanic[0].cuban[0]._8_ethnicity_Cuban[0]");
									pdfFormFields.SetField("topmostSubform[0].Page8[0].ethnicity[0].hispanic[0].hispanic[0].cuban[0]._8_ethnicity_Cuban[0]", Cuban[0]);

								}
								break;
							case "otherhispanicorlatino":
								{
									var OtherHispanicOrLatino = pdfFormFields.GetAppearanceStates("topmostSubform[0].Page8[0].ethnicity[0].hispanic[0].hispanic[0].other[0]._8_hispanic_other[0]");
									pdfFormFields.SetField("topmostSubform[0].Page8[0].ethnicity[0].hispanic[0].hispanic[0].other[0]._8_hispanic_other[0]", OtherHispanicOrLatino[0]);
									//  pdfFormFields.SetField("topmostSubform[0].Page8[0].ethnicity[0].hispanic[0].hispanic[0].other[0]._8_other_hispanic[0]", data.Declaration.BorrowerDemographic.Ethnicity);
								}
								break;
							case "nothispanicorlatino":
								{
									var NotHispanicOrLatino = pdfFormFields.GetAppearanceStates("topmostSubform[0].Page8[0].ethnicity[0].not_hispanic[0]._8_not_hispanic[0]");

									pdfFormFields.SetField("topmostSubform[0].Page8[0].ethnicity[0].not_hispanic[0]._8_not_hispanic[0]", NotHispanicOrLatino[0]);
								}
								break;
							case "cannotprovideethnic":
								{
									var CanNotProvideEthnic = pdfFormFields.GetAppearanceStates("topmostSubform[0].Page8[0].ethnicity[0].refuse[0]._8_ethnicity_refuse[0]");
									pdfFormFields.SetField("topmostSubform[0].Page8[0].ethnicity[0].refuse[0]._8_ethnicity_refuse[0]", CanNotProvideEthnic[0]);
								}
								break;
							default:
								break;
						}
					}
				}

				pdfFormFields.SetField("topmostSubform[0].Page8[0]._8_infosrc[0].email[0]._8_infosrc_email[0]", "1");
				pdfFormFields.SetField("topmostSubform[0].Page8[0]._8_infosrc[0].face[0]._8_infosrc_face[0]", "0");
				pdfFormFields.SetField("topmostSubform[0].Page8[0]._8_infosrc[0].fax[0]._8_infosrc_fax[0]", "0");
				pdfFormFields.SetField("topmostSubform[0].Page8[0]._8_infosrc[0].phone[0]._8_infosrc_phone[0]", "0");


				foreach (var demographicInformation in data.DemographicInformations)
					switch (demographicInformation.Race83)
					{
						case "AmericanIndian":
						case "AlaskaNative":
							{
								var AmericanIndianOrAlaskaNative = pdfFormFields.GetAppearanceStates("topmostSubform[0].Page8[0]._8_race[0].native_american[0]._8_race_native_american[0]");
								var RaceTribe = pdfFormFields.GetAppearanceStates("topmostSubform[0].Page8[0]._8_race[0].native_american[0]._8_race_tribe[0]");
								//var BorrowerAmericanIndianOrAlaskaNative = pdfFormFields.GetAppearanceStates("race 1");
								//pdfFormFields.SetField("race 1", BorrowerAmericanIndianOrAlaskaNative[0]);
								pdfFormFields.SetField("topmostSubform[0].Page8[0]._8_race[0].native_american[0]._8_race_native_american[0]", AmericanIndianOrAlaskaNative[0]);
								pdfFormFields.SetField("topmostSubform[0].Page8[0]._8_race[0].native_american[0]._8_race_tribe[0]", RaceTribe[0]);
							}

							break;
						case "asian":
							{
								var Asian = pdfFormFields.GetAppearanceStates("topmostSubform[0].Page8[0]._8_race[0].asian[0]._8_race_asian[0]");
								pdfFormFields.SetField("topmostSubform[0].Page8[0]._8_race[0].asian[0]._8_race_asian[0]", Asian[0]);
							}
							break;
						case "asianindian":
							{
								var AsianIndian = pdfFormFields.GetAppearanceStates("topmostSubform[0].Page8[0]._8_race[0].asian[0].asian[0].indian[0]._8_race_indian[0]");
								pdfFormFields.SetField("topmostSubform[0].Page8[0]._8_race[0].asian[0].asian[0].indian[0]._8_race_indian[0]", AsianIndian[0]);
							}
							break;
						case "black":
						case "africanamerican":
							{
								var BlackOrAfricanAmerican = pdfFormFields.GetAppearanceStates("topmostSubform[0].Page8[0]._8_race[0].black[0]._8_race_black[0]");
								pdfFormFields.SetField("topmostSubform[0].Page8[0]._8_race[0].black[0]._8_race_black[0]", BlackOrAfricanAmerican[0]);

							}
							break;
						case "cannotproviderace":
							{
								var CanNotProvideRace = pdfFormFields.GetAppearanceStates("topmostSubform[0].Page8[0]._8_race[0].not_provide[0]._8_race_refuse[0]");
								pdfFormFields.SetField("topmostSubform[0].Page8[0]._8_race[0].not_provide[0]._8_race_refuse[0]", CanNotProvideRace[0]);

							}
							break;
						case "Chinese":
							{
								var Chinese = pdfFormFields.GetAppearanceStates("topmostSubform[0].Page8[0]._8_race[0].asian[0].asian[0].chinese[0]._8_race_chinese[0]");

								pdfFormFields.SetField("topmostSubform[0].Page8[0]._8_race[0].asian[0].asian[0].chinese[0]._8_race_chinese[0]", Chinese[0]);

							}
							break;
						case "filipino":
							{
								var Filipino = pdfFormFields.GetAppearanceStates("topmostSubform[0].Page8[0]._8_race[0].asian[0].asian[0].filipino[0]._8_race_filipino[0]");
								pdfFormFields.SetField("topmostSubform[0].Page8[0]._8_race[0].asian[0].asian[0].filipino[0]._8_race_filipino[0]", Filipino[0]);
							}
							break;
						case "guamanianorchamorro":
							{
								var GuamanianOrChamorro = pdfFormFields.GetAppearanceStates("topmostSubform[0].Page8[0]._8_race[0].pacific[0].pacific[0].guanamian[0]._8_race_guamanian[0]");

								pdfFormFields.SetField("topmostSubform[0].Page8[0]._8_race[0].pacific[0].pacific[0].guanamian[0]._8_race_guamanian[0]", GuamanianOrChamorro[0]);
							}
							break;
						case "japanese":
							{
								var Japanese = pdfFormFields.GetAppearanceStates("topmostSubform[0].Page8[0]._8_race[0].asian[0].asian[0].japanese[0]._8_race_japanese[0]");

								pdfFormFields.SetField("topmostSubform[0].Page8[0]._8_race[0].asian[0].asian[0].japanese[0]._8_race_japanese[0]", Japanese[0]);
							}
							break;
						case "korean":
							{
								var Korean = pdfFormFields.GetAppearanceStates("topmostSubform[0].Page8[0]._8_race[0].asian[0].asian[0].korean[0]._8_race_korean[0]");
								pdfFormFields.SetField("topmostSubform[0].Page8[0]._8_race[0].asian[0].asian[0].korean[0]._8_race_korean[0]", Korean[0]);
							}
							break;
						case "nativehawaiian":
							{
								var NativeHawaiian = pdfFormFields.GetAppearanceStates("topmostSubform[0].Page8[0]._8_race[0].pacific[0].pacific[0].hawaiian[0]._8_race_hawaiian[0]");
								pdfFormFields.SetField("topmostSubform[0].Page8[0]._8_race[0].pacific[0].pacific[0].hawaiian[0]._8_race_hawaiian[0]", NativeHawaiian[0]);
							}
							break;
						case "nativeHawaiian":
						case "otherpacificislander":
							{
								var NativeHawaiianOrOtherPacificIslander = pdfFormFields.GetAppearanceStates("topmostSubform[0].Page8[0]._8_race[0].pacific[0]._8_race_pacific[0]");

								pdfFormFields.SetField("topmostSubform[0].Page8[0]._8_race[0].pacific[0]._8_race_pacific[0]", NativeHawaiianOrOtherPacificIslander[0]);
							}
							break;
						case "OtherAsian":
							{
								var OtherAsian = pdfFormFields.GetAppearanceStates("topmostSubform[0].Page8[0]._8_race[0].asian[0].asian[0].other[0]._8_race_asian_other[0]");
								pdfFormFields.SetField("topmostSubform[0].Page8[0]._8_race[0].asian[0].asian[0].other[0]._8_race_asian_other[0]", OtherAsian[0]);
							}
							break;
						case "otherPacificIslander":
							{
								var OtherPacificIslander = pdfFormFields.GetAppearanceStates("topmostSubform[0].Page8[0]._8_race[0].pacific[0].pacific[0].other[0]._8_pacific_race[0]");
								pdfFormFields.SetField("topmostSubform[0].Page8[0]._8_race[0].pacific[0].pacific[0].other[0]._8_pacific_race[0]", OtherPacificIslander[0]);
								// pdfFormFields.SetField("topmostSubform[0].Page8[0]._8_race[0].pacific[0].pacific[0].other[0]._8_race_pacific_other[0]", );
							}
							break;
						case "samoan":
							{
								var Samoan = pdfFormFields.GetAppearanceStates("topmostSubform[0].Page8[0]._8_race[0].pacific[0].pacific[0].samoan[0]._8_race_samoan[0]");
								pdfFormFields.SetField("topmostSubform[0].Page8[0]._8_race[0].pacific[0].pacific[0].samoan[0]._8_race_samoan[0]", Samoan[0]);
							}
							break;
						case "vietnamese":
							{
								var Vietnamese = pdfFormFields.GetAppearanceStates("topmostSubform[0].Page8[0]._8_race[0].asian[0].asian[0].vietnamese[0]._8_race_vietnamese[0]");
								pdfFormFields.SetField("topmostSubform[0].Page8[0]._8_race[0].asian[0].asian[0].vietnamese[0]._8_race_vietnamese[0]", Vietnamese[0]);
							}
							break;
						case "white":
							{
								var White = pdfFormFields.GetAppearanceStates("topmostSubform[0].Page8[0]._8_race[0].white[0]._8_race_white[0]");
								pdfFormFields.SetField("topmostSubform[0].Page8[0]._8_race[0].white[0]._8_race_white[0]", White[0]);
							}
							break;
						default:
							break;
					}


				if (data.DemographicInformations != null && data.DemographicInformations.Count > 0)
				{
					foreach (var demographicInformation in data.DemographicInformations)
						switch (demographicInformation.Gender82?.ToLower())
						{
							case "female":
								{
									var Female = pdfFormFields.GetAppearanceStates("topmostSubform[0].Page8[0].sex[0].female[0]._8_sex_female[0]");

									pdfFormFields.SetField("topmostSubform[0].Page8[0].sex[0].female[0]._8_sex_female[0]", Female[0]);
								}
								break;
							case "male":
								{
									var Male = pdfFormFields.GetAppearanceStates("topmostSubform[0].Page8[0].sex[0].male[0]._8_sex_male[0]");

									pdfFormFields.SetField("topmostSubform[0].Page8[0].sex[0].male[0]._8_sex_male[0]", Male[0]);
								}
								break;
							case "annotprovidesex":
								{
									var CanNotProvideSex = pdfFormFields.GetAppearanceStates("topmostSubform[0].Page8[0].sex[0].refuse[0]._8_sex_refuse[0]");

									pdfFormFields.SetField("topmostSubform[0].Page8[0].sex[0].refuse[0]._8_sex_refuse[0]", CanNotProvideSex[0]);
								}
								break;
							default:
								break;
						}
				}

				// Page 9 ends here ..

				return string.Empty;
			}
			catch (Exception err)
			{
				return err.Message;
			}
			finally
			{
				pdfStamper.Close();
				pdfReader.Close();
				fileStream.Dispose();
			}


		}

		private (string fileName, string filePath) CreateFileName(long id)
		{
			string fileName = "LoanDetails" + id + ".pdf";

			var globalDirectory = Path.Combine(_hostingEnvironment.ContentRootPath, "Files");
			if (!Directory.Exists(globalDirectory))
				Directory.CreateDirectory(globalDirectory);
			var path = Path.Combine(globalDirectory, fileName);

			return (fileName, path);
		}
	}
}
