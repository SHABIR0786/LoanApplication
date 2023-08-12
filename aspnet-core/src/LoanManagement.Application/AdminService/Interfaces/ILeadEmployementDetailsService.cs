using LoanManagement.Features.LeadEmploymentDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.Services.Interface
{
    public interface ILeadEmployementDetailsService
    {
        string Add(AddLeadEmploymentDetails request);
        string Update(UpdateLeadEmploymentDetails request);
        string Delete(int id);
        List<UpdateLeadEmploymentDetails> GetAll();
        List<UpdateLeadEmploymentDetails> GetPurchaseEmployementDetails(int id);
        List<UpdateLeadEmploymentDetails> GetRefinanceEmployementDetails(int id);
        UpdateLeadEmploymentDetails GetById(int id);
    }
}
