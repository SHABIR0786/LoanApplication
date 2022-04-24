using LoanManagement.Features.LeadRefinancingIncomeDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.Services.Interface
{
    internal interface ILeadRefinancingIncomeDetailsService
    {
        string Add(AddLeadRefinancingIncomeDetails request);
        string Update(UpdateLeadRefinancingIncomeDetails request);
        string Delete(int id);
        List<UpdateLeadRefinancingIncomeDetails> GetAll();
        UpdateLeadRefinancingIncomeDetails GetById(int id);
    }
}
