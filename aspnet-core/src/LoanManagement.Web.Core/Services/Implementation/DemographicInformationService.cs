using Microsoft.EntityFrameworkCore;

using LoanManagement.Services.Interface;
using LoanManagement.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using LoanManagement.Features.DemographicInformation;

namespace LoanManagement.Services.Implementation
{
	public class DemographicInformationService : IDemographicInformationService
	{
		private readonly LoanManagementDbContext _dbContext;

		public DemographicInformationService(LoanManagementDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public string AddDemographicInfoSource(AddDemographicInfoSourceRequest request)
		{
			_dbContext.DemographicInfoSources.Add(new codeFirstEntities.DemographicInfoSource()
			{
				Value = request.Value
			});

			_dbContext.SaveChanges();
			return AppConsts.SuccessfullyInserted;
		}

		public string UpdateDemographicInfoSource(UpdateDemographicInfoSourceRequest request)
		{
			var objDemographicInfoSource = _dbContext.DemographicInfoSources.Where(s => s.Id == request.Id).FirstOrDefault();

			if (objDemographicInfoSource == null)
			{
				return AppConsts.NoRecordFound;
			}

			objDemographicInfoSource.Value = request.Value;

			_dbContext.Entry(objDemographicInfoSource).State = EntityState.Modified;
			_dbContext.SaveChanges();

			return AppConsts.SuccessfullyUpdated;
		}

		public string DeleteDemographicInfoSource(int id)
		{
			var objDemographicInfoSource = _dbContext.DemographicInfoSources.Where(s => s.Id == id).FirstOrDefault();

			if (objDemographicInfoSource == null)
			{
				return AppConsts.NoRecordFound;
			}

			_dbContext.DemographicInfoSources.Remove(objDemographicInfoSource);
			_dbContext.SaveChanges();

			return AppConsts.SuccessfullyInserted;
		}

		public List<UpdateDemographicInfoSourceRequest> GetDemographicInfoSources()
		{
			return _dbContext.DemographicInfoSources.Select(d => new UpdateDemographicInfoSourceRequest()
			{
				Id = d.Id,
				Value = d.Value
			}).ToList();
		}

		public UpdateDemographicInfoSourceRequest GetDemographicInfoSourceById(int id)
		{
			return _dbContext.DemographicInfoSources.Where(s => s.Id == id).Select(d => new UpdateDemographicInfoSourceRequest()
			{
				Id = d.Id,
				Value = d.Value
			}).FirstOrDefault();
		}

		public string AddDemographicInformation(AddDemographicInformationRequest request)
		{
			_dbContext.DemographicInformations.Add(new codeFirstEntities.DemographicInformation()
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

			_dbContext.SaveChanges();
			return AppConsts.SuccessfullyInserted;
		}

		public string UpdateDemographicInformation(UpdateDemographicInformationRequest request)
		{
			var objDemographicInformation = _dbContext.DemographicInformations.Where(s => s.Id == request.Id).FirstOrDefault();

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

			_dbContext.Entry(objDemographicInformation).State = EntityState.Modified;
			_dbContext.SaveChanges();

			return AppConsts.SuccessfullyUpdated;
		}

		public string DeleteDemographicInformation(int id)
		{
			var objDemographicInformation = _dbContext.DemographicInformations.Where(s => s.Id == id).FirstOrDefault();

			if (objDemographicInformation == null)
			{
				return AppConsts.NoRecordFound;
			}

			_dbContext.DemographicInformations.Remove(objDemographicInformation);
			_dbContext.SaveChanges();

			return AppConsts.SuccessfullyDeleted;
		}

		public List<UpdateDemographicInformationRequest> GetDemographicInformations()
		{
			return _dbContext.DemographicInformations.Select(d => new UpdateDemographicInformationRequest()
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
			return _dbContext.DemographicInformations.Where(s => s.Id == id).Select(d => new UpdateDemographicInformationRequest()
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
