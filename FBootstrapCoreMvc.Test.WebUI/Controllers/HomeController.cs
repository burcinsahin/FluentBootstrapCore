using FBootstrapCoreMvc.Test.WebUI.Models.MvcTests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FBootstrapCoreMvc.Test.WebUI.Controllers
{
    public class HomeController : Controller
    {
        public virtual IActionResult Index()
        {
            return View();
        }

        public virtual IActionResult Test(string view)
        {
            return View(view);
        }

        public virtual IActionResult MvcTest(string view)
        {
            var customer = new Person
            {
                Name = "Behzat",
                Surname = "Ç",
                Bio = "Tüm meslektaşları daha üst makamlara gelirken, Behzat dedektif olarak kalır. Her zaman başını belaya soksa da, suçluları yakalamak için kendi yöntemleri vardır.",
                Email = "amirim4530@gmail.com",
                Age = 42,
                Gender = 1,
                Married = true,
                Address = new Address()
                {
                    City = "Ankara"
                }
            };
            //ModelState.AddModelError(string.Empty, "General error message.");
            //ModelState.AddModelError("PropB", "Property B error message.");
            return View(view, customer);
        }

        [HttpPost]
        public virtual IActionResult Submit(Person model)
        {
            return View("MvcForms", model);
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            ViewBag.GenderOptions = new SelectList(new Dictionary<int, string>()
            {
                { 1, "Male"},
                { 2, "Female"}
            }, "Key", "Value");
            base.OnActionExecuting(context);
        }
    }
}