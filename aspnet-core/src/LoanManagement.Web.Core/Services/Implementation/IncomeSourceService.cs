using Microsoft.EntityFrameworkCore;
using LoanManagement.Entities.Models;
using LoanManagement.Services.Interface;
using LoanManagement.EntityFrameworkCore;
using System.Collections.Generic;
using LoanManagement.Features.IncomeSource;
using System.Linq;

namespace LoanManagement.Services.Implementation
{
	public class IncomeSourceService : IIncomeSourceService
	{
		private readonly MortgagedbContext _dbContext;

		public IncomeSourceService(MortgagedbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public string AddIncomeSource(AddIncomeSourceRequest request)
		{
			_dbContext.IncomeSources.Add(new IncomeSource()
			{
				IncomeSource1 = request.IncomeSource1
			});

			_dbContext.SaveChanges();
			return AppConsts.SuccessfullyInserted;
		}

		public string UpdateIncomeSource(UpdateIncomeSourceRequest request)
		{
			var objIncomeSource = _dbContext.IncomeSources.Where(s => s.Id == request.Id).FirstOrDefault();

			if (objIncomeSource == null)
			{
				return AppConsts.NoRecordFound;
			}

			objIncomeSource.IncomeSource1 = request.IncomeSource1;

			_dbContext.Entry(objIncomeSource).State = EntityState.Modified;
			_dbContext.SaveChanges();

			return AppConsts.SuccessfullyUpdated;
		}

		public string DeleteIncomeSource(int id)
		{
			var objIncomeSource = _dbContext.IncomeSources.Where(s => s.Id == id).FirstOrDefault();

			if (objIncomeSource == null)
			{
				return AppConsts.NoRecordFound;
			}

			_dbContext.IncomeSources.Remove(objIncomeSource);
			_dbContext.SaveChanges();

			return AppConsts.SuccessfullyDeleted;
		}

		public List<UpdateIncomeSourceRequest> GetIncomeSources()
		{
			return _dbContext.IncomeSources.Select(d => new UpdateIncomeSourceRequest()
			{
				Id = d.Id,
				IncomeSource1 = d.IncomeSource1
			}).ToList();
		}

		public UpdateIncomeSourceRequest GetIncomeSourceById(int id)
		{
			return _dbContext.IncomeSources.Where(s => s.Id == id).Select(d => new UpdateIncomeSourceRequest()
			{
				Id = d.Id,
				IncomeSource1 = d.IncomeSource1
			}).FirstOrDefault();
		}
	}
}
