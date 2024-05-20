namespace EmployeeRequestTrackerAPI.Models.DTOs
{
    public class EmployeeLoginDTO
    {
        public int EmployeeId { get; set; }
        public string Password { get; set; } = string.Empty;
    }
}
