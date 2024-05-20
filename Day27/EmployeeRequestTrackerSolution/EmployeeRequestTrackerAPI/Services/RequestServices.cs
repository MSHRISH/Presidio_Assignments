using EmployeeRequestTrackerAPI.Execptions;
using EmployeeRequestTrackerAPI.Interfaces;
using EmployeeRequestTrackerAPI.Models;
using EmployeeRequestTrackerAPI.Models.DTOs;

namespace EmployeeRequestTrackerAPI.Services
{
    public class RequestServices : IRequestServices
    {
        private readonly IRepository<int, Request> _requestRepository;

        public RequestServices(IRepository<int,Request> requestRepository) 
        {
            _requestRepository = requestRepository;       
        }

        public async Task<Request> GetRequestById(int id)
        {
            var request=await _requestRepository.Get(id);
            if (request == null) 
            {
                throw new RequestNotFound();
            }
            return request;
        }

        public async Task<Request> RaiseRequest(RaiseRequestDTO raiseRequestDTO)
        {
            Request request = new Request();
            request.RequestMessage = raiseRequestDTO.RequestMessage;
            request.RequestRaisedBy = raiseRequestDTO.RaisedByEmployee;
            request=await _requestRepository.Add(request);
            return request;
        }

        public async Task<List<Request>> ViewAllRequests()
        {
            var request=await _requestRepository.GetAll();
            if(request.Count() == 0)
            {
                throw new RequestNotFound();
            }
            return request.ToList();
        }

        public async Task<List<Request>> ViewMyRequests(int id)
        {
            var request = await _requestRepository.GetAll();
            if (request.Count() == 0)
            {
                throw new RequestNotFound();
            }
            List<Request> res= new List<Request>();
            foreach (var item in request)
            {
                if (item.RequestRaisedBy == id)
                {
                    res.Add(item);
                }
            }
            return res;
        }
    }
}
