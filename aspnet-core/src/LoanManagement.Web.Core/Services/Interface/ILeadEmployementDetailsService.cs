using LoanManagement.Features.LeadEmploymentDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.Services.Interface
{
    internal interface ILeadEmployementDetailsService
    {
        string Add(AddLeadEmploymentDetails request);
        string Update(UpdateLeadEmploymentDetails request);
        string Delete(int id);
        List<UpdateLeadEmploymentDetails> GetAll();
        UpdateLeadEmploymentDetails GetById(int id);
    }
}
