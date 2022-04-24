using LoanManagement.Features.LeadIncomeTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.Services.Interface
{
    public interface ILeadIncomeTypesService
    {
        string Add(AddLeadIncomeTypes request);
        string Update(UpdateLeadIncomeTypes request);
        string Delete(int id);
        List<UpdateLeadIncomeTypes> GetAll();
        UpdateLeadIncomeTypes GetById(int id);
    }
}
