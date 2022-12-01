using Microsoft.EntityFrameworkCore;

using LoanManagement.Services.Interface;
using LoanManagement.EntityFrameworkCore;
using System.Collections.Generic;
using LoanManagement.Features.IncomeSource;
using System.Linq;
using Abp.Domain.Repositories;
using LoanManagement.codeFirstEntities;

namespace LoanManagement.Services.Implementation
{
	public class IncomeSourceService : Abp.Application.Services.ApplicationService, IIncomeSourceService
	{
		private readonly IRepository<IncomeSource, int> repository;

		public IncomeSourceService(IRepository<IncomeSource,int> repository)
		{
			this.repository = repository;
		}

		public string AddIncomeSource(AddIncomeSourceRequest request)
		{
			repository.Insert(new codeFirstEntities.IncomeSource()
			{
				IncomeSource1 = request.IncomeSource1
			});

            UnitOfWorkManager.Current.SaveChanges();
            return AppConsts.SuccessfullyInserted;
		}

		public string UpdateIncomeSource(UpdateIncomeSourceRequest request)
		{
			var objIncomeSource = repository.GetAll().Where(s => s.Id == request.Id).FirstOrDefault();

			if (objIncomeSource == null)
			{
				return AppConsts.NoRecordFound;
			}

			objIncomeSource.IncomeSource1 = request.IncomeSource1;

			repository.Update(objIncomeSource);
            UnitOfWorkManager.Current.SaveChanges();

            return AppConsts.SuccessfullyUpdated;
		}

		public string DeleteIncomeSource(int id)
		{
			var objIncomeSource = repository.GetAll().Where(s => s.Id == id).FirstOrDefault();

			if (objIncomeSource == null)
			{
				return AppConsts.NoRecordFound;
			}

			repository.Delete(objIncomeSource);
            UnitOfWorkManager.Current.SaveChanges();

            return AppConsts.SuccessfullyDeleted;
		}

		public List<UpdateIncomeSourceRequest> GetIncomeSources()
		{
			return repository.GetAll().Select(d => new UpdateIncomeSourceRequest()
			{
				Id = d.Id,
				IncomeSource1 = d.IncomeSource1
			}).ToList();
		}

		public UpdateIncomeSourceRequest GetIncomeSourceById(int id)
		{
			return repository.GetAll().Where(s => s.Id == id).Select(d => new UpdateIncomeSourceRequest()
			{
				Id = d.Id,
				IncomeSource1 = d.IncomeSource1
			}).FirstOrDefault();
		}
	}
}
