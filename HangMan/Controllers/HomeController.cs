using Microsoft.AspNetCore.Mvc;
using HangMan.Models;

namespace HangMan.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("/")]
        public ActionResult Index()
        {
            return View();
        }
    }
}
