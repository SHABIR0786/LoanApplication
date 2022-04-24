using LoanManagement.Features.LeadPurchasingDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.Services.Interface
{
    public interface ILeadPurchasingDetailsService
    {
        string Add(AddLeadPurchasingDetail request);
        string Update(UpdateLeadPurchasingDetail request);
        string Delete(int id);
        List<UpdateLeadPurchasingDetail> GetAll();
        UpdateLeadPurchasingDetail GetById(int id);
    }
}
