using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.EntityFrameworkCore;
using LoanManagement.codeFirstEntities;
using LoanManagement.EntityFrameworkCore;
using LoanManagement.Features.AdminLoanStatus;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace LoanManagement.Services.Implementation
{
    public class AdminLoanStatusService : Abp.Application.Services.ApplicationService, IAdminLoanStatusService
    {
        private readonly IRepository<AdminLoanstatus, int> repository;

        public AdminLoanStatusService(IRepository<AdminLoanstatus,int> repository)
        {
            this.repository = repository;
        }
        public string Add(AddAdminLoanStatus request)
        {
            var entity = new AdminLoanstatus
            {
                Status = request.Status,
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

        public List<UpdateAdminLoanStatus> GetAll()
        {
            return repository.GetAll().Select(d => new UpdateAdminLoanStatus()
            {
                Id = d.Id,
                Status = d.Status
            }).ToList();
        }

        public UpdateAdminLoanStatus GetById(int id)
        {
            return repository.GetAll().Where(s => s.Id == id).Select(d => new UpdateAdminLoanStatus()
            {
                Id = d.Id,
                Status = d.Status
            }).FirstOrDefault();
        }

        public string Update(UpdateAdminLoanStatus request)
        {
            var obj = repository.GetAll().Where(s => s.Id == request.Id).FirstOrDefault();

            if (obj == null)
            {
                return AppConsts.NoRecordFound;
            }

            obj.Status = request.Status;

            repository.Update(obj);
            UnitOfWorkManager.Current.SaveChanges();

            return AppConsts.SuccessfullyUpdated;
        }
    }
}
