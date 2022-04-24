using LoanManagement.EntityFrameworkCore;
using LoanManagement.Features.LeadEmploymentTypes;
using LoanManagement.Services.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.Services.Implementation
{
    internal class LeadEmploymentTypesService : ILeadEmploymentTypesService
    {
        private readonly MortgagedbContext _dbContext;
        public string Add(AddLeadEmploymentTypes request)
        {
            _dbContext.LeadEmployementTypes.Add(new Entities.Models.LeadEmployementType
            {
                EmployementType = request.EmployementType,
            });

            _dbContext.SaveChanges();
            return AppConsts.SuccessfullyInserted;
        }

        public string Delete(int id)
        {
            var obj = _dbContext.LeadEmployementTypes.Where(s => s.Id == id).FirstOrDefault();

            if (obj == null)
            {
                return AppConsts.NoRecordFound;
            }

            _dbContext.LeadEmployementTypes.Remove(obj);
            _dbContext.SaveChanges();

            return AppConsts.SuccessfullyDeleted;
        }

        public List<UpdateLeadEmploymentTypes> GetAll()
        {
            return _dbContext.LeadEmployementTypes.Select(d => new UpdateLeadEmploymentTypes()
            {
                Id = d.Id,
                EmployementType = d.EmployementType
            }).ToList();
        }

        public UpdateLeadEmploymentTypes GetById(int id)
        {
            return _dbContext.LeadEmployementTypes.Where(s => s.Id == id).Select(d => new UpdateLeadEmploymentTypes()
            {
                Id = d.Id,
                EmployementType = d.EmployementType
            }).FirstOrDefault();
        }

        public string Update(UpdateLeadEmploymentTypes request)
        {

            var obj = _dbContext.LeadEmployementTypes.Where(s => s.Id == request.Id).FirstOrDefault();

            if (obj == null)
            {
                return AppConsts.NoRecordFound;
            }

            obj.EmployementType = request.EmployementType;

            _dbContext.Entry(obj).State = EntityState.Modified;
            _dbContext.SaveChanges();

            return AppConsts.SuccessfullyUpdated;
        }
    }
}
