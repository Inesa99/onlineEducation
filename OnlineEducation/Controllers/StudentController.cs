using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineEducation.Models;

namespace OnlineEducation.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _context;
        private static Student _student;
        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Student Login
        [HttpGet]
        public async Task<IActionResult> Index(Student student)
        {
            _student = student;
            Package package = await _context.Packages
                                        .Where(i => i.Id == student.PackageId)
                                        .FirstOrDefaultAsync();
            List<Subject> subjects = await _context.Subjects.Where(s => s.PackageId == package.Id).ToListAsync();
            ViewBag.Subjects = subjects;
            ViewBag.Package = package;
            ViewBag.Student = student;
            return View();
        }

    }
}
