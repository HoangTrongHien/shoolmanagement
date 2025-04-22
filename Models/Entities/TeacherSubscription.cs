using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.Models.Entities
{
    public class TeacherSubscription
    {
        public int Id { get; set; }

        [Required]
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }

        [Required]
        public int OnTeachClassId { get; set; }
        public OnTeachClass OnTeachClass { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        public ICollection<Attendance> Attendances { get; set; }
    }
}