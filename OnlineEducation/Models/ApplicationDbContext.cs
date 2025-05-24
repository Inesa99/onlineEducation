using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace OnlineEducation.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<TestQuestion> TestQuestions { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }
    }
}
