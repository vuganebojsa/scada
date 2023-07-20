using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using scada.DTOS;
using scada.Interfaces;
using scada.Models;
using System.Net;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace scada.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly ITagService _tagService;
        private readonly IJwtService _jwtService;

        public UserController(IUserRepository userRepository, ITagService tagService, IJwtService jwtService)
        {
            _userRepository = userRepository;
            _tagService = tagService;
            this._jwtService = jwtService;
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetUsers()
        {
            if (HttpContext.User.HasClaim(c => c.Type == "Role"))
            {
                var role = HttpContext.User.Claims.First(c => c.Type == "Role").Value;
                if (role != "admin") return StatusCode(403, "No access");

            }
            var users = _userRepository.GetUsers();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(users);
        }
        [AllowAnonymous]
        [HttpPost("login")]
        public ActionResult<string> Login([FromBody]UserDTO userDTO)
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
            string token = _jwtService.GenerateToken(user.Username, user.Role);
            return Ok(token);
            //var newUser = new LoginUserDTO(user.Username, user.Role);

            //_tagService.StartSimulation();
            //return Ok(newUser);
        }

    }


}