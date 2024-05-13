using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerBLLibrary
{
    public interface IAdminBL
    {
        Task<int> RaiseRequest(string RequestMessage, int EmployeeId);
        Task<IList<(int,string)>> ViewRequestStatus();
        Task<IList<Solution>> ViewAllSolutions();
        Task<int> GiveFeedback(int EmployeeId, float Rating, string Remarks, int SolutionId);
        Task<bool> RespondToSolution(int SolutionId, string Response,int EmployeeId);

        Task<int> ProvideSolution(int RequestId,string SolutionDescription,int EmployeeId);
        Task<bool> CloseRequest(int RequestId,int EmployeeId);

        Task<IList<SolutionFeedback>> ViewFeedbacks(int EmployeeId);

    }
}
