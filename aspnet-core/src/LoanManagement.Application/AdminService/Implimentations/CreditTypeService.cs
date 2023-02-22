using Microsoft.EntityFrameworkCore;

using LoanManagement.Services.Interface;
using LoanManagement.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using LoanManagement.Features.CreditType;
using Abp.Domain.Repositories;
using LoanManagement.codeFirstEntities;

namespace LoanManagement.Services.Implementation
{
	public class CreditTypeService : Abp.Application.Services.ApplicationService, ICreditTypeService
	{
		private readonly IRepository<CreditType, int> repository;

		public CreditTypeService(IRepository<CreditType,int> repository)
		{
			this.repository = repository;
		}

		public string AddCreditType(AddCreditTypeRequest request)
		{
			repository.Insert(new codeFirstEntities.CreditType()
			{
				CreditType1 = request.CreditType1
			});

            UnitOfWorkManager.Current.SaveChanges();
            return AppConsts.SuccessfullyInserted;
		}

		public string UpdateCreditType(UpdateCreditTypeRequest request)
		{
			var objCreditType = repository.GetAll().Where(s => s.Id == request.Id).FirstOrDefault();

			if (objCreditType == null)
			{
				return AppConsts.NoRecordFound;
			}

			objCreditType.CreditType1 = request.CreditType1;

			repository.Update(objCreditType);
            UnitOfWorkManager.Current.SaveChanges();

            return AppConsts.SuccessfullyUpdated;
		}

		public string DeleteCreditType(int id)
		{
			var objCreditType = repository.GetAll().Where(s => s.Id == id).FirstOrDefault();

			if (objCreditType == null)
			{
				return AppConsts.NoRecordFound;
			}

			repository.Delete(objCreditType);
            UnitOfWorkManager.Current.SaveChanges();

            return AppConsts.SuccessfullyDeleted;
		}

		public List<UpdateCreditTypeRequest> GetCreditTypes()
		{
			return repository.GetAll().Select(d => new UpdateCreditTypeRequest()
			{
				Id = d.Id,
				CreditType1 = d.CreditType1
			}).ToList();
		}

		public UpdateCreditTypeRequest GetCreditTypeById(int id)
		{
			return repository.GetAll().Where(s => s.Id == id).Select(d => new UpdateCreditTypeRequest()
			{
				Id = d.Id,
				CreditType1 = d.CreditType1
			}).FirstOrDefault();
		}
	}
}
