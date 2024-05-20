using EmployeeRequestTrackerAPI.Execptions;
using EmployeeRequestTrackerAPI.Interfaces;
using EmployeeRequestTrackerAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeRequestTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService) 
        {
            _employeeService= employeeService;
        }
        [HttpGet]
        [Authorize(Policy = "RequireAdminRole")]
        public async Task<ActionResult<IList<Employee>>> GetAllEmployees()
        {
            var employees=await _employeeService.GetEmployees();
            return Ok(employees.ToList());
        }
        [HttpPut]
        public async Task<ActionResult<Employee>> UpdatePhoneNumber(int id, string phone)
        {   
            try
            {
                var employee =await _employeeService.UpdateEmployeePhone(id, phone);
                return Ok(employee);
            }
            catch (NoSuchEmployeeExecption exe) 
            {
                return NotFound(exe.Message);
            }
        }
    }
}
