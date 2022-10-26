using Abp.Domain.Repositories;
using LoanManagement.codeFirstEntities;
using LoanManagement.EntityFrameworkCore;
using LoanManagement.Features.AdminLoanDetail;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace LoanManagement.Services.Implementation
{
    public class AdminLoanDetailService : Abp.Application.Services.ApplicationService, IAdminLoanDetailService
    {
        private readonly IRepository<AdminLoandetail, int> repository;

        public AdminLoanDetailService(IRepository<AdminLoandetail,int> repository)
        {
            this.repository = repository;
        }
        public string Add(AddAdminLoanDetail request)
        {
            var entity = new AdminLoandetail
            {
                ApplicationDate = request.ApplicationDate,
                BorrowerName = request.BorrowerName,
                InterestRate = request.InterestRate,
                LoanAmount = request.LoanAmount,
                LoanApplicationId = request.LoanApplicationId,
                LoanNo = request.LoanNo,
                LoanProgramId = request.LoanProgramId,
                LoanPurpose = request.LoanPurpose,
                MortageConsultant = request.MortageConsultant,
                NmlsId = request.NmlsId,
                PropertyAddress = request.PropertyAddress,
                RateLockDate = request.RateLockDate,
                RateLockExpirationDate = request.RateLockExpirationDate,
                //UserId = request.UserId,
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

        public List<UpdateAdminLoanDetail> GetAll()
        {
            return repository.GetAll().Select(d => new UpdateAdminLoanDetail()
            {
                Id = d.Id,
                ApplicationDate = d.ApplicationDate,
                BorrowerName = d.BorrowerName,
                InterestRate = d.InterestRate,
                LoanAmount = d.LoanAmount,
                LoanApplicationId = d.LoanApplicationId,
                LoanNo = d.LoanNo,
                LoanProgramId = d.LoanProgramId,
                LoanPurpose = d.LoanPurpose,
                MortageConsultant = d.MortageConsultant,
                NmlsId = d.NmlsId,
                PropertyAddress = d.PropertyAddress,
                RateLockDate = d.RateLockDate,
                RateLockExpirationDate = d.RateLockExpirationDate,
                //UserId = d.UserId,
            }).ToList();
        }

        public UpdateAdminLoanDetail GetById(int id)
        {
            return repository.GetAll().Where(s => s.Id == id).Select(d => new UpdateAdminLoanDetail()
            {
                Id = d.Id,
                ApplicationDate = d.ApplicationDate,
                BorrowerName = d.BorrowerName,
                InterestRate = d.InterestRate,
                LoanAmount = d.LoanAmount,
                LoanApplicationId = d.LoanApplicationId,
                LoanNo = d.LoanNo,
                LoanProgramId = d.LoanProgramId,
                LoanPurpose = d.LoanPurpose,
                MortageConsultant = d.MortageConsultant,
                NmlsId = d.NmlsId,
                PropertyAddress = d.PropertyAddress,
                RateLockDate = d.RateLockDate,
                RateLockExpirationDate = d.RateLockExpirationDate,
            }).FirstOrDefault();
        }

        public string Update(UpdateAdminLoanDetail request)
        {
            var obj = repository.GetAll().Where(s => s.Id == request.Id).FirstOrDefault();

            if (obj == null)
            {
                return AppConsts.NoRecordFound;
            }

            obj.ApplicationDate = request.ApplicationDate;
            obj.BorrowerName = request.BorrowerName;
            obj.InterestRate = request.InterestRate;
            obj.LoanAmount = request.LoanAmount;
            obj.LoanApplicationId = request.LoanApplicationId;
            obj.LoanNo = request.LoanNo;
            obj.LoanProgramId = request.LoanProgramId;
            obj.LoanPurpose = request.LoanPurpose;
            obj.MortageConsultant = request.MortageConsultant;
            obj.NmlsId = request.NmlsId;
            obj.PropertyAddress = request.PropertyAddress;
            obj.RateLockDate = request.RateLockDate;
            obj.RateLockExpirationDate = request.RateLockExpirationDate;
            //obj.UserId = request.UserId;

            repository.Update(obj);


           UnitOfWorkManager.Current.SaveChanges();

            return AppConsts.SuccessfullyUpdated;
        }
    }
}
