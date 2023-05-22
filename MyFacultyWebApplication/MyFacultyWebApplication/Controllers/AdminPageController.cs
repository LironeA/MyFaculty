using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace MyFacultyWebApplication.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminPageController : Controller
    {
        // Path: root/AdminPage
        public IActionResult Index()
        {
            return View();
        }

    }
}
