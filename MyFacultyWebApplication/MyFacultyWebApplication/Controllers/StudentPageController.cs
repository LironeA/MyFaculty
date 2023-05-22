using Microsoft.AspNetCore.Mvc;

namespace MyFacultyWebApplication.Controllers
{
    public class StudentPageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
