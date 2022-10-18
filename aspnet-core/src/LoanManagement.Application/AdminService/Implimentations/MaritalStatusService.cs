using Microsoft.EntityFrameworkCore;
using LoanManagement.EntityFrameworkCore;
using LoanManagement.Features.MaritalStatus;

using LoanManagement.Services.Interface;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using LoanManagement.codeFirstEntities;
using Abp.Domain.Uow;

namespace LoanManagement.Services.Implementation
{
    public class MaritalStatusService : Abp.Application.Services.ApplicationService, IMaritalStatusService
	{

		private readonly IRepository<MaritialStatus, int> repository;

		public MaritalStatusService(IRepository<MaritialStatus,int> repository)
		{
			this.repository = repository;
		}

		public string AddMaritalStatus(AddMaritalStatusRequest request)
		{
			repository.Insert(new codeFirstEntities.MaritialStatus()
			{
				MaritialStatus1 = request.MaritialStatus1
			});


            UnitOfWorkManager.Current.SaveChanges();
            return AppConsts.SuccessfullyInserted;
		}

		public string UpdateMaritalStatus(UpdateMaritalStatusRequest request)
		{
			var objMaritalStatus = repository.GetAll().Where(s => s.Id == request.Id).FirstOrDefault();

			if (objMaritalStatus == null)
			{
				return AppConsts.NoRecordFound;
			}

			objMaritalStatus.MaritialStatus1 = request.MaritialStatus1;

			repository.Update(objMaritalStatus);

            UnitOfWorkManager.Current.SaveChanges();

            return AppConsts.SuccessfullyUpdated;
		}

		public string DeleteMaritalStatus(int id)
		{
			var objMaritalStatus = repository.GetAll().Where(s => s.Id == id).FirstOrDefault();

			if (objMaritalStatus == null)
			{
				return AppConsts.NoRecordFound;
			}

			repository.Delete(objMaritalStatus);
            UnitOfWorkManager.Current.SaveChanges();

            return AppConsts.SuccessfullyDeleted;
		}

		public List<UpdateMaritalStatusRequest> GetMaritalStatuses()
		{
			return repository.GetAll().Select(d => new UpdateMaritalStatusRequest()
			{
				Id = d.Id,
				MaritialStatus1 = d.MaritialStatus1
			}).ToList();
		}

		public UpdateMaritalStatusRequest GetMaritalStatusById(int id)
		{
			return repository.GetAll().Where(s => s.Id == id).Select(d => new UpdateMaritalStatusRequest()
			{
				Id = d.Id,
				MaritialStatus1 = d.MaritialStatus1
			}).FirstOrDefault();
		}

	}
}
