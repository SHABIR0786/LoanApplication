using Abp.Domain.Repositories;
using Abp.Runtime.Security;
using LoanManagement.codeFirstEntities;
using LoanManagement.EntityFrameworkCore;
using LoanManagement.Features.AdminUser;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace LoanManagement.Services.Implementation
{
    public class AdminUserService : IAdminUserService
    {
        

        public AdminUserService()
        {
            
        }
        //public string Add(AddAdminUser request)
        //{
        //    var entity = new AdminUser
        //    {
        //        CreatedOn = System.DateTime.Now,
        //        Email = request.Email,
        //        IsActive = request.IsActive,
        //        Password = SimpleStringCipher.Instance.Encrypt(request.Password, AppConsts.DefaultPassPhrase),
        //        UserName = request.UserName,
        //    };
        //      repository.Insert(entity) ;

        //    //UnitOfWorkManager.Current.SaveChanges();
        //    return entity.Id.ToString();
        //}

        //public string Delete(int id)
        //{

        //    var obj = repository.GetAll().Where(s => s.Id == id).FirstOrDefault();

        //    if (obj == null)
        //    {
        //        return AppConsts.NoRecordFound;
        //    }

        //   repository.Delete(obj);
        //    //UnitOfWorkManager.Current.SaveChanges();

        //    return AppConsts.SuccessfullyDeleted;
        //}

        //public List<UpdateAdminUser> GetAll()
        //{
        //    return repository.GetAll().Select(d => new UpdateAdminUser()
        //    {
        //        Id = d.Id,
        //        Email = d.Email,
        //        IsActive = d.IsActive,
        //        UserName = d.UserName,
        //    }).ToList();
        //}

        //public UpdateAdminUser GetById(int id)
        //{
        //    return repository.GetAll().Where(s => s.Id == id).Select(d => new UpdateAdminUser()
        //    {
        //        Id = d.Id,
        //        Email = d.Email,
        //        IsActive = d.IsActive,
        //        UserName = d.UserName,
        //    }).FirstOrDefault();
        //}

        //public string Update(UpdateAdminUser request)
        //{
        //    var obj = repository.GetAll().Where(s => s.Id == request.Id).FirstOrDefault();

        //    if (obj == null)
        //    {
        //        return AppConsts.NoRecordFound;
        //    }

        //    obj.Email = request.Email;
        //    obj.IsActive = request.IsActive;
        //    obj.Password = request.Password;
        //    obj.UserName = request.UserName;

        //    repository.Update(obj);
            

        //    return AppConsts.SuccessfullyUpdated;
        //}

        //public string ChangePassword(int id, string oldPassword, string newPassword)
        //{
        //    var obj = repository.GetAll().Where(s => s.Id == id).FirstOrDefault();

        //    if (obj == null)
        //    {
        //        return AppConsts.NoRecordFound;
        //    }
        //    if (SimpleStringCipher.Instance.Encrypt(obj.Password, AppConsts.DefaultPassPhrase) != oldPassword)
        //    {
        //        return AppConsts.PasswordMismatch;
        //    }

        //    obj.Password = SimpleStringCipher.Instance.Encrypt(newPassword, AppConsts.DefaultPassPhrase);

        //    repository.Update(obj);
        //    //UnitOfWorkManager.Current.SaveChanges();

        //    return AppConsts.SuccessfullyUpdated;
        //}

        //public string ChangeUsername(int id, string userName)
        //{
        //    var obj = repository.GetAll().Where(s => s.Id == id).FirstOrDefault();

        //    if (obj == null)
        //    {
        //        return AppConsts.NoRecordFound;
        //    }

        //    obj.UserName = userName;

        //    repository.Update(obj);
        //    //UnitOfWorkManager.Current.SaveChanges();

        //    return AppConsts.SuccessfullyUpdated;
        //}

        //public string ChangeEmail(int id, string email)
        //{
        //    var obj = repository.GetAll().Where(s => s.Id == id).FirstOrDefault();

        //    if (obj == null)
        //    {
        //        return AppConsts.NoRecordFound;
        //    }

        //    obj.Email = email;

        //    repository.Update(obj);
        //    //UnitOfWorkManager.Current.SaveChanges(); 

        //    return AppConsts.SuccessfullyUpdated;
        //}
    }
}
