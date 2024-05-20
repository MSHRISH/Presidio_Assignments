using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaApi.Interfaces;
using PizzaApi.Models;
using PizzaApi.Models.DTO;

namespace PizzaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAuthenticationController : ControllerBase
    {
        private readonly IUserAuthServices _userAuthServices;

        public UserAuthenticationController(IUserAuthServices userAuthServices) 
        { 
            _userAuthServices=userAuthServices;
        }

        [HttpPost("Login")]
        [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<User>> Login(LoginUserDTO loginUserDTO)
        {
            try
            {
                var res =await _userAuthServices.Login(loginUserDTO);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return Unauthorized(new ErrorModel(401,ex.Message));
            }
        }

        [HttpPost("Register")]
        [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<User>> Register(RegisterUserDTO registerUserDTO)
        {
            try
            {
                var res = await _userAuthServices.Register(registerUserDTO);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorModel(400,ex.Message));
            }
        }
    }
}
