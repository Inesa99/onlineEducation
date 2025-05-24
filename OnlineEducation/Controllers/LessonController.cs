using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineEducation.Models;

namespace OnlineEducation.Controllers
{
    public class LessonController : Controller
    {
        private readonly ApplicationDbContext _context;
        private static Subject _subject;
        public LessonController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(int subjectId)
        {
            _subject = await _context.Subjects.Where(s => s.Id == subjectId).FirstOrDefaultAsync();
            var lessons = await _context.Lessons.Where(l => l.SubjectId == _subject.Id).ToListAsync();

            ViewBag.Lessons = lessons;
            ViewBag.Subject = _subject;
            return View();
        }

        public async Task<IActionResult> Lesson(int lessonId)
        {
            var lesson = await _context.Lessons.Where(l => l.Id == lessonId).FirstOrDefaultAsync();
            var lessons = await _context.Lessons.Where(l => l.SubjectId == _subject.Id).ToListAsync();

            ViewBag.Lessons = lessons;
            ViewBag.Lesson = lesson;
            ViewBag.Subject = _subject;
            return View();
        }

        public async Task<IActionResult> Test(int subjectId)
        {
            var test = await _context.TestQuestions.Where(t => t.SubjectId == subjectId).ToListAsync();

            ViewBag.TestQuestions = test;
            return View();


        }
        [HttpPost]
        public async Task<IActionResult> Test(int questionId, string answer)
        {
            var question = await _context.TestQuestions.FindAsync(questionId);
            if (question != null && !string.IsNullOrWhiteSpace(answer))
            {
                question.Answer = answer;
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Test");
        }
    }
}
