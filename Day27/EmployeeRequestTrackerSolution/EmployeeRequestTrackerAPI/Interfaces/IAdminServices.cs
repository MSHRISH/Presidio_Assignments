using EmployeeRequestTrackerAPI.Models;

namespace EmployeeRequestTrackerAPI.Interfaces
{
    public interface IAdminServices
    {
        public Task<bool> ActivateUser(int id);
    }
}
