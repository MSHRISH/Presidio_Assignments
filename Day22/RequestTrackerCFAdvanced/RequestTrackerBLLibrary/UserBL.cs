using Models;
using RequestTrackerDALLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerBLLibrary
{
    public class UserBL:IUserBL
    {
        public readonly IRepository<int, Request> _RequestRepository;
        public readonly IRepository<int, Solution> _SolutionRepository;
        public readonly IRepository<int, SolutionFeedback> _FeedbackRepository;

        public UserBL()
        {
            _RequestRepository = new RequestRepository(new RequestTrackerContext());
            _SolutionRepository = new SolutionRepository(new RequestTrackerContext());
            _FeedbackRepository=new FeedbackRepository(new RequestTrackerContext());
        }
        public async Task<int> GenerateRequestId()
        {
            var employees = await _RequestRepository.GetAll();
            if(employees.Count == 0)
            {
                return 1;
            }
            int id = employees.Max(x => x.RequestId);
            return ++id;
        }
        public async Task<int> RaiseRequest(string RequestMessage,int EmployeeId)
        {
            Request request = new Request();
            //request.RequestId = await GenerateRequestId();
            request.RequestMessage = RequestMessage;
            request.RequestRaisedBy=EmployeeId;
            var AddedRequest = await _RequestRepository.Add(request);
            return AddedRequest.RequestId;
        }

        public async Task<string> ViewRequestStatus(int RequestId)
        {
            var request= await _RequestRepository.GetByKey(RequestId);

            if (request!= null)
            {
                return request.RequestStatus;
            }
            return null; 
        }

        //D
        public async Task<IList<Solution>> ViewSolutions(int RequestId)
        {
            var solutions = await _SolutionRepository.GetAll();
            IList<Solution> result = new List<Solution>();
            foreach (var solution in solutions)
            {
                if(solution.RequestId == RequestId)
                {
                    result.Add(solution);
                }
            }
            return result;
        }
        public async Task<int> GenerateFeedbackId()
        {
            var feedback = await _FeedbackRepository.GetAll();
            if (feedback.Count == 0)
            {
                return 1;
            }
            int id = feedback.Max(x => x.FeedbackId);
            return ++id;
        }
        public async Task<int> GiveFeedback(int EmployeeId, float Rating, string Remarks, int SolutionId)
        {
            SolutionFeedback feedback = new SolutionFeedback();
            feedback.FeedbackBy=EmployeeId;
            feedback.Rating=Rating;
            feedback.Remarks=Remarks;
            feedback.FeedbackDate=DateTime.Now;
            feedback.SolutionId=SolutionId;
            //feedback.FeedbackId=await GenerateFeedbackId();
            var AddedFeedback=await _FeedbackRepository.Add(feedback);
            return AddedFeedback.FeedbackId;
        }

        //Change req.
        public async Task<bool> RespondToSolution(int SolutionId, string Response)
        {
            var solutions = await _SolutionRepository.GetAll();
            foreach (var solution in solutions)
            {
                if (solution.SolutionId== SolutionId)
                {
                    solution.RequestRaiserComment = Response;
                    return true;
                }
            }
            return false;
        }
    }
}
