﻿using Microsoft.EntityFrameworkCore;
using LoanManagement.EntityFrameworkCore;
using LoanManagement.Features.State;

using LoanManagement.Services.Interface;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoanManagement.codeFirstEntities;

namespace LoanManagement.Services.Implementation
{
    public class StateService: IStateService
	{
		private readonly LoanManagementDbContext _dbContext;

		public StateService(LoanManagementDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public string AddState(AddStateRequest request)
		{
			_dbContext.States.Add(new State()
			{
				Name = request.StateName
			});


			_dbContext.SaveChanges();
			return AppConsts.SuccessfullyInserted;
		}

		public string UpdateState(UpdateStateRequest request)
		{
			var objState = _dbContext.States.Where(s => s.Id == request.Id).FirstOrDefault();

			if (objState == null)
			{
				return AppConsts.NoRecordFound;
			}

			objState.Name = request.StateName;

			_dbContext.Entry(objState).State = EntityState.Modified;
			_dbContext.SaveChanges();

			return AppConsts.SuccessfullyUpdated;
		}

		public string DeleteState(int id)
		{
			var objState = _dbContext.States.Where(s => s.Id == id).FirstOrDefault();

			if (objState == null)
			{
				return AppConsts.NoRecordFound;
			}

			_dbContext.States.Remove(objState);
			_dbContext.SaveChanges();

			return AppConsts.SuccessfullyDeleted;
		}

		public List<UpdateStateRequest> GetStates()
		{
			return _dbContext.States.Select(d => new UpdateStateRequest()
			{
				Id = d.Id,
				StateName = d.Name
			}).ToList();
		}

		public UpdateStateRequest GetStateById(int id)
		{
			return _dbContext.States.Where(s => s.Id == id).Select(d => new UpdateStateRequest()
			{
				Id = d.Id,
				StateName = d.Name
			}).FirstOrDefault();
		}

	}
}
