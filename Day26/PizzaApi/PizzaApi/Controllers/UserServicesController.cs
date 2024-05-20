using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaApi.Interfaces;
using PizzaApi.Models;

namespace PizzaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserServicesController : ControllerBase
    {
        private readonly IUserServices _userServices;

        public UserServicesController(IUserServices userServices) 
        {
            _userServices = userServices;     
        }

        [Authorize]
        [Route("ShowMenu")]
        [HttpGet]
        [ProducesResponseType(typeof(List<Pizza>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status401Unauthorized)]                                                                                                                                                                                                                                   
        public async Task<ActionResult<List<Pizza>>> ShowMenu()
        {
            try
            {
                var res = await _userServices.ShowMenu();
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorModel(400,ex.Message));
            }
        }
    }
}
