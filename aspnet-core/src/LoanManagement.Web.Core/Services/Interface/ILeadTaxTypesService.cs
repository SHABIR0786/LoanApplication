using LoanManagement.Features.LeadTaxTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.Services.Interface
{
    public interface ILeadTaxTypesService
    {
        string Add(AddLeadTaxTypes request);
        string Update(UpdateLeadTaxTypes request);
        string Delete(int id);
        List<UpdateLeadTaxTypes> GetAll();
        UpdateLeadTaxTypes GetById(int id);
    }
}
