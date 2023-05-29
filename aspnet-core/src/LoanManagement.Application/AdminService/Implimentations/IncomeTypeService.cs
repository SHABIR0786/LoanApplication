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
using Abp.Domain.Repositories;
using LoanManagement.codeFirstEntities;

namespace LoanManagement.Services.Implementation
{

	public class IncomeTypeService : Abp.Application.Services.ApplicationService, IIncomeTypeService
	{
		private readonly IRepository<IncomeType, int> repository;

		public IncomeTypeService(IRepository<IncomeType,int> repository)
		{
			this.repository = repository;
		}

		public string AddIncomeType(AddIncomeTypeRequest request)
		{
			repository.Insert(new codeFirstEntities.IncomeType()
			{
				IncomeType1 = request.IncomeType1
			});

            UnitOfWorkManager.Current.SaveChanges();
            return AppConsts.SuccessfullyInserted;
		}

		public string UpdateIncomeType(UpdateIncomeTypeRequest request)
		{
			var objIncomeType = repository.GetAll().Where(s => s.Id == request.Id).FirstOrDefault();

			if (objIncomeType == null)
			{
				return AppConsts.NoRecordFound;
			}

			objIncomeType.IncomeType1 = request.IncomeType1;

			repository.Update(objIncomeType);
            UnitOfWorkManager.Current.SaveChanges();

            return AppConsts.SuccessfullyUpdated;
		}

		public string DeleteIncomeType(int id)
		{
			var objIncomeType = repository.GetAll().Where(s => s.Id == id).FirstOrDefault();

			if (objIncomeType == null)
			{
				return AppConsts.NoRecordFound;
			}

			repository.Delete(objIncomeType);
            UnitOfWorkManager.Current.SaveChanges();

            return AppConsts.SuccessfullyDeleted;
		}

		public List<UpdateIncomeTypeRequest> GetIncomeTypes()
		{
			return repository.GetAll().Select(d => new UpdateIncomeTypeRequest()
			{
				Id = d.Id,
				IncomeType1 = d.IncomeType1
			}).ToList();
		}

		public UpdateIncomeTypeRequest GetIncomeTypeById(int id)
		{
			return repository.GetAll().Where(s => s.Id == id).Select(d => new UpdateIncomeTypeRequest()
			{
				Id = d.Id,
				IncomeType1 = d.IncomeType1
			}).FirstOrDefault();
		}
	}
}
