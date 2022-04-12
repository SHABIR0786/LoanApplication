using Microsoft.EntityFrameworkCore;
using System.Linq;
using LoanManagement.Entities.Models;
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

namespace LoanManagement.Services.Implementation
{
	public class LoanService : ILoanService
	{
		private readonly MortgagedbContext _dbContext;

		public LoanService(MortgagedbContext dbContext)
		{
			_dbContext = dbContext;
		}

		#region Loan Property Gift Type

		public string AddLoanPropertyGiftType(AddLoanPropertyGiftTypeRequest request)
		{
			_dbContext.LoanPropertyGiftTypes.Add(new LoanPropertyGiftType()
			{
				LoanPropertyGiftType1 = request.LoanPropertyGiftType1
			});

			_dbContext.SaveChanges();
			return AppConsts.SuccessfullyInserted;
		}

		public string UpdateLoanPropertyGiftType(UpdateLoanPropertyGiftTypeRequest request)
		{
			var objLoanPropertyGiftType = _dbContext.LoanPropertyGiftTypes.Where(s => s.Id == request.Id).FirstOrDefault();

			if (objLoanPropertyGiftType == null)
			{
				return AppConsts.NoRecordFound;
			}

			objLoanPropertyGiftType.LoanPropertyGiftType1 = request.LoanPropertyGiftType1;

			_dbContext.Entry(objLoanPropertyGiftType).State = EntityState.Modified;
			_dbContext.SaveChanges();

			return AppConsts.SuccessfullyUpdated;
		}

		public string DeleteLoanPropertyGiftType(int id)
		{
			var objLoanPropertyGiftType = _dbContext.LoanPropertyGiftTypes.Where(s => s.Id == id).FirstOrDefault();

			if (objLoanPropertyGiftType == null)
			{
				return AppConsts.NoRecordFound;
			}

			_dbContext.LoanPropertyGiftTypes.Remove(objLoanPropertyGiftType);
			_dbContext.SaveChanges();

			return AppConsts.SuccessfullyDeleted;
		}

		public List<UpdateLoanPropertyGiftTypeRequest> GetLoanPropertyGiftTypes()
		{
			return _dbContext.LoanPropertyGiftTypes.Select(d => new UpdateLoanPropertyGiftTypeRequest()
			{
				Id = d.Id,
				LoanPropertyGiftType1 = d.LoanPropertyGiftType1
			}).ToList();
		}

		public UpdateLoanPropertyGiftTypeRequest GetLoanPropertyGiftTypeById(int id)
		{
			return _dbContext.LoanPropertyGiftTypes.Where(s => s.Id == id).Select(d => new UpdateLoanPropertyGiftTypeRequest()
			{
				Id = d.Id,
				LoanPropertyGiftType1 = d.LoanPropertyGiftType1
			}).FirstOrDefault();
		}

		#endregion

		#region Loan Property Occupancy

		public string AddLoanPropertyOccupancy(AddLoanPropertyOccupancyRequest request)
		{
			_dbContext.LoanPropertyOccupancies.Add(new LoanPropertyOccupancy()
			{
				LoanPropertyOccupancy1 = request.LoanPropertyOccupancy1
			});

			_dbContext.SaveChanges();
			return AppConsts.SuccessfullyInserted;
		}

		public string UpdateLoanPropertyOccupancy(UpdateLoanPropertyOccupancyRequest request)
		{
			var objLoanPropertyOccupancy = _dbContext.LoanPropertyOccupancies.Where(s => s.Id == request.Id).FirstOrDefault();

			if (objLoanPropertyOccupancy == null)
			{
				return AppConsts.NoRecordFound;
			}

			objLoanPropertyOccupancy.LoanPropertyOccupancy1 = request.LoanPropertyOccupancy1;

			_dbContext.Entry(objLoanPropertyOccupancy).State = EntityState.Modified;
			_dbContext.SaveChanges();

			return AppConsts.SuccessfullyUpdated;
		}

		public string DeleteLoanPropertyOccupancy(int id)
		{
			var objLoanPropertyOccupancy = _dbContext.LoanPropertyOccupancies.Where(s => s.Id == id).FirstOrDefault();

			if (objLoanPropertyOccupancy == null)
			{
				return AppConsts.NoRecordFound;
			}

			_dbContext.LoanPropertyOccupancies.Remove(objLoanPropertyOccupancy);
			_dbContext.SaveChanges();

			return AppConsts.SuccessfullyDeleted;
		}

		public List<UpdateLoanPropertyOccupancyRequest> GetLoanPropertyOccupancies()
		{
			return _dbContext.LoanPropertyOccupancies.Select(d => new UpdateLoanPropertyOccupancyRequest()
			{
				Id = d.Id,
				LoanPropertyOccupancy1 = d.LoanPropertyOccupancy1
			}).ToList();
		}

		public UpdateLoanPropertyOccupancyRequest GetLoanPropertyOccupancyById(int id)
		{
			return _dbContext.LoanPropertyOccupancies.Where(s => s.Id == id).Select(d => new UpdateLoanPropertyOccupancyRequest()
			{
				Id = d.Id,
				LoanPropertyOccupancy1 = d.LoanPropertyOccupancy1
			}).FirstOrDefault();
		}

		#endregion

		#region Mortage Loan Type

		public string AddMortageLoanType(AddMortageLoanTypeRequest request)
		{
			_dbContext.MortageLoanTypes.Add(new MortageLoanType()
			{
				MortageLoanTypesId = request.MortageLoanTypesId
			});

			_dbContext.SaveChanges();
			return AppConsts.SuccessfullyInserted;
		}

		public string UpdateMortageLoanType(UpdateMortageLoanTypeRequest request)
		{
			var objMortageLoanType = _dbContext.MortageLoanTypes.Where(s => s.Id == request.Id).FirstOrDefault();

			if (objMortageLoanType == null)
			{
				return AppConsts.NoRecordFound;
			}

			objMortageLoanType.MortageLoanTypesId = request.MortageLoanTypesId;

			_dbContext.Entry(objMortageLoanType).State = EntityState.Modified;
			_dbContext.SaveChanges();

			return AppConsts.SuccessfullyUpdated;
		}

		public string DeleteMortageLoanType(int id)
		{
			var objMortageLoanType = _dbContext.MortageLoanTypes.Where(s => s.Id == id).FirstOrDefault();

			if (objMortageLoanType == null)
			{
				return AppConsts.NoRecordFound;
			}

			_dbContext.MortageLoanTypes.Remove(objMortageLoanType);
			_dbContext.SaveChanges();

			return AppConsts.SuccessfullyDeleted;
		}

		public List<UpdateMortageLoanTypeRequest> GetMortageLoanTypes()
		{
			return _dbContext.MortageLoanTypes.Select(d => new UpdateMortageLoanTypeRequest()
			{
				Id = d.Id,
				MortageLoanTypesId = d.MortageLoanTypesId
			}).ToList();
		}

		public UpdateMortageLoanTypeRequest GetMortageLoanTypeById(int id)
		{
			return _dbContext.MortageLoanTypes.Where(s => s.Id == id).Select(d => new UpdateMortageLoanTypeRequest()
			{
				Id = d.Id,
				MortageLoanTypesId = d.MortageLoanTypesId
			}).FirstOrDefault();
		}

		#endregion

		#region Loan And Property Information Gift

		public string AddLoanAndPropertyInformationGift(AddLoanAndPropertyInformationGiftRequest request)
		{
			_dbContext.LoanAndPropertyInformationGifts.Add(new LoanAndPropertyInformationGift()
			{
				ApplicationPersonalInformationId = request.ApplicationPersonalInformationId,
				Deposited4d2 = request.Deposited4d2,
				LoanPropertyGiftTypeId4d1 = request.LoanPropertyGiftTypeId4d1,
				Source4d3 = request.Source4d3,
				Value4d4 = request.Value4d4
			});

			_dbContext.SaveChanges();
			return AppConsts.SuccessfullyInserted;
		}

		public string UpdateLoanAndPropertyInformationGift(UpdateLoanAndPropertyInformationGiftRequest request)
		{
			var objLoanAndPropertyInformationGift = _dbContext.LoanAndPropertyInformationGifts.Where(s => s.Id == request.Id).FirstOrDefault();

			if (objLoanAndPropertyInformationGift == null)
			{
				return AppConsts.NoRecordFound;
			}

			objLoanAndPropertyInformationGift.ApplicationPersonalInformationId = request.ApplicationPersonalInformationId;
			objLoanAndPropertyInformationGift.Deposited4d2 = request.Deposited4d2;
			objLoanAndPropertyInformationGift.LoanPropertyGiftTypeId4d1 = request.LoanPropertyGiftTypeId4d1;
			objLoanAndPropertyInformationGift.Source4d3 = request.Source4d3;
			objLoanAndPropertyInformationGift.Value4d4 = request.Value4d4;

			_dbContext.Entry(objLoanAndPropertyInformationGift).State = EntityState.Modified;
			_dbContext.SaveChanges();

			return AppConsts.SuccessfullyUpdated;
		}

		public string DeleteLoanAndPropertyInformationGift(int id)
		{
			var objLoanAndPropertyInformationGift = _dbContext.LoanAndPropertyInformationGifts.Where(s => s.Id == id).FirstOrDefault();

			if (objLoanAndPropertyInformationGift == null)
			{
				return AppConsts.NoRecordFound;
			}

			_dbContext.LoanAndPropertyInformationGifts.Remove(objLoanAndPropertyInformationGift);
			_dbContext.SaveChanges();

			return AppConsts.SuccessfullyDeleted;
		}

		public List<UpdateLoanAndPropertyInformationGiftRequest> GetLoanAndPropertyInformationGifts()
		{
			return _dbContext.LoanAndPropertyInformationGifts.Select(d => new UpdateLoanAndPropertyInformationGiftRequest()
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
			return _dbContext.LoanAndPropertyInformationGifts.Where(s => s.Id == id).Select(d => new UpdateLoanAndPropertyInformationGiftRequest()
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
			_dbContext.LoanAndPropertyInformations.Add(new LoanAndPropertyInformation()
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

			_dbContext.SaveChanges();
			return AppConsts.SuccessfullyInserted;
		}

		public string UpdateLoanAndPropertyInformation(UpdateLoanAndPropertyInformationRequest request)
		{
			var objLoanAndPropertyInformation = _dbContext.LoanAndPropertyInformations.Where(s => s.Id == request.Id).FirstOrDefault();

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

			_dbContext.Entry(objLoanAndPropertyInformation).State = EntityState.Modified;
			_dbContext.SaveChanges();

			return AppConsts.SuccessfullyUpdated;
		}

		public string DeleteLoanAndPropertyInformation(int id)
		{
			var objLoanAndPropertyInformation = _dbContext.LoanAndPropertyInformations.Where(s => s.Id == id).FirstOrDefault();

			if (objLoanAndPropertyInformation == null)
			{
				return AppConsts.NoRecordFound;
			}

			_dbContext.LoanAndPropertyInformations.Remove(objLoanAndPropertyInformation);
			_dbContext.SaveChanges();

			return AppConsts.SuccessfullyDeleted;
		}

		public List<UpdateLoanAndPropertyInformationRequest> GetLoanAndPropertyInformations()
		{
			return _dbContext.LoanAndPropertyInformations.Select(d => new UpdateLoanAndPropertyInformationRequest()
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
			return _dbContext.LoanAndPropertyInformations.Where(s => s.Id == id).Select(d => new UpdateLoanAndPropertyInformationRequest()
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
			_dbContext.LoanOriginatorInformations.Add(new LoanOriginatorInformation()
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

			_dbContext.SaveChanges();
			return AppConsts.SuccessfullyInserted;
		}

		public string UpdateLoanOriginatorInformation(UpdateLoanOriginatorInformationRequest request)
		{
			var objLoanOriginatorInformation = _dbContext.LoanOriginatorInformations.Where(s => s.Id == request.Id).FirstOrDefault();

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

			_dbContext.Entry(objLoanOriginatorInformation).State = EntityState.Modified;
			_dbContext.SaveChanges();

			return AppConsts.SuccessfullyUpdated;
		}

		public string DeleteLoanOriginatorInformation(int id)
		{
			var objLoanOriginatorInformation = _dbContext.LoanOriginatorInformations.Where(s => s.Id == id).FirstOrDefault();

			if (objLoanOriginatorInformation == null)
			{
				return AppConsts.NoRecordFound;
			}

			_dbContext.LoanOriginatorInformations.Remove(objLoanOriginatorInformation);
			_dbContext.SaveChanges();

			return AppConsts.SuccessfullyDeleted;
		}

		public List<UpdateLoanOriginatorInformationRequest> GetLoanOriginatorInformations()
		{
			return _dbContext.LoanOriginatorInformations.Select(d => new UpdateLoanOriginatorInformationRequest()
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
			return _dbContext.LoanOriginatorInformations.Where(s => s.Id == id).Select(d => new UpdateLoanOriginatorInformationRequest()
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
			_dbContext.LoanAndPropertyInformationOtherMortageLoans.Add(new LoanAndPropertyInformationOtherMortageLoan()
			{
				ApplicationPersonalInformationId = request.ApplicationPersonalInformationId,
				CreditAmount4b5 = request.CreditAmount4b5,
				CreditorName4b1 = request.CreditorName4b1,
				LienType4b2 = request.LienType4b2,
				LoanAmount4b4 = request.LoanAmount4b4,
				MonthlyPayment4b3 = request.MonthlyPayment4b3
			});

			_dbContext.SaveChanges();
			return AppConsts.SuccessfullyInserted;
		}

		public string UpdateLoanAndPropertyInformationOtherMortageLoan(UpdateLoanAndPropertyInformationOtherMortageLoanRequest request)
		{
			var objLoanAndPropertyInformationOtherMortageLoan = _dbContext.LoanAndPropertyInformationOtherMortageLoans.Where(s => s.Id == request.Id).FirstOrDefault();

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

			_dbContext.Entry(objLoanAndPropertyInformationOtherMortageLoan).State = EntityState.Modified;
			_dbContext.SaveChanges();

			return AppConsts.SuccessfullyUpdated;
		}

		public string DeleteLoanAndPropertyInformationOtherMortageLoan(int id)
		{
			var objLoanAndPropertyInformationOtherMortageLoan = _dbContext.LoanAndPropertyInformationOtherMortageLoans.Where(s => s.Id == id).FirstOrDefault();

			if (objLoanAndPropertyInformationOtherMortageLoan == null)
			{
				return AppConsts.NoRecordFound;
			}

			_dbContext.LoanAndPropertyInformationOtherMortageLoans.Remove(objLoanAndPropertyInformationOtherMortageLoan);
			_dbContext.SaveChanges();

			return AppConsts.SuccessfullyDeleted;
		}

		public List<UpdateLoanAndPropertyInformationOtherMortageLoanRequest> GetLoanAndPropertyInformationOtherMortageLoans()
		{
			return _dbContext.LoanAndPropertyInformationOtherMortageLoans.Select(d => new UpdateLoanAndPropertyInformationOtherMortageLoanRequest()
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
			return _dbContext.LoanAndPropertyInformationOtherMortageLoans.Where(s => s.Id == id).Select(d => new UpdateLoanAndPropertyInformationOtherMortageLoanRequest()
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
			_dbContext.LoanAndPropertyInformationRentalIncomes.Add(new LoanAndPropertyInformationRentalIncome()
			{
				ApplicationPersonalInformationId = request.ApplicationPersonalInformationId,
				ExpectedMonthlyIncome4c1 = request.ExpectedMonthlyIncome4c1,
				LenderExpectedMonthlyIncome4c2 = request.LenderExpectedMonthlyIncome4c2
			});

			_dbContext.SaveChanges();
			return AppConsts.SuccessfullyInserted;
		}

		public string UpdateLoanAndPropertyInformationRentalIncome(UpdateLoanAndPropertyInformationRentalIncomeRequest request)
		{
			var objLoanAndPropertyInformationRentalIncome = _dbContext.LoanAndPropertyInformationRentalIncomes.Where(s => s.Id == request.Id).FirstOrDefault();

			if (objLoanAndPropertyInformationRentalIncome == null)
			{
				return AppConsts.NoRecordFound;
			}

			objLoanAndPropertyInformationRentalIncome.ApplicationPersonalInformationId = request.ApplicationPersonalInformationId;
			objLoanAndPropertyInformationRentalIncome.ExpectedMonthlyIncome4c1 = request.ExpectedMonthlyIncome4c1;
			objLoanAndPropertyInformationRentalIncome.LenderExpectedMonthlyIncome4c2 = request.LenderExpectedMonthlyIncome4c2;

			_dbContext.Entry(objLoanAndPropertyInformationRentalIncome).State = EntityState.Modified;
			_dbContext.SaveChanges();

			return AppConsts.SuccessfullyUpdated;
		}

		public string DeleteLoanAndPropertyInformationRentalIncome(int id)
		{
			var objLoanAndPropertyInformationRentalIncome = _dbContext.LoanAndPropertyInformationRentalIncomes.Where(s => s.Id == id).FirstOrDefault();

			if (objLoanAndPropertyInformationRentalIncome == null)
			{
				return AppConsts.NoRecordFound;
			}

			_dbContext.LoanAndPropertyInformationRentalIncomes.Remove(objLoanAndPropertyInformationRentalIncome);
			_dbContext.SaveChanges();

			return AppConsts.SuccessfullyDeleted;
		}

		public List<UpdateLoanAndPropertyInformationRentalIncomeRequest> GetLoanAndPropertyInformationRentalIncomes()
		{
			return _dbContext.LoanAndPropertyInformationRentalIncomes.Select(d => new UpdateLoanAndPropertyInformationRentalIncomeRequest()
			{
				Id = d.Id,
				ApplicationPersonalInformationId = d.ApplicationPersonalInformationId,
				ExpectedMonthlyIncome4c1 = d.ExpectedMonthlyIncome4c1,
				LenderExpectedMonthlyIncome4c2 = d.LenderExpectedMonthlyIncome4c2
			}).ToList();
		}

		public UpdateLoanAndPropertyInformationRentalIncomeRequest GetLoanAndPropertyInformationRentalIncomeById(int id)
		{
			return _dbContext.LoanAndPropertyInformationRentalIncomes.Where(s => s.Id == id).Select(d => new UpdateLoanAndPropertyInformationRentalIncomeRequest()
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
			_dbContext.MortageLoanOnProperties.Add(new MortageLoanOnProperty()
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

			_dbContext.SaveChanges();
			return AppConsts.SuccessfullyInserted;
		}

		public string UpdateMortageLoanOnProperty(UpdateMortageLoanOnPropertyRequest request)
		{
			var objMortageLoanOnProperty = _dbContext.MortageLoanOnProperties.Where(s => s.Id == request.Id).FirstOrDefault();

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

			_dbContext.Entry(objMortageLoanOnProperty).State = EntityState.Modified;
			_dbContext.SaveChanges();

			return AppConsts.SuccessfullyUpdated;
		}

		public string DeleteMortageLoanOnProperty(int id)
		{
			var objMortageLoanOnProperty = _dbContext.MortageLoanOnProperties.Where(s => s.Id == id).FirstOrDefault();

			if (objMortageLoanOnProperty == null)
			{
				return AppConsts.NoRecordFound;
			}

			_dbContext.MortageLoanOnProperties.Remove(objMortageLoanOnProperty);
			_dbContext.SaveChanges();

			return AppConsts.SuccessfullyDeleted;
		}

		public List<UpdateMortageLoanOnPropertyRequest> GetMortageLoanOnProperties()
		{
			return _dbContext.MortageLoanOnProperties.Select(d => new UpdateMortageLoanOnPropertyRequest()
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
			return _dbContext.MortageLoanOnProperties.Where(s => s.Id == id).Select(d => new UpdateMortageLoanOnPropertyRequest()
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
			return _dbContext.ApplicationPersonalInformations.Where(s => s.Id == id).Select(d => new GetPdfDataModel()
			{
				Id = d.Id,
				Ages1a81 = d.Ages1a81,
				AlternateFirstName1a21 = d.AlternateFirstName1a21,
				AlternateLastName1a23 = d.AlternateLastName1a23,
				AlternateMiddleName1a22 = d.AlternateMiddleName1a22,
				AlternateSuffix1a24 = d.AlternateSuffix1a24,
				ApplicationId = d.ApplicationId,
				CellPhone1a10 = d.CellPhone1a10,
				CitizenshipType1a5 = d.CitizenshipTypeId1a5Navigation.CitizenshipType1,
				CurrentCity1a133 = d.CurrentCityId1a133Navigation.CityName,
				CurrentCountry1a136 = d.CurrentCountryId1a136Navigation.CountryName,
				CurrentHousingType1a141 = d.CurrentHousingTypeId1a141Navigation.HousingType1,
				CurrentMonths1a15 = d.CurrentMonths1a15,
				CurrentRent1a142 = d.CurrentRent1a142,
				CurrentState1a134 = d.CurrentStateId1a134Navigation.StateName,
				CurrentStreet1a131 = d.CurrentStreet1a131,
				CurrentUnit1a132 = d.CurrentUnit1a132,
				CurrentYears1a14 = d.CurrentYears1a14,
				CurrentZip1a135 = d.CurrentZip1a135,
				Dependents1a8 = d.Dependents1a8,
				Dob1a4 = d.Dob1a4,
				Email1a12 = d.Email1a12,
				Ext1a111 = d.Ext1a111,
				FirstName1a1 = d.FirstName1a1,
				FormerCity1a153 = d.FormerCityId1a153Navigation.CityName,
				FormerHousingType1a161 = d.FormerCountryId1a156Navigation.CountryName,
				FormerCountry1a156 = d.FormerHousingTypeId1a161Navigation.HousingType1,
				FormerMonths1a161 = d.FormerMonths1a161,
				FormerRent1a162 = d.FormerRent1a162,
				FormerState1a154 = d.FormerStateId1a154Navigation.StateName,
				FormerStreet1a151 = d.FormerStreet1a151,
				FormerUnit1a152 = d.FormerUnit1a152,
				FormerYears1a16 = d.FormerYears1a16,
				FormerZip1a155 = d.FormerZip1a155,
				HomePhone1a9 = d.HomePhone1a9,
				LastName1a3 = d.LastName1a3,
				MailingCity1a173 = d.MailingCityId1a173Navigation.CityName,
				MailingCountry1a176 = d.MailingCountryId1a176Navigation.CountryName,
				MailingState1a174 = d.MailingStateId1a174Navigation.StateName,
				MailingStreet1a171 = d.MailingStreet1a171,
				MailingUnit1a172 = d.MailingUnit1a172,
				MailingZip1a175 = d.MailingZip1a175,
				MaritialStatus1a7 = d.MaritialStatusId1a7Navigation.MaritialStatus1,
				MiddleName1a2 = d.MiddleName1a2,
				Ssn1a3 = d.Ssn1a3,
				Suffix1a4 = d.Suffix1a4,
				WorkPhone1a11 = d.WorkPhone1a11,
				Application = new ApplicationDetail()
				{
					AgencyCaseNoB2 = d.Application.AgencyCaseNoB2,
					CreditType = d.Application.CreditType.CreditType1,
					Date = d.Application.Date,
					Initials = d.Application.Initials,
					LoanNoIdentifierB1B3 = d.Application.LoanNoIdentifierB1B3,
					TotalBorrowers1a6 = d.Application.TotalBorrowers1a6
				},
				ApplicationDeclarationQuestionDetail = d.ApplicationDeclarationQuestions.Select(x => new Features.PdfData.DeclarationCategory()
				{
					ApplicationPersonalInformationId = x.ApplicationPersonalInformationId,
					Category = x.DeclarationQuestion.DeclarationCategory.DeclarationCategory1,
					YesNo = (x.YesNo != null && x.YesNo == 1 ? true : false),
					ApplicationDeclarationQuestions = new List<Features.PdfData.ApplicationDeclarationQuestion>()
				}).ToList(),
				ApplicationEmployementDetails = d.ApplicationEmployementDetails.Select(x => new Features.PdfData.ApplicationEmployementDetail()
				{
					ApplicationPersonalInformationId = x.ApplicationPersonalInformationId,
					City1b43 = x.CityId1b43Navigation.CityName,
					Country1b46 = x.CountryId1b46Navigation.CountryName,
					EmployerBusinessName1b2 = x.EmployerBusinessName1b2,
					IsEmployedBySomeone1b8 = x.IsEmployedBySomeone1b8,
					IsOwnershipLessThan251b91 = x.IsOwnershipLessThan251b91,
					IsSelfEmployed1b9 = x.IsSelfEmployed1b9,
					MonthlyIncome1b92 = x.MonthlyIncome1b92,
					Phone1b3 = x.Phone1b3,
					PositionTitle1b5 = x.PositionTitle1b5,
					StartDate1b6 = x.StartDate1b6,
					State1b44 = x.StateId1b44Navigation.StateName,
					Street1b41 = x.Street1b41,
					Unit1b42 = x.Unit1b42,
					WorkingMonths = x.WorkingMonths,
					WorkingYears1b7 = x.WorkingYears1b7,
					Zip1b45 = x.Zip1b45
				}).ToList(),
				ApplicationFinancialAssets = d.ApplicationFinancialAssets.Select(x => new Features.PdfData.ApplicationFinancialAsset()
				{
					AccountNumber2a3 = x.AccountNumber2a3,
					FinancialAccountType2a1 = x.FinancialAccountTypeId2a1Navigation.FinancialAccountType1,
					FinancialInstitution2a2 = x.FinancialInstitution2a2,
					Value2a4 = x.Value2a4
				}).ToList(),
				ApplicationFinancialLaibilities = d.ApplicationFinancialLaibilities.Select(x => new Features.PdfData.ApplicationFinancialLiabilityDetail()
				{
					AccountNumber2c3 = x.AccountNumber2c3,
					ApplicationPersonalInformationId = x.ApplicationPersonalInformationId,
					CompanyName2c2 = x.CompanyName2c2,
					MonthlyValue2c6 = x.MonthlyValue2c6,
					PaidOff2c5 = x.PaidOff2c5,
					UnpaidBalance2c4 = x.UnpaidBalance2c4,
					FinancialLaibilitiesType2c1 = x.FinancialLaibilitiesType2c1Navigation.FinancialLaibilitiesType1
				}).ToList(),
				
			}).FirstOrDefault();
		}
	}
}
