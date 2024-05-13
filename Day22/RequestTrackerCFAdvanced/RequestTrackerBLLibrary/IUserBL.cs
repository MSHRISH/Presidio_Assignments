using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerBLLibrary
{
    public interface IUserBL
    {
        Task<int> RaiseRequest(string RequestMessage, int EmployeeId);
        Task<string> ViewRequestStatus(int RequestId);
        Task<IList<Solution>> ViewSolutions(int RequestId);
        Task<int> GiveFeedback(int EmployeeId, float Rating, string Remarks, int SolutionId);

        Task<bool> RespondToSolution(int SolutionId, string Response);
    }
}
