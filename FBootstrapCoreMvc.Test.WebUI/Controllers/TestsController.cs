using Microsoft.AspNetCore.Mvc;

namespace FBootstrapCoreMvc.Test.WebUI.Controllers
{
    public class TestsController : Controller
    {
        public virtual ActionResult Tests(string view)
        {
            return View(view);
        }
    }
}