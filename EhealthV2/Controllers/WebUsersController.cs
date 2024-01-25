using Microsoft.AspNetCore.Mvc;

namespace EhealthV2.Controllers
{
    public class WebUsersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
