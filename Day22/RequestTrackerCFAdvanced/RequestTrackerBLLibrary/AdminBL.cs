﻿using Models;
using RequestTrackerDALLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerBLLibrary
{
    public class AdminBL:IAdminBL
    {
        public readonly IRepository<int, Request> _RequestRepository;
        public readonly IRepository<int, Solution> _SolutionRepository;
        public readonly IRepository<int, SolutionFeedback> _FeedbackRepository;

        public AdminBL()
        {
            _RequestRepository = new RequestRepository(new RequestTrackerContext());
            _SolutionRepository = new SolutionRepository(new RequestTrackerContext());
            _FeedbackRepository = new FeedbackRepository(new RequestTrackerContext());
        }
        public async Task<int> GenerateRequestId()
        {
            var request= await _RequestRepository.GetAll();
            if (request.Count == 0)
            {
                return 1;
            }
            int id = request.Max(x => x.RequestId);
            return ++id;
        }
        public async Task<int> RaiseRequest(string RequestMessage, int EmployeeId)
        {
            Request request = new Request();
            //request.RequestId = await GenerateRequestId();
            request.RequestMessage = RequestMessage;
            request.RequestRaisedBy = EmployeeId;
            var AddedRequest = await _RequestRepository.Add(request);
            return AddedRequest.RequestId;
        }
        public async Task<IList<(int, string)>> ViewRequestStatus()
        {
            var AllRequest = await _RequestRepository.GetAll();
            IList<(int,string)> result=new List<(int,string)>();
            foreach (var request in AllRequest)
            {
                result.Add((request.RequestId, request.RequestStatus));
            }
            return result;
        }
        public async Task<IList<Solution>> ViewAllSolutions()
        {
            var solutions = await _SolutionRepository.GetAll();
            return solutions;
        }
        public async Task<int> GenerateFeedbackId()
        {
            var feedback= await _FeedbackRepository.GetAll();
            if (feedback.Count == 0)
            {
                return 1;
            }
            int id = feedback.Max(x => x.FeedbackId);
            return ++id;
        }
        //D
        public async Task<int> GiveFeedback(int EmployeeId, float Rating, string Remarks, int SolutionId)
        {
            Solution solution=await _SolutionRepository.GetByKey(SolutionId);
            Request request=await _RequestRepository.GetByKey(solution.RequestId);
            if (request.RequestRaisedBy != EmployeeId)
            {
                return -1;
            }

            SolutionFeedback feedback = new SolutionFeedback();
            feedback.FeedbackBy = EmployeeId;
            feedback.Rating = Rating;
            feedback.Remarks = Remarks;
            feedback.FeedbackDate = DateTime.Now;
            feedback.SolutionId = SolutionId;
            //feedback.FeedbackId = await GenerateFeedbackId();
            var AddedFeedback = await _FeedbackRepository.Add(feedback);
            return AddedFeedback.FeedbackId;
        }

        public async Task<bool> RespondToSolution(int SolutionId, string Response, int EmployeeId)
        {
            Solution solution=await _SolutionRepository.GetByKey(SolutionId);
            Request request = await _RequestRepository.GetByKey(solution.RequestId);
            if (request.RequestRaisedBy != EmployeeId)
            {
                return false;
            }
            solution.RequestRaiserComment = Response;
            var UpdatedSolution=_SolutionRepository.Update(solution);
            return true;
        }
        public async Task<int> GenerateSolutionId()
        {
            var solution= await _FeedbackRepository.GetAll();
            if (solution.Count == 0)
            {
                return 1;
            }
            int id = solution.Max(x => x.FeedbackId);
            return ++id;
        }
        public async Task<int> ProvideSolution(int RequestId, string SolutionDescription, int EmployeeId)
        {
            Solution solution=new Solution();
            solution.SolutionDescription = SolutionDescription;
            solution.SolvedBy = EmployeeId;
            solution.SolvedDate=DateTime.Now;
            solution.RequestId = RequestId;
            solution.RequestRaiserComment = "";
            var AddedSolution = await _SolutionRepository.Add(solution);
            return AddedSolution.SolutionId;
        }

        public async Task<bool> CloseRequest(int RequestId, int EmployeeId)
        {
            Request request=await _RequestRepository.GetByKey(RequestId);
            if (request == null)
            {
                return false;
            }
            request.RequestClosedBy=EmployeeId;
            request.ClosedDate=DateTime.Now;
            request.RequestStatus = "Closed";
            return true;
        }



        public async Task<IList<SolutionFeedback>> ViewFeedbacks(int EmployeeId)
        {
            var AllFeedbacks=await _FeedbackRepository.GetAll();
            IList < SolutionFeedback > result = new List<SolutionFeedback>();
            foreach (var Feedback in AllFeedbacks)
            {
                Solution solution = await _SolutionRepository.GetByKey(Feedback.SolutionId);
                Request request = await _RequestRepository.GetByKey(solution.RequestId);
                if (request.RequestRaisedBy== EmployeeId)
                {
                    result.Add(Feedback);
                }

            }
            return result;
        }
    }
}
