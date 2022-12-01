using LoanManagement.Features.LeadApplicationQuestions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.Services.Interface
{
    public interface ILeadApplicationQuestionService
    {
        string Add(AddLeadApplicationQuestions request);
        string Update(UpdateLeadApplicationQuestions request);
        string Delete(int id);
        List<UpdateLeadApplicationQuestions> GetAll();
        UpdateLeadApplicationQuestions GetById(int id);
    }
}
