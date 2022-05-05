using LoanManagement.EntityFrameworkCore;
using LoanManagement.Features.LeadTaxTypes;
using LoanManagement.Services.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.Services.Implementation
{
    public class LeadTaxTypesService : ILeadTaxTypesService
    {
        private readonly MortgagedbContext _dbContext;

        public LeadTaxTypesService(MortgagedbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public string Add(AddLeadTaxTypes request)
        {
            try
            {
                _dbContext.LeadTaxesTypes.Add(new Entities.Models.LeadTaxesType
                {
                    TaxesType = request.TaxesType
                });

                _dbContext.SaveChanges();
                return AppConsts.SuccessfullyInserted;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public string Update(UpdateLeadTaxTypes request)
        {
            var obj = _dbContext.LeadTaxesTypes.Where(s => s.Id == request.Id).FirstOrDefault();

            if (obj == null)
            {
                return AppConsts.NoRecordFound;
            }

            obj.TaxesType = request.TaxesType;

            _dbContext.Entry(obj).State = EntityState.Modified;
            _dbContext.SaveChanges();

            return AppConsts.SuccessfullyUpdated;
        }
        public string Delete(int id)
        {
            var obj = _dbContext.LeadTaxesTypes.Where(s => s.Id == id).FirstOrDefault();

            if (obj == null)
            {
                return AppConsts.NoRecordFound;
            }

            _dbContext.LeadTaxesTypes.Remove(obj);
            _dbContext.SaveChanges();

            return AppConsts.SuccessfullyDeleted;
        }

        public List<UpdateLeadTaxTypes> GetAll()
        {
            return _dbContext.LeadTaxesTypes.Select(d => new UpdateLeadTaxTypes()
            {
                Id = d.Id,
                TaxesType = d.TaxesType
            }).ToList();
        }

        public UpdateLeadTaxTypes GetById(int id)
        {
            return _dbContext.LeadTaxesTypes.Where(s => s.Id == id).Select(d => new UpdateLeadTaxTypes()
            {
                Id = d.Id,
                TaxesType = d.TaxesType
            }).FirstOrDefault();
        }

       
    }
}
