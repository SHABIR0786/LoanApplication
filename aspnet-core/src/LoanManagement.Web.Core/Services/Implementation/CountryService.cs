using Microsoft.EntityFrameworkCore;
using LoanManagement.EntityFrameworkCore;
using LoanManagement.Features.Country;

using LoanManagement.Services.Interface;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.Services.Implementation
{
	public class CountryService : ICountryService
	{
		private readonly LoanManagementDbContext _dbContext;

		public CountryService(LoanManagementDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public string AddCountry(AddCountryRequest request)
		{
			_dbContext.Countries.Add(new codeFirstEntities.Country()
			{
				CountryName = request.CountryName
			});

			_dbContext.SaveChanges();
			return AppConsts.SuccessfullyInserted;
		}

		public string UpdateCountry(UpdateCountryRequest request)
		{
			var objCountry = _dbContext.Countries.Where(s => s.Id == request.Id).FirstOrDefault();

			if (objCountry == null)
			{
				return AppConsts.NoRecordFound;
			}

			objCountry.CountryName = request.CountryName;

			_dbContext.Entry(objCountry).State = EntityState.Modified;
			_dbContext.SaveChanges();

			return AppConsts.SuccessfullyUpdated;
		}

		public string DeleteCountry(int id)
		{
			var objCountry = _dbContext.Countries.Where(s => s.Id == id).FirstOrDefault();

			if (objCountry == null)
			{
				return AppConsts.NoRecordFound;
			}

			_dbContext.Countries.Remove(objCountry);
			_dbContext.SaveChanges();

			return AppConsts.SuccessfullyDeleted;
		}

		public List<UpdateCountryRequest> GetCountries()
		{
			return _dbContext.Countries.Select(d => new UpdateCountryRequest()
			{
				Id = d.Id,
				CountryName = d.CountryName
			}).ToList();
		}

		public UpdateCountryRequest GetCountryById(int id)
		{
			return _dbContext.Countries.Where(s => s.Id == id).Select(d => new UpdateCountryRequest()
			{
				Id = d.Id,
				CountryName = d.CountryName
			}).FirstOrDefault();
		}
	}
}
