using EmployeeRequestTrackerAPI.Models;
using EmployeeRequestTrackerAPI.Models.DTOs;

namespace EmployeeRequestTrackerAPI.Interfaces
{
    public interface IRequestServices
    {
        public Task<Request> RaiseRequest(RaiseRequestDTO raiseRequestDTO);
        public Task<Request> GetRequestById(int id);

        public Task<List<Request>> ViewAllRequests();
        public Task<List<Request>> ViewMyRequests(int id);
    }
}
