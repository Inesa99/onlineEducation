using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineEducation.Models;

namespace OnlineEducation.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Admin Registration
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(Admin admin)
        {
            if (ModelState.IsValid)
            {
                await _context.Admins.AddAsync(admin);
                await _context.SaveChangesAsync();
                return RedirectToAction("Login");
            }
            return View(admin);
        }

        [HttpGet]
        public async Task<IActionResult> AddStudent()
        {
            List<Package> packages = await _context.Packages.ToListAsync();
            ViewBag.PackagesList = packages;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddStudent(Student student, int packageId)
        {
            if (student is not null)
            {
                student.PackageId = packageId;
                await _context.Students.AddAsync(student);
                await _context.SaveChangesAsync();
                return RedirectToAction("Dashboard");
            }
            return View();
        }

        // Admin Login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            var admin = await _context.Admins
                .FirstOrDefaultAsync(a => a.Username == username && a.Password == password);

            if (admin != null)
            {
                // Login Success
                return RedirectToAction("Dashboard");
            }

            ViewBag.Error = "Invalid credentials";
            return View();
        }

        public async Task<IActionResult> Dashboard()
        {
            List<Admin> admins = await _context.Admins.ToListAsync();
            List<Student> students = await _context.Students.ToListAsync();

            ViewBag.StudentsList = students;
            ViewBag.AdminsList = admins;
            return View(); // Admin Dashboard
        }

        [HttpGet]
        public IActionResult AddPackage()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddPackage(Package package)
        {
            if (package is not null)
            {
                await _context.Packages.AddAsync(package);
                await _context.SaveChangesAsync();
                return RedirectToAction("PackagesList");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> PackagesList()
        {
            List<Package> packages = await _context.Packages.ToListAsync();
            ViewBag.PackagesList = packages;
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> AddSubject()
        {
            List<Package> packages = await _context.Packages.ToListAsync();
            ViewBag.PackagesList = packages;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddSubject(Subject subject, int packageId)
        {
            if (subject is not null)
            {
                subject.PackageId = packageId;
                await _context.Subjects.AddAsync(subject);
                await _context.SaveChangesAsync();
                return RedirectToAction("SubjectList");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> SubjectList()
        {
            List<Subject> subjects = await _context.Subjects
                                                    .Include(s => s.Package)
                                                    .ToListAsync();
            ViewBag.SubjectsList = subjects;
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> AddLesson()
        {
            List<Subject> subjects = await _context.Subjects.ToListAsync();
            ViewBag.SubjectList = subjects;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddLesson(Lesson lesson, int subjectId)
        {
            if (lesson is not null)
            {
                lesson.SubjectId = subjectId;
                await _context.Lessons.AddAsync(lesson);
                await _context.SaveChangesAsync();
                return RedirectToAction("SubjectList");
            }
            return View();
        }
    }
}
