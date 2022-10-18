using Microsoft.EntityFrameworkCore;
using LoanManagement.EntityFrameworkCore;
using LoanManagement.Features.State;

using LoanManagement.Services.Interface;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoanManagement.codeFirstEntities;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;

namespace LoanManagement.Services.Implementation
{
    public class StateService: Abp.Application.Services.ApplicationService, IStateService
	{
		private readonly IRepository<State, int> repository;

		public StateService(IRepository<State,int> repository)
		{
			this.repository = repository;
		}

		public string AddState(AddStateRequest request)
		{
			repository.Insert(new State()
			{
				Name = request.StateName
			});


            UnitOfWorkManager.Current.SaveChanges();
            return AppConsts.SuccessfullyInserted;
		}

		public string UpdateState(UpdateStateRequest request)
		{
			var objState = repository.GetAll().Where(s => s.Id == request.Id).FirstOrDefault();

			if (objState == null)
			{
				return AppConsts.NoRecordFound;
			}

			objState.Name = request.StateName;

			repository.Update(objState);
            UnitOfWorkManager.Current.SaveChanges();

            return AppConsts.SuccessfullyUpdated;
		}

		public string DeleteState(int id)
		{
			var objState = repository.GetAll().Where(s => s.Id == id).FirstOrDefault();

			if (objState == null)
			{
				return AppConsts.NoRecordFound;
			}

			repository.Delete(objState);
            UnitOfWorkManager.Current.SaveChanges();

            return AppConsts.SuccessfullyDeleted;
		}

		public List<UpdateStateRequest> GetStates()
		{
			return repository.GetAll().Select(d => new UpdateStateRequest()
			{
				Id = d.Id,
				StateName = d.Name
			}).ToList();
		}

		public UpdateStateRequest GetStateById(int id)
		{
			return repository.GetAll().Where(s => s.Id == id).Select(d => new UpdateStateRequest()
			{
				Id = d.Id,
				StateName = d.Name
			}).FirstOrDefault();
		}

	}
}
