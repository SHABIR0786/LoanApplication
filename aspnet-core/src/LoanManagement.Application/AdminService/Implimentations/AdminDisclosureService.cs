using LoanManagement.codeFirstEntities;
using LoanManagement.EntityFrameworkCore;
using LoanManagement.Features.AdminDisclosure;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp;
using Abp.Application.Services;
using LoanManagement.AdminService.Interfaces;

namespace LoanManagement.AdminService.Implimentations
{
    public class AdminDisclosureService : ApplicationService, IAdminDisclosureService
    {
        private readonly IRepository<AdminDisclosure, int> repository;

        public AdminDisclosureService(IRepository<AdminDisclosure, int> repository)
        {
            this.repository = repository;
        }
        public string Add(AddAdminDisclosure request)
        {
            var entity = new AdminDisclosure
            {
                Title = request.Title,
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

            return AppConsts.SuccessfullyDeleted;
        }

        public List<UpdateAdminDisclosure> GetAll()
        {
            return repository.GetAll().Select(d => new UpdateAdminDisclosure()
            {
                Id = d.Id,
                Title = d.Title,
            }).ToList();
        }

        public UpdateAdminDisclosure GetById(int id)
        {
            return repository.GetAll().Where(s => s.Id == id).Select(d => new UpdateAdminDisclosure()
            {
                Id = d.Id,
                Title = d.Title,
            }).FirstOrDefault();
        }

        public string Update(UpdateAdminDisclosure request)
        {
            var obj = repository.GetAll().Where(s => s.Id == request.Id).FirstOrDefault();

            if (obj == null)
            {
                return AppConsts.NoRecordFound;
            }

            obj.Title = request.Title;

            repository.Update(obj);

            return AppConsts.SuccessfullyUpdated;
        }
    }
}
