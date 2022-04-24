using LoanManagement.Features.LeadAssetDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.Services.Interface
{
    public interface ILeadAssetsDetailsService
    {
        string Add(AddLeadAssetDetails request);
        string Update(UpdateLeadAssetDetails request);
        string Delete(int id);
        List<UpdateLeadAssetDetails> GetAll();
        UpdateLeadAssetDetails GetById(int id);
    }
}
