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

namespace LoanManagement.Services.Implementation
{
	public class FinancialService : IFinancialService
	{
		private readonly LoanManagementDbContext _dbContext;

		public FinancialService(LoanManagementDbContext dbContext)
		{
			_dbContext = dbContext;
		}

        #region Peroperty Status
        public string AddFinancialPropertyStatus(AddPropertyStatusRequest request)
		{
			_dbContext.FinancialPropertyStatuses.Add(new codeFirstEntities.FinancialPropertyStatus()
			{
				FinancialPropertyStatus1 = request.FinancialPropertyStatus1
			});

			_dbContext.SaveChanges();
			return AppConsts.SuccessfullyInserted;
		}

		public string UpdateFinancialPropertyStatus(UpdatePropertyStatusRequest request)
		{
			var objFinancialPropertyStatus = _dbContext.FinancialPropertyStatuses.Where(s => s.Id == request.Id).FirstOrDefault();

			if (objFinancialPropertyStatus == null)
			{
				return AppConsts.NoRecordFound;
			}

			objFinancialPropertyStatus.FinancialPropertyStatus1 = request.FinancialPropertyStatus1;

			_dbContext.Entry(objFinancialPropertyStatus).State = EntityState.Modified;
			_dbContext.SaveChanges();

			return AppConsts.SuccessfullyUpdated;
		}

		public string DeleteFinancialPropertyStatus(int id)
		{
			var objFinancialPropertyStatus = _dbContext.FinancialPropertyStatuses.Where(s => s.Id == id).FirstOrDefault();

			if (objFinancialPropertyStatus == null)
			{
				return AppConsts.NoRecordFound;
			}

			_dbContext.FinancialPropertyStatuses.Remove(objFinancialPropertyStatus);
			_dbContext.SaveChanges();

			return AppConsts.SuccessfullyDeleted;
		}

		public List<UpdatePropertyStatusRequest> GetFinancialPropertyStatuses()
		{
			return _dbContext.FinancialPropertyStatuses.Select(d => new UpdatePropertyStatusRequest()
			{
				Id = d.Id,
				FinancialPropertyStatus1 = d.FinancialPropertyStatus1
			}).ToList();
		}

		public UpdatePropertyStatusRequest GetFinancialPropertyStatusById(int id)
		{
			return _dbContext.FinancialPropertyStatuses.Where(s => s.Id == id).Select(d => new UpdatePropertyStatusRequest()
			{
				Id = d.Id,
				FinancialPropertyStatus1 = d.FinancialPropertyStatus1
			}).FirstOrDefault();
		}

        #endregion

        #region Property Intended Occupency

        public string AddFinancialPropertyIntendedOccupancy(AddPropertyIntendedOccupancyRequest request)
		{
			_dbContext.FinancialPropertyIntendedOccupancies.Add(new codeFirstEntities.FinancialPropertyIntendedOccupancy()
			{
				FinancialPropertyIntendedOccupancy1 = request.FinancialPropertyIntendedOccupancy1
			});

			_dbContext.SaveChanges();
			return AppConsts.SuccessfullyInserted;
		}

		public string UpdateFinancialPropertyIntendedOccupancy(UpdatePropertyIntendedOccupancyRequest request)
		{
			var objFinancialPropertyIntendedOccupancy = _dbContext.FinancialPropertyIntendedOccupancies.Where(s => s.Id == request.Id).FirstOrDefault();

			if (objFinancialPropertyIntendedOccupancy == null)
			{
				return AppConsts.NoRecordFound;
			}

			objFinancialPropertyIntendedOccupancy.FinancialPropertyIntendedOccupancy1 = request.FinancialPropertyIntendedOccupancy1;

			_dbContext.Entry(objFinancialPropertyIntendedOccupancy).State = EntityState.Modified;
			_dbContext.SaveChanges();

			return AppConsts.SuccessfullyUpdated;
		}

		public string DeleteFinancialPropertyIntendedOccupancy(int id)
		{
			var objFinancialPropertyIntendedOccupancy = _dbContext.FinancialPropertyIntendedOccupancies.Where(s => s.Id == id).FirstOrDefault();

			if (objFinancialPropertyIntendedOccupancy == null)
			{
				return AppConsts.NoRecordFound;
			}

			_dbContext.FinancialPropertyIntendedOccupancies.Remove(objFinancialPropertyIntendedOccupancy);
			_dbContext.SaveChanges();

			return AppConsts.SuccessfullyDeleted;
		}

		public List<UpdatePropertyIntendedOccupancyRequest> GetFinancialPropertyIntendedOccupancies()
		{
			return _dbContext.FinancialPropertyIntendedOccupancies.Select(d => new UpdatePropertyIntendedOccupancyRequest()
			{
				Id = d.Id,
				FinancialPropertyIntendedOccupancy1 = d.FinancialPropertyIntendedOccupancy1
			}).ToList();
		}

		public UpdatePropertyIntendedOccupancyRequest GetFinancialPropertyIntendedOccupancyById(int id)
		{
			return _dbContext.FinancialPropertyIntendedOccupancies.Where(s => s.Id == id).Select(d => new UpdatePropertyIntendedOccupancyRequest()
			{
				Id = d.Id,
				FinancialPropertyIntendedOccupancy1 = d.FinancialPropertyIntendedOccupancy1
			}).FirstOrDefault();
		}

		#endregion

		#region Other Liabilities Type

		public string AddFinancialOtherLaibilitiesType(AddOtherLaibilitiesTypeRequest request)
		{
			_dbContext.FinancialOtherLaibilitiesTypes.Add(new codeFirstEntities.FinancialOtherLaibilitiesType()
			{
				FinancialOtherLaibilitiesType1 = request.FinancialOtherLaibilitiesType1
			});

			_dbContext.SaveChanges();
			return AppConsts.SuccessfullyInserted;
		}

		public string UpdateFinancialOtherLaibilitiesType(UpdateOtherLaibilitiesTypeRequest request)
		{
			var objFinancialOtherLaibilitiesType = _dbContext.FinancialOtherLaibilitiesTypes.Where(s => s.Id == request.Id).FirstOrDefault();

			if (objFinancialOtherLaibilitiesType == null)
			{
				return AppConsts.NoRecordFound;
			}

			objFinancialOtherLaibilitiesType.FinancialOtherLaibilitiesType1 = request.FinancialOtherLaibilitiesType1;

			_dbContext.Entry(objFinancialOtherLaibilitiesType).State = EntityState.Modified;
			_dbContext.SaveChanges();

			return AppConsts.SuccessfullyUpdated;
		}

		public string DeleteFinancialOtherLaibilitiesType(int id)
		{
			var objFinancialOtherLaibilitiesType = _dbContext.FinancialOtherLaibilitiesTypes.Where(s => s.Id == id).FirstOrDefault();

			if (objFinancialOtherLaibilitiesType == null)
			{
				return AppConsts.NoRecordFound;
			}

			_dbContext.FinancialOtherLaibilitiesTypes.Remove(objFinancialOtherLaibilitiesType);
			_dbContext.SaveChanges();

			return AppConsts.SuccessfullyDeleted;
		}

		public List<UpdateOtherLaibilitiesTypeRequest> GetFinancialOtherLaibilitiesTypes()
		{
			return _dbContext.FinancialOtherLaibilitiesTypes.Select(d => new UpdateOtherLaibilitiesTypeRequest()
			{
				Id = d.Id,
				FinancialOtherLaibilitiesType1 = d.FinancialOtherLaibilitiesType1
			}).ToList();
		}

		public UpdateOtherLaibilitiesTypeRequest GetFinancialOtherLaibilitiesTypeById(int id)
		{
			return _dbContext.FinancialOtherLaibilitiesTypes.Where(s => s.Id == id).Select(d => new UpdateOtherLaibilitiesTypeRequest()
			{
				Id = d.Id,
				FinancialOtherLaibilitiesType1 = d.FinancialOtherLaibilitiesType1
			}).FirstOrDefault();
		}


		#endregion

		#region Liabilities Type

		public string AddFinancialLaibilitiesType(AddLaibilitiesTypeRequest request)
		{
			_dbContext.FinancialLaibilitiesTypes.Add(new codeFirstEntities.FinancialLaibilitiesType()
			{
				FinancialLaibilitiesType1 = request.FinancialLaibilitiesType1
			});

			_dbContext.SaveChanges();
			return AppConsts.SuccessfullyInserted;
		}

		public string UpdateFinancialLaibilitiesType(UpdateLaibilitiesTypeRequest request)
		{
			var objFinancialLaibilitiesType = _dbContext.FinancialLaibilitiesTypes.Where(s => s.Id == request.Id).FirstOrDefault();

			if (objFinancialLaibilitiesType == null)
			{
				return AppConsts.NoRecordFound;
			}

			objFinancialLaibilitiesType.FinancialLaibilitiesType1 = request.FinancialLaibilitiesType1;

			_dbContext.Entry(objFinancialLaibilitiesType).State = EntityState.Modified;
			_dbContext.SaveChanges();

			return AppConsts.SuccessfullyUpdated;
		}

		public string DeleteFinancialLaibilitiesType(int id)
		{
			var objFinancialLaibilitiesType = _dbContext.FinancialLaibilitiesTypes.Where(s => s.Id == id).FirstOrDefault();

			if (objFinancialLaibilitiesType == null)
			{
				return AppConsts.NoRecordFound;
			}

			_dbContext.FinancialLaibilitiesTypes.Remove(objFinancialLaibilitiesType);
			_dbContext.SaveChanges();

			return AppConsts.SuccessfullyDeleted;
		}

		public List<UpdateLaibilitiesTypeRequest> GetFinancialLaibilitiesTypes()
		{
			return _dbContext.FinancialLaibilitiesTypes.Select(d => new UpdateLaibilitiesTypeRequest()
			{
				Id = d.Id,
				FinancialLaibilitiesType1 = d.FinancialLaibilitiesType1
			}).ToList();
		}

		public UpdateLaibilitiesTypeRequest GetFinancialLaibilitiesTypeById(int id)
		{
			return _dbContext.FinancialLaibilitiesTypes.Where(s => s.Id == id).Select(d => new UpdateLaibilitiesTypeRequest()
			{
				Id = d.Id,
				FinancialLaibilitiesType1 = d.FinancialLaibilitiesType1
			}).FirstOrDefault();
		}


		#endregion

		#region Account Type

		public string AddFinancialAccountType(AddAccountTypeRequest request)
		{
			_dbContext.FinancialAccountTypes.Add(new codeFirstEntities.FinancialAccountType()
			{
				FinancialAccountType1 = request.FinancialAccountType1
			});

			_dbContext.SaveChanges();
			return AppConsts.SuccessfullyInserted;
		}

		public string UpdateFinancialAccountType(UpdateAccountTypeRequest request)
		{
			var objFinancialAccountType = _dbContext.FinancialAccountTypes.Where(s => s.Id == request.Id).FirstOrDefault();

			if (objFinancialAccountType == null)
			{
				return AppConsts.NoRecordFound;
			}

			objFinancialAccountType.FinancialAccountType1 = request.FinancialAccountType1;

			_dbContext.Entry(objFinancialAccountType).State = EntityState.Modified;
			_dbContext.SaveChanges();

			return AppConsts.SuccessfullyUpdated;
		}

		public string DeleteFinancialAccountType(int id)
		{
			var objFinancialAccountType = _dbContext.FinancialAccountTypes.Where(s => s.Id == id).FirstOrDefault();

			if (objFinancialAccountType == null)
			{
				return AppConsts.NoRecordFound;
			}

			_dbContext.FinancialAccountTypes.Remove(objFinancialAccountType);
			_dbContext.SaveChanges();

			return AppConsts.SuccessfullyDeleted;
		}

		public List<UpdateAccountTypeRequest> GetFinancialAccountTypes()
		{
			return _dbContext.FinancialAccountTypes.Select(d => new UpdateAccountTypeRequest()
			{
				Id = d.Id,
				FinancialAccountType1 = d.FinancialAccountType1
			}).ToList();
		}

		public UpdateAccountTypeRequest GetFinancialAccountTypeById(int id)
		{
			return _dbContext.FinancialAccountTypes.Where(s => s.Id == id).Select(d => new UpdateAccountTypeRequest()
			{
				Id = d.Id,
				FinancialAccountType1 = d.FinancialAccountType1
			}).FirstOrDefault();
		}

		#endregion
	}
}
