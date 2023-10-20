using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.Controllers
{
    public class DefaltController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
