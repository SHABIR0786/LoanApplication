using LoanManagement.EntityFrameworkCore;
using LoanManagement.Features.AdminLoanStatus;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace LoanManagement.Services.Implementation
{
    public class AdminLoanStatusService : IAdminLoanStatusService
    {
        private readonly MortgagedbContext _dbContext;
        public AdminLoanStatusService(MortgagedbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public string Add(AddAdminLoanStatus request)
        {
            var entity = new Entities.Models.AdminLoanstatus
            {
                Status = request.Status,
            };
               _dbContext.AdminLoanstatuses.Add(entity);

            _dbContext.SaveChanges();
            return entity.Id.ToString();
        }

        public string Delete(int id)
        {

            var obj = _dbContext.AdminLoanstatuses.Where(s => s.Id == id).FirstOrDefault();

            if (obj == null)
            {
                return AppConsts.NoRecordFound;
            }

            _dbContext.AdminLoanstatuses.Remove(obj);
            _dbContext.SaveChanges();

            return AppConsts.SuccessfullyDeleted;
        }

        public List<UpdateAdminLoanStatus> GetAll()
        {
            return _dbContext.AdminLoanstatuses.Select(d => new UpdateAdminLoanStatus()
            {
                Id = d.Id,
                Status = d.Status
            }).ToList();
        }

        public UpdateAdminLoanStatus GetById(int id)
        {
            return _dbContext.AdminLoanstatuses.Where(s => s.Id == id).Select(d => new UpdateAdminLoanStatus()
            {
                Id = d.Id,
                Status = d.Status
            }).FirstOrDefault();
        }

        public string Update(UpdateAdminLoanStatus request)
        {
            var obj = _dbContext.AdminLoanstatuses.Where(s => s.Id == request.Id).FirstOrDefault();

            if (obj == null)
            {
                return AppConsts.NoRecordFound;
            }

            obj.Status = request.Status;

            _dbContext.Entry(obj).State = EntityState.Modified;
            _dbContext.SaveChanges();

            return AppConsts.SuccessfullyUpdated;
        }
    }
}
