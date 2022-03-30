using Microsoft.EntityFrameworkCore;
using LoanManagement.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using LoanManagement.Services.Interface;
using LoanManagement.Entities.Models;
using System;
using LoanManagement.Features.HousingType;

namespace LoanManagement.Services.Implementation
{
	public class HousingTypeService: IHousingTypeService
	{
		private readonly MortgagedbContext _dbContext;

		public HousingTypeService(MortgagedbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public string AddHousingType(AddHousingTypeRequest request)
		{
			_dbContext.HousingTypes.Add(new HousingType()
			{
				HousingType1 = request.HousingType1
			});

			_dbContext.SaveChanges();
			return AppConsts.SuccessfullyInserted;
		}

		public string UpdateHousingType(UpdateHousingTypeRequest request)
		{
			var objHousingType = _dbContext.HousingTypes.Where(s => s.Id == request.Id).FirstOrDefault();

			if (objHousingType == null)
			{
				return AppConsts.NoRecordFound;
			}

			objHousingType.HousingType1 = request.HousingType1;

			_dbContext.Entry(objHousingType).State = EntityState.Modified;
			_dbContext.SaveChanges();

			return AppConsts.SuccessfullyUpdated;
		}

		public string DeleteHousingType(int id)
		{
			var objHousingType = _dbContext.HousingTypes.Where(s => s.Id == id).FirstOrDefault();

			if (objHousingType == null)
			{
				return AppConsts.NoRecordFound;
			}

			_dbContext.HousingTypes.Remove(objHousingType);
			_dbContext.SaveChanges();

			return AppConsts.SuccessfullyDeleted;
		}

		public List<UpdateHousingTypeRequest> GetHousingTypes()
		{
			return _dbContext.HousingTypes.Select(d => new UpdateHousingTypeRequest()
			{
				Id = d.Id,
				HousingType1 = d.HousingType1
			}).ToList();
		}

		public UpdateHousingTypeRequest GetHousingTypeById(int id)
		{
			return _dbContext.HousingTypes.Where(s => s.Id == id).Select(d => new UpdateHousingTypeRequest()
			{
				Id = d.Id,
				HousingType1 = d.HousingType1
			}).FirstOrDefault();
		}
	}
}
