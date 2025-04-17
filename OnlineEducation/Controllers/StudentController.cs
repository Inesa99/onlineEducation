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
            Package? package = await _context.Packages
                                        .Where(i => i.Id == student.PackageId)
                                        .FirstOrDefaultAsync();
            List<Subject> subjects = await _context.Subjects.Where(s => s.PackageId == package.Id).ToListAsync();
            ViewBag.Subjects = subjects;
            ViewBag.Package = package;
            ViewBag.Student = student;
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> AddQuestion()
        {
            Package? package = await _context.Packages
                                        .Where(i => i.Id == _student.PackageId)
                                        .FirstOrDefaultAsync();
            List<Subject> subjects = await _context.Subjects.Where(s => s.PackageId == package.Id).ToListAsync();
            ViewBag.Subjects = subjects;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddQuestion(int subjectId, string questionText)
        {
            var newQuestion = new Question()
            {
                Description = questionText,
                SubjectId = subjectId,
                StudentId = _student.Id,
            };

            await _context.Questions.AddAsync(newQuestion);
            await _context.SaveChangesAsync();
            return View();
        }

    }
}
