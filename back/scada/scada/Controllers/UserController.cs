using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
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

    }
}