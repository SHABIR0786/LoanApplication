using LoanManagement.EntityFrameworkCore;
using LoanManagement.Features.AdminUser;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace LoanManagement.Services.Implementation
{
    public class AdminUserService : IAdminUserService
    {
        private readonly MortgagedbContext _dbContext;
        public AdminUserService(MortgagedbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public string Add(AddAdminUser request)
        {
            _dbContext.AdminUsers.Add(new Entities.Models.AdminUser
            {
                CreatedOn = System.DateTime.Now,
                Email = request.Email,
                IsActive = request.IsActive,
                Password = request.Password,
                UserName = request.UserName,
            });

            _dbContext.SaveChanges();
            return AppConsts.SuccessfullyInserted;
        }

        public string Delete(int id)
        {

            var obj = _dbContext.AdminUsers.Where(s => s.Id == id).FirstOrDefault();

            if (obj == null)
            {
                return AppConsts.NoRecordFound;
            }

            _dbContext.AdminUsers.Remove(obj);
            _dbContext.SaveChanges();

            return AppConsts.SuccessfullyDeleted;
        }

        public List<UpdateAdminUser> GetAll()
        {
            return _dbContext.AdminUsers.Select(d => new UpdateAdminUser()
            {
                Id = d.Id,
                Email = d.Email,
                IsActive = d.IsActive,
                Password = d.Password,
                UserName = d.UserName,
            }).ToList();
        }

        public UpdateAdminUser GetById(int id)
        {
            return _dbContext.AdminUsers.Where(s => s.Id == id).Select(d => new UpdateAdminUser()
            {
                Id = d.Id,
                Email = d.Email,
                IsActive = d.IsActive,
                Password = d.Password,
                UserName = d.UserName,
            }).FirstOrDefault();
        }

        public string Update(UpdateAdminUser request)
        {
            var obj = _dbContext.AdminUsers.Where(s => s.Id == request.Id).FirstOrDefault();

            if (obj == null)
            {
                return AppConsts.NoRecordFound;
            }

            obj.Email = request.Email;
            obj.IsActive = request.IsActive;
            obj.Password = request.Password;
            obj.UserName = request.UserName;

            _dbContext.Entry(obj).State = EntityState.Modified;
            _dbContext.SaveChanges();

            return AppConsts.SuccessfullyUpdated;
        }
    }
}
