using Microsoft.EntityFrameworkCore;
using LoanManagement.EntityFrameworkCore;
using LoanManagement.Features.MaritalStatus;

using LoanManagement.Services.Interface;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.Services.Implementation
{
    public class MaritalStatusService : IMaritalStatusService
	{
		private readonly LoanManagementDbContext _dbContext;

		public MaritalStatusService(LoanManagementDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public string AddMaritalStatus(AddMaritalStatusRequest request)
		{
			_dbContext.MaritialStatuses.Add(new codeFirstEntities.MaritialStatus()
			{
				MaritialStatus1 = request.MaritialStatus1
			});

			_dbContext.SaveChanges();
			return AppConsts.SuccessfullyInserted;
		}

		public string UpdateMaritalStatus(UpdateMaritalStatusRequest request)
		{
			var objMaritalStatus = _dbContext.MaritialStatuses.Where(s => s.Id == request.Id).FirstOrDefault();

			if (objMaritalStatus == null)
			{
				return AppConsts.NoRecordFound;
			}

			objMaritalStatus.MaritialStatus1 = request.MaritialStatus1;

			_dbContext.Entry(objMaritalStatus).State = EntityState.Modified;
			_dbContext.SaveChanges();

			return AppConsts.SuccessfullyUpdated;
		}

		public string DeleteMaritalStatus(int id)
		{
			var objMaritalStatus = _dbContext.MaritialStatuses.Where(s => s.Id == id).FirstOrDefault();

			if (objMaritalStatus == null)
			{
				return AppConsts.NoRecordFound;
			}

			_dbContext.MaritialStatuses.Remove(objMaritalStatus);
			_dbContext.SaveChanges();

			return AppConsts.SuccessfullyDeleted;
		}

		public List<UpdateMaritalStatusRequest> GetMaritalStatuses()
		{
			return _dbContext.MaritialStatuses.Select(d => new UpdateMaritalStatusRequest()
			{
				Id = d.Id,
				MaritialStatus1 = d.MaritialStatus1
			}).ToList();
		}

		public UpdateMaritalStatusRequest GetMaritalStatusById(int id)
		{
			return _dbContext.MaritialStatuses.Where(s => s.Id == id).Select(d => new UpdateMaritalStatusRequest()
			{
				Id = d.Id,
				MaritialStatus1 = d.MaritialStatus1
			}).FirstOrDefault();
		}

	}
}
