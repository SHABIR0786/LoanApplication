
using LoanManagement.Features.LeadAssetTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.Services.Interface
{
    public interface ILeadAssetTypesService
    {
        string Add(AddLeadAssetTypes request);
        string Update(UpdateLeadAssetTypes request);
        string Delete(int id);
        List<UpdateLeadAssetTypes> GetAll();
        UpdateLeadAssetTypes GetById(int id);
    }
}
