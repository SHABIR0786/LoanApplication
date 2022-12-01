using LoanManagement.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using LoanManagement.Features.Application;
using LoanManagement.Features.Application.AdditionalEmployementIncomeDetail;
using LoanManagement.Features.Application.AdditionalEmploymentDetail;
using LoanManagement.Features.Application.ApplicationFinancialAsset;
using LoanManagement.Features.Application.ApplicationFinancialLiability;
using LoanManagement.Features.Application.ApplicationFinancialOtherAsset;
using LoanManagement.Features.Application.ApplicationFinancialOtherLaibility;
using LoanManagement.Features.Application.ApplicationIncomeSource;
using LoanManagement.Features.Application.DeclarationQuestion;
using LoanManagement.Features.Application.EmployementIncomeDetail;
using LoanManagement.Features.Application.EmploymentDetail;
using LoanManagement.Features.Application.FinancialRealEstate;
using LoanManagement.Features.Application.MilitaryService;
using LoanManagement.Features.Application.PersonalInformation;
using LoanManagement.Features.Application.PreviousEmployementDetail;
using LoanManagement.Services.Interface;
using System.Collections.Generic;
using System.Linq;
using LoanManagement.codeFirstEntities;
using Abp.EntityFrameworkCore;

namespace LoanManagement.Services.Implementation
{
	public class ApplicationService : IApplicationService
	{
		private  LoanManagementDbContext _dbContext  => dbContextProvider.GetDbContext();
		private readonly IDbContextProvider<LoanManagementDbContext> dbContextProvider;

		public ApplicationService(IDbContextProvider<LoanManagementDbContext> dbContextProvider)
		{
			this.dbContextProvider = dbContextProvider;
		}

		#region Application

		public string AddApplication(InsertApplicationRequest request)
		{
			_dbContext.Applications.Add(new Application()
			{
				AgencyCaseNoB2 = request.AgencyCaseNoB2,
				CreditTypeId = request.CreditTypeId,
				Date = request.Date,
				Initials = request.Initials,
				LoanNoIdentifierB1B3 = request.LoanNoIdentifierB1B3,
				TotalBorrowers1a6 = request.TotalBorrowers1a6
			});
			_dbContext.SaveChanges();
			return AppConsts.SuccessfullyInserted;
		}

		public string UpdateApplication(UpdateApplicationRequest request)
		{
			var objApplication = _dbContext.Applications.Where(s => s.Id == request.Id).FirstOrDefault();

			if (objApplication == null)
			{
				return AppConsts.NoRecordFound;
			}

			objApplication.AgencyCaseNoB2 = request.AgencyCaseNoB2;
			objApplication.CreditTypeId = request.CreditTypeId;
			objApplication.Date = request.Date;
			objApplication.Initials = request.Initials;
			objApplication.LoanNoIdentifierB1B3 = request.LoanNoIdentifierB1B3;
			objApplication.TotalBorrowers1a6 = request.TotalBorrowers1a6;

			_dbContext.Entry(objApplication).State = EntityState.Modified;
			_dbContext.SaveChanges();

			return AppConsts.SuccessfullyUpdated;
		}

		public string DeleteApplication(int id)
		{
			var objApplication = _dbContext.Applications.Where(s => s.Id == id).FirstOrDefault();

			if (objApplication == null)
			{
				return AppConsts.NoRecordFound;
			}

			_dbContext.Applications.Remove(objApplication);
			_dbContext.SaveChanges();

			return AppConsts.SuccessfullyDeleted;
		}

		public List<UpdateApplicationRequest> GetApplications()
		{
			return _dbContext.Applications.Select(d => new UpdateApplicationRequest()
			{
				Id = d.Id,
				AgencyCaseNoB2 = d.AgencyCaseNoB2,
				CreditTypeId = d.CreditTypeId,
				Date = d.Date,
				Initials = d.Initials,
				LoanNoIdentifierB1B3 = d.LoanNoIdentifierB1B3,
				TotalBorrowers1a6 = d.TotalBorrowers1a6
			}).ToList();
		}

		public UpdateApplicationRequest GetApplicationById(int id)
		{
			return _dbContext.Applications.Where(s => s.Id == id).Select(d => new UpdateApplicationRequest()
			{
				Id = d.Id,
				AgencyCaseNoB2 = d.AgencyCaseNoB2,
				CreditTypeId = d.CreditTypeId,
				Date = d.Date,
				Initials = d.Initials,
				LoanNoIdentifierB1B3 = d.LoanNoIdentifierB1B3,
				TotalBorrowers1a6 = d.TotalBorrowers1a6
			}).FirstOrDefault();
		}

		#endregion

		#region Application Additional Employment Detail

		public string AddApplicationAdditionalEmployementDetail(AddAdditionalEmploymentDetailRequest request)
		{
			_dbContext.ApplicationAdditionalEmployementDetails.Add(new ApplicationAdditionalEmployementDetail()
			{
				ApplicationPersonalInformationId = request.ApplicationPersonalInformationId,
				CityId = request.CityId,
				CountryId = request.CountryId,
				EmployerBusinessName = request.EmployerBusinessName,
				IsEmployedBySomeone = request.IsEmployedBySomeone,
				IsOwnershipLessThan25 = request.IsOwnershipLessThan25,
				IsSelfEmployed = request.IsSelfEmployed,
				MonthlyIncome = request.MonthlyIncome,
				Phone = request.Phone,
				PositionTitle = request.PositionTitle,
				StartDate = request.StartDate,
				StateId = request.StateId,
				Street = request.Street,
				Unit = request.Unit,
				WorkingMonths = request.WorkingMonths,
				WorkingYears = request.WorkingYears,
				Zip = request.Zip
			});

			_dbContext.SaveChanges();
			return AppConsts.SuccessfullyInserted;
		}

		public string UpdateApplicationAdditionalEmployementDetail(UpdateAdditionalEmploymentDetailRequest request)
		{
			var objApplicationAdditionalEmployementDetail = _dbContext.ApplicationAdditionalEmployementDetails.Where(s => s.Id == request.Id).FirstOrDefault();

			if (objApplicationAdditionalEmployementDetail == null)
			{
				return AppConsts.NoRecordFound;
			}

			objApplicationAdditionalEmployementDetail.ApplicationPersonalInformationId = request.ApplicationPersonalInformationId;
			objApplicationAdditionalEmployementDetail.CityId = request.CityId;
			objApplicationAdditionalEmployementDetail.CountryId = request.CountryId;
			objApplicationAdditionalEmployementDetail.EmployerBusinessName = request.EmployerBusinessName;
			objApplicationAdditionalEmployementDetail.IsEmployedBySomeone = request.IsEmployedBySomeone;
			objApplicationAdditionalEmployementDetail.IsOwnershipLessThan25 = request.IsOwnershipLessThan25;
			objApplicationAdditionalEmployementDetail.IsSelfEmployed = request.IsSelfEmployed;
			objApplicationAdditionalEmployementDetail.MonthlyIncome = request.MonthlyIncome;
			objApplicationAdditionalEmployementDetail.Phone = request.Phone;
			objApplicationAdditionalEmployementDetail.PositionTitle = request.PositionTitle;
			objApplicationAdditionalEmployementDetail.StartDate = request.StartDate;
			objApplicationAdditionalEmployementDetail.StateId = request.StateId;
			objApplicationAdditionalEmployementDetail.Street = request.Street;
			objApplicationAdditionalEmployementDetail.Unit = request.Unit;
			objApplicationAdditionalEmployementDetail.WorkingMonths = request.WorkingMonths;
			objApplicationAdditionalEmployementDetail.WorkingYears = request.WorkingYears;
			objApplicationAdditionalEmployementDetail.Zip = request.Zip;

			_dbContext.Entry(objApplicationAdditionalEmployementDetail).State = EntityState.Modified;
			_dbContext.SaveChanges();

			return AppConsts.SuccessfullyUpdated;
		}

		public string DeleteApplicationAdditionalEmployementDetail(int id)
		{
			var objApplicationAdditionalEmployementDetail = _dbContext.ApplicationAdditionalEmployementDetails.Where(s => s.Id == id).FirstOrDefault();

			if (objApplicationAdditionalEmployementDetail == null)
			{
				return AppConsts.NoRecordFound;
			}

			_dbContext.ApplicationAdditionalEmployementDetails.Remove(objApplicationAdditionalEmployementDetail);
			_dbContext.SaveChanges();

			return AppConsts.SuccessfullyDeleted;
		}

		public List<UpdateAdditionalEmploymentDetailRequest> GetApplicationAdditionalEmployementDetails()
		{
			return _dbContext.ApplicationAdditionalEmployementDetails.Select(d => new UpdateAdditionalEmploymentDetailRequest()
			{
				Id = d.Id,
				ApplicationPersonalInformationId = d.ApplicationPersonalInformationId,
				CityId = d.CityId,
				CountryId = d.CountryId,
				EmployerBusinessName = d.EmployerBusinessName,
				IsEmployedBySomeone = d.IsEmployedBySomeone,
				IsOwnershipLessThan25 = d.IsOwnershipLessThan25,
				IsSelfEmployed = d.IsSelfEmployed,
				MonthlyIncome = d.MonthlyIncome,
				Phone = d.Phone,
				PositionTitle = d.PositionTitle,
				StartDate = d.StartDate,
				StateId = d.StateId,
				Street = d.Street,
				Unit = d.Unit,
				WorkingMonths = d.WorkingMonths,
				WorkingYears = d.WorkingYears,
				Zip = d.Zip
			}).ToList();
		}

		public UpdateAdditionalEmploymentDetailRequest GetApplicationAdditionalEmployementDetailById(int id)
		{
			return _dbContext.ApplicationAdditionalEmployementDetails.Where(s => s.Id == id).Select(d => new UpdateAdditionalEmploymentDetailRequest()
			{
				Id = d.Id,
				ApplicationPersonalInformationId = d.ApplicationPersonalInformationId,
				CityId = d.CityId,
				CountryId = d.CountryId,
				EmployerBusinessName = d.EmployerBusinessName,
				IsEmployedBySomeone = d.IsEmployedBySomeone,
				IsOwnershipLessThan25 = d.IsOwnershipLessThan25,
				IsSelfEmployed = d.IsSelfEmployed,
				MonthlyIncome = d.MonthlyIncome,
				Phone = d.Phone,
				PositionTitle = d.PositionTitle,
				StartDate = d.StartDate,
				StateId = d.StateId,
				Street = d.Street,
				Unit = d.Unit,
				WorkingMonths = d.WorkingMonths,
				WorkingYears = d.WorkingYears,
				Zip = d.Zip
			}).FirstOrDefault();
		}

		#endregion

		#region Application Additional Employment Income Detail

		public string AddApplicationAdditionalEmployementIncomeDetail(AddAdditionalEmployementIncomeDetailRequest request)
		{
			_dbContext.ApplicationAdditionalEmployementIncomeDetails.Add(new ApplicationAdditionalEmployementIncomeDetail()
			{
				Amount = request.Amount,
				IncomeTypeId = request.IncomeTypeId,
				ApplicationAdditionalEmployementDetails = request.ApplicationAdditionalEmployementDetails
			});

			_dbContext.SaveChanges();
			return AppConsts.SuccessfullyInserted;
		}

		public string UpdateApplicationAdditionalEmployementIncomeDetail(UpdateAdditionalEmployementIncomeDetailRequest request)
		{
			var objApplicationAdditionalEmployementIncomeDetail = _dbContext.ApplicationAdditionalEmployementIncomeDetails.Where(s => s.Id == request.Id).FirstOrDefault();

			if (objApplicationAdditionalEmployementIncomeDetail == null)
			{
				return AppConsts.NoRecordFound;
			}

			objApplicationAdditionalEmployementIncomeDetail.Amount = request.Amount;
			objApplicationAdditionalEmployementIncomeDetail.IncomeTypeId = request.IncomeTypeId;
			objApplicationAdditionalEmployementIncomeDetail.ApplicationAdditionalEmployementDetails = request.ApplicationAdditionalEmployementDetails;

			_dbContext.Entry(objApplicationAdditionalEmployementIncomeDetail).State = EntityState.Modified;
			_dbContext.SaveChanges();

			return AppConsts.SuccessfullyUpdated;
		}

		public string DeleteApplicationAdditionalEmployementIncomeDetail(int id)
		{
			var objApplicationAdditionalEmployementIncomeDetail = _dbContext.ApplicationAdditionalEmployementIncomeDetails.Where(s => s.Id == id).FirstOrDefault();

			if (objApplicationAdditionalEmployementIncomeDetail == null)
			{
				return AppConsts.NoRecordFound;
			}

			_dbContext.ApplicationAdditionalEmployementIncomeDetails.Remove(objApplicationAdditionalEmployementIncomeDetail);
			_dbContext.SaveChanges();

			return AppConsts.SuccessfullyDeleted;
		}

		public List<UpdateAdditionalEmployementIncomeDetailRequest> GetApplicationAdditionalEmployementIncomeDetails()
		{
			return _dbContext.ApplicationAdditionalEmployementIncomeDetails.Select(d => new UpdateAdditionalEmployementIncomeDetailRequest()
			{
				Id = d.Id,
				Amount = d.Amount,
				IncomeTypeId = d.IncomeTypeId,
				ApplicationAdditionalEmployementDetails = d.ApplicationAdditionalEmployementDetails
			}).ToList();
		}

		public UpdateAdditionalEmployementIncomeDetailRequest GetApplicationAdditionalEmployementIncomeDetailById(int id)
		{
			return _dbContext.ApplicationAdditionalEmployementIncomeDetails.Where(s => s.Id == id).Select(d => new UpdateAdditionalEmployementIncomeDetailRequest()
			{
				Id = d.Id,
				Amount = d.Amount,
				IncomeTypeId = d.IncomeTypeId,
				ApplicationAdditionalEmployementDetails = d.ApplicationAdditionalEmployementDetails
			}).FirstOrDefault();
		}

		#endregion

		#region Application Declaration Question

		public string AddApplicationDeclarationQuestion(AddApplicationDeclarationQuestionRequest request)
		{
			_dbContext.ApplicationDeclarationQuestions.Add(new ApplicationDeclarationQuestion()
			{
				ApplicationPersonalInformationId = request.ApplicationPersonalInformationId,
				DeclarationQuestionId = request.DeclarationQuestionId,
				Description5a = request.Description5a,
				YesNo = request.YesNo
			});

			_dbContext.SaveChanges();
			return AppConsts.SuccessfullyInserted;
		}

		public string UpdateApplicationDeclarationQuestion(UpdateApplicationDeclarationQuestionRequest request)
		{
			var objApplicationDeclarationQuestion = _dbContext.ApplicationDeclarationQuestions.Where(s => s.Id == request.Id).FirstOrDefault();

			if (objApplicationDeclarationQuestion == null)
			{
				return AppConsts.NoRecordFound;
			}

			objApplicationDeclarationQuestion.ApplicationPersonalInformationId = request.ApplicationPersonalInformationId;
			objApplicationDeclarationQuestion.DeclarationQuestionId = request.DeclarationQuestionId;
			objApplicationDeclarationQuestion.Description5a = request.Description5a;
			objApplicationDeclarationQuestion.YesNo = request.YesNo;

			_dbContext.Entry(objApplicationDeclarationQuestion).State = EntityState.Modified;
			_dbContext.SaveChanges();

			return AppConsts.SuccessfullyUpdated;
		}

		public string DeleteApplicationDeclarationQuestion(int id)
		{
			var objApplicationDeclarationQuestion = _dbContext.ApplicationDeclarationQuestions.Where(s => s.Id == id).FirstOrDefault();

			if (objApplicationDeclarationQuestion == null)
			{
				return AppConsts.NoRecordFound;
			}

			_dbContext.ApplicationDeclarationQuestions.Remove(objApplicationDeclarationQuestion);
			_dbContext.SaveChanges();

			return AppConsts.SuccessfullyDeleted;
		}

		public List<UpdateApplicationDeclarationQuestionRequest> GetApplicationDeclarationQuestions()
		{
			return _dbContext.ApplicationDeclarationQuestions.Select(d => new UpdateApplicationDeclarationQuestionRequest()
			{
				Id = d.Id,
				ApplicationPersonalInformationId = d.ApplicationPersonalInformationId,
				DeclarationQuestionId = d.DeclarationQuestionId,
				Description5a = d.Description5a,
				YesNo = d.YesNo
			}).ToList();
		}

		public UpdateApplicationDeclarationQuestionRequest GetApplicationDeclarationQuestionById(int id)
		{
			return _dbContext.ApplicationDeclarationQuestions.Where(s => s.Id == id).Select(d => new UpdateApplicationDeclarationQuestionRequest()
			{
				Id = d.Id,
				ApplicationPersonalInformationId = d.ApplicationPersonalInformationId,
				DeclarationQuestionId = d.DeclarationQuestionId,
				Description5a = d.Description5a,
				YesNo = d.YesNo
			}).FirstOrDefault();
		}

		#endregion

		#region Application Employment Detail

		public string AddApplicationEmployementDetail(AddEmploymentDetailRequest request)
		{
			_dbContext.ApplicationEmployementDetails.Add(new ApplicationEmployementDetail()
			{
				ApplicationPersonalInformationId = request.ApplicationPersonalInformationId,
				CityId1b43 = request.CityId1b43,
				CountryId1b46 = request.CountryId1b46,
				EmployerBusinessName1b2 = request.EmployerBusinessName1b2,
				IsEmployedBySomeone1b8 = request.IsEmployedBySomeone1b8,
				IsOwnershipLessThan251b91 = request.IsOwnershipLessThan251b91,
				IsSelfEmployed1b9 = request.IsSelfEmployed1b9,
				MonthlyIncome1b92 = request.MonthlyIncome1b92,
				Phone1b3 = request.Phone1b3,
				PositionTitle1b5 = request.PositionTitle1b5,
				StartDate1b6 = request.StartDate1b6,
				StateId1b44 = request.StateId1b44,
				Street1b41 = request.Street1b41,
				Unit1b42 = request.Unit1b42,
				WorkingMonths = request.WorkingMonths,
				WorkingYears1b7 = request.WorkingYears1b7,
				Zip1b45 = request.Zip1b45
			});

			_dbContext.SaveChanges();
			return AppConsts.SuccessfullyInserted;
		}

		public string UpdateApplicationEmployementDetail(UpdateEmploymentDetailRequest request)
		{
			var objApplicationEmployementDetail = _dbContext.ApplicationEmployementDetails.Where(s => s.Id == request.Id).FirstOrDefault();

			if (objApplicationEmployementDetail == null)
			{
				return AppConsts.NoRecordFound;
			}

			objApplicationEmployementDetail.ApplicationPersonalInformationId = request.ApplicationPersonalInformationId;
			objApplicationEmployementDetail.CityId1b43 = request.CityId1b43;
			objApplicationEmployementDetail.CountryId1b46 = request.CountryId1b46;
			objApplicationEmployementDetail.EmployerBusinessName1b2 = request.EmployerBusinessName1b2;
			objApplicationEmployementDetail.IsEmployedBySomeone1b8 = request.IsEmployedBySomeone1b8;
			objApplicationEmployementDetail.IsOwnershipLessThan251b91 = request.IsOwnershipLessThan251b91;
			objApplicationEmployementDetail.IsSelfEmployed1b9 = request.IsSelfEmployed1b9;
			objApplicationEmployementDetail.MonthlyIncome1b92 = request.MonthlyIncome1b92;
			objApplicationEmployementDetail.Phone1b3 = request.Phone1b3;
			objApplicationEmployementDetail.PositionTitle1b5 = request.PositionTitle1b5;
			objApplicationEmployementDetail.StartDate1b6 = request.StartDate1b6;
			objApplicationEmployementDetail.StateId1b44 = request.StateId1b44;
			objApplicationEmployementDetail.Street1b41 = request.Street1b41;
			objApplicationEmployementDetail.Unit1b42 = request.Unit1b42;
			objApplicationEmployementDetail.WorkingMonths = request.WorkingMonths;
			objApplicationEmployementDetail.WorkingYears1b7 = request.WorkingYears1b7;
			objApplicationEmployementDetail.Zip1b45 = request.Zip1b45;

			_dbContext.Entry(objApplicationEmployementDetail).State = EntityState.Modified;
			_dbContext.SaveChanges();

			return AppConsts.SuccessfullyUpdated;
		}

		public string DeleteApplicationEmployementDetail(int id)
		{
			var objApplicationEmployementDetail = _dbContext.ApplicationEmployementDetails.Where(s => s.Id == id).FirstOrDefault();

			if (objApplicationEmployementDetail == null)
			{
				return AppConsts.NoRecordFound;
			}

			_dbContext.ApplicationEmployementDetails.Remove(objApplicationEmployementDetail);
			_dbContext.SaveChanges();

			return AppConsts.SuccessfullyDeleted;
		}

		public List<UpdateEmploymentDetailRequest> GetApplicationEmployementDetails()
		{
			return _dbContext.ApplicationEmployementDetails.Select(d => new UpdateEmploymentDetailRequest()
			{
				Id = d.Id,
				ApplicationPersonalInformationId = d.ApplicationPersonalInformationId,
				CityId1b43 = d.CityId1b43,
				CountryId1b46 = d.CountryId1b46,
				EmployerBusinessName1b2 = d.EmployerBusinessName1b2,
				IsEmployedBySomeone1b8 = d.IsEmployedBySomeone1b8,
				IsOwnershipLessThan251b91 = d.IsOwnershipLessThan251b91,
				IsSelfEmployed1b9 = d.IsSelfEmployed1b9,
				MonthlyIncome1b92 = d.MonthlyIncome1b92,
				Phone1b3 = d.Phone1b3,
				PositionTitle1b5 = d.PositionTitle1b5,
				StartDate1b6 = d.StartDate1b6,
				StateId1b44 = d.StateId1b44,
				Street1b41 = d.Street1b41,
				Unit1b42 = d.Unit1b42,
				WorkingMonths = d.WorkingMonths,
				WorkingYears1b7 = d.WorkingYears1b7,
				Zip1b45 = d.Zip1b45
			}).ToList();
		}

		public UpdateEmploymentDetailRequest GetApplicationEmployementDetailById(int id)
		{
			return _dbContext.ApplicationEmployementDetails.Where(s => s.Id == id).Select(d => new UpdateEmploymentDetailRequest()
			{
				Id = d.Id,
				ApplicationPersonalInformationId = d.ApplicationPersonalInformationId,
				CityId1b43 = d.CityId1b43,
				CountryId1b46 = d.CountryId1b46,
				EmployerBusinessName1b2 = d.EmployerBusinessName1b2,
				IsEmployedBySomeone1b8 = d.IsEmployedBySomeone1b8,
				IsOwnershipLessThan251b91 = d.IsOwnershipLessThan251b91,
				IsSelfEmployed1b9 = d.IsSelfEmployed1b9,
				MonthlyIncome1b92 = d.MonthlyIncome1b92,
				Phone1b3 = d.Phone1b3,
				PositionTitle1b5 = d.PositionTitle1b5,
				StartDate1b6 = d.StartDate1b6,
				StateId1b44 = d.StateId1b44,
				Street1b41 = d.Street1b41,
				Unit1b42 = d.Unit1b42,
				WorkingMonths = d.WorkingMonths,
				WorkingYears1b7 = d.WorkingYears1b7,
				Zip1b45 = d.Zip1b45
			}).FirstOrDefault();
		}

		#endregion

		#region Application Employment Income Detail

		public string AddApplicationEmployementIncomeDetail(AddEmployementIncomeDetailRequest request)
		{
			_dbContext.ApplicationEmployementIncomeDetails.Add(new ApplicationEmployementIncomeDetail()
			{
				Amount1b10 = request.Amount1b10,
				ApplicationEmployementDetailsId = request.ApplicationEmployementDetailsId,
				IncomeTypeId1b101 = request.IncomeTypeId1b101
			});

			_dbContext.SaveChanges();
			return AppConsts.SuccessfullyInserted;
		}

		public string UpdateApplicationEmployementIncomeDetail(UpdateEmployementIncomeDetailRequest request)
		{
			var objApplicationEmployementIncomeDetail = _dbContext.ApplicationEmployementIncomeDetails.Where(s => s.Id == request.Id).FirstOrDefault();

			if (objApplicationEmployementIncomeDetail == null)
			{
				return AppConsts.NoRecordFound;
			}

			objApplicationEmployementIncomeDetail.Amount1b10 = request.Amount1b10;
			objApplicationEmployementIncomeDetail.ApplicationEmployementDetailsId = request.ApplicationEmployementDetailsId;
			objApplicationEmployementIncomeDetail.IncomeTypeId1b101 = request.IncomeTypeId1b101;

			_dbContext.Entry(objApplicationEmployementIncomeDetail).State = EntityState.Modified;
			_dbContext.SaveChanges();

			return AppConsts.SuccessfullyUpdated;
		}

		public string DeleteApplicationEmployementIncomeDetail(int id)
		{
			var objApplicationEmployementIncomeDetail = _dbContext.ApplicationEmployementIncomeDetails.Where(s => s.Id == id).FirstOrDefault();

			if (objApplicationEmployementIncomeDetail == null)
			{
				return AppConsts.NoRecordFound;
			}

			_dbContext.ApplicationEmployementIncomeDetails.Remove(objApplicationEmployementIncomeDetail);
			_dbContext.SaveChanges();

			return AppConsts.SuccessfullyDeleted;
		}

		public List<UpdateEmployementIncomeDetailRequest> GetApplicationEmployementIncomeDetails()
		{
			return _dbContext.ApplicationEmployementIncomeDetails.Select(d => new UpdateEmployementIncomeDetailRequest()
			{
				Id = d.Id,
				Amount1b10 = d.Amount1b10,
				ApplicationEmployementDetailsId = d.ApplicationEmployementDetailsId,
				IncomeTypeId1b101 = d.IncomeTypeId1b101
			}).ToList();
		}

		public UpdateEmployementIncomeDetailRequest GetApplicationEmployementIncomeDetailById(int id)
		{
			return _dbContext.ApplicationEmployementIncomeDetails.Where(s => s.Id == id).Select(d => new UpdateEmployementIncomeDetailRequest()
			{
				Id = d.Id,
				Amount1b10 = d.Amount1b10,
				ApplicationEmployementDetailsId = d.ApplicationEmployementDetailsId,
				IncomeTypeId1b101 = d.IncomeTypeId1b101
			}).FirstOrDefault();
		}

		#endregion

		#region Previous Employment Detail
		public string AddApplicationPreviousEmployementDetail(AddPreviousEmployementDetailRequest request)
		{
			_dbContext.ApplicationPreviousEmployementDetails.Add(new ApplicationPreviousEmployementDetail()
			{
				ApplicationPersonalInformationId = request.ApplicationPersonalInformationId,
				CityId1d33 = request.CityId1d33,
				CountryId1d36 = request.CountryId1d36,
				EmployerBusinessName1d2 = request.EmployerBusinessName1d2,
				GrossMonthlyIncome1d8 = request.GrossMonthlyIncome1d8,
				EndDate1d6 = request.EndDate1d6,
				IsSelfEmployed1d7 = request.IsSelfEmployed1d7,
				PositionTitle1d4 = request.PositionTitle1d4,
				StartDate1d5 = request.StartDate1d5,
				StateId1d34 = request.StateId1d34,
				Street1d31 = request.Street1d31,
				Unit1d32 = request.Unit1d32,
				Zip1d35 = request.Zip1d35
			});

			_dbContext.SaveChanges();
			return AppConsts.SuccessfullyInserted;
		}

		public string UpdateApplicationPreviousEmployementDetail(UpdatePreviousEmployementDetailRequest request)
		{
			var objApplicationPreviousEmployementDetail = _dbContext.ApplicationPreviousEmployementDetails.Where(s => s.Id == request.Id).FirstOrDefault();

			if (objApplicationPreviousEmployementDetail == null)
			{
				return AppConsts.NoRecordFound;
			}

			objApplicationPreviousEmployementDetail.ApplicationPersonalInformationId = request.ApplicationPersonalInformationId;
			objApplicationPreviousEmployementDetail.CityId1d33 = request.CityId1d33;
			objApplicationPreviousEmployementDetail.CountryId1d36 = request.CountryId1d36;
			objApplicationPreviousEmployementDetail.EmployerBusinessName1d2 = request.EmployerBusinessName1d2;
			objApplicationPreviousEmployementDetail.GrossMonthlyIncome1d8 = request.GrossMonthlyIncome1d8;
			objApplicationPreviousEmployementDetail.EndDate1d6 = request.EndDate1d6;
			objApplicationPreviousEmployementDetail.IsSelfEmployed1d7 = request.IsSelfEmployed1d7;
			objApplicationPreviousEmployementDetail.PositionTitle1d4 = request.PositionTitle1d4;
			objApplicationPreviousEmployementDetail.StartDate1d5 = request.StartDate1d5;
			objApplicationPreviousEmployementDetail.StateId1d34 = request.StateId1d34;
			objApplicationPreviousEmployementDetail.Street1d31 = request.Street1d31;
			objApplicationPreviousEmployementDetail.Unit1d32 = request.Unit1d32;
			objApplicationPreviousEmployementDetail.Zip1d35 = request.Zip1d35;

			_dbContext.Entry(objApplicationPreviousEmployementDetail).State = EntityState.Modified;
			_dbContext.SaveChanges();

			return AppConsts.SuccessfullyUpdated;
		}

		public string DeleteApplicationPreviousEmployementDetail(int id)
		{
			var objApplicationPreviousEmployementDetail = _dbContext.ApplicationPreviousEmployementDetails.Where(s => s.Id == id).FirstOrDefault();

			if (objApplicationPreviousEmployementDetail == null)
			{
				return AppConsts.NoRecordFound;
			}

			_dbContext.ApplicationPreviousEmployementDetails.Remove(objApplicationPreviousEmployementDetail);
			_dbContext.SaveChanges();

			return AppConsts.SuccessfullyDeleted;
		}

		public List<UpdatePreviousEmployementDetailRequest> GetApplicationPreviousEmployementDetails()
		{
			return _dbContext.ApplicationPreviousEmployementDetails.Select(d => new UpdatePreviousEmployementDetailRequest()
			{
				Id = d.Id,
				ApplicationPersonalInformationId = d.ApplicationPersonalInformationId,
				CityId1d33 = d.CityId1d33,
				CountryId1d36 = d.CountryId1d36,
				EmployerBusinessName1d2 = d.EmployerBusinessName1d2,
				EndDate1d6 = d.EndDate1d6,
				GrossMonthlyIncome1d8 = d.GrossMonthlyIncome1d8,
				IsSelfEmployed1d7 = d.IsSelfEmployed1d7,
				PositionTitle1d4 = d.PositionTitle1d4,
				StartDate1d5 = d.StartDate1d5,
				StateId1d34 = d.StateId1d34,
				Street1d31 = d.Street1d31,
				Unit1d32 = d.Unit1d32,
				Zip1d35 = d.Zip1d35
			}).ToList();
		}

		public UpdatePreviousEmployementDetailRequest GetApplicationPreviousEmployementDetailById(int id)
		{
			return _dbContext.ApplicationPreviousEmployementDetails.Where(s => s.Id == id).Select(d => new UpdatePreviousEmployementDetailRequest()
			{
				Id = d.Id,
				ApplicationPersonalInformationId = d.ApplicationPersonalInformationId,
				CityId1d33 = d.CityId1d33,
				CountryId1d36 = d.CountryId1d36,
				EmployerBusinessName1d2 = d.EmployerBusinessName1d2,
				EndDate1d6 = d.EndDate1d6,
				GrossMonthlyIncome1d8 = d.GrossMonthlyIncome1d8,
				IsSelfEmployed1d7 = d.IsSelfEmployed1d7,
				PositionTitle1d4 = d.PositionTitle1d4,
				StartDate1d5 = d.StartDate1d5,
				StateId1d34 = d.StateId1d34,
				Street1d31 = d.Street1d31,
				Unit1d32 = d.Unit1d32,
				Zip1d35 = d.Zip1d35
			}).FirstOrDefault();
		}

		#endregion

		#region Financial Real State

		public string AddApplicationFinancialRealEstate(AddFinancialRealEstateRequest request)
		{
			_dbContext.ApplicationFinancialRealEstates.Add(new ApplicationFinancialRealEstate()
			{
				ApplicationPersonalInformationId = request.ApplicationPersonalInformationId,
				CityId3a23 = request.CityId3a23,
				CountryId3a26 = request.CountryId3a26,
				FinancialPropertyIntendedOccupancyId3a5 = request.FinancialPropertyIntendedOccupancyId3a5,
				FinancialPropertyStatusId3a4 = request.FinancialPropertyStatusId3a4,
				MonthlyMortagePayment3a6 = request.MonthlyMortagePayment3a6,
				MonthlyRentalIncome3a7 = request.MonthlyRentalIncome3a7,
				NetMonthlyRentalIncome3a8 = request.NetMonthlyRentalIncome3a8,
				PropertyValue3a3 = request.PropertyValue3a3,
				StateId3a24 = request.StateId3a24,
				Street3a21 = request.Street3a21,
				UnitNo3a22 = request.UnitNo3a22,
				Zip3a25 = request.Zip3a25
			});

			_dbContext.SaveChanges();
			return AppConsts.SuccessfullyInserted;
		}

		public string UpdateApplicationFinancialRealEstate(UpdateFinancialRealEstateRequest request)
		{
			var objApplicationFinancialRealEstate = _dbContext.ApplicationFinancialRealEstates.Where(s => s.Id == request.Id).FirstOrDefault();

			if (objApplicationFinancialRealEstate == null)
			{
				return AppConsts.NoRecordFound;
			}

			objApplicationFinancialRealEstate.ApplicationPersonalInformationId = request.ApplicationPersonalInformationId;
			objApplicationFinancialRealEstate.CityId3a23 = request.CityId3a23;
			objApplicationFinancialRealEstate.CountryId3a26 = request.CountryId3a26;
			objApplicationFinancialRealEstate.FinancialPropertyIntendedOccupancyId3a5 = request.FinancialPropertyIntendedOccupancyId3a5;
			objApplicationFinancialRealEstate.FinancialPropertyStatusId3a4 = request.FinancialPropertyStatusId3a4;
			objApplicationFinancialRealEstate.MonthlyMortagePayment3a6 = request.MonthlyMortagePayment3a6;
			objApplicationFinancialRealEstate.MonthlyRentalIncome3a7 = request.MonthlyRentalIncome3a7;
			objApplicationFinancialRealEstate.NetMonthlyRentalIncome3a8 = request.NetMonthlyRentalIncome3a8;
			objApplicationFinancialRealEstate.PropertyValue3a3 = request.PropertyValue3a3;
			objApplicationFinancialRealEstate.StateId3a24 = request.StateId3a24;
			objApplicationFinancialRealEstate.Street3a21 = request.Street3a21;
			objApplicationFinancialRealEstate.UnitNo3a22 = request.UnitNo3a22;
			objApplicationFinancialRealEstate.Zip3a25 = request.Zip3a25;

			_dbContext.Entry(objApplicationFinancialRealEstate).State = EntityState.Modified;
			_dbContext.SaveChanges();

			return AppConsts.SuccessfullyUpdated;
		}

		public string DeleteApplicationFinancialRealEstate(int id)
		{
			var objApplicationFinancialRealEstate = _dbContext.ApplicationFinancialRealEstates.Where(s => s.Id == id).FirstOrDefault();

			if (objApplicationFinancialRealEstate == null)
			{
				return AppConsts.NoRecordFound;
			}

			_dbContext.ApplicationFinancialRealEstates.Remove(objApplicationFinancialRealEstate);
			_dbContext.SaveChanges();

			return AppConsts.SuccessfullyDeleted;
		}

		public List<UpdateFinancialRealEstateRequest> GetApplicationFinancialRealEstates()
		{
			return _dbContext.ApplicationFinancialRealEstates.Select(d => new UpdateFinancialRealEstateRequest()
			{
				Id = d.Id,
				ApplicationPersonalInformationId = d.ApplicationPersonalInformationId,
				CityId3a23 = d.CityId3a23,
				CountryId3a26 = d.CountryId3a26,
				FinancialPropertyIntendedOccupancyId3a5 = d.FinancialPropertyIntendedOccupancyId3a5,
				FinancialPropertyStatusId3a4 = d.FinancialPropertyStatusId3a4,
				MonthlyMortagePayment3a6 = d.MonthlyMortagePayment3a6,
				MonthlyRentalIncome3a7 = d.MonthlyRentalIncome3a7,
				NetMonthlyRentalIncome3a8 = d.NetMonthlyRentalIncome3a8,
				PropertyValue3a3 = d.PropertyValue3a3,
				StateId3a24 = d.StateId3a24,
				Street3a21 = d.Street3a21,
				UnitNo3a22 = d.UnitNo3a22,
				Zip3a25 = d.Zip3a25
			}).ToList();
		}

		public UpdateFinancialRealEstateRequest GetApplicationFinancialRealEstateById(int id)
		{
			return _dbContext.ApplicationFinancialRealEstates.Where(s => s.Id == id).Select(d => new UpdateFinancialRealEstateRequest()
			{
				Id = d.Id,
				ApplicationPersonalInformationId = d.ApplicationPersonalInformationId,
				CityId3a23 = d.CityId3a23,
				CountryId3a26 = d.CountryId3a26,
				FinancialPropertyIntendedOccupancyId3a5 = d.FinancialPropertyIntendedOccupancyId3a5,
				FinancialPropertyStatusId3a4 = d.FinancialPropertyStatusId3a4,
				MonthlyMortagePayment3a6 = d.MonthlyMortagePayment3a6,
				MonthlyRentalIncome3a7 = d.MonthlyRentalIncome3a7,
				NetMonthlyRentalIncome3a8 = d.NetMonthlyRentalIncome3a8,
				PropertyValue3a3 = d.PropertyValue3a3,
				StateId3a24 = d.StateId3a24,
				Street3a21 = d.Street3a21,
				UnitNo3a22 = d.UnitNo3a22,
				Zip3a25 = d.Zip3a25
			}).FirstOrDefault();
		}

		#endregion

		#region Application Personal Information

		public string AddApplicationPersonalInformation(AddPersonalInformationRequest request)
		{
			_dbContext.ApplicationPersonalInformations.Add(new ApplicationPersonalInformation()
			{
				Ages1a81 = request.Ages1a81,
				AlternateFirstName1a21 = request.AlternateFirstName1a21,
				AlternateLastName1a23 = request.AlternateLastName1a23,
				AlternateMiddleName1a22 = request.AlternateMiddleName1a22,
				AlternateSuffix1a24 = request.AlternateSuffix1a24,
				ApplicationId = request.ApplicationId,
				CellPhone1a10 = request.CellPhone1a10,
				CitizenshipTypeId1a5 = request.CitizenshipTypeId1a5,
				CurrentCityId1a133 = request.CurrentCityId1a133,
				CurrentCountryId1a136 = request.CurrentCountryId1a136,
				CurrentHousingTypeId1a141 = request.CurrentHousingTypeId1a141,
				CurrentMonths1a15 = request.CurrentMonths1a15,
				CurrentRent1a142 = request.CurrentRent1a142,
				CurrentStateId1a134 = request.CurrentStateId1a134,
				CurrentStreet1a131 = request.CurrentStreet1a131,
				CurrentUnit1a132 = request.CurrentUnit1a132,
				CurrentYears1a14 = request.CurrentYears1a14,
				CurrentZip1a135 = request.CurrentZip1a135,
				Dependents1a8 = request.Dependents1a8,
				Dob1a4 = request.Dob1a4,
				Email1a12 = request.Email1a12,
				Ext1a111 = request.Ext1a111,
				FirstName1a1 = request.FirstName1a1,
				FormerCityId1a153 = request.FormerCityId1a153,
				FormerCountryId1a156 = request.FormerCountryId1a156,
				FormerHousingTypeId1a161 = request.FormerHousingTypeId1a161,
				FormerRent1a162 = request.FormerRent1a162,
				FormerMonths1a161 = request.FormerMonths1a161,
				FormerStateId1a154 = request.FormerStateId1a154,
				FormerStreet1a151 = request.FormerStreet1a151,
				FormerUnit1a152 = request.FormerUnit1a152,
				FormerYears1a16 = request.FormerYears1a16,
				FormerZip1a155 = request.FormerZip1a155,
				LastName1a3 = request.LastName1a3,
				HomePhone1a9 = request.HomePhone1a9,
				MailingCityId1a173 = request.MailingCityId1a173,
				MailingCountryId1a176 = request.MailingCountryId1a176,
				MailingStateId1a174 = request.MailingStateId1a174,
				MailingStreet1a171 = request.MailingStreet1a171,
				MailingUnit1a172 = request.MailingUnit1a172,
				MailingZip1a175 = request.MailingZip1a175,
				MaritialStatusId1a7 = request.MaritialStatusId1a7,
				MiddleName1a2 = request.MiddleName1a2,
				Ssn1a3 = request.Ssn1a3,
				Suffix1a4 = request.Suffix1a4,
				WorkPhone1a11 = request.WorkPhone1a11
			});

			_dbContext.SaveChanges();
			return AppConsts.SuccessfullyInserted;
		}

		public string UpdateApplicationPersonalInformation(UpdatePersonalInformationRequest request)
		{
			var objApplicationPersonalInformation = _dbContext.ApplicationPersonalInformations.Where(s => s.Id == request.Id).FirstOrDefault();

			if (objApplicationPersonalInformation == null)
			{
				return AppConsts.NoRecordFound;
			}

			objApplicationPersonalInformation.Ages1a81 = request.Ages1a81;
			objApplicationPersonalInformation.AlternateFirstName1a21 = request.AlternateFirstName1a21;
			objApplicationPersonalInformation.AlternateLastName1a23 = request.AlternateLastName1a23;
			objApplicationPersonalInformation.AlternateMiddleName1a22 = request.AlternateMiddleName1a22;
			objApplicationPersonalInformation.AlternateSuffix1a24 = request.AlternateSuffix1a24;
			objApplicationPersonalInformation.ApplicationId = request.ApplicationId;
			objApplicationPersonalInformation.CellPhone1a10 = request.CellPhone1a10;
			objApplicationPersonalInformation.CitizenshipTypeId1a5 = request.CitizenshipTypeId1a5;
			objApplicationPersonalInformation.CurrentCityId1a133 = request.CurrentCityId1a133;
			objApplicationPersonalInformation.CurrentCountryId1a136 = request.CurrentCountryId1a136;
			objApplicationPersonalInformation.CurrentHousingTypeId1a141 = request.CurrentHousingTypeId1a141;
			objApplicationPersonalInformation.CurrentMonths1a15 = request.CurrentMonths1a15;
			objApplicationPersonalInformation.CurrentRent1a142 = request.CurrentRent1a142;
			objApplicationPersonalInformation.CurrentStateId1a134 = request.CurrentStateId1a134;
			objApplicationPersonalInformation.CurrentStreet1a131 = request.CurrentStreet1a131;
			objApplicationPersonalInformation.CurrentUnit1a132 = request.CurrentUnit1a132;
			objApplicationPersonalInformation.CurrentYears1a14 = request.CurrentYears1a14;
			objApplicationPersonalInformation.CurrentZip1a135 = request.CurrentZip1a135;
			objApplicationPersonalInformation.Dependents1a8 = request.Dependents1a8;
			objApplicationPersonalInformation.Dob1a4 = request.Dob1a4;
			objApplicationPersonalInformation.Email1a12 = request.Email1a12;
			objApplicationPersonalInformation.Ext1a111 = request.Ext1a111;
			objApplicationPersonalInformation.FirstName1a1 = request.FirstName1a1;
			objApplicationPersonalInformation.FormerCityId1a153 = request.FormerCityId1a153;
			objApplicationPersonalInformation.FormerCountryId1a156 = request.FormerCountryId1a156;
			objApplicationPersonalInformation.FormerHousingTypeId1a161 = request.FormerHousingTypeId1a161;
			objApplicationPersonalInformation.FormerRent1a162 = request.FormerRent1a162;
			objApplicationPersonalInformation.FormerMonths1a161 = request.FormerMonths1a161;
			objApplicationPersonalInformation.FormerStateId1a154 = request.FormerStateId1a154;
			objApplicationPersonalInformation.FormerStreet1a151 = request.FormerStreet1a151;
			objApplicationPersonalInformation.FormerUnit1a152 = request.FormerUnit1a152;
			objApplicationPersonalInformation.FormerYears1a16 = request.FormerYears1a16;
			objApplicationPersonalInformation.FormerZip1a155 = request.FormerZip1a155;
			objApplicationPersonalInformation.LastName1a3 = request.LastName1a3;
			objApplicationPersonalInformation.HomePhone1a9 = request.HomePhone1a9;
			objApplicationPersonalInformation.MailingCityId1a173 = request.MailingCityId1a173;
			objApplicationPersonalInformation.MailingCountryId1a176 = request.MailingCountryId1a176;
			objApplicationPersonalInformation.MailingStateId1a174 = request.MailingStateId1a174;
			objApplicationPersonalInformation.MailingStreet1a171 = request.MailingStreet1a171;
			objApplicationPersonalInformation.MailingUnit1a172 = request.MailingUnit1a172;
			objApplicationPersonalInformation.MailingZip1a175 = request.MailingZip1a175;
			objApplicationPersonalInformation.MaritialStatusId1a7 = request.MaritialStatusId1a7;
			objApplicationPersonalInformation.MiddleName1a2 = request.MiddleName1a2;
			objApplicationPersonalInformation.Ssn1a3 = request.Ssn1a3;
			objApplicationPersonalInformation.Suffix1a4 = request.Suffix1a4;
			objApplicationPersonalInformation.WorkPhone1a11 = request.WorkPhone1a11;

			_dbContext.Entry(objApplicationPersonalInformation).State = EntityState.Modified;
			_dbContext.SaveChanges();

			return AppConsts.SuccessfullyUpdated;
		}

		public string DeleteApplicationPersonalInformation(int id)
		{
			var objApplicationPersonalInformation = _dbContext.ApplicationPersonalInformations.Where(s => s.Id == id).FirstOrDefault();

			if (objApplicationPersonalInformation == null)
			{
				return AppConsts.NoRecordFound;
			}

			_dbContext.ApplicationPersonalInformations.Remove(objApplicationPersonalInformation);
			_dbContext.SaveChanges();

			return AppConsts.SuccessfullyDeleted;
		}

		public List<UpdatePersonalInformationRequest> GetApplicationPersonalInformations()
		{
			return _dbContext.ApplicationPersonalInformations.Select(d => new UpdatePersonalInformationRequest()
			{
				Id = d.Id,
				Ages1a81 = d.Ages1a81,
				AlternateFirstName1a21 = d.AlternateFirstName1a21,
				AlternateLastName1a23 = d.AlternateLastName1a23,
				AlternateMiddleName1a22 = d.AlternateMiddleName1a22,
				AlternateSuffix1a24 = d.AlternateSuffix1a24,
				ApplicationId = d.ApplicationId,
				CellPhone1a10 = d.CellPhone1a10,
				CitizenshipTypeId1a5 = d.CitizenshipTypeId1a5,
				CurrentCityId1a133 = d.CurrentCityId1a133,
				CurrentCountryId1a136 = d.CurrentCountryId1a136,
				CurrentHousingTypeId1a141 = d.CurrentHousingTypeId1a141,
				CurrentMonths1a15 = d.CurrentMonths1a15,
				CurrentRent1a142 = d.CurrentRent1a142,
				CurrentStateId1a134 = d.CurrentStateId1a134,
				CurrentStreet1a131 = d.CurrentStreet1a131,
				CurrentUnit1a132 = d.CurrentUnit1a132,
				CurrentYears1a14 = d.CurrentYears1a14,
				CurrentZip1a135 = d.CurrentZip1a135,
				Dependents1a8 = d.Dependents1a8,
				Dob1a4 = d.Dob1a4,
				Email1a12 = d.Email1a12,
				Ext1a111 = d.Ext1a111,
				FirstName1a1 = d.FirstName1a1,
				FormerCityId1a153 = d.FormerCityId1a153,
				FormerHousingTypeId1a161 = d.FormerCountryId1a156,
				FormerCountryId1a156 = d.FormerHousingTypeId1a161,
				FormerMonths1a161 = d.FormerMonths1a161,
				FormerRent1a162 = d.FormerRent1a162,
				FormerStateId1a154 = d.FormerStateId1a154,
				FormerStreet1a151 = d.FormerStreet1a151,
				FormerUnit1a152 = d.FormerUnit1a152,
				FormerYears1a16 = d.FormerYears1a16,
				FormerZip1a155 = d.FormerZip1a155,
				HomePhone1a9 = d.HomePhone1a9,
				LastName1a3 = d.LastName1a3,
				MailingCityId1a173 = d.MailingCityId1a173,
				MailingCountryId1a176 = d.MailingCountryId1a176,
				MailingStateId1a174 = d.MailingStateId1a174,
				MailingStreet1a171 = d.MailingStreet1a171,
				MailingUnit1a172 = d.MailingUnit1a172,
				MailingZip1a175 = d.MailingZip1a175,
				MaritialStatusId1a7 = d.MaritialStatusId1a7,
				MiddleName1a2 = d.MiddleName1a2,
				Ssn1a3 = d.Ssn1a3,
				Suffix1a4 = d.Suffix1a4,
				WorkPhone1a11 = d.WorkPhone1a11
			}).ToList();
		}

		public UpdatePersonalInformationRequest GetApplicationPersonalInformationById(int id)
		{
			return _dbContext.ApplicationPersonalInformations.Where(s => s.Id == id).Select(d => new UpdatePersonalInformationRequest()
			{
				Id = d.Id,
				Ages1a81 = d.Ages1a81,
				AlternateFirstName1a21 = d.AlternateFirstName1a21,
				AlternateLastName1a23 = d.AlternateLastName1a23,
				AlternateMiddleName1a22 = d.AlternateMiddleName1a22,
				AlternateSuffix1a24 = d.AlternateSuffix1a24,
				ApplicationId = d.ApplicationId,
				CellPhone1a10 = d.CellPhone1a10,
				CitizenshipTypeId1a5 = d.CitizenshipTypeId1a5,
				CurrentCityId1a133 = d.CurrentCityId1a133,
				CurrentCountryId1a136 = d.CurrentCountryId1a136,
				CurrentHousingTypeId1a141 = d.CurrentHousingTypeId1a141,
				CurrentMonths1a15 = d.CurrentMonths1a15,
				CurrentRent1a142 = d.CurrentRent1a142,
				CurrentStateId1a134 = d.CurrentStateId1a134,
				CurrentStreet1a131 = d.CurrentStreet1a131,
				CurrentUnit1a132 = d.CurrentUnit1a132,
				CurrentYears1a14 = d.CurrentYears1a14,
				CurrentZip1a135 = d.CurrentZip1a135,
				Dependents1a8 = d.Dependents1a8,
				Dob1a4 = d.Dob1a4,
				Email1a12 = d.Email1a12,
				Ext1a111 = d.Ext1a111,
				FirstName1a1 = d.FirstName1a1,
				FormerCityId1a153 = d.FormerCityId1a153,
				FormerHousingTypeId1a161 = d.FormerCountryId1a156,
				FormerCountryId1a156 = d.FormerHousingTypeId1a161,
				FormerMonths1a161 = d.FormerMonths1a161,
				FormerRent1a162 = d.FormerRent1a162,
				FormerStateId1a154 = d.FormerStateId1a154,
				FormerStreet1a151 = d.FormerStreet1a151,
				FormerUnit1a152 = d.FormerUnit1a152,
				FormerYears1a16 = d.FormerYears1a16,
				FormerZip1a155 = d.FormerZip1a155,
				HomePhone1a9 = d.HomePhone1a9,
				LastName1a3 = d.LastName1a3,
				MailingCityId1a173 = d.MailingCityId1a173,
				MailingCountryId1a176 = d.MailingCountryId1a176,
				MailingStateId1a174 = d.MailingStateId1a174,
				MailingStreet1a171 = d.MailingStreet1a171,
				MailingUnit1a172 = d.MailingUnit1a172,
				MailingZip1a175 = d.MailingZip1a175,
				MaritialStatusId1a7 = d.MaritialStatusId1a7,
				MiddleName1a2 = d.MiddleName1a2,
				Ssn1a3 = d.Ssn1a3,
				Suffix1a4 = d.Suffix1a4,
				WorkPhone1a11 = d.WorkPhone1a11
			}).FirstOrDefault();
		}

		#endregion

		#region Application Financial Asset

		public string AddApplicationFinancialAsset(AddApplicationFinancialAssetRequest request)
		{
			_dbContext.ApplicationFinancialAssets.Add(new ApplicationFinancialAsset()
			{
				AccountNumber2a3 = request.AccountNumber2a3,
				FinancialAccountTypeId2a1 = request.FinancialAccountTypeId2a1,
				FinancialInstitution2a2 = request.FinancialInstitution2a2,
				Value2a4 = request.Value2a4,
				ApplicationPersonalInformationId = request.ApplicationPersonalInformationId
			});

			_dbContext.SaveChanges();
			return AppConsts.SuccessfullyInserted;
		}

		public string UpdateApplicationFinancialAsset(UpdateApplicationFinancialAssetRequest request)
		{
			var objApplicationFinancialAsset = _dbContext.ApplicationFinancialAssets.Where(s => s.Id == request.Id).FirstOrDefault();

			if (objApplicationFinancialAsset == null)
			{
				return AppConsts.NoRecordFound;
			}

			objApplicationFinancialAsset.AccountNumber2a3 = request.AccountNumber2a3;
			objApplicationFinancialAsset.FinancialAccountTypeId2a1 = request.FinancialAccountTypeId2a1;
			objApplicationFinancialAsset.FinancialInstitution2a2 = request.FinancialInstitution2a2;
			objApplicationFinancialAsset.Value2a4 = request.Value2a4;
			objApplicationFinancialAsset.ApplicationPersonalInformationId = request.ApplicationPersonalInformationId;

			_dbContext.Entry(objApplicationFinancialAsset).State = EntityState.Modified;
			_dbContext.SaveChanges();

			return AppConsts.SuccessfullyUpdated;
		}

		public string DeleteApplicationFinancialAsset(int id)
		{
			var objApplicationFinancialAsset = _dbContext.ApplicationFinancialAssets.Where(s => s.Id == id).FirstOrDefault();

			if (objApplicationFinancialAsset == null)
			{
				return AppConsts.NoRecordFound;
			}

			_dbContext.ApplicationFinancialAssets.Remove(objApplicationFinancialAsset);
			_dbContext.SaveChanges();

			return AppConsts.SuccessfullyDeleted;
		}

		public List<UpdateApplicationFinancialAssetRequest> GetApplicationFinancialAssets()
		{
			return _dbContext.ApplicationFinancialAssets.Select(d => new UpdateApplicationFinancialAssetRequest()
			{
				Id = d.Id,
				AccountNumber2a3 = d.AccountNumber2a3,
				FinancialAccountTypeId2a1 = d.FinancialAccountTypeId2a1,
				FinancialInstitution2a2 = d.FinancialInstitution2a2,
				Value2a4 = d.Value2a4,
				ApplicationPersonalInformationId = d.ApplicationPersonalInformationId
			}).ToList();
		}

		public UpdateApplicationFinancialAssetRequest GetApplicationFinancialAssetById(int id)
		{
			return _dbContext.ApplicationFinancialAssets.Where(s => s.Id == id).Select(d => new UpdateApplicationFinancialAssetRequest()
			{
				Id = d.Id,
				AccountNumber2a3 = d.AccountNumber2a3,
				FinancialAccountTypeId2a1 = d.FinancialAccountTypeId2a1,
				FinancialInstitution2a2 = d.FinancialInstitution2a2,
				Value2a4 = d.Value2a4,
				ApplicationPersonalInformationId = d.ApplicationPersonalInformationId
			}).FirstOrDefault();
		}

		#endregion

		#region Application Financial Liabilities

		public string AddApplicationFinancialLiability(AddApplicationFinancialLiabilityRequest request)
		{
			_dbContext.ApplicationFinancialLaibilities.Add(new ApplicationFinancialLaibility()
			{
				ApplicationPersonalInformationId = request.ApplicationPersonalInformationId,
				AccountNumber2c3 = request.AccountNumber2c3,
				CompanyName2c2 = request.CompanyName2c2,
				FinancialLaibilitiesType2c1 = request.FinancialLaibilitiesType2c1,
				MonthlyValue2c6 = request.MonthlyValue2c6,
				PaidOff2c5 = request.PaidOff2c5,
				UnpaidBalance2c4 = request.UnpaidBalance2c4
			});

			_dbContext.SaveChanges();
			return AppConsts.SuccessfullyInserted;
		}

		public string UpdateApplicationFinancialLiability(UpdateApplicationFinancialLiabilityRequest request)
		{
			var objApplicationFinancialLiability = _dbContext.ApplicationFinancialLaibilities.Where(s => s.Id == request.Id).FirstOrDefault();

			if (objApplicationFinancialLiability == null)
			{
				return AppConsts.NoRecordFound;
			}

			objApplicationFinancialLiability.AccountNumber2c3 = request.AccountNumber2c3;
			objApplicationFinancialLiability.CompanyName2c2 = request.CompanyName2c2;
			objApplicationFinancialLiability.FinancialLaibilitiesType2c1 = request.FinancialLaibilitiesType2c1;
			objApplicationFinancialLiability.MonthlyValue2c6 = request.MonthlyValue2c6;
			objApplicationFinancialLiability.PaidOff2c5 = request.PaidOff2c5;
			objApplicationFinancialLiability.UnpaidBalance2c4 = request.UnpaidBalance2c4;
			objApplicationFinancialLiability.ApplicationPersonalInformationId = request.ApplicationPersonalInformationId;

			_dbContext.Entry(objApplicationFinancialLiability).State = EntityState.Modified;
			_dbContext.SaveChanges();

			return AppConsts.SuccessfullyUpdated;
		}

		public string DeleteApplicationFinancialLiability(int id)
		{
			var objApplicationFinancialLiability = _dbContext.ApplicationFinancialLaibilities.Where(s => s.Id == id).FirstOrDefault();

			if (objApplicationFinancialLiability == null)
			{
				return AppConsts.NoRecordFound;
			}

			_dbContext.ApplicationFinancialLaibilities.Remove(objApplicationFinancialLiability);
			_dbContext.SaveChanges();

			return AppConsts.SuccessfullyDeleted;
		}

		public List<UpdateApplicationFinancialLiabilityRequest> GetApplicationFinancialLiabilities()
		{
			return _dbContext.ApplicationFinancialLaibilities.Select(d => new UpdateApplicationFinancialLiabilityRequest()
			{
				Id = d.Id,
				ApplicationPersonalInformationId = d.ApplicationPersonalInformationId,
				AccountNumber2c3 = d.AccountNumber2c3,
				CompanyName2c2 = d.CompanyName2c2,
				FinancialLaibilitiesType2c1 = d.FinancialLaibilitiesType2c1,
				MonthlyValue2c6 = d.MonthlyValue2c6,
				PaidOff2c5 = d.PaidOff2c5,
				UnpaidBalance2c4 = d.UnpaidBalance2c4
			}).ToList();
		}

		public UpdateApplicationFinancialLiabilityRequest GetApplicationFinancialLiabilityById(int id)
		{
			return _dbContext.ApplicationFinancialLaibilities.Where(s => s.Id == id).Select(d => new UpdateApplicationFinancialLiabilityRequest()
			{
				Id = d.Id,
				ApplicationPersonalInformationId = d.ApplicationPersonalInformationId,
				AccountNumber2c3 = d.AccountNumber2c3,
				CompanyName2c2 = d.CompanyName2c2,
				FinancialLaibilitiesType2c1 = d.FinancialLaibilitiesType2c1,
				MonthlyValue2c6 = d.MonthlyValue2c6,
				PaidOff2c5 = d.PaidOff2c5,
				UnpaidBalance2c4 = d.UnpaidBalance2c4
			}).FirstOrDefault();
		}

		#endregion

		#region Application Income Source

		public string AddApplicationIncomeSource(AddApplicationIncomeSourceRequest request)
		{
			_dbContext.ApplicationIncomeSources.Add(new ApplicationIncomeSource()
			{
				Amount1e2 = request.Amount1e2,
				ApplicationPersonalInformationId = request.ApplicationPersonalInformationId,
				IncomeSourceId1e1 = request.IncomeSourceId1e1
			});

			_dbContext.SaveChanges();
			return AppConsts.SuccessfullyInserted;
		}

		public string UpdateApplicationIncomeSource(UpdateApplicationIncomeSourceRequest request)
		{
			var objApplicationIncomeSource = _dbContext.ApplicationIncomeSources.Where(s => s.Id == request.Id).FirstOrDefault();

			if (objApplicationIncomeSource == null)
			{
				return AppConsts.NoRecordFound;
			}

			objApplicationIncomeSource.Amount1e2 = request.Amount1e2;
			objApplicationIncomeSource.ApplicationPersonalInformationId = request.ApplicationPersonalInformationId;
			objApplicationIncomeSource.IncomeSourceId1e1 = request.IncomeSourceId1e1;

			_dbContext.Entry(objApplicationIncomeSource).State = EntityState.Modified;
			_dbContext.SaveChanges();

			return AppConsts.SuccessfullyUpdated;
		}

		public string DeleteApplicationIncomeSource(int id)
		{
			var objApplicationIncomeSource = _dbContext.ApplicationIncomeSources.Where(s => s.Id == id).FirstOrDefault();

			if (objApplicationIncomeSource == null)
			{
				return AppConsts.NoRecordFound;
			}

			_dbContext.ApplicationIncomeSources.Remove(objApplicationIncomeSource);
			_dbContext.SaveChanges();

			return AppConsts.SuccessfullyDeleted;
		}

		public List<UpdateApplicationIncomeSourceRequest> GetApplicationIncomeSources()
		{
			return _dbContext.ApplicationIncomeSources.Select(d => new UpdateApplicationIncomeSourceRequest()
			{
				Id = d.Id,
				Amount1e2 = d.Amount1e2,
				ApplicationPersonalInformationId = d.ApplicationPersonalInformationId,
				IncomeSourceId1e1 = d.IncomeSourceId1e1
			}).ToList();
		}

		public UpdateApplicationIncomeSourceRequest GetApplicationIncomeSourceById(int id)
		{
			return _dbContext.ApplicationIncomeSources.Where(s => s.Id == id).Select(d => new UpdateApplicationIncomeSourceRequest()
			{
				Id = d.Id,
				Amount1e2 = d.Amount1e2,
				ApplicationPersonalInformationId = d.ApplicationPersonalInformationId,
				IncomeSourceId1e1 = d.IncomeSourceId1e1
			}).FirstOrDefault();
		}

		#endregion

		#region Application Financial Other Asset

		public string AddApplicationFinancialOtherAsset(AddApplicationFinancialOtherAssetRequest request)
		{
			_dbContext.ApplicationFinancialOtherAssets.Add(new ApplicationFinancialOtherAsset()
			{
				ApplicationPersonalInformationId = request.ApplicationPersonalInformationId,
				FinancialAssetsTypesId2b1 = request.FinancialAssetsTypesId2b1,
				Value2b2 = request.Value2b2
			});

			_dbContext.SaveChanges();
			return AppConsts.SuccessfullyInserted;
		}

		public string UpdateApplicationFinancialOtherAsset(UpdateApplicationFinancialOtherAssetRequest request)
		{
			var objApplicationFinancialOtherAsset = _dbContext.ApplicationFinancialOtherAssets.Where(s => s.Id == request.Id).FirstOrDefault();

			if (objApplicationFinancialOtherAsset == null)
			{
				return AppConsts.NoRecordFound;
			}

			objApplicationFinancialOtherAsset.ApplicationPersonalInformationId = request.ApplicationPersonalInformationId;
			objApplicationFinancialOtherAsset.FinancialAssetsTypesId2b1 = request.FinancialAssetsTypesId2b1;
			objApplicationFinancialOtherAsset.Value2b2 = request.Value2b2;

			_dbContext.Entry(objApplicationFinancialOtherAsset).State = EntityState.Modified;
			_dbContext.SaveChanges();

			return AppConsts.SuccessfullyUpdated;
		}

		public string DeleteApplicationFinancialOtherAsset(int id)
		{
			var objApplicationFinancialOtherAsset = _dbContext.ApplicationFinancialOtherAssets.Where(s => s.Id == id).FirstOrDefault();

			if (objApplicationFinancialOtherAsset == null)
			{
				return AppConsts.NoRecordFound;
			}

			_dbContext.ApplicationFinancialOtherAssets.Remove(objApplicationFinancialOtherAsset);
			_dbContext.SaveChanges();

			return AppConsts.SuccessfullyDeleted;
		}

		public List<UpdateApplicationFinancialOtherAssetRequest> GetApplicationFinancialOtherAssets()
		{
			return _dbContext.ApplicationFinancialOtherAssets.Select(d => new UpdateApplicationFinancialOtherAssetRequest()
			{
				Id = d.Id,
				ApplicationPersonalInformationId = d.ApplicationPersonalInformationId,
				FinancialAssetsTypesId2b1 = d.FinancialAssetsTypesId2b1,
				Value2b2 = d.Value2b2
			}).ToList();
		}

		public UpdateApplicationFinancialOtherAssetRequest GetApplicationFinancialOtherAssetById(int id)
		{
			return _dbContext.ApplicationFinancialOtherAssets.Where(s => s.Id == id).Select(d => new UpdateApplicationFinancialOtherAssetRequest()
			{
				Id = d.Id,
				ApplicationPersonalInformationId = d.ApplicationPersonalInformationId,
				FinancialAssetsTypesId2b1 = d.FinancialAssetsTypesId2b1,
				Value2b2 = d.Value2b2
			}).FirstOrDefault();
		}

		#endregion

		#region Application Financial Other Liabilities

		public string AddApplicationFinancialOtherLaibility(AddApplicationFinancialOtherLaibilityRequest request)
		{
			_dbContext.ApplicationFinancialOtherLaibilities.Add(new ApplicationFinancialOtherLaibility()
			{
				ApplicationPersonalInformationId = request.ApplicationPersonalInformationId,
				FinancialOtherLaibilitiesTypeId2d1 = request.FinancialOtherLaibilitiesTypeId2d1,
				MonthlyPayment2d2 = request.MonthlyPayment2d2
			});

			_dbContext.SaveChanges();
			return AppConsts.SuccessfullyInserted;
		}

		public string UpdateApplicationFinancialOtherLaibility(UpdateApplicationFinancialOtherLaibilityRequest request)
		{
			var objApplicationFinancialOtherLaibility = _dbContext.ApplicationFinancialOtherLaibilities.Where(s => s.Id == request.Id).FirstOrDefault();

			if (objApplicationFinancialOtherLaibility == null)
			{
				return AppConsts.NoRecordFound;
			}

			objApplicationFinancialOtherLaibility.ApplicationPersonalInformationId = request.ApplicationPersonalInformationId;
			objApplicationFinancialOtherLaibility.FinancialOtherLaibilitiesTypeId2d1 = request.FinancialOtherLaibilitiesTypeId2d1;
			objApplicationFinancialOtherLaibility.MonthlyPayment2d2 = request.MonthlyPayment2d2;

			_dbContext.Entry(objApplicationFinancialOtherLaibility).State = EntityState.Modified;
			_dbContext.SaveChanges();

			return AppConsts.SuccessfullyUpdated;
		}

		public string DeleteApplicationFinancialOtherLaibility(int id)
		{
			var objApplicationFinancialOtherLaibility = _dbContext.ApplicationFinancialOtherLaibilities.Where(s => s.Id == id).FirstOrDefault();

			if (objApplicationFinancialOtherLaibility == null)
			{
				return AppConsts.NoRecordFound;
			}

			_dbContext.ApplicationFinancialOtherLaibilities.Remove(objApplicationFinancialOtherLaibility);
			_dbContext.SaveChanges();

			return AppConsts.SuccessfullyDeleted;
		}

		public List<UpdateApplicationFinancialOtherLaibilityRequest> GetApplicationFinancialOtherLaibilities()
		{
			return _dbContext.ApplicationFinancialOtherLaibilities.Select(d => new UpdateApplicationFinancialOtherLaibilityRequest()
			{
				Id = d.Id,
				ApplicationPersonalInformationId = d.ApplicationPersonalInformationId,
				FinancialOtherLaibilitiesTypeId2d1 = d.FinancialOtherLaibilitiesTypeId2d1,
				MonthlyPayment2d2 = d.MonthlyPayment2d2
			}).ToList();
		}

		public UpdateApplicationFinancialOtherLaibilityRequest GetApplicationFinancialOtherLaibilityById(int id)
		{
			return _dbContext.ApplicationFinancialOtherLaibilities.Where(s => s.Id == id).Select(d => new UpdateApplicationFinancialOtherLaibilityRequest()
			{
				Id = d.Id,
				ApplicationPersonalInformationId = d.ApplicationPersonalInformationId,
				FinancialOtherLaibilitiesTypeId2d1 = d.FinancialOtherLaibilitiesTypeId2d1,
				MonthlyPayment2d2 = d.MonthlyPayment2d2
			}).FirstOrDefault();
		}

		#endregion

		#region Military Service

		public string AddMilitaryService(AddMilitaryServiceRequest request)
		{
			_dbContext.MilitaryServices.Add(new MilitaryService()
			{
				ApplicationPersonalInformationId = request.ApplicationPersonalInformationId,
				CurrentlyServing7a2 = request.CurrentlyServing7a2,
				DateOfServiceExpiration7a3 = request.DateOfServiceExpiration7a3,
				NonActivatedMember7a2 = request.NonActivatedMember7a2,
				Retired7a2 = request.Retired7a2,
				ServedInForces7a1 = request.ServedInForces7a1,
				SurvivingSpouse7a21 = request.SurvivingSpouse7a21
			});

			_dbContext.SaveChanges();
			return AppConsts.SuccessfullyInserted;
		}

		public string UpdateMilitaryService(UpdateMilitaryServiceRequest request)
		{
			var objMilitaryService = _dbContext.MilitaryServices.Where(s => s.Id == request.Id).FirstOrDefault();

			if (objMilitaryService == null)
			{
				return AppConsts.NoRecordFound;
			}

			objMilitaryService.ApplicationPersonalInformationId = request.ApplicationPersonalInformationId;
			objMilitaryService.CurrentlyServing7a2 = request.CurrentlyServing7a2;
			objMilitaryService.DateOfServiceExpiration7a3 = request.DateOfServiceExpiration7a3;
			objMilitaryService.NonActivatedMember7a2 = request.NonActivatedMember7a2;
			objMilitaryService.Retired7a2 = request.Retired7a2;
			objMilitaryService.ServedInForces7a1 = request.ServedInForces7a1;
			objMilitaryService.SurvivingSpouse7a21 = request.SurvivingSpouse7a21;

			_dbContext.Entry(objMilitaryService).State = EntityState.Modified;
			_dbContext.SaveChanges();

			return AppConsts.SuccessfullyUpdated;
		}

		public string DeleteMilitaryService(int id)
		{
			var objMilitaryService = _dbContext.MilitaryServices.Where(s => s.Id == id).FirstOrDefault();

			if (objMilitaryService == null)
			{
				return AppConsts.NoRecordFound;
			}

			_dbContext.MilitaryServices.Remove(objMilitaryService);
			_dbContext.SaveChanges();

			return AppConsts.SuccessfullyDeleted;
		}

		public List<UpdateMilitaryServiceRequest> GetMilitaryServices()
		{
			return _dbContext.MilitaryServices.Select(d => new UpdateMilitaryServiceRequest()
			{
				Id = d.Id,
				ApplicationPersonalInformationId = d.ApplicationPersonalInformationId,
				CurrentlyServing7a2 = d.CurrentlyServing7a2,
				DateOfServiceExpiration7a3 = d.DateOfServiceExpiration7a3,
				NonActivatedMember7a2 = d.NonActivatedMember7a2,
				Retired7a2 = d.Retired7a2,
				ServedInForces7a1 = d.ServedInForces7a1,
				SurvivingSpouse7a21 = d.SurvivingSpouse7a21
			}).ToList();
		}

		public UpdateMilitaryServiceRequest GetMilitaryServiceById(int id)
		{
			return _dbContext.MilitaryServices.Where(s => s.Id == id).Select(d => new UpdateMilitaryServiceRequest()
			{
				Id = d.Id,
				ApplicationPersonalInformationId = d.ApplicationPersonalInformationId,
				CurrentlyServing7a2 = d.CurrentlyServing7a2,
				DateOfServiceExpiration7a3 = d.DateOfServiceExpiration7a3,
				NonActivatedMember7a2 = d.NonActivatedMember7a2,
				Retired7a2 = d.Retired7a2,
				ServedInForces7a1 = d.ServedInForces7a1,
				SurvivingSpouse7a21 = d.SurvivingSpouse7a21
			}).FirstOrDefault();
		}

		#endregion
	}
}
