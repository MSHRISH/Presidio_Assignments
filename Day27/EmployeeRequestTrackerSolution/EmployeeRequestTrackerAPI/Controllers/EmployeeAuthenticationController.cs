using EmployeeRequestTrackerAPI.Models.DTOs;
using EmployeeRequestTrackerAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EmployeeRequestTrackerAPI.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace EmployeeRequestTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeAuthenticationController : ControllerBase
    {
        private readonly IEmployeeAuthenticationServices _employeeAuthenticationServices;
        private readonly IAdminServices _adminServices;

        public EmployeeAuthenticationController(IEmployeeAuthenticationServices employeeAuthenticationServices,IAdminServices adminServices) 
        {
            _employeeAuthenticationServices= employeeAuthenticationServices;
            _adminServices= adminServices;
        }
        [HttpPost("Login")]
        [ProducesResponseType(typeof(LoginReturnDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<LoginReturnDTO>> Login(EmployeeLoginDTO loginEmployeeDTO)
        {
            try
            {
                var res = await _employeeAuthenticationServices.Login(loginEmployeeDTO);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return Unauthorized(new ErrorModel(401, ex.Message));
            }
        }


        [HttpPost("Register")]
        [ProducesResponseType(typeof(Employee), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Employee>> Register(RegisterDTO registerEmployeeDTO)
        {
            try
            {
                var res = await _employeeAuthenticationServices.Register(registerEmployeeDTO);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorModel(400, ex.Message));
            }
        }


        [Authorize(Policy = "RequireAdminRole")]
        [HttpPost("ActivateUser")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<string>> ActivateUser(int id)
        {
            try
            {
                var res = await _adminServices.ActivateUser(id);
                return Ok("User Activated");
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorModel(400,ex.Message));
            }
        }
    }
}
