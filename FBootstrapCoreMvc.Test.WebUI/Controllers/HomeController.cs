using Microsoft.AspNetCore.Mvc;

namespace FBootstrapCoreMvc.Test.WebUI.Controllers
{
    public class HomeController : Controller
    {
        public virtual IActionResult Index()
        {
            return View();
        }
    }
}