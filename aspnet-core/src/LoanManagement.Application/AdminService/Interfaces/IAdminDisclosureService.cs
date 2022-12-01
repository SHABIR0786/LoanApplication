using LoanManagement.Features.AdminDisclosure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.AdminService.Interfaces
{
    public interface IAdminDisclosureService
    {
        string Add(AddAdminDisclosure request);
        string Update(UpdateAdminDisclosure request);
        string Delete(int id);
        List<UpdateAdminDisclosure> GetAll();
        UpdateAdminDisclosure GetById(int id);
    }
}
