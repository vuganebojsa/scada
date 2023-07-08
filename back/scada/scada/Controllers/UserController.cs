using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using scada.DTOS;
using scada.Interfaces;
using scada.Models;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace scada.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = _userRepository.GetUsers();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(users);
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody]UserDTO userDTO)
        {
            var user = _userRepository.GetByUsernameAndPassword(userDTO.username, userDTO.password);
            if (user == null)
            {
                return BadRequest("Invalid username or password");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var newUser = new LoginUserDTO(user.Username, user.Role);
            return Ok(newUser);
        }

    }


}