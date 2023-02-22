using Microsoft.EntityFrameworkCore;
using LoanManagement.EntityFrameworkCore;
using LoanManagement.Features.City;

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
	public class CityService : Abp.Application.Services.ApplicationService, ICityService
	{
		private readonly IRepository<City, int> repository;

		public CityService(IRepository<City,int> repository)
		{
			
			this.repository = repository;
		}

		public string AddCity(AddCityRequest request)
		{
			repository.Insert(new codeFirstEntities.City()
			{
				StateId = request.StateId,
				CityName = request.CityName
			});

            UnitOfWorkManager.Current.SaveChanges();
            return AppConsts.SuccessfullyInserted;
		}

		public string UpdateCity(UpdateCityRequest request)
		{
			var objCity = repository.GetAll().Where(s => s.Id == request.Id).FirstOrDefault();

			if (objCity == null)
			{
				return AppConsts.NoRecordFound;
			}

			objCity.StateId = request.StateId;
			objCity.CityName = request.CityName;

			repository.Update(objCity);
            UnitOfWorkManager.Current.SaveChanges();

            return AppConsts.SuccessfullyUpdated;
		}

		public string DeleteCity(int id)
		{
			var objCity = repository.GetAll().Where(s => s.Id == id).FirstOrDefault();

			if (objCity == null)
			{
				return AppConsts.NoRecordFound;
			}

			repository.Delete(objCity);
            UnitOfWorkManager.Current.SaveChanges();

            return AppConsts.SuccessfullyDeleted;
		}

		public List<UpdateCityRequest> GetCities()
		{
			return repository.GetAll().Select(d => new UpdateCityRequest()
			{
				Id = d.Id,
				StateId = d.StateId,
				CityName = d.CityName
			}).ToList();
		}

		public UpdateCityRequest GetCityById(int id)
		{
			return repository.GetAll().Where(s => s.Id == id).Select(d => new UpdateCityRequest()
			{
				Id = d.Id,
				StateId = d.StateId,
				CityName = d.CityName
			}).FirstOrDefault();
		}
	}
}
