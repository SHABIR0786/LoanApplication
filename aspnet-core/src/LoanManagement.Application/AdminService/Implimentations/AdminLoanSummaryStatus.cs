using Abp.Domain.Repositories;
using LoanManagement.codeFirstEntities;
using LoanManagement.EntityFrameworkCore;
using LoanManagement.Features.AdminLoanSummaryStatus;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace LoanManagement.Services.Implementation
{
    public class AdminLoanSummaryStatusService : Abp.Application.Services.ApplicationService, IAdminLoanSummaryStatusService
    {
        private readonly IRepository<AdminLoansummarystatus, int> repository;

        public AdminLoanSummaryStatusService(IRepository<AdminLoansummarystatus,int> repository)
        {
            this.repository = repository;
        }
        public string Add(AddAdminLoanSummaryStatus request)
        {
            var entity = new AdminLoansummarystatus
            {
                StatusId = request.StatusId,
                LoanId = request.LoanId,
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

        public List<UpdateAdminLoanSummaryStatus> GetAll()
        {
            return repository.GetAll().Select(d => new UpdateAdminLoanSummaryStatus()
            {
                Id = d.Id,
                StatusId = d.StatusId,
                LoanId = d.LoanId,
            }).ToList();
        }

        public UpdateAdminLoanSummaryStatus GetById(int id)
        {
            return repository.GetAll().Where(s => s.Id == id).Select(d => new UpdateAdminLoanSummaryStatus()
            {
                Id = d.Id,
                StatusId = d.StatusId,
                LoanId = d.LoanId,
            }).FirstOrDefault();
        }

        public string Update(UpdateAdminLoanSummaryStatus request)
        {
            var obj = repository.GetAll().Where(s => s.Id == request.Id).FirstOrDefault();

            if (obj == null)
            {
                return AppConsts.NoRecordFound;
            }

            obj.StatusId = request.StatusId;
            obj.LoanId = request.LoanId;
            obj.UpdatedOn = System.DateTime.Now;

            repository.Update(obj);
            UnitOfWorkManager.Current.SaveChanges();

            return AppConsts.SuccessfullyUpdated;
        }
    }
}
