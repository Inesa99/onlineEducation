using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineEducation.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string? Answer { get; set; }

        [ForeignKey("Subject")]
        public int SubjectId { get; set; }
        public virtual Subject Subject { get; set; }

        [ForeignKey("Student")]
        public int StudentId { get; set; }
        public virtual Student Student { get; set; }
    }
}
