using Microsoft.AspNetCore.Mvc;

namespace AjaxSergey.Controllers
{
    public class HomeController : Controller 
    {
        public IActionResult Index() => View();
        
        public IActionResult Privacy() => View();
    }
}