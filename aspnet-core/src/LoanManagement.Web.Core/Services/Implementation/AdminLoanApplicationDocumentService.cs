using LoanManagement.EntityFrameworkCore;
using LoanManagement.Features.AdminLoanApplicationDocument;
using LoanManagement.Services.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.Services.Implementation
{
    public class AdminLoanApplicationDocumentService : IAdminLoanApplicationDocumentService
    {
        private readonly MortgagedbContext _dbContext;
        public AdminLoanApplicationDocumentService(MortgagedbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public string Add(AddAdminLoanApplicationDocument request)
        {
            _dbContext.AdminLoanapplicationdocuments.Add(new Entities.Models.AdminLoanapplicationdocument
            {
                DisclosureId = request.DisclosureId,
                DocumentPath = request.DocumentPath,
                LoanId = request.LoanId,
                UserId = request.UserId,
            });

            _dbContext.SaveChanges();
            return AppConsts.SuccessfullyInserted;
        }

        public string Delete(int id)
        {

            var obj = _dbContext.AdminLoanapplicationdocuments.Where(s => s.Id == id).FirstOrDefault();

            if (obj == null)
            {
                return AppConsts.NoRecordFound;
            }

            _dbContext.AdminLoanapplicationdocuments.Remove(obj);
            _dbContext.SaveChanges();

            return AppConsts.SuccessfullyDeleted;
        }

        public List<UpdateAdminLoanApplicationDocument> GetAll()
        {
            return _dbContext.AdminLoanapplicationdocuments.Select(d => new UpdateAdminLoanApplicationDocument()
            {
                Id = d.Id,
                DisclosureId = d.DisclosureId,
                DocumentPath = d.DocumentPath,
                LoanId = d.LoanId,
                UserId = d.UserId,
            }).ToList();
        }

        public UpdateAdminLoanApplicationDocument GetById(int id)
        {
            return _dbContext.AdminLoanapplicationdocuments.Where(s => s.Id == id).Select(d => new UpdateAdminLoanApplicationDocument()
            {
                Id = d.Id,
                DisclosureId = d.DisclosureId,
                DocumentPath = d.DocumentPath,
                LoanId = d.LoanId,
                UserId = d.UserId,
            }).FirstOrDefault();
        }

        public string Update(UpdateAdminLoanApplicationDocument request)
        {
            var obj = _dbContext.AdminLoanapplicationdocuments.Where(s => s.Id == request.Id).FirstOrDefault();

            if (obj == null)
            {
                return AppConsts.NoRecordFound;
            }

            obj.DisclosureId = request.DisclosureId;
            obj.DocumentPath = request.DocumentPath;
            obj.LoanId = request.LoanId;
            obj.UserId = request.UserId;

            _dbContext.Entry(obj).State = EntityState.Modified;
            _dbContext.SaveChanges();

            return AppConsts.SuccessfullyUpdated;
        }
    }
}
