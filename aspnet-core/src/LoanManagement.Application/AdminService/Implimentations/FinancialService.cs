using Microsoft.EntityFrameworkCore;
using LoanManagement.EntityFrameworkCore;
using LoanManagement.Features.Financial.AccountType;
using LoanManagement.Features.Financial.LaibilitiesType;
using LoanManagement.Features.Financial.OtherLaibilitiesType;
using LoanManagement.Features.Financial.PropertyIntendedOccupancy;
using LoanManagement.Features.Financial.PropertyStatus;

using System.Collections.Generic;
using LoanManagement.Services.Interface;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using LoanManagement.codeFirstEntities;

namespace LoanManagement.Services.Implementation
{
	public class FinancialService : Abp.Application.Services.ApplicationService, IFinancialService
	{
		private readonly IRepository<FinancialPropertyStatus, int> financialPropertyStatusRepo;
		private readonly IRepository<FinancialPropertyIntendedOccupancy, int> financialPropertyIntendedOccupancyRepo;
		private readonly IRepository<FinancialOtherLaibilitiesType, int> financialOtherLaibilitiesTypeRepo;
		private readonly IRepository<FinancialLaibilitiesType, int> financialLaibilitiesTypeRepo;
		private readonly IRepository<FinancialAccountType, int> financialAccountTypeRepo;

		public FinancialService(IRepository<FinancialPropertyStatus,int> financialPropertyStatusRepo,
			IRepository<FinancialPropertyIntendedOccupancy,int> financialPropertyIntendedOccupancyRepo,
			IRepository<FinancialOtherLaibilitiesType,int> financialOtherLaibilitiesTypeRepo,
			IRepository<FinancialLaibilitiesType, int> financialLaibilitiesTypeRepo,
			IRepository<FinancialAccountType,int> financialAccountTypeRepo)
		{
			this.financialPropertyStatusRepo = financialPropertyStatusRepo;
			this.financialPropertyIntendedOccupancyRepo = financialPropertyIntendedOccupancyRepo;
			this.financialOtherLaibilitiesTypeRepo = financialOtherLaibilitiesTypeRepo;
			this.financialLaibilitiesTypeRepo = financialLaibilitiesTypeRepo;
			this.financialAccountTypeRepo = financialAccountTypeRepo;
		}

        #region Peroperty Status
        public string AddFinancialPropertyStatus(AddPropertyStatusRequest request)
		{
			financialPropertyStatusRepo.Insert(new codeFirstEntities.FinancialPropertyStatus()
			{
				FinancialPropertyStatus1 = request.FinancialPropertyStatus1
			});

            UnitOfWorkManager.Current.SaveChanges();
            return AppConsts.SuccessfullyInserted;
		}

		public string UpdateFinancialPropertyStatus(UpdatePropertyStatusRequest request)
		{
			var objFinancialPropertyStatus = financialPropertyStatusRepo.GetAll().Where(s => s.Id == request.Id).FirstOrDefault();

			if (objFinancialPropertyStatus == null)
			{
				return AppConsts.NoRecordFound;
			}

			objFinancialPropertyStatus.FinancialPropertyStatus1 = request.FinancialPropertyStatus1;

			financialPropertyStatusRepo.Update(objFinancialPropertyStatus);
            UnitOfWorkManager.Current.SaveChanges();

            return AppConsts.SuccessfullyUpdated;
		}

		public string DeleteFinancialPropertyStatus(int id)
		{
			var objFinancialPropertyStatus = financialPropertyStatusRepo.GetAll().Where(s => s.Id == id).FirstOrDefault();

			if (objFinancialPropertyStatus == null)
			{
				return AppConsts.NoRecordFound;
			}

			financialPropertyStatusRepo.Delete(objFinancialPropertyStatus);
            UnitOfWorkManager.Current.SaveChanges();

            return AppConsts.SuccessfullyDeleted;
		}

		public List<UpdatePropertyStatusRequest> GetFinancialPropertyStatuses()
		{
			return financialPropertyStatusRepo.GetAll().Select(d => new UpdatePropertyStatusRequest()
			{
				Id = d.Id,
				FinancialPropertyStatus1 = d.FinancialPropertyStatus1
			}).ToList();
		}

		public UpdatePropertyStatusRequest GetFinancialPropertyStatusById(int id)
		{
			return financialPropertyStatusRepo.GetAll().Where(s => s.Id == id).Select(d => new UpdatePropertyStatusRequest()
			{
				Id = d.Id,
				FinancialPropertyStatus1 = d.FinancialPropertyStatus1
			}).FirstOrDefault();
		}

        #endregion

        #region Property Intended Occupency

        public string AddFinancialPropertyIntendedOccupancy(AddPropertyIntendedOccupancyRequest request)
		{
            financialPropertyIntendedOccupancyRepo.Insert(new codeFirstEntities.FinancialPropertyIntendedOccupancy()
			{
				FinancialPropertyIntendedOccupancy1 = request.FinancialPropertyIntendedOccupancy1
			});

            UnitOfWorkManager.Current.SaveChanges();
            return AppConsts.SuccessfullyInserted;
		}

		public string UpdateFinancialPropertyIntendedOccupancy(UpdatePropertyIntendedOccupancyRequest request)
		{
			var objFinancialPropertyIntendedOccupancy = financialPropertyIntendedOccupancyRepo.GetAll().Where(s => s.Id == request.Id).FirstOrDefault();

			if (objFinancialPropertyIntendedOccupancy == null)
			{
				return AppConsts.NoRecordFound;
			}

			objFinancialPropertyIntendedOccupancy.FinancialPropertyIntendedOccupancy1 = request.FinancialPropertyIntendedOccupancy1;

            financialPropertyIntendedOccupancyRepo.Update(objFinancialPropertyIntendedOccupancy);

            UnitOfWorkManager.Current.SaveChanges();

            return AppConsts.SuccessfullyUpdated;
		}

		public string DeleteFinancialPropertyIntendedOccupancy(int id)
		{
			var objFinancialPropertyIntendedOccupancy = financialPropertyIntendedOccupancyRepo.GetAll().Where(s => s.Id == id).FirstOrDefault();

			if (objFinancialPropertyIntendedOccupancy == null)
			{
				return AppConsts.NoRecordFound;
			}

            financialPropertyIntendedOccupancyRepo.Delete(objFinancialPropertyIntendedOccupancy);
            UnitOfWorkManager.Current.SaveChanges();

            return AppConsts.SuccessfullyDeleted;
		}

		public List<UpdatePropertyIntendedOccupancyRequest> GetFinancialPropertyIntendedOccupancies()
		{
			return financialPropertyIntendedOccupancyRepo.GetAll().Select(d => new UpdatePropertyIntendedOccupancyRequest()
			{
				Id = d.Id,
				FinancialPropertyIntendedOccupancy1 = d.FinancialPropertyIntendedOccupancy1
			}).ToList();
		}

		public UpdatePropertyIntendedOccupancyRequest GetFinancialPropertyIntendedOccupancyById(int id)
		{
			return financialPropertyIntendedOccupancyRepo.GetAll().Where(s => s.Id == id).Select(d => new UpdatePropertyIntendedOccupancyRequest()
			{
				Id = d.Id,
				FinancialPropertyIntendedOccupancy1 = d.FinancialPropertyIntendedOccupancy1
			}).FirstOrDefault();
		}

		#endregion

		#region Other Liabilities Type

		public string AddFinancialOtherLaibilitiesType(AddOtherLaibilitiesTypeRequest request)
		{
            financialOtherLaibilitiesTypeRepo.Insert(new codeFirstEntities.FinancialOtherLaibilitiesType()
			{
				FinancialOtherLaibilitiesType1 = request.FinancialOtherLaibilitiesType1
			});

            UnitOfWorkManager.Current.SaveChanges();
            return AppConsts.SuccessfullyInserted;
		}

		public string UpdateFinancialOtherLaibilitiesType(UpdateOtherLaibilitiesTypeRequest request)
		{
			var objFinancialOtherLaibilitiesType = financialOtherLaibilitiesTypeRepo.GetAll().Where(s => s.Id == request.Id).FirstOrDefault();

			if (objFinancialOtherLaibilitiesType == null)
			{
				return AppConsts.NoRecordFound;
			}

			objFinancialOtherLaibilitiesType.FinancialOtherLaibilitiesType1 = request.FinancialOtherLaibilitiesType1;

            financialOtherLaibilitiesTypeRepo.Update(objFinancialOtherLaibilitiesType);

            UnitOfWorkManager.Current.SaveChanges();

            return AppConsts.SuccessfullyUpdated;
		}

		public string DeleteFinancialOtherLaibilitiesType(int id)
		{
			var objFinancialOtherLaibilitiesType = financialOtherLaibilitiesTypeRepo.GetAll().Where(s => s.Id == id).FirstOrDefault();

			if (objFinancialOtherLaibilitiesType == null)
			{
				return AppConsts.NoRecordFound;
			}

            financialOtherLaibilitiesTypeRepo.Delete(objFinancialOtherLaibilitiesType);
            UnitOfWorkManager.Current.SaveChanges();

            return AppConsts.SuccessfullyDeleted;
		}

		public List<UpdateOtherLaibilitiesTypeRequest> GetFinancialOtherLaibilitiesTypes()
		{
			return financialOtherLaibilitiesTypeRepo.GetAll().Select(d => new UpdateOtherLaibilitiesTypeRequest()
			{
				Id = d.Id,
				FinancialOtherLaibilitiesType1 = d.FinancialOtherLaibilitiesType1
			}).ToList();
		}

		public UpdateOtherLaibilitiesTypeRequest GetFinancialOtherLaibilitiesTypeById(int id)
		{
			return financialOtherLaibilitiesTypeRepo.GetAll().Where(s => s.Id == id).Select(d => new UpdateOtherLaibilitiesTypeRequest()
			{
				Id = d.Id,
				FinancialOtherLaibilitiesType1 = d.FinancialOtherLaibilitiesType1
			}).FirstOrDefault();
		}


		#endregion

		#region Liabilities Type

		public string AddFinancialLaibilitiesType(AddLaibilitiesTypeRequest request)
		{
            financialLaibilitiesTypeRepo.Insert(new codeFirstEntities.FinancialLaibilitiesType()
			{
				FinancialLaibilitiesType1 = request.FinancialLaibilitiesType1
			});

            UnitOfWorkManager.Current.SaveChanges();
            return AppConsts.SuccessfullyInserted;
		}

		public string UpdateFinancialLaibilitiesType(UpdateLaibilitiesTypeRequest request)
		{
			var objFinancialLaibilitiesType = financialLaibilitiesTypeRepo.GetAll().Where(s => s.Id == request.Id).FirstOrDefault();

			if (objFinancialLaibilitiesType == null)
			{
				return AppConsts.NoRecordFound;
			}

			objFinancialLaibilitiesType.FinancialLaibilitiesType1 = request.FinancialLaibilitiesType1;

            financialLaibilitiesTypeRepo.Update(objFinancialLaibilitiesType);

            UnitOfWorkManager.Current.SaveChanges();

            return AppConsts.SuccessfullyUpdated;
		}

		public string DeleteFinancialLaibilitiesType(int id)
		{
			var objFinancialLaibilitiesType = financialLaibilitiesTypeRepo.GetAll().Where(s => s.Id == id).FirstOrDefault();

			if (objFinancialLaibilitiesType == null)
			{
				return AppConsts.NoRecordFound;
			}

            financialLaibilitiesTypeRepo.Delete(objFinancialLaibilitiesType);
            UnitOfWorkManager.Current.SaveChanges();

            return AppConsts.SuccessfullyDeleted;
		}

		public List<UpdateLaibilitiesTypeRequest> GetFinancialLaibilitiesTypes()
		{
			return financialLaibilitiesTypeRepo.GetAll().Select(d => new UpdateLaibilitiesTypeRequest()
			{
				Id = d.Id,
				FinancialLaibilitiesType1 = d.FinancialLaibilitiesType1
			}).ToList();
		}

		public UpdateLaibilitiesTypeRequest GetFinancialLaibilitiesTypeById(int id)
		{
			return financialLaibilitiesTypeRepo.GetAll().Where(s => s.Id == id).Select(d => new UpdateLaibilitiesTypeRequest()
			{
				Id = d.Id,
				FinancialLaibilitiesType1 = d.FinancialLaibilitiesType1
			}).FirstOrDefault();
		}


		#endregion

		#region Account Type

		public string AddFinancialAccountType(AddAccountTypeRequest request)
		{
            financialAccountTypeRepo.Insert(new codeFirstEntities.FinancialAccountType()
			{
				FinancialAccountType1 = request.FinancialAccountType1
			});

            UnitOfWorkManager.Current.SaveChanges();
            return AppConsts.SuccessfullyInserted;
		}

		public string UpdateFinancialAccountType(UpdateAccountTypeRequest request)
		{
			var objFinancialAccountType = financialAccountTypeRepo.GetAll().Where(s => s.Id == request.Id).FirstOrDefault();

			if (objFinancialAccountType == null)
			{
				return AppConsts.NoRecordFound;
			}

			objFinancialAccountType.FinancialAccountType1 = request.FinancialAccountType1;

            financialAccountTypeRepo.Update(objFinancialAccountType);

            UnitOfWorkManager.Current.SaveChanges();

            return AppConsts.SuccessfullyUpdated;
		}

		public string DeleteFinancialAccountType(int id)
		{
			var objFinancialAccountType = financialAccountTypeRepo.GetAll().Where(s => s.Id == id).FirstOrDefault();

			if (objFinancialAccountType == null)
			{
				return AppConsts.NoRecordFound;
			}

            financialAccountTypeRepo.Delete(objFinancialAccountType);
            UnitOfWorkManager.Current.SaveChanges();
            return AppConsts.SuccessfullyDeleted;
		}

		public List<UpdateAccountTypeRequest> GetFinancialAccountTypes()
		{
            return financialAccountTypeRepo.GetAll().Select(d => new UpdateAccountTypeRequest()
			{
				Id = d.Id,
				FinancialAccountType1 = d.FinancialAccountType1
			}).ToList();
		}

		public UpdateAccountTypeRequest GetFinancialAccountTypeById(int id)
		{
			return financialAccountTypeRepo.GetAll().Where(s => s.Id == id).Select(d => new UpdateAccountTypeRequest()
			{
				Id = d.Id,
				FinancialAccountType1 = d.FinancialAccountType1
			}).FirstOrDefault();
		}

		#endregion
	}
}
