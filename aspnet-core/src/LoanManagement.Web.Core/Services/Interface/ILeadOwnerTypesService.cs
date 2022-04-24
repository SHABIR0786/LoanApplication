using LoanManagement.Features.LeadOwnerTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.Services.Interface
{
    public interface ILeadOwnerTypesService
    {
        string Add(AddLeadOwnerTypes request);
        string Update(UpdateLeadOwnerTypes request);
        string Delete(int id);
        List<UpdateLeadOwnerTypes> GetAll();
        UpdateLeadOwnerTypes GetById(int id);
    }
}
