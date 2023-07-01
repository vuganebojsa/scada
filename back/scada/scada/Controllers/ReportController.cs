using Microsoft.AspNetCore.Mvc;

namespace scada.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
