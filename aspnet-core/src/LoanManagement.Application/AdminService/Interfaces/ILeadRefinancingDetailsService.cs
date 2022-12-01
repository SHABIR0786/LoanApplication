using LoanManagement.Features.LeadRefinancingDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.Services.Interface
{
    public interface ILeadRefinancingDetailsService
    {
        string Add(AddLeadRefinancingDetails request);
        string Update(UpdateLeadRefinancingDetails request);
        string Delete(int id);
        List<UpdateLeadRefinancingDetails> GetAll();
        UpdateLeadRefinancingDetails GetById(int id);
    }
}
