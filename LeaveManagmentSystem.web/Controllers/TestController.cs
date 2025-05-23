using LeaveManagmentSystem.web.Models;
using Microsoft.AspNetCore.Mvc;

namespace LeaveManagmentSystem.web.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            var data = new TestViewModel()
            {
                Name = "Muzaffar Mansour",
                DateofBirth = new DateTime(1987, 07, 11)
            };
            return View(data);
        }
    }
}
