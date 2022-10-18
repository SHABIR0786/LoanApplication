using LoanManagement.Features.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.Services.Interface
{
    public interface IStateService
    {
        string AddState(AddStateRequest request);
        string UpdateState(UpdateStateRequest request);
        string DeleteState(int id);
        List<UpdateStateRequest> GetStates();
        UpdateStateRequest GetStateById(int id);
    }
}
