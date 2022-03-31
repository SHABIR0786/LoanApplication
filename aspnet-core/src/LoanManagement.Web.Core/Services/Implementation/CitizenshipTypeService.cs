using Microsoft.EntityFrameworkCore;
using LoanManagement.EntityFrameworkCore;
using LoanManagement.Features.CitizenshipType;
using LoanManagement.Services.Interface;
using LoanManagement.Entities.Models;
using System.Collections.Generic;
using System.Linq;

namespace LoanManagement.Services.Implementation
{
    public class CitizenshipTypeService: ICitizenshipTypeService
	{
		private readonly MortgagedbContext _dbContext;

		public CitizenshipTypeService(MortgagedbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public string AddCitizenshipType(AddCitizenshipTypeRequest request)
		{
			_dbContext.CitizenshipTypes.Add(new CitizenshipType()
			{
				CitizenshipType1 = request.CitizenshipType1
			});

			_dbContext.SaveChanges();
			return AppConsts.SuccessfullyInserted;
		}

		public string UpdateCitizenshipType(UpdateCitizenshipTypeRequest request)
		{
			var objCitizenshipType = _dbContext.CitizenshipTypes.Where(s => s.Id == request.Id).FirstOrDefault();

			if (objCitizenshipType == null)
			{
				return AppConsts.NoRecordFound;
			}

			objCitizenshipType.CitizenshipType1 = request.CitizenshipType1;

			_dbContext.Entry(objCitizenshipType).State = EntityState.Modified;
			_dbContext.SaveChanges();

			return AppConsts.SuccessfullyUpdated;
		}

		public string DeleteCitizenshipType(int id)
		{
			var objCitizenshipType = _dbContext.CitizenshipTypes.Where(s => s.Id == id).FirstOrDefault();

			if (objCitizenshipType == null)
			{
				return AppConsts.NoRecordFound;
			}

			_dbContext.CitizenshipTypes.Remove(objCitizenshipType);
			_dbContext.SaveChanges();

			return AppConsts.SuccessfullyDeleted;
		}

		public List<UpdateCitizenshipTypeRequest> GetCitizenshipTypes()
		{
			return _dbContext.CitizenshipTypes.Select(d => new UpdateCitizenshipTypeRequest()
			{
				Id = d.Id,
				CitizenshipType1 = d.CitizenshipType1
			}).ToList();
		}

		public UpdateCitizenshipTypeRequest GetCitizenshipTypeById(int id)
		{
			return _dbContext.CitizenshipTypes.Where(s => s.Id == id).Select(d => new UpdateCitizenshipTypeRequest()
			{
				Id = d.Id,
				CitizenshipType1 = d.CitizenshipType1
			}).FirstOrDefault();
		}
	}
}
