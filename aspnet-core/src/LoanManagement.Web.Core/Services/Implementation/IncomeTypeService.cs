using Microsoft.EntityFrameworkCore;
using LoanManagement.EntityFrameworkCore;
using LoanManagement.Features.IncomeType;

using System.Collections.Generic;
using LoanManagement.Services.Interface;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.Services.Implementation
{

	public class IncomeTypeService : IIncomeTypeService
	{
		private readonly LoanManagementDbContext _dbContext;

		public IncomeTypeService(LoanManagementDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public string AddIncomeType(AddIncomeTypeRequest request)
		{
			_dbContext.IncomeTypes.Add(new codeFirstEntities.IncomeType()
			{
				IncomeType1 = request.IncomeType1
			});

			_dbContext.SaveChanges();
			return AppConsts.SuccessfullyInserted;
		}

		public string UpdateIncomeType(UpdateIncomeTypeRequest request)
		{
			var objIncomeType = _dbContext.IncomeTypes.Where(s => s.Id == request.Id).FirstOrDefault();

			if (objIncomeType == null)
			{
				return AppConsts.NoRecordFound;
			}

			objIncomeType.IncomeType1 = request.IncomeType1;

			_dbContext.Entry(objIncomeType).State = EntityState.Modified;
			_dbContext.SaveChanges();

			return AppConsts.SuccessfullyUpdated;
		}

		public string DeleteIncomeType(int id)
		{
			var objIncomeType = _dbContext.IncomeTypes.Where(s => s.Id == id).FirstOrDefault();

			if (objIncomeType == null)
			{
				return AppConsts.NoRecordFound;
			}

			_dbContext.IncomeTypes.Remove(objIncomeType);
			_dbContext.SaveChanges();

			return AppConsts.SuccessfullyDeleted;
		}

		public List<UpdateIncomeTypeRequest> GetIncomeTypes()
		{
			return _dbContext.IncomeTypes.Select(d => new UpdateIncomeTypeRequest()
			{
				Id = d.Id,
				IncomeType1 = d.IncomeType1
			}).ToList();
		}

		public UpdateIncomeTypeRequest GetIncomeTypeById(int id)
		{
			return _dbContext.IncomeTypes.Where(s => s.Id == id).Select(d => new UpdateIncomeTypeRequest()
			{
				Id = d.Id,
				IncomeType1 = d.IncomeType1
			}).FirstOrDefault();
		}
	}
}
