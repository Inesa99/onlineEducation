using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineEducation.Models
{
    public class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [ForeignKey("Package")]
        public int PackageId { get; set; }
        public virtual Package Package { get; set; }
        public List<Lesson> Lessons { get; set; }
    }
}
