using LoanManagement.Features.LeadEmploymentTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.Services.Interface
{
    internal interface ILeadEmploymentTypesService
    {
        string Add(AddLeadEmploymentTypes request);
        string Update(UpdateLeadEmploymentTypes request);
        string Delete(int id);
        List<UpdateLeadEmploymentTypes> GetAll();
        UpdateLeadEmploymentTypes GetById(int id);
    }
}
