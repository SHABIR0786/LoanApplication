using LoanManagement.EntityFrameworkCore;
using LoanManagement.Features.AdminLoanSummaryStatus;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace LoanManagement.Services.Implementation
{
    public class AdminLoanSummaryStatusService : IAdminLoanSummaryStatusService
    {
        private readonly MortgagedbContext _dbContext;
        public AdminLoanSummaryStatusService(MortgagedbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public string Add(AddAdminLoanSummaryStatus request)
        {
            var entity = new Entities.Models.AdminLoansummarystatus
            {
                StatusId = request.StatusId,
                LoanId = request.LoanId,
            };
            _dbContext.AdminLoansummarystatuses.Add(entity);

            _dbContext.SaveChanges();
            return entity.Id.ToString();
        }

        public string Delete(int id)
        {

            var obj = _dbContext.AdminLoansummarystatuses.Where(s => s.Id == id).FirstOrDefault();

            if (obj == null)
            {
                return AppConsts.NoRecordFound;
            }

            _dbContext.AdminLoansummarystatuses.Remove(obj);
            _dbContext.SaveChanges();

            return AppConsts.SuccessfullyDeleted;
        }

        public List<UpdateAdminLoanSummaryStatus> GetAll()
        {
            return _dbContext.AdminLoansummarystatuses.Select(d => new UpdateAdminLoanSummaryStatus()
            {
                Id = d.Id,
                StatusId = d.StatusId,
                LoanId = d.LoanId,
            }).ToList();
        }

        public UpdateAdminLoanSummaryStatus GetById(int id)
        {
            return _dbContext.AdminLoansummarystatuses.Where(s => s.Id == id).Select(d => new UpdateAdminLoanSummaryStatus()
            {
                Id = d.Id,
                StatusId = d.StatusId,
                LoanId = d.LoanId,
            }).FirstOrDefault();
        }

        public string Update(UpdateAdminLoanSummaryStatus request)
        {
            var obj = _dbContext.AdminLoansummarystatuses.Where(s => s.Id == request.Id).FirstOrDefault();

            if (obj == null)
            {
                return AppConsts.NoRecordFound;
            }

            obj.StatusId = request.StatusId;
            obj.LoanId = request.LoanId;
            obj.UpdatedOn = System.DateTime.Now;

            _dbContext.Entry(obj).State = EntityState.Modified;
            _dbContext.SaveChanges();

            return AppConsts.SuccessfullyUpdated;
        }
    }
}
