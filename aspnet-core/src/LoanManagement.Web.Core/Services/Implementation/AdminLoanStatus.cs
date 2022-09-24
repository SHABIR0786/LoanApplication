using Abp.EntityFrameworkCore;
using LoanManagement.codeFirstEntities;
using LoanManagement.EntityFrameworkCore;
using LoanManagement.Features.AdminLoanStatus;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace LoanManagement.Services.Implementation
{
    public class AdminLoanStatusService : IAdminLoanStatusService
    {
        private LoanManagementDbContext _dbContext => dbContextProvider.GetDbContext();
        private readonly IDbContextProvider<LoanManagementDbContext> dbContextProvider;

        public AdminLoanStatusService(LoanManagementDbContext dbContext, IDbContextProvider<LoanManagementDbContext> dbContextProvider)
        {

            this.dbContextProvider = dbContextProvider;
        }
        public string Add(AddAdminLoanStatus request)
        {
            var entity = new AdminLoanstatus
            {
                Status = request.Status,
            };
            _dbContext.admin_loanstatus.Add(entity);

            _dbContext.SaveChanges();
            return entity.Id.ToString();
        }

        public string Delete(int id)
        {

            var obj = _dbContext.admin_loanstatus.Where(s => s.Id == id).FirstOrDefault();

            if (obj == null)
            {
                return AppConsts.NoRecordFound;
            }

            _dbContext.admin_loanstatus.Remove(obj);
            _dbContext.SaveChanges();

            return AppConsts.SuccessfullyDeleted;
        }

        public List<UpdateAdminLoanStatus> GetAll()
        {
            return _dbContext.admin_loanstatus.Select(d => new UpdateAdminLoanStatus()
            {
                Id = d.Id,
                Status = d.Status
            }).ToList();
        }

        public UpdateAdminLoanStatus GetById(int id)
        {
            return _dbContext.admin_loanstatus.Where(s => s.Id == id).Select(d => new UpdateAdminLoanStatus()
            {
                Id = d.Id,
                Status = d.Status
            }).FirstOrDefault();
        }

        public string Update(UpdateAdminLoanStatus request)
        {
            var obj = _dbContext.admin_loanstatus.Where(s => s.Id == request.Id).FirstOrDefault();

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
