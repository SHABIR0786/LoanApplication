using Microsoft.EntityFrameworkCore;
using LoanManagement.EntityFrameworkCore;
using LoanManagement.Features.City;

using LoanManagement.Services.Interface;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.Services.Implementation
{
	public class CityService : ICityService
	{
		private readonly LoanManagementDbContext _dbContext;

		public CityService(LoanManagementDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public string AddCity(AddCityRequest request)
		{
			_dbContext.Cities.Add(new codeFirstEntities.City()
			{
				StateId = request.StateId,
				CityName = request.CityName
			});

			_dbContext.SaveChanges();
			return AppConsts.SuccessfullyInserted;
		}

		public string UpdateCity(UpdateCityRequest request)
		{
			var objCity = _dbContext.Cities.Where(s => s.Id == request.Id).FirstOrDefault();

			if (objCity == null)
			{
				return AppConsts.NoRecordFound;
			}

			objCity.StateId = request.StateId;
			objCity.CityName = request.CityName;

			_dbContext.Entry(objCity).State = EntityState.Modified;
			_dbContext.SaveChanges();

			return AppConsts.SuccessfullyUpdated;
		}

		public string DeleteCity(int id)
		{
			var objCity = _dbContext.Cities.Where(s => s.Id == id).FirstOrDefault();

			if (objCity == null)
			{
				return AppConsts.NoRecordFound;
			}

			_dbContext.Cities.Remove(objCity);
			_dbContext.SaveChanges();

			return AppConsts.SuccessfullyDeleted;
		}

		public List<UpdateCityRequest> GetCities()
		{
			return _dbContext.Cities.Select(d => new UpdateCityRequest()
			{
				Id = d.Id,
				StateId = d.StateId,
				CityName = d.CityName
			}).ToList();
		}

		public UpdateCityRequest GetCityById(int id)
		{
			return _dbContext.Cities.Where(s => s.Id == id).Select(d => new UpdateCityRequest()
			{
				Id = d.Id,
				StateId = d.StateId,
				CityName = d.CityName
			}).FirstOrDefault();
		}
	}
}
