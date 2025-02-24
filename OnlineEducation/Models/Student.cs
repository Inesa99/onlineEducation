using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineEducation.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        [ForeignKey("Package")]
        public int PackageId { get; set; }
        public virtual Package Package { get; set; }
    }
}
