using System.ComponentModel.DataAnnotations;

namespace OnlineEducation.Models
{
    public class Package
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Package Name is required")]
        public string Name { get; set; }
        public List<Subject> Subjects { get; set; }
        public List<Student> Students { get; set; }
    }
}
