using Microsoft.EntityFrameworkCore;
using LoanManagement.Entities.Models;
using LoanManagement.Services.Interface;
using LoanManagement.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using LoanManagement.Features.CreditType;

namespace LoanManagement.Services.Implementation
{
	public class CreditTypeService : ICreditTypeService
	{
		private readonly MortgagedbContext _dbContext;

		public CreditTypeService(MortgagedbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public string AddCreditType(AddCreditTypeRequest request)
		{
			_dbContext.CreditTypes.Add(new CreditType()
			{
				CreditType1 = request.CreditType1
			});

			_dbContext.SaveChanges();
			return AppConsts.SuccessfullyInserted;
		}

		public string UpdateCreditType(UpdateCreditTypeRequest request)
		{
			var objCreditType = _dbContext.CreditTypes.Where(s => s.Id == request.Id).FirstOrDefault();

			if (objCreditType == null)
			{
				return AppConsts.NoRecordFound;
			}

			objCreditType.CreditType1 = request.CreditType1;

			_dbContext.Entry(objCreditType).State = EntityState.Modified;
			_dbContext.SaveChanges();

			return AppConsts.SuccessfullyUpdated;
		}

		public string DeleteCreditType(int id)
		{
			var objCreditType = _dbContext.CreditTypes.Where(s => s.Id == id).FirstOrDefault();

			if (objCreditType == null)
			{
				return AppConsts.NoRecordFound;
			}

			_dbContext.CreditTypes.Remove(objCreditType);
			_dbContext.SaveChanges();

			return AppConsts.SuccessfullyDeleted;
		}

		public List<UpdateCreditTypeRequest> GetCreditTypes()
		{
			return _dbContext.CreditTypes.Select(d => new UpdateCreditTypeRequest()
			{
				Id = d.Id,
				CreditType1 = d.CreditType1
			}).ToList();
		}

		public UpdateCreditTypeRequest GetCreditTypeById(int id)
		{
			return _dbContext.CreditTypes.Where(s => s.Id == id).Select(d => new UpdateCreditTypeRequest()
			{
				Id = d.Id,
				CreditType1 = d.CreditType1
			}).FirstOrDefault();
		}
	}
}
