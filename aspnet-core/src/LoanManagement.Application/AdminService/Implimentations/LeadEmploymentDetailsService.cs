using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using LoanManagement.codeFirstEntities;
using LoanManagement.EntityFrameworkCore;
using LoanManagement.Features.LeadEmploymentDetails;
using LoanManagement.Services.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.Services.Implementation
{
    public class LeadEmploymentDetailsService : Abp.Application.Services.ApplicationService, ILeadEmployementDetailsService
    {
        private readonly IRepository<LeadEmployementDetail, int> repository;

        public LeadEmploymentDetailsService(IRepository<LeadEmployementDetail,int> repository)
        {
            this.repository = repository;
        }
        public string Add(AddLeadEmploymentDetails request)
        {
            var entity = new LeadEmployementDetail
            {
                EmployeeTypeId = request.EmployeeTypeId,
                EmployementAddress = request.EmployementAddress,
                EmployementCity = request.EmployementCity,
                EmployementSuite = request.EmployementSuite,
                EmployementTaxeId = request.EmployementTaxeId,
                EmployementZip = request.EmployementZip,
                EmployerName = request.EmployerName,
                EmployerPhoneNumber = request.EmployerPhoneNumber,
                EstimatedAnnualBaseSalary = request.EstimatedAnnualBaseSalary,
                EstimatedAnnualBonus = request.EstimatedAnnualBonus,
                EstimatedAnnualCommission = request.EstimatedAnnualCommission,
                EstimatedAnnualOvertime = request.EstimatedAnnualOvertime,
                EstimatedStartDate = request.EstimatedStartDate,
                IsCoBorrower = request.IsCoBorrower,
                IsCurrentJob = request.IsCurrentJob,
                JobTitle = request.JobTitle,
                LeadApplicationDetailPurchasingId = request.LeadApplicationDetailPurchasingId,
                LeadApplicationDetailRefinancingId = request.LeadApplicationDetailRefinancingId,
                LeadApplicationTypeId = request.LeadApplicationTypeId
            };
              repository.Insert(entity);


            UnitOfWorkManager.Current.SaveChanges();
            return entity.Id.ToString();
        }

        public string Delete(int id)
        {

            var obj = repository.GetAll().Where(s => s.Id == id).FirstOrDefault();

            if (obj == null)
            {
                return AppConsts.NoRecordFound;
            }

            repository.Delete(obj);

            UnitOfWorkManager.Current.SaveChanges();

            return AppConsts.SuccessfullyDeleted;
        }

        public List<UpdateLeadEmploymentDetails> GetAll()
        {
            return repository.GetAll().Select(d => new UpdateLeadEmploymentDetails()
            {
                Id = d.Id,
                EmployeeTypeId = d.EmployeeTypeId,
                EmployementAddress = d.EmployementAddress,
                EmployementCity = d.EmployementCity,
                EmployementSuite = d.EmployementSuite,
                EmployementTaxeId = d.EmployementTaxeId,
                EmployementZip = d.EmployementZip,
                EmployerName = d.EmployerName,
                EmployerPhoneNumber = d.EmployerPhoneNumber,
                EstimatedAnnualBaseSalary = d.EstimatedAnnualBaseSalary,
                EstimatedAnnualBonus = d.EstimatedAnnualBonus,
                EstimatedAnnualCommission = d.EstimatedAnnualCommission,
                EstimatedAnnualOvertime = d.EstimatedAnnualOvertime,
                EstimatedStartDate = d.EstimatedStartDate,
                IsCoBorrower = d.IsCoBorrower,
                IsCurrentJob = d.IsCurrentJob,
                JobTitle = d.JobTitle,
                LeadApplicationDetailPurchasingId = d.LeadApplicationDetailPurchasingId,
                LeadApplicationDetailRefinancingId = d.LeadApplicationDetailRefinancingId,
                LeadApplicationTypeId = d.LeadApplicationTypeId
            }).ToList();
        }

        public List<UpdateLeadEmploymentDetails> GetPurchaseEmployementDetails(int id)
        {
            return repository.GetAll().Where(x=>x.LeadApplicationDetailPurchasingId == id).Select(d => new UpdateLeadEmploymentDetails()
            {
                Id = d.Id,
                EmployeeTypeId = d.EmployeeTypeId,
                EmployementAddress = d.EmployementAddress,
                EmployementCity = d.EmployementCity,
                EmployementSuite = d.EmployementSuite,
                EmployementTaxeId = d.EmployementTaxeId,
                EmployementZip = d.EmployementZip,
                EmployerName = d.EmployerName,
                EmployerPhoneNumber = d.EmployerPhoneNumber,
                EstimatedAnnualBaseSalary = d.EstimatedAnnualBaseSalary,
                EstimatedAnnualBonus = d.EstimatedAnnualBonus,
                EstimatedAnnualCommission = d.EstimatedAnnualCommission,
                EstimatedAnnualOvertime = d.EstimatedAnnualOvertime,
                EstimatedStartDate = d.EstimatedStartDate,
                IsCoBorrower = d.IsCoBorrower,
                IsCurrentJob = d.IsCurrentJob,
                JobTitle = d.JobTitle,
                LeadApplicationDetailPurchasingId = d.LeadApplicationDetailPurchasingId,
                LeadApplicationDetailRefinancingId = d.LeadApplicationDetailRefinancingId,
                LeadApplicationTypeId = d.LeadApplicationTypeId
            }).ToList();
        }

        public List<UpdateLeadEmploymentDetails> GetRefinanceEmployementDetails(int id)
        {
            return repository.GetAll().Where(x => x.LeadApplicationDetailRefinancingId == id).Select(d => new UpdateLeadEmploymentDetails()
            {
                Id = d.Id,
                EmployeeTypeId = d.EmployeeTypeId,
                EmployementAddress = d.EmployementAddress,
                EmployementCity = d.EmployementCity,
                EmployementSuite = d.EmployementSuite,
                EmployementTaxeId = d.EmployementTaxeId,
                EmployementZip = d.EmployementZip,
                EmployerName = d.EmployerName,
                EmployerPhoneNumber = d.EmployerPhoneNumber,
                EstimatedAnnualBaseSalary = d.EstimatedAnnualBaseSalary,
                EstimatedAnnualBonus = d.EstimatedAnnualBonus,
                EstimatedAnnualCommission = d.EstimatedAnnualCommission,
                EstimatedAnnualOvertime = d.EstimatedAnnualOvertime,
                EstimatedStartDate = d.EstimatedStartDate,
                IsCoBorrower = d.IsCoBorrower,
                IsCurrentJob = d.IsCurrentJob,
                JobTitle = d.JobTitle,
                LeadApplicationDetailPurchasingId = d.LeadApplicationDetailPurchasingId,
                LeadApplicationDetailRefinancingId = d.LeadApplicationDetailRefinancingId,
                LeadApplicationTypeId = d.LeadApplicationTypeId
            }).ToList();
        }

        public UpdateLeadEmploymentDetails GetById(int id)
        {
            return repository.GetAll().Where(s => s.Id == id).Select(d => new UpdateLeadEmploymentDetails()
            {
                Id = d.Id,
                EmployeeTypeId = d.EmployeeTypeId,
                EmployementAddress = d.EmployementAddress,
                EmployementCity = d.EmployementCity,
                EmployementSuite = d.EmployementSuite,
                EmployementTaxeId = d.EmployementTaxeId,
                EmployementZip = d.EmployementZip,
                EmployerName = d.EmployerName,
                EmployerPhoneNumber = d.EmployerPhoneNumber,
                EstimatedAnnualBaseSalary = d.EstimatedAnnualBaseSalary,
                EstimatedAnnualBonus = d.EstimatedAnnualBonus,
                EstimatedAnnualCommission = d.EstimatedAnnualCommission,
                EstimatedAnnualOvertime = d.EstimatedAnnualOvertime,
                EstimatedStartDate = d.EstimatedStartDate,
                IsCoBorrower = d.IsCoBorrower,
                IsCurrentJob = d.IsCurrentJob,
                JobTitle = d.JobTitle,
                LeadApplicationDetailPurchasingId = d.LeadApplicationDetailPurchasingId,
                LeadApplicationDetailRefinancingId = d.LeadApplicationDetailRefinancingId,
                LeadApplicationTypeId = d.LeadApplicationTypeId
            }).FirstOrDefault();
        }

        public string Update(UpdateLeadEmploymentDetails request)
        {
            var obj = repository.GetAll().Where(s => s.Id == request.Id).FirstOrDefault();

            if (obj == null)
            {
                return AppConsts.NoRecordFound;
            }

            obj.EmployeeTypeId = request.EmployeeTypeId;
            obj.EmployementAddress = request.EmployementAddress;
            obj.EmployementCity = request.EmployementCity;
            obj.EmployementSuite = request.EmployementSuite;
            obj.EmployementTaxeId = request.EmployementTaxeId;
            obj.EmployementZip = request.EmployementZip;
            obj.EmployerName = request.EmployerName;
            obj.EmployerPhoneNumber = request.EmployerPhoneNumber;
            obj.EstimatedAnnualBaseSalary = request.EstimatedAnnualBaseSalary;
            obj.EstimatedAnnualBonus = request.EstimatedAnnualBonus;
            obj.EstimatedAnnualCommission = request.EstimatedAnnualCommission;
            obj.EstimatedAnnualOvertime = request.EstimatedAnnualOvertime;
            obj.EstimatedStartDate = request.EstimatedStartDate;
            obj.IsCoBorrower = request.IsCoBorrower;
            obj.IsCurrentJob = request.IsCurrentJob;
            obj.JobTitle = request.JobTitle;
            obj.LeadApplicationDetailPurchasingId = request.LeadApplicationDetailPurchasingId;
            obj.LeadApplicationDetailRefinancingId = request.LeadApplicationDetailRefinancingId;
            obj.LeadApplicationTypeId = request.LeadApplicationTypeId;

           repository.Update(obj);

            UnitOfWorkManager.Current.SaveChanges();

            return AppConsts.SuccessfullyUpdated;
        }
    }
}
