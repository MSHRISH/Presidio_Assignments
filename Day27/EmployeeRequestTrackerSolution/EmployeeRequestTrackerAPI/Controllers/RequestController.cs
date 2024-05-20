using EmployeeRequestTrackerAPI.Interfaces;
using EmployeeRequestTrackerAPI.Models;
using EmployeeRequestTrackerAPI.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeRequestTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        private readonly IRequestServices _requestService;

        public RequestController(IRequestServices requestServices) 
        { 
            _requestService= requestServices;
        }

        [HttpPost("RaiseRequest")]
        [Authorize]
        [ProducesResponseType(typeof(Request), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Request>> RaiseRequest(RaiseRequestDTO raiseRequestDTO)
        {
            try
            {
                var res = await _requestService.RaiseRequest(raiseRequestDTO);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorModel(400, ex.Message));
            }
        }


        [HttpPost("GetRequestById")]
        [Authorize]
        [ProducesResponseType(typeof(Request), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Request>> GetRequestById(int id)
        {
            try
            {
                var res = await _requestService.GetRequestById(id);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorModel(400, ex.Message));
            }

        }

        [HttpPost("ViewAllRequests")]
        [Authorize(Policy = "RequireAdminRole")]
        [ProducesResponseType(typeof(List<Request>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<Request>>> ViewAllRequests()
        {
            try
            {
                var res = await _requestService.ViewAllRequests();
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorModel(400, ex.Message));
            }
        }

        [HttpPost("ViewMyRequests")]
        [Authorize]
        [ProducesResponseType(typeof(List<Request>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<Request>>> ViewMyRequests(int id)
        {
            try
            {
                var res = await _requestService.ViewMyRequests(id);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorModel(400, ex.Message));
            }
        }



    }
}
