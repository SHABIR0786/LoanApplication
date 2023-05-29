using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoanManagement.Features.LeadApplicationTypes;

namespace LoanManagement.Services.Interface
{
    public interface ILeadApplicationTypesService
    {
        string Add(AddLeadApplicationType request);
        string Update(UpdateLeadApplicationType request);
        string Delete(int id);
        List<UpdateLeadApplicationType> GetAll();
        UpdateLeadApplicationType GetById(int id);
    }
}
