using Microsoft.EntityFrameworkCore;
using LoanManagement.EntityFrameworkCore;
using LoanManagement.Features.CitizenshipType;
using LoanManagement.Services.Interface;
using System.Collections.Generic;
using System.Linq;
using LoanManagement.codeFirstEntities;
using Abp.Domain.Repositories;

namespace LoanManagement.Services.Implementation
{
    public class CitizenshipTypeService: Abp.Application.Services.ApplicationService, ICitizenshipTypeService
	{
		private readonly IRepository<CitizenshipType> repository;

		public CitizenshipTypeService(IRepository<CitizenshipType>repository)
		{
			
			this.repository = repository;
		}

		public string AddCitizenshipType(AddCitizenshipTypeRequest request)
		{
			repository.Insert(new CitizenshipType()
			{
				CitizenshipType1 = request.CitizenshipType1
			});

            UnitOfWorkManager.Current.SaveChanges();
            return AppConsts.SuccessfullyInserted;
		}

		public string UpdateCitizenshipType(UpdateCitizenshipTypeRequest request)
		{
			var objCitizenshipType = repository.GetAll().Where(s => s.Id == request.Id).FirstOrDefault();

			if (objCitizenshipType == null)
			{
				return AppConsts.NoRecordFound;
			}

			objCitizenshipType.CitizenshipType1 = request.CitizenshipType1;

			repository.Update(objCitizenshipType);
            UnitOfWorkManager.Current.SaveChanges();

            return AppConsts.SuccessfullyUpdated;
		}

		public string DeleteCitizenshipType(int id)
		{
			var objCitizenshipType = repository.GetAll().Where(s => s.Id == id).FirstOrDefault();

			if (objCitizenshipType == null)
			{
				return AppConsts.NoRecordFound;
			}

			repository.Delete(objCitizenshipType);
            UnitOfWorkManager.Current.SaveChanges();

            return AppConsts.SuccessfullyDeleted;
		}

		public List<UpdateCitizenshipTypeRequest> GetCitizenshipTypes()
		{
			return repository.GetAll().Select(d => new UpdateCitizenshipTypeRequest()
			{
				Id = d.Id,
				CitizenshipType1 = d.CitizenshipType1
			}).ToList();
		}

		public UpdateCitizenshipTypeRequest GetCitizenshipTypeById(int id)
		{
			return repository.GetAll().Where(s => s.Id == id).Select(d => new UpdateCitizenshipTypeRequest()
			{
				Id = d.Id,
				CitizenshipType1 = d.CitizenshipType1
			}).FirstOrDefault();
		}
	}
}
