using Microsoft.EntityFrameworkCore;
using LoanManagement.EntityFrameworkCore;
using LoanManagement.Features.Country;

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
	public class CountryService : Abp.Application.Services.ApplicationService, ICountryService
	{
		private readonly IRepository<Country, int> repository;



		public CountryService(IRepository<Country,int>repository)
		{
			
			this.repository = repository;
		}

		public string AddCountry(AddCountryRequest request)
		{
			repository.Insert(new codeFirstEntities.Country()
			{
				CountryName = request.CountryName
			});

            UnitOfWorkManager.Current.SaveChanges();
            return AppConsts.SuccessfullyInserted;
		}

		public string UpdateCountry(UpdateCountryRequest request)
		{
			var objCountry = repository.GetAll().Where(s => s.Id == request.Id).FirstOrDefault();

			if (objCountry == null)
			{
				return AppConsts.NoRecordFound;
			}

			objCountry.CountryName = request.CountryName;

			repository.Update(objCountry);
            UnitOfWorkManager.Current.SaveChanges();

            return AppConsts.SuccessfullyUpdated;
		}

		public string DeleteCountry(int id)
		{
			var objCountry = repository.GetAll().Where(s => s.Id == id).FirstOrDefault();

			if (objCountry == null)
			{
				return AppConsts.NoRecordFound;
			}

			repository.Delete(objCountry);
            UnitOfWorkManager.Current.SaveChanges();

            return AppConsts.SuccessfullyDeleted;
		}

		public List<UpdateCountryRequest> GetCountries()
		{
			return repository.GetAll().Select(d => new UpdateCountryRequest()
			{
				Id = d.Id,
				CountryName = d.CountryName
			}).ToList();
		}

		public UpdateCountryRequest GetCountryById(int id)
		{
			return repository.GetAll().Where(s => s.Id == id).Select(d => new UpdateCountryRequest()
			{
				Id = d.Id,
				CountryName = d.CountryName
			}).FirstOrDefault();
		}
	}
}
