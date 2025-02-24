using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineEducation.Models;
using System.Diagnostics;

namespace OnlineEducation.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            var student = await _context.Students
                .FirstOrDefaultAsync(s => s.Username == username && s.Password == password);

            if (student != null)
            {
                // Login Success
                return RedirectToAction("Login", "Index");
            }

            ViewBag.Error = "Invalid credentials";
            return View();
        }

    }
}
