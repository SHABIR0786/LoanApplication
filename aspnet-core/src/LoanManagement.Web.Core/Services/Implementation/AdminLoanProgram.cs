using LoanManagement.EntityFrameworkCore;
using LoanManagement.Features.AdminLoanProgram;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace LoanManagement.Services.Implementation
{
    public class AdminLoanProgramService : IAdminLoanProgramService
    {
        private readonly MortgagedbContext _dbContext;
        public AdminLoanProgramService(MortgagedbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public string Add(AddAdminLoanProgram request)
        {
            var entity = new Entities.Models.AdminLoanprogram
            {
                LoanProgram = request.LoanProgram
            };
               _dbContext.AdminLoanprograms.Add(entity);

            _dbContext.SaveChanges();
            return entity.Id.ToString();
        }

        public string Delete(int id)
        {

            var obj = _dbContext.AdminLoanprograms.Where(s => s.Id == id).FirstOrDefault();

            if (obj == null)
            {
                return AppConsts.NoRecordFound;
            }

            _dbContext.AdminLoanprograms.Remove(obj);
            _dbContext.SaveChanges();

            return AppConsts.SuccessfullyDeleted;
        }

        public List<UpdateAdminLoanProgram> GetAll()
        {
            return _dbContext.AdminLoanprograms.Select(d => new UpdateAdminLoanProgram()
            {
                Id = d.Id,
                LoanProgram = d.LoanProgram
            }).ToList();
        }

        public UpdateAdminLoanProgram GetById(int id)
        {
            return _dbContext.AdminLoanprograms.Where(s => s.Id == id).Select(d => new UpdateAdminLoanProgram()
            {
                Id = d.Id,
                LoanProgram = d.LoanProgram
            }).FirstOrDefault();
        }

        public string Update(UpdateAdminLoanProgram request)
        {
            var obj = _dbContext.AdminLoanprograms.Where(s => s.Id == request.Id).FirstOrDefault();

            if (obj == null)
            {
                return AppConsts.NoRecordFound;
            }

            obj.LoanProgram = request.LoanProgram;

            _dbContext.Entry(obj).State = EntityState.Modified;
            _dbContext.SaveChanges();

            return AppConsts.SuccessfullyUpdated;
        }
    }
}
