using Microsoft.AspNetCore.Mvc;

namespace scada.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
