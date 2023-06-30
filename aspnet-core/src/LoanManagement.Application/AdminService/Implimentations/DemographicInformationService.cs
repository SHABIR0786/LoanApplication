using Microsoft.EntityFrameworkCore;

using LoanManagement.Services.Interface;
using LoanManagement.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using LoanManagement.Features.DemographicInformation;
using Abp.Domain.Repositories;
using LoanManagement.codeFirstEntities;
using Abp.Domain.Uow;

namespace LoanManagement.Services.Implementation
{
	public class DemographicInformationService : Abp.Application.Services.ApplicationService, IDemographicInformationService
	{
		private readonly IRepository<DemographicInfoSource, int> repository;
		private readonly IRepository<DemographicInformation, int> demographicInformationRepo;

		public DemographicInformationService(IRepository<DemographicInfoSource,int> repository,IRepository<DemographicInformation,int> demographicInformationRepo)
		{
			this.repository = repository;
			this.demographicInformationRepo = demographicInformationRepo;
		}

		public string AddDemographicInfoSource(AddDemographicInfoSourceRequest request)
		{
			repository.Insert(new codeFirstEntities.DemographicInfoSource()
			{
				Value = request.Value
			});

            UnitOfWorkManager.Current.SaveChanges();
            return AppConsts.SuccessfullyInserted;
		}

		public string UpdateDemographicInfoSource(UpdateDemographicInfoSourceRequest request)
		{
			var objDemographicInfoSource = repository.GetAll().Where(s => s.Id == request.Id).FirstOrDefault();

			if (objDemographicInfoSource == null)
			{
				return AppConsts.NoRecordFound;
			}

			objDemographicInfoSource.Value = request.Value;

			repository.Update(objDemographicInfoSource);
            UnitOfWorkManager.Current.SaveChanges();

            return AppConsts.SuccessfullyUpdated;
		}

		public string DeleteDemographicInfoSource(int id)
		{
			var objDemographicInfoSource = repository.GetAll().Where(s => s.Id == id).FirstOrDefault();

			if (objDemographicInfoSource == null)
			{
				return AppConsts.NoRecordFound;
			}

			repository.Delete(objDemographicInfoSource);
            UnitOfWorkManager.Current.SaveChanges();

            return AppConsts.SuccessfullyInserted;
		}

		public List<UpdateDemographicInfoSourceRequest> GetDemographicInfoSources()
		{
			return repository.GetAll().Select(d => new UpdateDemographicInfoSourceRequest()
			{
				Id = d.Id,
				Value = d.Value
			}).ToList();
		}

		public UpdateDemographicInfoSourceRequest GetDemographicInfoSourceById(int id)
		{
			return repository.GetAll().Where(s => s.Id == id).Select(d => new UpdateDemographicInfoSourceRequest()
			{
				Id = d.Id,
				Value = d.Value
			}).FirstOrDefault();
		}

		public string AddDemographicInformation(AddDemographicInformationRequest request)
		{
			demographicInformationRepo.Insert(new codeFirstEntities.DemographicInformation()
			{
				DemographicInfoSourceId87 = request.DemographicInfoSourceId87,
				Ethnicity81 = request.Ethnicity81,
				Gender82 = request.Gender82,
				ApplicationPersonalInformationId=request.ApplicationPersonalInformationId,
				IsEthnicityByObservation84 = request.IsEthnicityByObservation84,
				IsGenderByObservation85=request.IsGenderByObservation85,
				IsRaceByObservation86=request.IsRaceByObservation86,
				Race83=request.Race83
			});

            UnitOfWorkManager.Current.SaveChanges();
            return AppConsts.SuccessfullyInserted;
		}

		public string UpdateDemographicInformation(UpdateDemographicInformationRequest request)
		{
			var objDemographicInformation = demographicInformationRepo.GetAll().Where(s => s.Id == request.Id).FirstOrDefault();

			if (objDemographicInformation == null)
			{
				return AppConsts.NoRecordFound;
			}

			objDemographicInformation.DemographicInfoSourceId87 = request.DemographicInfoSourceId87;
			objDemographicInformation.Ethnicity81 = request.Ethnicity81;
			objDemographicInformation.Gender82 = request.Gender82;
			objDemographicInformation.ApplicationPersonalInformationId = request.ApplicationPersonalInformationId;
			objDemographicInformation.IsEthnicityByObservation84 = request.IsEthnicityByObservation84;
			objDemographicInformation.IsGenderByObservation85 = request.IsGenderByObservation85;
			objDemographicInformation.IsRaceByObservation86 = request.IsRaceByObservation86;
			objDemographicInformation.Race83 = request.Race83;

			demographicInformationRepo.Update(objDemographicInformation);
            UnitOfWorkManager.Current.SaveChanges();

            return AppConsts.SuccessfullyUpdated;
		}

		public string DeleteDemographicInformation(int id)
		{
			var objDemographicInformation = demographicInformationRepo.GetAll().Where(s => s.Id == id).FirstOrDefault();

			if (objDemographicInformation == null)
			{
				return AppConsts.NoRecordFound;
			}

			demographicInformationRepo.Update(objDemographicInformation);
            UnitOfWorkManager.Current.SaveChanges();

            return AppConsts.SuccessfullyDeleted;
		}

		public List<UpdateDemographicInformationRequest> GetDemographicInformations()
		{
			return demographicInformationRepo.GetAll().Select(d => new UpdateDemographicInformationRequest()
			{
				Id = d.Id,
				DemographicInfoSourceId87 = d.DemographicInfoSourceId87,
				Ethnicity81 = d.Ethnicity81,
				Gender82 = d.Gender82,
				ApplicationPersonalInformationId = d.ApplicationPersonalInformationId,
				IsEthnicityByObservation84 = d.IsEthnicityByObservation84,
				IsGenderByObservation85 = d.IsGenderByObservation85,
				IsRaceByObservation86 = d.IsRaceByObservation86,
				Race83 = d.Race83
			}).ToList();
		}

		public UpdateDemographicInformationRequest GetDemographicInformationById(int id)
		{
			return demographicInformationRepo.GetAll().Where(s => s.Id == id).Select(d => new UpdateDemographicInformationRequest()
			{
				Id = d.Id,
				DemographicInfoSourceId87 = d.DemographicInfoSourceId87,
				Ethnicity81 = d.Ethnicity81,
				Gender82 = d.Gender82,
				ApplicationPersonalInformationId = d.ApplicationPersonalInformationId,
				IsEthnicityByObservation84 = d.IsEthnicityByObservation84,
				IsGenderByObservation85 = d.IsGenderByObservation85,
				IsRaceByObservation86 = d.IsRaceByObservation86,
				Race83 = d.Race83
			}).FirstOrDefault();
		}
	}
}
