using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineEducation.Models
{
    public class TestQuestion
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public string? Answer { get; set; }

        [ForeignKey("Subject")]
        public int SubjectId { get; set; }
        public virtual Subject Subject { get; set; }
        public int StudentId { get; set; }
    }
}
