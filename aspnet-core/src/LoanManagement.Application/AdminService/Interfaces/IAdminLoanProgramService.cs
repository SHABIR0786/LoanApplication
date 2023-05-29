using LoanManagement.Features.AdminLoanProgram;
using System.Collections.Generic;

namespace LoanManagement.Services.Implementation
{
    public interface IAdminLoanProgramService
    {
        string Add(AddAdminLoanProgram request);
        string Delete(int id);
        List<UpdateAdminLoanProgram> GetAll();
        UpdateAdminLoanProgram GetById(int id);
        string Update(UpdateAdminLoanProgram request);
    }
}