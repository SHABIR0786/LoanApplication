using Microsoft.EntityFrameworkCore;
using LoanManagement.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using LoanManagement.Services.Interface;

using System;
using LoanManagement.Features.HousingType;
using Abp.Domain.Repositories;
using LoanManagement.codeFirstEntities;
using Abp.Domain.Uow;

namespace LoanManagement.Services.Implementation
{
	public class HousingTypeService: Abp.Application.Services.ApplicationService, IHousingTypeService
	{
		private readonly IRepository<HousingType, int> repository;

		public HousingTypeService(IRepository<HousingType,int> repository)
		{
			this.repository = repository;
		}

		public string AddHousingType(AddHousingTypeRequest request)
		{
			repository.Insert(new codeFirstEntities.HousingType()
			{
				HousingType1 = request.HousingType1
			});

            UnitOfWorkManager.Current.SaveChanges();
            return AppConsts.SuccessfullyInserted;
		}

		public string UpdateHousingType(UpdateHousingTypeRequest request)
		{
			var objHousingType = repository.GetAll().Where(s => s.Id == request.Id).FirstOrDefault();

			if (objHousingType == null)
			{
				return AppConsts.NoRecordFound;
			}

			objHousingType.HousingType1 = request.HousingType1;

			repository.Update(objHousingType);
            UnitOfWorkManager.Current.SaveChanges();

            return AppConsts.SuccessfullyUpdated;
		}

		public string DeleteHousingType(int id)
		{
			var objHousingType = repository.GetAll().Where(s => s.Id == id).FirstOrDefault();

			if (objHousingType == null)
			{
				return AppConsts.NoRecordFound;
			}

			repository.Delete(objHousingType);
            UnitOfWorkManager.Current.SaveChanges();

            return AppConsts.SuccessfullyDeleted;
		}

		public List<UpdateHousingTypeRequest> GetHousingTypes()
		{
			return repository.GetAll().Select(d => new UpdateHousingTypeRequest()
			{
				Id = d.Id,
				HousingType1 = d.HousingType1
			}).ToList();
		}

		public UpdateHousingTypeRequest GetHousingTypeById(int id)
		{
			return repository.GetAll().Where(s => s.Id == id).Select(d => new UpdateHousingTypeRequest()
			{
				Id = d.Id,
				HousingType1 = d.HousingType1
			}).FirstOrDefault();
		}
	}
}
