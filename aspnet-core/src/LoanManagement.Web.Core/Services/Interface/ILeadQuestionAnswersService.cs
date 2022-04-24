using LoanManagement.Features.LeadQuestionAnswers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.Services.Interface
{
    public interface ILeadQuestionAnswersService
    {
        string Add(AddLeadQuestionAnswers request);
        string Update(UpdateLeadQuestionAnswers request);
        string Delete(int id);
        List<UpdateLeadQuestionAnswers> GetAll();
        UpdateLeadQuestionAnswers GetById(int id);
    }
}
