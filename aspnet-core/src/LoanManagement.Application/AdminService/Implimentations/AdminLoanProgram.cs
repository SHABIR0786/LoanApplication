using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using LoanManagement.codeFirstEntities;
using LoanManagement.EntityFrameworkCore;
using LoanManagement.Features.AdminLoanProgram;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace LoanManagement.Services.Implementation
{
    public class AdminLoanProgramService : Abp.Application.Services.ApplicationService, IAdminLoanProgramService
    {
        private readonly IRepository<AdminLoanprogram, int> repository;

        public AdminLoanProgramService(IRepository<AdminLoanprogram,int>repository)
        {
            this.repository = repository;
        }
        public string Add(AddAdminLoanProgram request)
        {
            var entity = new AdminLoanprogram
            {
                LoanProgram = request.LoanProgram
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

        public List<UpdateAdminLoanProgram> GetAll()
        {
            return repository.GetAll().Select(d => new UpdateAdminLoanProgram()
            {
                Id = d.Id,
                LoanProgram = d.LoanProgram
            }).ToList();
        }

        public UpdateAdminLoanProgram GetById(int id)
        {
            return repository.GetAll().Where(s => s.Id == id).Select(d => new UpdateAdminLoanProgram()
            {
                Id = d.Id,
                LoanProgram = d.LoanProgram
            }).FirstOrDefault();
        }

        public string Update(UpdateAdminLoanProgram request)
        {
            var obj = repository.GetAll().Where(s => s.Id == request.Id).FirstOrDefault();

            if (obj == null)
            {
                return AppConsts.NoRecordFound;
            }

            obj.LoanProgram = request.LoanProgram;

            repository.Update(obj);
            UnitOfWorkManager.Current.SaveChanges();

            return AppConsts.SuccessfullyUpdated;
        }
    }
}
